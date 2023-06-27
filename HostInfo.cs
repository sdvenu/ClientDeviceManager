namespace ClientDeviceMgr
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Web;

    public static class HostInfo
    {
        /// <summary>
        /// Can the new name replace the old name, or are they the same?
        /// </summary>
        /// <param name="anOldName">an old name.</param>
        /// <param name="aNewName">a new name.</param>
        /// <returns>
        ///   <c>true</c> if the new name can replace the old name; otherwise, <c>false</c>.
        /// </returns>
        public static bool CanRename(string anOldName, string aNewName)
        {
            // See if the Name is being changing.
            if (aNewName.Equals(anOldName, StringComparison.OrdinalIgnoreCase))
                return true;
            else
                // Any new name cannot already exist.
                return !DoesNameExist(aNewName);
        }

        /// <summary>
        /// See if the Name already exists.
        /// </summary>
        /// <param name="aNewName">a new name.</param>
        /// <returns>true if the name already exists.</returns>
        public static bool DoesNameExist(string aNewName)
        {
            try
            {
                Common.Database database = new Common.Database();

                string dbCommand =
                    "SELECT Name" +
                    " FROM HostInfo" +
                    " WHERE Name = '" +
                    aNewName + "'";

                string result = database.MyGetDataExecuteScalar(dbCommand);
                database.Dispose();

                return !string.IsNullOrEmpty(result);
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Parse the HOSTINFO contents into a standard format and
        /// produce a list of any errors that may be present.
        /// </summary>
        /// <param name="aContents">The original contents.</param>
        /// <param name="aParsedContents">The parsed contents.</param>
        /// <param name="anErrorList">A list of any errors.</param>
        /// <returns></returns>
        public static bool ParseContents(
            string aContents,
            out string aParsedContents,
            out string anErrorList)
        {
            StringBuilder output = new StringBuilder();
            StringBuilder errorMessage = new StringBuilder();
            aParsedContents = string.Empty;
            anErrorList = string.Empty;

            if (null == aContents)
                return false;

            // Get each of the lines.
            string[] contents = aContents.Split(EndOfLine, StringSplitOptions.None);

            int i = 0;
            foreach(string line in contents)
            {
                i++;

                // Ignore empty lines.
                if (string.IsNullOrEmpty(line))
                    continue;

                // Split each line into parts.
                string[] parts = line.Trim().Split(PartsSeparator, 4, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Count() < 3)
                {
                    errorMessage.AddError(i, "NAME;DNS;CLUSTER; are required");
                    output.Append(line.Trim().ToUpper());
                    output.AppendLine();
                    continue;
                }

                parts[0] = parts[0].Trim().ToUpper();
                parts[1] = parts[1].Trim().ToUpper();
                parts[2] = parts[2].Trim().ToUpper();

                if (!parts[0].IsName() || !parts[2].IsName())
                {
                    errorMessage.AddError(i, "NAME and CLUSTER must be just letters or digits");
                }
                if (!parts[1].IsDNS())
                {
                    errorMessage.AddError(i, "DNS must be just letters/digits/hyphen/period");
                }

                // Create the parsed line.
                output.AppendFormat("{0};{1};{2};", parts[0], parts[1], parts[2]);
                output.AppendLine();
            }

            aParsedContents = output.ToString();
            anErrorList = errorMessage.ToString();

            return string.IsNullOrEmpty(anErrorList);
        }

        /// <summary>
        /// Be sure the HOSTINFO name is valid.
        /// </summary>
        /// <param name="aName">A name.</param>
        /// <param name="aParsedName">The parsed name.</param>
        /// <param name="anErrorMessage">An error message.</param>
        /// <returns>True if the name is valid.</returns>
        public static bool ParseName(
            string aName,
            out string aParsedName,
            out string anErrorMessage)
        {
            if (string.IsNullOrEmpty(aName))
            {
                anErrorMessage = "The name must not be blank";
                aParsedName = string.Empty;
                return false;
            }
            else if (!aName.All(c => Char.IsLetterOrDigit(c) || '_' == c))
            {
                anErrorMessage = "The name must consist of alphanumerics and/or underscores";
                aParsedName = string.Empty;
                return false;
            }
            else
            {
                anErrorMessage = string.Empty;
                aParsedName = aName.Trim();
                return true;
            }
        }

        ///////////////////////////////////////////////////////////////

        /// <summary>
        /// Add an error message.
        /// </summary>
        /// <param name="aMessage">the list of error messages.</param>
        /// <param name="aLineNumber">a line number.</param>
        /// <param name="aLine">a line.</param>
        private static void AddError(
            this StringBuilder aMessage,
            int aLineNumber,
            string aLine)
        {
            aMessage.AppendFormat("Line {0}: {1}", aLineNumber, aLine);
            aMessage.AppendLine();
        }

        /// <summary>
        /// Check whether the string is a valid DNS name.
        /// </summary>
        /// <param name="aString">a string.</param>
        /// <returns>
        ///   <c>true</c> if the specified a string is valid; otherwise, <c>false</c>.
        /// </returns>
        private static bool IsDNS(this string aString)
        {
            foreach (char c in aString)
                if (!Char.IsLetterOrDigit(c) && '.' != c && '-' != c)
                    return false;
            return true;
        }

        /// <summary>
        /// Check whether the string is a valid name.
        /// </summary>
        /// <param name="aString">a string.</param>
        /// <returns>
        ///   <c>true</c> if the specified a string is valid; otherwise, <c>false</c>.
        /// </returns>
        private static bool IsName(this string aString)
        {
            foreach (char c in aString)
                if (!Char.IsLetterOrDigit(c))
                    return false;
            return true;
        }

        // Lexical items.

        private static string EOLMark = "\r\n";
        private static string[] EndOfLine = new string[] { EOLMark };
        private static char[] PartsSeparator = new char[] { ';' };
    }
}