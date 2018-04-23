using System;
using DevExpress.ExpressApp.Win;

namespace WinSample.Win {
    public partial class WinSampleWindowsFormsApplication : WinApplication {
        public WinSampleWindowsFormsApplication() {
            InitializeComponent();
        }
        private void WinSampleWindowsFormsApplication_DatabaseVersionMismatch(object sender, DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs e) {
            e.Updater.Update();
            e.Handled = true;
        }
    }
}
