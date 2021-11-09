Imports System.Windows
Imports DevExpress.Xpf.Core.Native
Imports DevExpress.Xpf.Spreadsheet.Internal

Namespace SpreadsheetSpellchecking_WPF

    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Public Partial Class MainWindow
        Inherits DevExpress.Xpf.Core.ThemedWindow

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub OnSpreadsheetControl_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim activeSheet = spreadsheetControl.ActiveWorksheet
            activeSheet.Columns(1).WidthInPixels = 150
            spreadsheetControl.SelectedCell = activeSheet("B2")
            spreadsheetControl.SelectedCell.Value = "Missspelled wods"
            ' Specify margins to display a wavy line for misspelled words.
            Dim inplaceEditor As XpfCellInplaceEditor = TryCast(LayoutHelper.FindElementByName(spreadsheetControl, "PART_CellEditor"), XpfCellInplaceEditor)
            If inplaceEditor Is Nothing Then Return
            inplaceEditor.Padding = New Thickness(-3, 0, -3, -7)
            inplaceEditor.Margin = New Thickness(0, 0, 0, 3)
        End Sub
    End Class
End Namespace
