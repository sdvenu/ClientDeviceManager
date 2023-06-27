' Data Access Application Block Quick Start Samples.
' Please run CreateStoredProcedures.sql in SQL Query Analyzer
' to create database objects used by these examples.
Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents cmdSample6 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtConnectionString As System.Windows.Forms.TextBox
    Friend WithEvents cmdSample5 As System.Windows.Forms.Button
    Friend WithEvents cmdSample4 As System.Windows.Forms.Button
    Friend WithEvents cmdSample3 As System.Windows.Forms.Button
    Friend WithEvents cmdSample2 As System.Windows.Forms.Button
    Friend WithEvents cmdClearResults As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtResults As System.Windows.Forms.RichTextBox
    Friend WithEvents cmdSample1 As System.Windows.Forms.Button
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents cmdSample7 As System.Windows.Forms.Button
    Friend WithEvents cmdSample8 As System.Windows.Forms.Button
    Friend WithEvents cmdSample9 As System.Windows.Forms.Button
    Friend WithEvents cmdSample10 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.cmdSample6 = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtConnectionString = New System.Windows.Forms.TextBox
        Me.cmdSample5 = New System.Windows.Forms.Button
        Me.cmdSample4 = New System.Windows.Forms.Button
        Me.cmdSample3 = New System.Windows.Forms.Button
        Me.cmdSample2 = New System.Windows.Forms.Button
        Me.cmdClearResults = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtResults = New System.Windows.Forms.RichTextBox
        Me.cmdSample1 = New System.Windows.Forms.Button
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdSample7 = New System.Windows.Forms.Button
        Me.cmdSample8 = New System.Windows.Forms.Button
        Me.cmdSample9 = New System.Windows.Forms.Button
        Me.cmdSample10 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'cmdSample6
        '
        Me.cmdSample6.Location = New System.Drawing.Point(16, 264)
        Me.cmdSample6.Name = "cmdSample6"
        Me.cmdSample6.Size = New System.Drawing.Size(224, 32)
        Me.cmdSample6.TabIndex = 32
        Me.cmdSample6.Text = "Retrieve XML Data"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(272, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 16)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Connection String"
        '
        'txtConnectionString
        '
        Me.txtConnectionString.Location = New System.Drawing.Point(272, 32)
        Me.txtConnectionString.Name = "txtConnectionString"
        Me.txtConnectionString.Size = New System.Drawing.Size(480, 20)
        Me.txtConnectionString.TabIndex = 30
        Me.txtConnectionString.Text = "Server=(local);Database=Northwind;Integrated Security=True;"
        '
        'cmdSample5
        '
        Me.cmdSample5.Location = New System.Drawing.Point(16, 216)
        Me.cmdSample5.Name = "cmdSample5"
        Me.cmdSample5.Size = New System.Drawing.Size(224, 32)
        Me.cmdSample5.TabIndex = 29
        Me.cmdSample5.Text = "Perform Transactional Update"
        '
        'cmdSample4
        '
        Me.cmdSample4.Location = New System.Drawing.Point(16, 168)
        Me.cmdSample4.Name = "cmdSample4"
        Me.cmdSample4.Size = New System.Drawing.Size(224, 32)
        Me.cmdSample4.TabIndex = 28
        Me.cmdSample4.Text = "Look Up Single Item"
        '
        'cmdSample3
        '
        Me.cmdSample3.Location = New System.Drawing.Point(16, 120)
        Me.cmdSample3.Name = "cmdSample3"
        Me.cmdSample3.Size = New System.Drawing.Size(224, 32)
        Me.cmdSample3.TabIndex = 27
        Me.cmdSample3.Text = "Retrieve Single Row"
        '
        'cmdSample2
        '
        Me.cmdSample2.Location = New System.Drawing.Point(16, 72)
        Me.cmdSample2.Name = "cmdSample2"
        Me.cmdSample2.Size = New System.Drawing.Size(224, 32)
        Me.cmdSample2.TabIndex = 26
        Me.cmdSample2.Text = "Retrieve Multiple Rows using DataSet"
        '
        'cmdClearResults
        '
        Me.cmdClearResults.Location = New System.Drawing.Point(16, 504)
        Me.cmdClearResults.Name = "cmdClearResults"
        Me.cmdClearResults.Size = New System.Drawing.Size(224, 32)
        Me.cmdClearResults.TabIndex = 25
        Me.cmdClearResults.Text = "Clear Results"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(272, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 16)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Results"
        '
        'txtResults
        '
        Me.txtResults.Location = New System.Drawing.Point(272, 88)
        Me.txtResults.Name = "txtResults"
        Me.txtResults.Size = New System.Drawing.Size(480, 440)
        Me.txtResults.TabIndex = 23
        Me.txtResults.Text = ""
        '
        'cmdSample1
        '
        Me.cmdSample1.Location = New System.Drawing.Point(16, 24)
        Me.cmdSample1.Name = "cmdSample1"
        Me.cmdSample1.Size = New System.Drawing.Size(224, 32)
        Me.cmdSample1.TabIndex = 22
        Me.cmdSample1.Text = "Retrieve Multiple Rows using DataReader"
        '
        'cmdSample7
        '
        Me.cmdSample7.Location = New System.Drawing.Point(16, 312)
        Me.cmdSample7.Name = "cmdSample7"
        Me.cmdSample7.Size = New System.Drawing.Size(224, 32)
        Me.cmdSample7.TabIndex = 33
        Me.cmdSample7.Text = "Fill Dataset"
        '
        'cmdSample8
        '
        Me.cmdSample8.Location = New System.Drawing.Point(16, 360)
        Me.cmdSample8.Name = "cmdSample8"
        Me.cmdSample8.Size = New System.Drawing.Size(224, 32)
        Me.cmdSample8.TabIndex = 34
        Me.cmdSample8.Text = "Update data source"
        '
        'cmdSample9
        '
        Me.cmdSample9.Location = New System.Drawing.Point(16, 408)
        Me.cmdSample9.Name = "cmdSample9"
        Me.cmdSample9.Size = New System.Drawing.Size(224, 32)
        Me.cmdSample9.TabIndex = 36
        Me.cmdSample9.Text = "Perform update with parameter binding"
        '
        'cmdSample10
        '
        Me.cmdSample10.Location = New System.Drawing.Point(16, 456)
        Me.cmdSample10.Name = "cmdSample10"
        Me.cmdSample10.Size = New System.Drawing.Size(224, 32)
        Me.cmdSample10.TabIndex = 37
        Me.cmdSample10.Text = "Fill Strong Typed Dataset"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(776, 558)
        Me.Controls.Add(Me.cmdSample10)
        Me.Controls.Add(Me.cmdSample9)
        Me.Controls.Add(Me.cmdSample8)
        Me.Controls.Add(Me.cmdSample7)
        Me.Controls.Add(Me.cmdSample6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtConnectionString)
        Me.Controls.Add(Me.cmdSample5)
        Me.Controls.Add(Me.cmdSample4)
        Me.Controls.Add(Me.cmdSample3)
        Me.Controls.Add(Me.cmdSample2)
        Me.Controls.Add(Me.cmdClearResults)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtResults)
        Me.Controls.Add(Me.cmdSample1)
        Me.Name = "Form1"
        Me.Text = "Data Access Application Block for .NET QuickStart Samples (VB)"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Add tooltips to command buttons
        ToolTip.SetToolTip(cmdSample1, "Retrieving Multiple Rows Using a SqlDataReader")
        ToolTip.SetToolTip(cmdSample2, "Retrieving Multiple Rows Using a DataSet")
        ToolTip.SetToolTip(cmdSample3, "Retrieving a Single Row")
        ToolTip.SetToolTip(cmdSample4, "Looking Up a Single Item")
        ToolTip.SetToolTip(cmdSample5, "Performing Transactional Updates")
        ToolTip.SetToolTip(cmdSample6, "Retrieving XML Data")
        ToolTip.SetToolTip(cmdSample7, "Retrieving Multiple Rows Using a existing DataSet")
        toolTip.SetToolTip(cmdSample8, "Updating the data source with DataSet changes")
        toolTip.SetToolTip(cmdSample9, "Performing update with parameter binding")
        toolTip.SetToolTip(cmdSample10, "Retrieving Multiple Rows Using a existing strong typed DataSet")
    End Sub

    Private Sub cmdClearResults_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearResults.Click
        txtResults.Clear()
    End Sub

    Private Function GetConnection(ByVal connectionString As String) As SqlConnection
        Dim connection As New SqlConnection(txtConnectionString.Text)

        connection.Open()

        Return connection
    End Function

    Private Sub cmdSample1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSample1.Click
        ' SqlDataReader that will hold the returned results		
        Dim dr As SqlDataReader = Nothing

        ' SqlConnection that will be used to execute the sql commands
        Dim connection As SqlConnection = Nothing

        Try

            Try
                connection = GetConnection(txtConnectionString.Text)
            Catch ex As Exception
                MessageBox.Show("The connection with the database can´t be established", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            ' Call ExecuteReader static method of SqlHelper class that returns a SqlDataReader
            ' We pass in database connection string, stored procedure name and value of categoryID parameterand, and a "1" for CategoryID value
            dr = SqlHelper.ExecuteReader(connection, "getProductsByCategory", 1)

            ' display results in textbox on the form.
            txtResults.Clear()

            ' iterate through SqlDataReader
            While dr.Read()
                ' get the value of second column in the datareader (product description)
                txtResults.Text = txtResults.Text + dr.GetValue(1) + Environment.NewLine
            End While
        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("There are some problems while trying to use the Data Access Application block, please check the following error messages: {0}" _
              + Environment.NewLine + "This test requires some modifications to the database. Please make sure the database has been initialized using the SetUpDataBase.bat database script.", errMessage), _
              "Application error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Not dr Is Nothing Then
                CType(dr, IDisposable).Dispose()
            End If

            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try
    End Sub

    Private Sub cmdSample2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSample2.Click
        ' SqlConnection that will be used to execute the sql commands
        Dim connection As SqlConnection = Nothing

        Try
            Try
                connection = GetConnection(txtConnectionString.Text)
            Catch ex As Exception
                MessageBox.Show("The connection with the database can´t be established", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            ' DataSet that will hold the returned results
            Dim ds As DataSet

            ' Call ExecuteDataset static method of SqlHelper class that returns a Dataset
            ' We pass in database connection string, command type, stored procedure name and a "1" for CategoryID SqlParameter value 
            ds = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "getProductsByCategory", New SqlParameter("@CategoryID", 1))

            ' Get XML representation of the dataset and display results in text box
            txtResults.Clear()
            txtResults.Text = ds.GetXml()
        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("There are some problems while trying to use the Data Access Application block, please check the following error messages: {0}" _
              + Environment.NewLine + "This test requires some modifications to the database. Please make sure the database has been initialized using the SetUpDataBase.bat database script.", errMessage), _
              "Application error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try
    End Sub

    Private Sub cmdSample3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSample3.Click
        ' SqlConnection that will be used to execute the sql commands
        Dim connection As SqlConnection = Nothing

        Try
            Try
                connection = GetConnection(txtConnectionString.Text)
            Catch ex As Exception
                MessageBox.Show("The connection with the database can´t be established", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            ' Set up parameters (1 input and 3 output) 
            Dim arParms() As SqlParameter = New SqlParameter(3) {}

            ' @ProductID Input Parameter 
            ' assign a "1" for ProductID parameter value
            arParms(0) = New SqlParameter("@ProductID", SqlDbType.Int)
            arParms(0).Value = 1

            ' @ProductName Output Parameter
            arParms(1) = New SqlParameter("@ProductName", SqlDbType.NVarChar, 40)
            arParms(1).Direction = ParameterDirection.Output

            ' @UnitPrice Output Parameter
            arParms(2) = New SqlParameter("@UnitPrice", SqlDbType.Money)
            arParms(2).Direction = ParameterDirection.Output

            ' @QtyPerUnit Output Parameter
            arParms(3) = New SqlParameter("@QtyPerUnit", SqlDbType.NVarChar, 20)
            arParms(3).Direction = ParameterDirection.Output

            ' Call ExecuteNonQuery static method of SqlHelper class
            ' We pass in database connection string, command type, stored procedure name and an array of SqlParameter object
            SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "getProductDetails", arParms)

            ' Display results in text box using the values of output parameters	
            txtResults.Clear()
            txtResults.Text = arParms(1).Value & ", " & arParms(2).Value & ", " & arParms(3).Value

        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("There are some problems while trying to use the Data Access Application block, please check the following error messages: {0}" _
              + Environment.NewLine + "This test requires some modifications to the database. Please make sure the database has been initialized using the SetUpDataBase.bat database script.", errMessage), _
              "Application error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try

    End Sub

    Private Sub cmdSample4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSample4.Click
        ' String variable that will hold the returned result
        Dim productName As String

        ' SqlConnection that will be used to execute the sql commands
        Dim connection As SqlConnection = Nothing

        Try
            Try
                connection = GetConnection(txtConnectionString.Text)
            Catch ex As Exception
                MessageBox.Show("The connection with the database can´t be established", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            ' Call ExecuteScalar static method of SqlHelper class that returns an Object. Then cast the return value to string.
            ' We pass in database connection string, command type, stored procedure name, and a "1" as value for productID SqlParameter
            productName = CType(SqlHelper.ExecuteScalar(connection, CommandType.StoredProcedure, "getProductName", New SqlParameter("@ProductID", 1)), String)

            ' Display results in text box
            txtResults.Text = productName

        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("There are some problems while trying to use the Data Access Application block, please check the following error messages: {0}" _
              + Environment.NewLine + "This test requires some modifications to the database. Please make sure the database has been initialized using the SetUpDataBase.bat database script.", errMessage), _
              "Application error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try
    End Sub

    Private Sub cmdSample5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSample5.Click

        ' SqlConnection that will be used to execute the sql commands
        Dim connection As SqlConnection = Nothing

        Try
            Try
                connection = GetConnection(txtConnectionString.Text)
            Catch ex As Exception
                MessageBox.Show("The connection with the database can´t be established", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            Dim trans As SqlTransaction = Nothing
            Try
                trans = connection.BeginTransaction()

                ' Establish command parameters

                ' @AccountNo (From Account)
                Dim paramFromAcc As New SqlParameter("@AccountNo", SqlDbType.Char, 20)
                paramFromAcc.Value = "12345"

                ' @AccountNo (To Account)
                Dim paramToAcc As New SqlParameter("@AccountNo", SqlDbType.Char, 20)
                paramToAcc.Value = "67890"

                ' @Money (Credit amount)
                Dim paramCreditAmount As New SqlParameter("@Amount", SqlDbType.Money)
                paramCreditAmount.Value = 500

                ' @Money (Debit amount)
                Dim paramDebitAmount As New SqlParameter("@Amount", SqlDbType.Money)
                paramDebitAmount.Value = 500

                Try
                    ' Perform the debit operation
                    SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "Debit", paramFromAcc, paramDebitAmount)

                    ' Perform the credit operation
                    SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "Credit", paramToAcc, paramCreditAmount)

                    trans.Commit()
                    ' If we got this far, transfer completed without errors being thrown
                    txtResults.Text = "Transfer Completed"

                Catch ex As Exception
                    ' throw an exception
                    trans.Rollback()
                    txtResults.Text = "Transfer Error"
                    Throw ex
                End Try
            Finally
                If Not trans Is Nothing Then trans.Dispose()
            End Try
        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("There are some problems while trying to use the Data Access Application block, please check the following error messages: {0}" _
              + Environment.NewLine + "This test requires some modifications to the database. Please make sure the database has been initialized using the SetUpDataBase.bat database script.", errMessage), _
              "Application error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try
    End Sub

    Private Sub cmdSample6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSample6.Click

        ' XmlReader that will hold the returned results
        Dim xreader As XmlReader

        ' SqlConnection that will be used to execute the sql commands
        Dim connection As SqlConnection = Nothing

        Try
            Try
                connection = GetConnection(txtConnectionString.Text)
            Catch ex As Exception
                MessageBox.Show("The connection with the database can´t be established", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            ' Call ExecuteXmlReader static method of SqlHelper class that returns an XmlReader
            ' We pass in an open database connection object, command type, and command text
            xreader = SqlHelper.ExecuteXmlReader(connection, CommandType.Text, "SELECT * FROM Products FOR XML AUTO")

            ' read the contents of xml reader and populate the results text box:
            txtResults.Clear()
            While (Not xreader.EOF)
                If xreader.IsStartElement() Then
                    txtResults.Text = txtResults.Text + xreader.ReadOuterXml() + Environment.NewLine
                End If
            End While

            ' close XmlReader and connection objects
            xreader.Close()
            connection.Close()
        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("There are some problems while trying to use the Data Access Application block, please check the following error messages: {0}" _
              + Environment.NewLine + "This test requires some modifications to the database. Please make sure the database has been initialized using the SetUpDataBase.bat database script.", errMessage), _
              "Application error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try
    End Sub

    Private Sub cmdSample7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSample7.Click
        'DataSet that will hold the returned results
        Dim ds As DataSet = New DataSet

        ' SqlConnection that will be used to execute the sql commands
        Dim connection As SqlConnection = Nothing

        Try

            Try
                connection = GetConnection(txtConnectionString.Text)
            Catch ex As Exception
                MessageBox.Show("The connection with the database can´t be established", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            'Call FillDataset static method of SqlHelper class that fills a existing Dataset
            'We pass in database connection string, command type, stored procedure name and categoryID SqlParameter
            'that has a value of "1"
            SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "getProductsByCategory", ds, New String() {"Products"}, New SqlParameter("@CategoryID", 1))

            'Get XML representation of the dataset and display results in text box
            txtResults.Text = ds.GetXml()
        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("There are some problems while trying to use the Data Access Application block, please check the following error messages: {0}" _
              + Environment.NewLine + "This test requires some modifications to the database. Please make sure the database has been initialized using the SetUpDataBase.bat database script.", errMessage), _
              "Application error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try
    End Sub

    Private Sub cmdSample8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSample8.Click

        'DataSet that will hold the returned results
        Dim ds As New DataSet

        ' SqlConnection that will be used to execute the sql commands
        Dim connection As SqlConnection = Nothing

        Try
            Try
                connection = GetConnection(txtConnectionString.Text)
            Catch ex As Exception
                MessageBox.Show("The connection with the database can´t be established", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            'Call FillDataset static method of SqlHelper class that fills a Dataset
            'We pass in database connection string, command type, stored procedure name and categoryID SqlParameter
            'that has a value of "1"
            SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "getProductsByCategory", ds, New String() {"Products"}, New SqlParameter("@CategoryID", 1))

            'DataTable that hold the returned results
            Dim table As DataTable = ds.Tables("Products")

            'Add a new product to existing DataSet
            Dim addedRow As DataRow = table.Rows.Add(New Object() {DBNull.Value, "New product", DBNull.Value, 10})

            'Modify a existing product
            table.Rows(0)("ProductName") = "Modified product"

            'Create the command that will be used for insert operations
            Dim insertCommand As SqlCommand = SqlHelper.CreateCommand(connection, "addProduct", "ProductName", "UnitPrice")

            'Create the command that will be used for update operations
            ' The sotred procedure also performs a SELECT to allow updating the DataSet with other changes (Identity columns, changes performed by triggers, etc)
            Dim updateCommand As SqlCommand = SqlHelper.CreateCommand(connection, "updateProduct", "ProductID", "ProductName", "LastUpdate")

            'Create the command that will be used for delete operations
            Dim deleteCommand As SqlCommand = SqlHelper.CreateCommand(connection, "deleteProduct", "ProductID")

            Try
                'Update the data source with the DataSet changes
                SqlHelper.UpdateDataset(insertCommand, deleteCommand, updateCommand, ds, "Products")

                'Get the new product id. This id was generated in the data source
                txtResults.Text = "ProductID: " & addedRow("ProductID").ToString()
            Catch concurrencyException As DBConcurrencyException
                MessageBox.Show("A concurrency error has ocurred while trying to update the data source", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtResults.Text = "The following rows wasn´t updated: "
                Dim currentRow As DataRow
                For Each currentRow In table.Rows
                    If currentRow.RowState <> DataRowState.Unchanged Then
                        txtResults.Text += Environment.NewLine & "Product ID: " & currentRow("ProductID").ToString() & _
                                            " Product Name: " & currentRow("ProductName").ToString()
                    End If
                Next
            End Try
        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("There are some problems while trying to use the Data Access Application block, please check the following error messages: {0}" _
              + Environment.NewLine + "This test requires some modifications to the database. Please make sure the database has been initialized using the SetUpDataBase.bat database script.", errMessage), _
              "Application error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try
    End Sub

    Private Sub cmdSample9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSample9.Click
        'DataSet that will hold the returned results
        Dim productDS As New ProductDS

        ' SqlConnection that will be used to execute the sql commands
        Dim connection As SqlConnection = Nothing

        Try
            Try
                connection = GetConnection(txtConnectionString.Text)
            Catch ex As Exception
                MessageBox.Show("The connection with the database can´t be established", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            'Call FillDataset static method of SqlHelper class that fills a Dataset
            'We pass in database connection string, command type, stored procedure name and categoryID SqlParameter
            'that has a value of "1"
            SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "getProductsByCategory", productDS, New String() {productDS.Products.TableName}, New SqlParameter("@CategoryID", 1))

            'Modify a existing product
            productDS.Products(0).ProductName = "Modified product"

            'Apply changes in the data source
            SqlHelper.ExecuteDatasetTypedParams(connection, "updateProduct", productDS.Products(0))

            txtResults.Text = "The product " + productDS.Products(0).ProductID.ToString() + " has been modified. Now, its name is " + productDS.Products(0).ProductName
        Catch concurrencyException As DBConcurrencyException
            MessageBox.Show("A concurrency error has ocurred while trying to update the data source", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("There are some problems while trying to use the Data Access Application block, please check the following error messages: {0}" _
              + Environment.NewLine + "This test requires some modifications to the database. Please make sure the database has been initialized using the SetUpDataBase.bat database script.", errMessage), _
              "Application error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try
    End Sub

    Private Sub cmdSample10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSample10.Click
        ' SqlConnection that will be used to execute the sql commands
        Dim connection As SqlConnection = Nothing

        Try

            Try
                connection = GetConnection(txtConnectionString.Text)
            Catch ex As Exception
                MessageBox.Show("The connection with the database can´t be established", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            'Strong Typed DataSet that will hold the returned results
            Dim productDS As New ProductDS

            'Call FillDataset static method of SqlHelper class that fills a existing Dataset
            'We pass in database connection string, command type, stored procedure name and categoryID SqlParameter
            'that has a value of "1"
            SqlHelper.FillDataset(connection, CommandType.StoredProcedure, "getProductsByCategory", productDS, New String() {"Products"}, New SqlParameter("@CategoryID", 1))

            'Get XML representation of the dataset and display results in text box
            txtResults.Text = productDS.GetXml()
        Catch ex As Exception
            Dim errMessage As String = ""
            Dim tempException As Exception = ex

            While (Not tempException Is Nothing)
                errMessage += tempException.Message + Environment.NewLine + Environment.NewLine
                tempException = tempException.InnerException
            End While

            MessageBox.Show(String.Format("There are some problems while trying to use the Data Access Application block, please check the following error messages: {0}" _
              + Environment.NewLine + "This test requires some modifications to the database. Please make sure the database has been initialized using the SetUpDataBase.bat database script.", errMessage), _
              "Application error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            If Not connection Is Nothing Then
                CType(connection, IDisposable).Dispose()
            End If
        End Try
    End Sub
End Class