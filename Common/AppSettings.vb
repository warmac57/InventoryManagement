Imports System.Configuration

Namespace Common

    ''' <summary>
    ''' Application settings and configuration
    ''' </summary>
    Public Class AppSettings
        Private Shared _instance As AppSettings
        Private Shared ReadOnly _lock As New Object()

        ' Connection string - update this for your environment
        Private Const DEFAULT_CONNECTION_STRING As String = "Server=.\SQLEXPRESS;Database=InventoryManagement;Trusted_Connection=True;TrustServerCertificate=True;"

        ' Cached store settings
        Private _negativeStockAllowed As Boolean = False
        Private _inStockCheck As Boolean = True
        Private _movingAveragePrice As Boolean = True
        Private _taxRate As Decimal = 8.25D
        Private _companyName As String = "Inventory Solutions Inc."
        Private _defaultCurrency As String = "USD"
        Private _orderNumberPrefix As String = "ORD-"
        Private _purchaseNumberPrefix As String = "PO-"
        Private _autoGenerateOrderNumber As Boolean = True
        Private _autoGeneratePurchaseNumber As Boolean = True

        ''' <summary>
        ''' Singleton instance
        ''' </summary>
        Public Shared ReadOnly Property Instance As AppSettings
            Get
                If _instance Is Nothing Then
                    SyncLock _lock
                        If _instance Is Nothing Then
                            _instance = New AppSettings()
                        End If
                    End SyncLock
                End If
                Return _instance
            End Get
        End Property

        ''' <summary>
        ''' Database connection string
        ''' </summary>
        Public Property ConnectionString As String = DEFAULT_CONNECTION_STRING

        ''' <summary>
        ''' Allow negative stock quantities
        ''' </summary>
        Public Property NegativeStockAllowed As Boolean
            Get
                Return _negativeStockAllowed
            End Get
            Set(value As Boolean)
                _negativeStockAllowed = value
            End Set
        End Property

        ''' <summary>
        ''' Check stock availability before order
        ''' </summary>
        Public Property InStockCheck As Boolean
            Get
                Return _inStockCheck
            End Get
            Set(value As Boolean)
                _inStockCheck = value
            End Set
        End Property

        ''' <summary>
        ''' Use moving average for item costing
        ''' </summary>
        Public Property MovingAveragePrice As Boolean
            Get
                Return _movingAveragePrice
            End Get
            Set(value As Boolean)
                _movingAveragePrice = value
            End Set
        End Property

        ''' <summary>
        ''' Default tax rate percentage
        ''' </summary>
        Public Property TaxRate As Decimal
            Get
                Return _taxRate
            End Get
            Set(value As Decimal)
                _taxRate = value
            End Set
        End Property

        ''' <summary>
        ''' Company name for reports
        ''' </summary>
        Public Property CompanyName As String
            Get
                Return _companyName
            End Get
            Set(value As String)
                _companyName = value
            End Set
        End Property

        ''' <summary>
        ''' Default currency code
        ''' </summary>
        Public Property DefaultCurrency As String
            Get
                Return _defaultCurrency
            End Get
            Set(value As String)
                _defaultCurrency = value
            End Set
        End Property

        ''' <summary>
        ''' Order number prefix
        ''' </summary>
        Public Property OrderNumberPrefix As String
            Get
                Return _orderNumberPrefix
            End Get
            Set(value As String)
                _orderNumberPrefix = value
            End Set
        End Property

        ''' <summary>
        ''' Purchase number prefix
        ''' </summary>
        Public Property PurchaseNumberPrefix As String
            Get
                Return _purchaseNumberPrefix
            End Get
            Set(value As String)
                _purchaseNumberPrefix = value
            End Set
        End Property

        ''' <summary>
        ''' Auto-generate order numbers
        ''' </summary>
        Public Property AutoGenerateOrderNumber As Boolean
            Get
                Return _autoGenerateOrderNumber
            End Get
            Set(value As Boolean)
                _autoGenerateOrderNumber = value
            End Set
        End Property

        ''' <summary>
        ''' Auto-generate purchase numbers
        ''' </summary>
        Public Property AutoGeneratePurchaseNumber As Boolean
            Get
                Return _autoGeneratePurchaseNumber
            End Get
            Set(value As Boolean)
                _autoGeneratePurchaseNumber = value
            End Set
        End Property

        Private Sub New()
            ' Private constructor for singleton
        End Sub

        ''' <summary>
        ''' Load settings from database
        ''' </summary>
        Public Sub LoadSettings()
            Try
                Using helper As New DatabaseHelper()
                    Dim sql As String = "SELECT Setting_Name, Setting_Value FROM STORE_SETTINGS WHERE Setting_Value IS NOT NULL"
                    Using reader = helper.ExecuteReader(sql)
                        While reader.Read()
                            Dim name As String = reader("Setting_Name").ToString()
                            Dim value As String = reader("Setting_Value").ToString()

                            Select Case name
                                Case "Negative_Stock_Allowed"
                                    _negativeStockAllowed = Boolean.Parse(value)
                                Case "In_Stock_Check"
                                    _inStockCheck = Boolean.Parse(value)
                                Case "Moving_Average_Price"
                                    _movingAveragePrice = Boolean.Parse(value)
                                Case "Tax_Rate"
                                    _taxRate = Decimal.Parse(value)
                                Case "Company_Name"
                                    _companyName = value
                                Case "Default_Currency"
                                    _defaultCurrency = value
                                Case "Order_Number_Prefix"
                                    _orderNumberPrefix = value
                                Case "Purchase_Number_Prefix"
                                    _purchaseNumberPrefix = value
                                Case "Auto_Generate_Order_Number"
                                    _autoGenerateOrderNumber = Boolean.Parse(value)
                                Case "Auto_Generate_Purchase_Number"
                                    _autoGeneratePurchaseNumber = Boolean.Parse(value)
                            End Select
                        End While
                    End Using
                End Using
            Catch ex As Exception
                ' Use default values if settings cannot be loaded
                System.Diagnostics.Debug.WriteLine("Error loading settings: " & ex.Message)
            End Try
        End Sub

        ''' <summary>
        ''' Save a setting to database
        ''' </summary>
        Public Sub SaveSetting(settingName As String, settingValue As String)
            Try
                Using helper As New DatabaseHelper()
                    Dim sql As String = "UPDATE STORE_SETTINGS SET Setting_Value = @Value, Modified_Date = GETDATE(), Modified_By_User_ID = @UserID WHERE Setting_Name = @Name"
                    helper.AddParameter("@Value", settingValue)
                    helper.AddParameter("@UserID", SessionManager.Instance.CurrentUser?.User_ID)
                    helper.AddParameter("@Name", settingName)
                    helper.ExecuteNonQuery(sql)
                End Using
            Catch ex As Exception
                Throw New Exception("Error saving setting: " & ex.Message, ex)
            End Try
        End Sub

    End Class

End Namespace
