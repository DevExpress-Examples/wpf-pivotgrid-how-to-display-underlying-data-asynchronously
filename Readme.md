<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/195058597/21.1.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T828661)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# Pivot Grid for WPF - How to Display Underlying Records Asynchronously


This example demonstrates how to obtain records from the control's underlying data source for a selected cell or multiple selected cells asynchronously.

- Click a cell to show the underlying data in [GridControl](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridControl).
- Select multiple cells to show the order IDs of the orders summarized in the selected cells. Order IDs are displayed as buttons in [ItemsControl](https://docs.microsoft.com/en-us/dotnet/api/system.windows.controls.itemscontrol).

![](/images/screenshot.png)

## Examples Overview 

The [PivotGridControl.CellClick](https://docs.devexpress.com/WPF/DevExpress.Xpf.PivotGrid.PivotGridControl.CellClick) event raises when you click the Pivot Grid cell. The [CreateDrillDownDataSourceAsync](https://docs.devexpress.com/WPF/DevExpress.Xpf.PivotGrid.PivotGridControl.CreateDrillDownDataSourceAsync(System.Int32-System.Int32)) method returns the [PivotDrillDownDataSource](https://docs.devexpress.com/WPF/DevExpress.Xpf.PivotGrid.PivotDrillDownDataSource) instance that contains underlying data for the current cell. The `PivotDrillDownDataSource` object is used as the Grid Control's data source (it is assigned to the [GridControl.ItemsSource](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.DataControlBase.ItemsSource) property).

The [PivotGridControl.CellSelectionChanged](https://docs.devexpress.com/WPF/DevExpress.Xpf.PivotGrid.PivotGridControl.CellSelectionChanged) event raises when you select several Pivot Grid cells. The coordinates of the selected cells are obtained with the [PivotGridControl.MultiSelection.SelectedCells](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraPivotGrid.Selection.IMultipleSelection.SelectedCells) notation. For each (X, Y) pair of cell coordinates, the [CreateDrillDownDataSourceAsync](https://docs.devexpress.com/WPF/DevExpress.Xpf.PivotGrid.PivotGridControl.CreateDrillDownDataSourceAsync(System.Int32-System.Int32)) method yields the [PivotDrillDownDataSource](https://docs.devexpress.com/WPF/DevExpress.Xpf.PivotGrid.PivotDrillDownDataSource) object. The `PivotDrillDownDataSource` exposes an enumerator and supports an iteration over a collection of [PivotDrillDownDataRow](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraPivotGrid.PivotDrillDownDataRow) objects. The [PivotDrillDownDataRow.ListSourceRowIndex](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraPivotGrid.PivotDrillDownDataRow.ListSourceRowIndex) property value is an index of the record in the original data source, so the source record is also available and can be added to a collection. The resulting collection is bound to [ItemsControl](https://docs.microsoft.com/en-us/dotnet/api/system.windows.controls.itemscontrol) for display.

## Files to Look At

- [MainWindow.xaml](./CS/WpfDrillDownDataSourceExample/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/WpfDrillDownDataSourceExample/MainWindow.xaml))
- [MainWindow.xaml.cs](./CS/WpfDrillDownDataSourceExample/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/WpfDrillDownDataSourceExample/MainWindow.xaml.vb))
- [DatabaseHelper.cs](./CS/WpfDrillDownDataSourceExample/DatabaseHelper.cs) (VB: [DatabaseHelper.vb](./VB/WpfDrillDownDataSourceExample/DatabaseHelper.vb))

## Documentation

- [Drill Down to the Underlying Data](https://docs.devexpress.com/WPF/8056)
- [Asynchronous Mode](https://docs.devexpress.com/WPF/9776)

## More Examples

- [Pivot Grid for WPF - How to Display Underlying (Drill-Down) Records](https://github.com/DevExpress-Examples/how-to-obtain-underlying-data-e2173)
- [Pivot Grid for WinForms - How to Create the Underlying Data Source (Drill-Down) Asynchronously](https://github.com/DevExpress-Examples/how-to-use-asynchronous-operations-that-return-the-result-e4567)
