using System.Windows;
using DevExpress.Xpf.Core.Native;
using DevExpress.Xpf.Spreadsheet.Internal;

namespace SpreadsheetSpellchecking_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : DevExpress.Xpf.Core.ThemedWindow
    {
        public MainWindow() {
            InitializeComponent();
        }

        void OnSpreadsheetControl_Loaded(object sender, RoutedEventArgs e) {
            var activeSheet = spreadsheetControl.ActiveWorksheet;
            activeSheet.Columns[1].WidthInPixels = 150;
            spreadsheetControl.SelectedCell = activeSheet["B2"];
            spreadsheetControl.SelectedCell.Value = "Missspelled wods";

            // Specify margins to display a wavy line for misspelled words.
            XpfCellInplaceEditor inplaceEditor = LayoutHelper.FindElementByName(spreadsheetControl, "PART_CellEditor") as XpfCellInplaceEditor;
            if (inplaceEditor == null)
                return;
            inplaceEditor.Padding = new Thickness(-3, 0, -3, -7);
            inplaceEditor.Margin = new Thickness(0, 0, 0, 3);
        }
    }
}
