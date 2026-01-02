Imports System.Data
Imports Microsoft.Data.SqlClient
Imports InventoryManagement.Common

Namespace DataAccess

    Public Class DashboardMetrics
        Public Property TotalInventoryValue As Decimal
        Public Property TotalItemCount As Integer
        Public Property LowStockCount As Integer
        Public Property PendingOrderCount As Integer
        Public Property PendingPurchaseCount As Integer
        Public Property TodaySalesTotal As Decimal
    End Class

    Public Class CategoryStockValue
        Public Property CategoryName As String
        Public Property StockValue As Decimal
    End Class

    Public Class DashboardDAO

        Public Function GetDashboardMetrics() As DashboardMetrics
            Dim metrics As New DashboardMetrics()

            Using db As New DatabaseHelper()
                ' Total Inventory Value
                Dim sqlValue = "SELECT ISNULL(SUM(Stock_Quantity * Current_Item_Cost), 0) FROM ITEM WHERE Is_Active = 1"
                Dim result = db.ExecuteScalar(sqlValue)
                metrics.TotalInventoryValue = If(result IsNot Nothing AndAlso Not IsDBNull(result), Convert.ToDecimal(result), 0D)

                ' Total Item Count
                Dim sqlCount = "SELECT COUNT(*) FROM ITEM WHERE Is_Active = 1"
                result = db.ExecuteScalar(sqlCount)
                metrics.TotalItemCount = If(result IsNot Nothing AndAlso Not IsDBNull(result), Convert.ToInt32(result), 0)

                ' Low Stock Count (items below reorder level)
                Dim sqlLowStock = "SELECT COUNT(*) FROM ITEM WHERE Is_Active = 1 AND Track_Inventory = 1 AND Stock_Quantity <= Reorder_Level"
                result = db.ExecuteScalar(sqlLowStock)
                metrics.LowStockCount = If(result IsNot Nothing AndAlso Not IsDBNull(result), Convert.ToInt32(result), 0)

                ' Pending Orders (Submitted status - awaiting approval)
                Dim sqlPendingOrders = "SELECT COUNT(*) FROM ORDER_HEADER WHERE Order_Status IN ('Draft', 'Submitted')"
                result = db.ExecuteScalar(sqlPendingOrders)
                metrics.PendingOrderCount = If(result IsNot Nothing AndAlso Not IsDBNull(result), Convert.ToInt32(result), 0)

                ' Pending Purchases (Approved status - awaiting receipt)
                Dim sqlPendingPurchases = "SELECT COUNT(*) FROM PURCHASE_HEADER WHERE Purchase_Status IN ('Draft', 'Approved')"
                result = db.ExecuteScalar(sqlPendingPurchases)
                metrics.PendingPurchaseCount = If(result IsNot Nothing AndAlso Not IsDBNull(result), Convert.ToInt32(result), 0)

                ' Today's Sales (Delivered orders today)
                Dim sqlTodaySales = "SELECT ISNULL(SUM(Total_Amount), 0) FROM ORDER_HEADER WHERE Order_Status = 'Delivered' AND CAST(Order_Date AS DATE) = CAST(GETDATE() AS DATE)"
                result = db.ExecuteScalar(sqlTodaySales)
                metrics.TodaySalesTotal = If(result IsNot Nothing AndAlso Not IsDBNull(result), Convert.ToDecimal(result), 0D)
            End Using

            Return metrics
        End Function

        Public Function GetStockValueByCategory() As List(Of CategoryStockValue)
            Dim result As New List(Of CategoryStockValue)

            Using db As New DatabaseHelper()
                Dim sql = "
                    SELECT
                        ISNULL(c.Category_Name, 'Uncategorized') AS CategoryName,
                        ISNULL(SUM(i.Stock_Quantity * i.Current_Item_Cost), 0) AS StockValue
                    FROM ITEM i
                    LEFT JOIN CATEGORY c ON i.Category_ID = c.Category_ID
                    WHERE i.Is_Active = 1
                    GROUP BY c.Category_Name
                    HAVING SUM(i.Stock_Quantity * i.Current_Item_Cost) > 0
                    ORDER BY StockValue DESC"

                Dim dt = db.GetDataTable(sql)
                For Each row As DataRow In dt.Rows
                    Dim item As New CategoryStockValue()
                    item.CategoryName = row("CategoryName").ToString()
                    item.StockValue = Convert.ToDecimal(row("StockValue"))
                    result.Add(item)
                Next
            End Using

            Return result
        End Function

        Public Function GetRecentActivity(count As Integer) As DataTable
            Using db As New DatabaseHelper()
                Dim sql = $"
                    SELECT TOP {count} * FROM (
                        SELECT
                            'Order' AS ActivityType,
                            Order_Number AS Reference,
                            Order_Status AS Status,
                            Total_Amount AS Amount,
                            Order_Date AS ActivityDate
                        FROM ORDER_HEADER
                        UNION ALL
                        SELECT
                            'Purchase' AS ActivityType,
                            Purchase_Number AS Reference,
                            Purchase_Status AS Status,
                            Total_Amount AS Amount,
                            Purchase_Date AS ActivityDate
                        FROM PURCHASE_HEADER
                    ) AS Activities
                    ORDER BY ActivityDate DESC"

                Return db.GetDataTable(sql)
            End Using
        End Function

    End Class

End Namespace
