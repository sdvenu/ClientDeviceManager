namespace ClientDeviceMgr
{
    using System.Data;

    /// <summary>
    /// Handle the data in the HOSTINFO database.
    /// The database is constructed so that:
    /// Ignore has ID 0 and is immutable; Ignore means do not add, change, or delete HOSTINFO.TXT.
    /// None has ID 1 and is immutable; None means erase any HOSTINFO.TXT that is found.
    /// DEFAULT has ID 2 and the name is immutable; DEFAULT is al=pplied to most workstations.
    /// </summary>
    public class HostInfoData
    {
        /// <summary>
        /// Gets the contents.
        /// </summary>
        public string Contents
        {
            get { return dtContents ?? (dtContents = GetField<string>("Contents")); }
        }

        /// <summary>
        /// Gets the description.
        /// </summary>
        public string Description
        {
            get { return dtDescription ?? (dtDescription = GetField<string>("Description")); }
        }

        /// <summary>
        /// Gets the ID.
        /// </summary>
        public int ID
        {
            get { return -1 != dtID ? dtID : (dtID = GetField<int>("ID")); }
        }

        /// <summary>
        /// See if any data is allowed to change.
        /// </summary>
        public bool IsChangeable
        {
            get { return (IsNameChangeable || IsDescriptionChangeable || IsContentChangeable); }
        }

        /// <summary>
        /// See if the name is allowed to change.
        /// The Ignore and None definitions cannot change their content.
        /// </summary>
        public bool IsContentChangeable
        {
            get { return (2 <= ID); }
        }

        /// <summary>
        /// See if the name is allowed to change.
        /// The Ignore and None definitions cannot change their description.
        /// </summary>
        public bool IsDescriptionChangeable
        {
            get { return (2 <= ID); }
        }

        /// <summary>
        /// See if the name is allowed to change.
        /// The DEFAULT, Ignore, and None definitions cannot change their name.
        /// </summary>
        public bool IsNameChangeable
        {
            get { return (3 <= ID); }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name
        {
            get { return dtName ?? (dtName = GetField<string>("Name")); }
        }

        /// <summary>
        /// Return the data table.
        /// </summary>
        public DataTable Table
        {
            get { return dtTable; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HostInfoData"/> class.
        /// </summary>
        /// <param name="aTable">a data table.</param>
        public HostInfoData(DataTable aTable)
        {
            dtID = -1;
            dtTable = aTable;
        }

        ///////////////////////////////////////////////////////////////

        /// <summary>
        /// Get a named field from the table row.
        /// </summary>
        /// <typeparam name="T">the type.</typeparam>
        /// <param name="aColumnName">the column name.</param>
        /// <returns>the column value or null.</returns>
        private T GetField<T>(string aColumnName)
        {
            T Result = default(T);

            if (null != dtTable && 0 < dtTable.Rows.Count)
                try {
                    Result = dtTable.Rows[0].Field<T>(aColumnName);
                } catch { }

            return Result;
        }

        // Database data.

        private DataTable dtTable;

        private string dtContents;
        private string dtDescription;
        private int dtID;
        private string dtName;
    }
}