namespace ClientDeviceMgr.Common.Data
{
    using System;
    using System.Data;
	using System.Runtime.Serialization;
    using System.Runtime;
	
    /// <summary>
    ///     A custom serializable dataset containing category information.
    ///     <remarks>
    ///         This class is used to define the shape of CategoryData.
    ///     </remarks>
    ///     <remarks>
    ///         The serializable constructor allows objects of type CategoryData to be remoted.
    ///     </remarks>
    /// </summary>
    [System.ComponentModel.DesignerCategory("Code")]
    [SerializableAttribute] 
    public class SupportData : DataSet
    {
        //
        // Categories table constants
        //
        /// <value>The constant used for Categories table. </value>
        public const String SUPPORT_OPTIONS_TABLE  = "SupportOptions";
        /// <value>The constant used for WebForm field in the SupportOptions table. </value>
        public const String WEB_FORM_FIELD        = "WebForm";
        /// <value>The constant used for Description field in the SupportOptions table. </value>
        public const String DESCRIPTION_FIELD = "Description";
        /// <value>The constant used for Rights field in the SupportOptions table. </value>
        public const String RIGHTS_FIELD     = "Rights";

        /// <summary>
        ///     Constructor to support serialization.
        ///     <remarks>Constructor that supports serialization.</remarks> 
        ///     <param name="info">The SerializationInfo object to read from.</param>
        ///     <param name="context">Information on who is calling this method.</param>
        /// </summary>
        private SupportData(SerializationInfo info, StreamingContext context) : base(info, context) 
        {		
        }		
        
        /// <summary>
        ///     Constructor for CategoryData.  
        ///     <remarks>Initialize a CategoryData instance by building the table schema.</remarks> 
        /// </summary>
        public SupportData()
        {
            //
            // Create the tables in the dataset
            //
            BuildDataTables();
        }
        
        
        //----------------------------------------------------------------
        // Sub BuildDataTables:
        //   Creates the following datatables:  Categories
        //----------------------------------------------------------------
        private void BuildDataTables()
        {
            //
            // Create the Categories table
            //
            DataTable         table   = new DataTable(SUPPORT_OPTIONS_TABLE);
            DataColumnCollection columns = table.Columns;
        
            columns.Add(DESCRIPTION_FIELD, typeof(System.String));
            columns.Add(WEB_FORM_FIELD, typeof(System.String));
            columns.Add(RIGHTS_FIELD, typeof(System.String));
        
            this.Tables.Add(table);
        }
    
    } //class CategoryData
    
} //namespace Duwamish7.Common.Data
