using DevExpress.Xpf.Core;
using DevExpress.Xpf.PivotGrid;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfDrillDownDataSourceExample {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : ThemedWindow {
        public ObservableCollection<MyOrderRow> OrderSourceList { get; set; }
        public ObservableCollection<MyOrderRow> OrderDrillDownList { get; set; }
        public MainWindow() {
            InitializeComponent();
            OrderSourceList = DatabaseHelper.CreateData();
            pivotGridControl1.DataSource = OrderSourceList;
        }
        private async void PivotGridControl1_CellSelectionChanged(object sender, RoutedEventArgs e) {
            OrderDrillDownList = new ObservableCollection<MyOrderRow>();
            var selectionCopy = pivotGridControl1.MultiSelection.SelectedCells.Cast<System.Drawing.Point>().ToList();
            foreach (var cellPoint in selectionCopy) {
                foreach (PivotDrillDownDataRow record in await pivotGridControl1.CreateDrillDownDataSourceAsync(cellPoint.X, cellPoint.Y)) {
                    
                    OrderDrillDownList.Add(OrderSourceList[record.ListSourceRowIndex]);
                }
            }
            lvOrders.ItemsSource = OrderDrillDownList;
        }
        private void ThemedWindow_Loaded(object sender, RoutedEventArgs e) {
            pivotGridControl1.BestFitArea = DevExpress.Xpf.PivotGrid.FieldBestFitArea.FieldHeader;
            pivotGridControl1.BestFit();
        }

        private async void pivotGridControl1_CellClick(object sender, PivotCellEventArgs e) {
            gridControl1.ItemsSource = await pivotGridControl1.CreateDrillDownDataSourceAsync(e.ColumnIndex, e.RowIndex);
        }
    }
}
