﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.573
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

namespace QuickStartSamples_CS {
    using System;
    using System.Data;
    using System.Xml;
    using System.Runtime.Serialization;
    
    
    [Serializable()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.ToolboxItem(true)]
    public class ProductDS : DataSet {
        
        private ProductsDataTable tableProducts;
        
        public ProductDS() {
            this.InitClass();
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        protected ProductDS(SerializationInfo info, StreamingContext context) {
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((strSchema != null)) {
                DataSet ds = new DataSet();
                ds.ReadXmlSchema(new XmlTextReader(new System.IO.StringReader(strSchema)));
                if ((ds.Tables["Products"] != null)) {
                    this.Tables.Add(new ProductsDataTable(ds.Tables["Products"]));
                }
                this.DataSetName = ds.DataSetName;
                this.Prefix = ds.Prefix;
                this.Namespace = ds.Namespace;
                this.Locale = ds.Locale;
                this.CaseSensitive = ds.CaseSensitive;
                this.EnforceConstraints = ds.EnforceConstraints;
                this.Merge(ds, false, System.Data.MissingSchemaAction.Add);
                this.InitVars();
            }
            else {
                this.InitClass();
            }
            this.GetSerializationData(info, context);
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public ProductsDataTable Products {
            get {
                return this.tableProducts;
            }
        }
        
        public override DataSet Clone() {
            ProductDS cln = ((ProductDS)(base.Clone()));
            cln.InitVars();
            return cln;
        }
        
        protected override bool ShouldSerializeTables() {
            return false;
        }
        
        protected override bool ShouldSerializeRelations() {
            return false;
        }
        
        protected override void ReadXmlSerializable(XmlReader reader) {
            this.Reset();
            DataSet ds = new DataSet();
            ds.ReadXml(reader);
            if ((ds.Tables["Products"] != null)) {
                this.Tables.Add(new ProductsDataTable(ds.Tables["Products"]));
            }
            this.DataSetName = ds.DataSetName;
            this.Prefix = ds.Prefix;
            this.Namespace = ds.Namespace;
            this.Locale = ds.Locale;
            this.CaseSensitive = ds.CaseSensitive;
            this.EnforceConstraints = ds.EnforceConstraints;
            this.Merge(ds, false, System.Data.MissingSchemaAction.Add);
            this.InitVars();
        }
        
        protected override System.Xml.Schema.XmlSchema GetSchemaSerializable() {
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            this.WriteXmlSchema(new XmlTextWriter(stream, null));
            stream.Position = 0;
            return System.Xml.Schema.XmlSchema.Read(new XmlTextReader(stream), null);
        }
        
        internal void InitVars() {
            this.tableProducts = ((ProductsDataTable)(this.Tables["Products"]));
            if ((this.tableProducts != null)) {
                this.tableProducts.InitVars();
            }
        }
        
        private void InitClass() {
            this.DataSetName = "ProductDS";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/ProductDS.xsd";
            this.Locale = new System.Globalization.CultureInfo("en-US");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tableProducts = new ProductsDataTable();
            this.Tables.Add(this.tableProducts);
        }
        
        private bool ShouldSerializeProducts() {
            return false;
        }
        
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        public delegate void ProductsRowChangeEventHandler(object sender, ProductsRowChangeEvent e);
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class ProductsDataTable : DataTable, System.Collections.IEnumerable {
            
            private DataColumn columnProductID;
            
            private DataColumn columnProductName;
            
            private DataColumn columnQuantityPerUnit;
            
            private DataColumn columnUnitPrice;
            
            internal ProductsDataTable() : 
                    base("Products") {
                this.InitClass();
            }
            
            internal ProductsDataTable(DataTable table) : 
                    base(table.TableName) {
                if ((table.CaseSensitive != table.DataSet.CaseSensitive)) {
                    this.CaseSensitive = table.CaseSensitive;
                }
                if ((table.Locale.ToString() != table.DataSet.Locale.ToString())) {
                    this.Locale = table.Locale;
                }
                if ((table.Namespace != table.DataSet.Namespace)) {
                    this.Namespace = table.Namespace;
                }
                this.Prefix = table.Prefix;
                this.MinimumCapacity = table.MinimumCapacity;
                this.DisplayExpression = table.DisplayExpression;
            }
            
            [System.ComponentModel.Browsable(false)]
            public int Count {
                get {
                    return this.Rows.Count;
                }
            }
            
            internal DataColumn ProductIDColumn {
                get {
                    return this.columnProductID;
                }
            }
            
            internal DataColumn ProductNameColumn {
                get {
                    return this.columnProductName;
                }
            }
            
            internal DataColumn QuantityPerUnitColumn {
                get {
                    return this.columnQuantityPerUnit;
                }
            }
            
            internal DataColumn UnitPriceColumn {
                get {
                    return this.columnUnitPrice;
                }
            }
            
            public ProductsRow this[int index] {
                get {
                    return ((ProductsRow)(this.Rows[index]));
                }
            }
            
            public event ProductsRowChangeEventHandler ProductsRowChanged;
            
            public event ProductsRowChangeEventHandler ProductsRowChanging;
            
            public event ProductsRowChangeEventHandler ProductsRowDeleted;
            
            public event ProductsRowChangeEventHandler ProductsRowDeleting;
            
            public void AddProductsRow(ProductsRow row) {
                this.Rows.Add(row);
            }
            
            public ProductsRow AddProductsRow(int ProductID, string ProductName, string QuantityPerUnit, System.Decimal UnitPrice) {
                ProductsRow rowProductsRow = ((ProductsRow)(this.NewRow()));
                rowProductsRow.ItemArray = new object[] {
                        ProductID,
                        ProductName,
                        QuantityPerUnit,
                        UnitPrice};
                this.Rows.Add(rowProductsRow);
                return rowProductsRow;
            }
            
            public System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            public override DataTable Clone() {
                ProductsDataTable cln = ((ProductsDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            protected override DataTable CreateInstance() {
                return new ProductsDataTable();
            }
            
            internal void InitVars() {
                this.columnProductID = this.Columns["ProductID"];
                this.columnProductName = this.Columns["ProductName"];
                this.columnQuantityPerUnit = this.Columns["QuantityPerUnit"];
                this.columnUnitPrice = this.Columns["UnitPrice"];
            }
            
            private void InitClass() {
                this.columnProductID = new DataColumn("ProductID", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnProductID);
                this.columnProductName = new DataColumn("ProductName", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnProductName);
                this.columnQuantityPerUnit = new DataColumn("QuantityPerUnit", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnQuantityPerUnit);
                this.columnUnitPrice = new DataColumn("UnitPrice", typeof(System.Decimal), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnUnitPrice);
                this.columnProductID.AllowDBNull = false;
                this.columnProductName.AllowDBNull = false;
                this.columnQuantityPerUnit.AllowDBNull = false;
                this.columnUnitPrice.AllowDBNull = false;
            }
            
            public ProductsRow NewProductsRow() {
                return ((ProductsRow)(this.NewRow()));
            }
            
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
                return new ProductsRow(builder);
            }
            
            protected override System.Type GetRowType() {
                return typeof(ProductsRow);
            }
            
            protected override void OnRowChanged(DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.ProductsRowChanged != null)) {
                    this.ProductsRowChanged(this, new ProductsRowChangeEvent(((ProductsRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowChanging(DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.ProductsRowChanging != null)) {
                    this.ProductsRowChanging(this, new ProductsRowChangeEvent(((ProductsRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleted(DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.ProductsRowDeleted != null)) {
                    this.ProductsRowDeleted(this, new ProductsRowChangeEvent(((ProductsRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleting(DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.ProductsRowDeleting != null)) {
                    this.ProductsRowDeleting(this, new ProductsRowChangeEvent(((ProductsRow)(e.Row)), e.Action));
                }
            }
            
            public void RemoveProductsRow(ProductsRow row) {
                this.Rows.Remove(row);
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class ProductsRow : DataRow {
            
            private ProductsDataTable tableProducts;
            
            internal ProductsRow(DataRowBuilder rb) : 
                    base(rb) {
                this.tableProducts = ((ProductsDataTable)(this.Table));
            }
            
            public int ProductID {
                get {
                    return ((int)(this[this.tableProducts.ProductIDColumn]));
                }
                set {
                    this[this.tableProducts.ProductIDColumn] = value;
                }
            }
            
            public string ProductName {
                get {
                    return ((string)(this[this.tableProducts.ProductNameColumn]));
                }
                set {
                    this[this.tableProducts.ProductNameColumn] = value;
                }
            }
            
            public string QuantityPerUnit {
                get {
                    return ((string)(this[this.tableProducts.QuantityPerUnitColumn]));
                }
                set {
                    this[this.tableProducts.QuantityPerUnitColumn] = value;
                }
            }
            
            public System.Decimal UnitPrice {
                get {
                    return ((System.Decimal)(this[this.tableProducts.UnitPriceColumn]));
                }
                set {
                    this[this.tableProducts.UnitPriceColumn] = value;
                }
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class ProductsRowChangeEvent : EventArgs {
            
            private ProductsRow eventRow;
            
            private DataRowAction eventAction;
            
            public ProductsRowChangeEvent(ProductsRow row, DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            public ProductsRow Row {
                get {
                    return this.eventRow;
                }
            }
            
            public DataRowAction Action {
                get {
                    return this.eventAction;
                }
            }
        }
    }
}
