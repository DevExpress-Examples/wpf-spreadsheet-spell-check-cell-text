using DevExpress.Xpf.Core;
using DevExpress.Xpf.SpellChecker;
using DevExpress.Xpf.Spreadsheet;
using DevExpress.Xpf.Spreadsheet.Internal;
using DevExpress.XtraSpellChecker;

namespace SpreadsheetSpellchecking_WPF {
    public class SpreadsheetSpellChecker : DXSpellCheckerBase<SpreadsheetControl> {
        SpreadsheetControl Spreadsheet { get { return AssociatedObject; } }
        protected override void OnAttached() {
            base.OnAttached();
            SpellingSettings.RegisterTextControl(typeof(XpfCellInplaceEditor));
            SubscribeToEvents();
        }
        protected override void OnDetaching() {
            UnsubscribeFromEvents();
            SpellingSettings.UnregisterTextControl(typeof(XpfCellInplaceEditor));
            base.OnDetaching();
        }

        void SubscribeToEvents() {
            Spreadsheet.CellEditorOpened += OnSpreadsheet_CellEditorOpened;
            SpellChecker.CheckCompleteFormShowing += OnChecker_CheckCompleteFormShowing;   
        }
        void UnsubscribeFromEvents() {
            Spreadsheet.CellEditorOpened -= OnSpreadsheet_CellEditorOpened;
            SpellChecker.CheckCompleteFormShowing -= OnChecker_CheckCompleteFormShowing;
        }

        void OnSpreadsheet_CellEditorOpened(object sender, CellEditorOpenedEventArgs e) {
            if (!e.IsCustom)
            {
                e.Editor.SetValue(ThemeManager.ThemeNameProperty, ApplicationThemeHelper.ApplicationThemeName);
                SpellChecker.Check(e.Editor);
            }
        }

        void OnChecker_CheckCompleteFormShowing(object sender, FormShowingEventArgs e)
        {
           e.Handled = true;
        }
    }
}
