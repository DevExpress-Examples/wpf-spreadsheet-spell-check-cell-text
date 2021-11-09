Imports DevExpress.Xpf.Core
Imports DevExpress.Xpf.SpellChecker
Imports DevExpress.Xpf.Spreadsheet
Imports DevExpress.Xpf.Spreadsheet.Internal
Imports DevExpress.XtraSpellChecker

Namespace SpreadsheetSpellchecking_WPF

    Public Class SpreadsheetSpellChecker
        Inherits DXSpellCheckerBase(Of SpreadsheetControl)

        Private ReadOnly Property Spreadsheet As SpreadsheetControl
            Get
                Return AssociatedObject
            End Get
        End Property

        Protected Overrides Sub OnAttached()
            MyBase.OnAttached()
            SpellingSettings.RegisterTextControl(GetType(XpfCellInplaceEditor))
            SubscribeToEvents()
        End Sub

        Protected Overrides Sub OnDetaching()
            UnsubscribeFromEvents()
            SpellingSettings.UnregisterTextControl(GetType(XpfCellInplaceEditor))
            MyBase.OnDetaching()
        End Sub

        Private Sub SubscribeToEvents()
            Me.Spreadsheet.CellEditorOpened += AddressOf OnSpreadsheet_CellEditorOpened
            SpellChecker.CheckCompleteFormShowing += AddressOf OnChecker_CheckCompleteFormShowing
        End Sub

        Private Sub UnsubscribeFromEvents()
            Me.Spreadsheet.CellEditorOpened -= AddressOf OnSpreadsheet_CellEditorOpened
            SpellChecker.CheckCompleteFormShowing -= AddressOf OnChecker_CheckCompleteFormShowing
        End Sub

        Private Sub OnSpreadsheet_CellEditorOpened(ByVal sender As Object, ByVal e As CellEditorOpenedEventArgs)
            If Not e.IsCustom Then
                e.Editor.SetValue(ThemeManager.ThemeNameProperty, ApplicationThemeHelper.ApplicationThemeName)
                SpellChecker.Check(e.Editor)
            End If
        End Sub

        Private Sub OnChecker_CheckCompleteFormShowing(ByVal sender As Object, ByVal e As FormShowingEventArgs)
            e.Handled = True
        End Sub
    End Class
End Namespace
