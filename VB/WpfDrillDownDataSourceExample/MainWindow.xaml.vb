Imports DevExpress.Xpf.Core
Imports DevExpress.Xpf.PivotGrid
Imports System.Collections.ObjectModel
Imports System.Windows

Namespace WpfDrillDownDataSourceExample

    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Public Partial Class MainWindow
        Inherits ThemedWindow

        Public Property OrderSourceList As ObservableCollection(Of MyOrderRow)

        Public Property OrderDrillDownList As ObservableCollection(Of MyOrderRow)

        Public Sub New()
            Me.InitializeComponent()
            OrderSourceList = CreateData()
            Me.pivotGridControl1.DataSource = OrderSourceList
        End Sub

        Private Async Sub PivotGridControl1_CellSelectionChanged(ByVal sender As Object, ByVal e As RoutedEventArgs)
            OrderDrillDownList = New ObservableCollection(Of MyOrderRow)()
            Dim selectionCopy = Me.pivotGridControl1.MultiSelection.SelectedCells.Cast(Of System.Drawing.Point)().ToList()
            For Each cellPoint In selectionCopy
                For Each record As PivotDrillDownDataRow In Await Me.pivotGridControl1.CreateDrillDownDataSourceAsync(cellPoint.X, cellPoint.Y)
                    OrderDrillDownList.Add(OrderSourceList(record.ListSourceRowIndex))
                Next
            Next

            Me.gridControl1.ItemsSource = OrderDrillDownList
        End Sub

        Private Sub ThemedWindow_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Me.pivotGridControl1.BestFitArea = FieldBestFitArea.FieldHeader
            Me.pivotGridControl1.BestFit()
        End Sub

        Private Async Sub pivotGridControl1_CellClick(ByVal sender As Object, ByVal e As PivotCellEventArgs)
            Me.gridControl1.ItemsSource = Await Me.pivotGridControl1.CreateDrillDownDataSourceAsync(e.ColumnIndex, e.RowIndex)
        End Sub
    End Class
End Namespace
