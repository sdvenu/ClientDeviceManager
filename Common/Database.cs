using System;
using System.Configuration;
using System.Text;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using ClientDeviceMgr.Common.Data;
using System.Security.Cryptography;
using Microsoft.Win32;
using System.Security;
using System.IO;

namespace ClientDeviceMgr.Common
{
	/// <summary>
	/// The database object that manages all of the SQL connections and data.
	/// </summary>
	public class Database: IDisposable
	{
		ArrayList arConnectStringList;
		ArrayList arSqlConnectObjects;
		ArrayList arSynConnectStrList;
		ArrayList arSynSqlConnectList;
        string myDbConnectionString = "?";
        private const bool registryEncrypted = true;

        /// <summary>
        /// Manage the SQL database connections.
        /// </summary>
		public Database()
		{
			arConnectStringList = new ArrayList();
			arSqlConnectObjects = new ArrayList();
			arSynConnectStrList = ArrayList.Synchronized(arConnectStringList);
			arSynSqlConnectList = ArrayList.Synchronized(arSqlConnectObjects);
			try
			{
				string DbConnection = GetConnectString();
                myDbConnectionString = DbConnection;
				arSynConnectStrList.Add(DbConnection);
			}
			catch(NotSupportedException ex)
			{
				string msg = ex.Message;
                myDbConnectionString = ex.Message + " for " + myDbConnectionString;
            }
			catch(Exception e)
			{
                myDbConnectionString += " used and gave error { " + e.Message + " } at { " + e.StackTrace + " }";
			}
		}

        public string MyDbConnectionString()
        {
            return myDbConnectionString;
        }

        /// <summary>
        /// Get a data set.
        /// </summary>
        /// <param name="aSQLCommand">a SQL command.</param>
        /// <param name="aDataSetName">The name of the data set.</param>
        /// <returns>a DataSet</returns>
        public static DataSet GetDataSet( string aSQLCommand, string aDataSetName )
        {
            Common.Database myDatabase = new Common.Database();
            DataSet myDataSet = myDatabase.MyFillDataSet( aSQLCommand, aDataSetName );
            myDatabase.Dispose();
            return myDataSet;
        }

        /// <summary>
        /// Get the database connection string from the registry.
        /// </summary>
        /// <returns></returns>
		string GetConnectString()
		{
            if(registryEncrypted)
            {
                // Decrypt the connection string from the registry.
                ProfileDBRegistry reg = new ProfileDBRegistry();
                reg.OpenKey();
                MemoryStream outstream = new MemoryStream();
                MemoryStream instream = new MemoryStream();
                byte[] regtest = reg.GetConnectionStringValue();
                instream.Position = 0;
                instream.Write( regtest, 0, regtest.Length );
                outstream.Position = 0;
                instream.Position = 0;
                XorCrypt xor2 = new XorCrypt();
                xor2.XorStream( instream, outstream );
                outstream.Position = 0;
                byte[] bufout = outstream.ToArray();
                reg.CloseKey();
                StringBuilder result = new StringBuilder(8);
                foreach (byte b in bufout)
                    result.Append(Convert.ToChar(b & 0x7f));
                return result.ToString();
                //?? return Encoding.ASCII.GetString(bufout);
            }
            //else //??
            //{
            //    // Get the unencrypted connection string from the registry.
            //    ProfileDBRegistry reg = new ProfileDBRegistry();
            //    reg.OpenKey();
            //    string result = reg.GetConnectionString();
            //    reg.CloseKey();
            //    return result;
            //}
		}

        /// <summary>
        /// Attempt to open all SQL Connections for which our server is configured,
        /// so we can update all available databases, as a configuration change
        /// has most likely occured.
        /// </summary>
        /// <returns>the number of successful databases opened. Zero indicates a failure.</returns>
		private int GetAllSqlConnectionsUp()
		{
			int result = 0;
			SqlConnection sq = null;
			try
			{
				for (int i=0; i < arSynConnectStrList.Count; i++)
				{
					sq = new SqlConnection(((string)arSynConnectStrList[i]).Trim());
					if (sq == null)
					{
						return result;
					}

                    // Try and open this database.
					sq.Open();
					if (sq.State == ConnectionState.Open)
					{
						arSynSqlConnectList.Add(sq);
						result++;
					}
				}
			}
			catch(SqlException sqlex)
			{
				string msg = sqlex.Message;
			}
			catch(Exception e)
			{
				string msg = e.ToString();
			}
			return result;
		}

        /// <summary>
        /// Attempt to get one SQL Connection up. It will try the first connection
        /// string in the list. This is the default database for this web server.
        /// If it can't get that connection established then it continues
        /// in the list until a connection is established. It returns null
        /// if no connections can be established.
        /// </summary>
        /// <returns>the established connection or null</returns>
		public SqlConnection GetSqlConnectionUp()
		{
			SqlConnection sq = null;
			try
			{
				//for (int i=0; i < arSynConnectStrList.Count; i++)
				for (int i=0; i < 1; i++)
				{
					sq = new SqlConnection(((string)arSynConnectStrList[i]).Trim());
					if (sq == null)
					{
						return null;
					}

					// Try and open this database.
					sq.Open();
					if (sq.State == ConnectionState.Open)
					{
						arSynSqlConnectList.Add(sq);
						break;
					}
				}
			}
			catch(SqlException)
			{
                sq = null;
			}
			catch(Exception)
			{
                sq = null;
			}
			return sq;
		}

        /// <summary>
        /// Close any open SQL Connections.
        /// </summary>
		public void TearDownSqlConnections()
		{
			SqlConnection sq = null;
			try
			{
				for (int i=0; i < arSynSqlConnectList.Count; i++)
				{
					sq = (SqlConnection)arSynSqlConnectList[i];
					if (sq == null)
						continue;

					if (sq.State == ConnectionState.Open)
						sq.Close();
				}
			}
			catch(SqlException sqlex)
			{
				string msg = sqlex.Message;
			}
			catch(Exception e)
			{
				string msg = e.ToString();
			}
			finally
			{
				arSynSqlConnectList.Clear();
			}
		}

        /// <summary>
        /// Fill a dataset from the given support command.
        /// </summary>
        /// <param name="command">the SQL commeand</param>
        /// <returns>the dataset returned</returns>
		public SupportData MyFillSupportDataSet(string command)
		{
			SupportData dataset = null;
			SqlConnection sq = null;

			// Establish a connection to the database.
			try
			{
				sq = GetSqlConnectionUp();
				if (sq == null)
					return dataset;

				// Execute the SQL command.
				SqlDataAdapter dAdapt = new SqlDataAdapter(command, sq);
				dataset = new SupportData();
				dAdapt.Fill(dataset);
			}
			catch(SqlException sqlex)
			{
				string msg = sqlex.Message;
			}
			catch(Exception e)
			{
				string msg = e.ToString();
			}
			finally
			{
				TearDownSqlConnections();
			}
			return dataset;
		}

        /// <summary>
        /// Fill a dataset from the given command in the dataset given.
        /// </summary>
        /// <param name="command">the SQL command</param>
        /// <param name="DataSetName">the dataset name</param>
        /// <returns>the dataset returned</returns>
        public DataSet MyFillDataSet( string command, string DataSetName )
		{
			DataSet ds = null;
			SqlConnection sq = null;

			// Establish a connection to the database.
			try
			{
				sq = GetSqlConnectionUp();
				if (sq == null)
					return ds;

				// Execute the SQL command.
				SqlDataAdapter dAdapt = new SqlDataAdapter(command, sq);
				ds = new DataSet();
				dAdapt.Fill(ds, DataSetName.Trim());
			}
			catch(SqlException sqlex)
			{
				string msg = sqlex.Message;
			}
			catch(Exception e)
			{
				string msg = e.ToString();
			}
			finally
			{
				TearDownSqlConnections();
			}
			return ds;
		}

        /// <summary>
        /// Executes the query, and returns the first column of the first row
        /// in the result set returned by the query.
        /// </summary>
        /// <param name="command">the SQL command</param>
        /// <returns>the first column of the first row of the dataset</returns>
		public string MyGetDataExecuteScalar(string command)
		{
			string result = null;
			SqlConnection sq = null;

			// Establish a connection to the database.
			try
			{
				sq = GetSqlConnectionUp();
				if (sq == null)
					return result;

				// Execute the SQL command.
				SqlCommand myCommand = new SqlCommand(command, sq);
				result = (string)myCommand.ExecuteScalar();
			}
			catch(SqlException sqlex)
			{
				string msg = sqlex.Message;
			}
			catch(Exception e)
			{
				string msg = e.ToString();
			}
			finally
			{
				TearDownSqlConnections();
			}
			return result;
		}

        /// <summary>
        /// Executes the query, and returns the first column of the first row
        /// as an int from the result set returned by the query.
        /// </summary>
        /// <param name="command">the SQL command</param>
        /// <returns>the first column of the first row of the dataset, or -1.</returns>
        public int MyGetDataExecuteScalarInt(string command)
        {
            int? result = -1;
            SqlConnection sq = null;

            // Establish a connection to the database.
            try
            {
                sq = GetSqlConnectionUp();
                if (sq == null)
                    return -1;

                // Execute the SQL command.
                SqlCommand myCommand = new SqlCommand(command, sq);
                result = myCommand.ExecuteScalar() as int?;
            }
            catch (SqlException sqlex)
            {
                string msg = sqlex.Message;
            }
            catch (Exception e)
            {
                string msg = e.ToString();
            }
            finally
            {
                TearDownSqlConnections();
            }
            return result.HasValue ? result.Value : -1;
        }

        /// <summary>
        /// Get a data table from the results of the given command.
        /// </summary>
        /// <param name="command">the SQL command</param>
        /// <returns>the data table or null</returns>
        public DataTable MyGetDataTable(string command)
        {
            DataSet dbDataSet = MyFillDataSet(command, "Data");
            if (null != dbDataSet)
                return dbDataSet.Tables["Data"];

            return null;
        }

        /// <summary>
        /// Create a database table if it does not already exist.
        /// </summary>
        /// <param name="QueryCommand">the table selection command</param>
        /// <param name="UpdateCommand">the table definition</param>
        /// <param name="TableName">the name of the table</param>
        /// <returns>true if the </returns>
		public bool CreateTableIfNotExist(
            string QueryCommand,
            string UpdateCommand,
            string TableName)
		{
			int count = 0;
			SqlConnection sq = null;
			bool created = false;
			try
			{
				count = GetAllSqlConnectionsUp();
				if (0 == count)
				{
					return created;
				}

				for (int i = 0; i < arSynSqlConnectList.Count; i++)
				{
					sq = (SqlConnection)arSynSqlConnectList[i];
					if ((null == sq) || (ConnectionState.Open != sq.State))
						continue;

					// Query for the table.
					SqlDataAdapter dAdapt = new SqlDataAdapter(QueryCommand, sq);
					DataSet ds = new DataSet();
					dAdapt.Fill(ds, TableName.Trim());
					if (null != ds)
					{
						DataTable dt = ds.Tables[TableName.Trim()];
						count = (dt.Rows.Count > 0) ? 1 : 0;
					}

					if (0 < count)
					{
                        // The table is already created.
						created = true;
					}
					else
					{
						// Create the table.
						SqlCommand myInserCommand = new SqlCommand(UpdateCommand, sq);
						count = myInserCommand.ExecuteNonQuery();
						created = (0 < count);
					}
				}
			}
			catch(SqlException sqlex)
			{
				string msg = sqlex.Message;
			}
			catch(Exception e)
			{
				string msg = e.ToString();
			}
			finally
			{
				TearDownSqlConnections();
			}
			return created;
		}

        /// <summary>
        /// Executes a Transact-SQL statement against all of the connections
        /// and returns the number of rows affected.
        /// </summary>
        /// <param name="command">the SQL command</param>
        /// <returns>the number of rows affected</returns>
		public int MyUpdateDataExecuteNonQuery(string command)
		{
			int count = 0;
			int totalAffected = 0;
			SqlConnection sq = null;
			try
			{
				count = GetAllSqlConnectionsUp();
				if (0 < count)
				{
				    for (int i = 0; i < arSynSqlConnectList.Count; i++)
				    {
					    sq = (SqlConnection)arSynSqlConnectList[i];
					    if ((null == sq) || (ConnectionState.Open != sq.State))
						    continue;

					    // Execute the SQL command.
					    SqlCommand myCommand = new SqlCommand(command, sq);
                        totalAffected += myCommand.ExecuteNonQuery();
				    }
                }
			}
			catch(SqlException sqlex)
			{
				string msg = sqlex.Message;
            }
			catch(Exception e)
			{
				string msg = e.ToString();
            }
			finally
			{
				TearDownSqlConnections();
			}
			return totalAffected;
		}

        /// <summary>
        /// Dispose of the database.
        /// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(true); // as a service to those who might inherit from us
		}

        /// <summary>
        /// Dispose of the database.
        /// </summary>
        /// <param name="disposing">false if called from the finalizer</param>
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
                return; // Free managed resources.
            else
				return; // We're being collected, so let the GC take care of this object.
		}
	}
	public class XorCrypt
	{
		private static byte[] SALT = {0xC0, 0xFF, 0xE};
		private byte[] xorBuf = null;
		private const int LEN = 1024;
		private int count;
		private PasswordDeriveBytes rand;
		private string key = "0723197203241976EDS";

		public XorCrypt()
		{
			rand = new PasswordDeriveBytes(key, SALT);
			xorBuf = rand.GetBytes(LEN);
			count = 0;
		}

		public void XorStream(Stream inx, Stream outx)
		{
			int b;
			while((b = inx.ReadByte()) != -1)
				outx.WriteByte(crypt((byte)b));

		}
		public byte crypt(byte b)
		{
			byte by = b;
			by ^= xorBuf[count++];
			if (count >= xorBuf.Length)
			{
				xorBuf = rand.GetBytes(LEN);
				count = 0;
			}
			return by;
		}
	}

	class ProfileDBRegistry
	{
		private RegistryKey rk = null;
		private RegistryKey createkey = null;
		private string RegKey = "SOFTWARE\\ProfileDB";
		private string RegSubKey = "AuthString";
		private string errmsg = "";
		public bool OpenKey()
		{
			rk = Registry.LocalMachine.OpenSubKey(RegKey, false);
			return true;
		}

		public bool CreateKey()
		{
			try
			{
				createkey = Registry.LocalMachine.CreateSubKey(RegKey);
			}
			catch(SecurityException secex)
			{
				errmsg = secex.Message;
				return false;
			}

			catch(UnauthorizedAccessException unauthex)
			{
				errmsg = unauthex.Message;
				return false;
			}
				
			return true;
		}

		public bool StoreData(byte[] data, int iLen)
		{
			if (createkey == null)
			{
				if (!CreateKey())
					return false;
			}
			try
			{
				createkey.SetValue(RegSubKey, data);
			}
			catch(SecurityException secex)
			{
				errmsg = secex.Message;
				return false;
			}

			catch(UnauthorizedAccessException unauthex)
			{
				errmsg = unauthex.Message;
				return false;
			}
			return true;
		}
        public string GetConnectionString()
        {
            if(rk == null)
            {
                rk = Registry.LocalMachine.OpenSubKey( RegKey );
            }
            return (string)rk.GetValue( RegSubKey );
        }

		public byte[] GetConnectionStringValue()
		{
			if (rk == null)
			{
				rk = Registry.LocalMachine.OpenSubKey(RegKey);
			}
			//??byte[] ConnectString = null;
//			ConnectString = (byte[])rk.GetValue(RegSubKey);
            object result = rk.GetValue( RegSubKey );
            byte[] resultBytes = result as byte[];
            if (resultBytes != null)
                return resultBytes;
            char[] resultChars = result as char[];
            if (resultChars != null)
                return Encoding.UTF8.GetBytes(resultChars);
            //??ConnectString = Encoding.UTF8.GetBytes( (char[])result );
			//??return ConnectString;
            return null;
		}

		public void CloseKey()
		{
			if (rk != null)
				rk.Close();
			if (createkey != null)
				createkey.Close();
		}
	}
}
