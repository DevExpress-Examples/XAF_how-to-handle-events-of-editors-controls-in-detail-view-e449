using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Xpo;
using System;
using DevExpress.ExpressApp.Win;

namespace WinSample.Win {
    public partial class WinSampleWindowsFormsApplication : WinApplication {
        protected override void CreateDefaultObjectSpaceProvider(CreateCustomObjectSpaceProviderEventArgs args) {
            args.ObjectSpaceProvider = new XPObjectSpaceProvider(args.ConnectionString, args.Connection);
        }
        public WinSampleWindowsFormsApplication() {
            InitializeComponent();
        }
        private void WinSampleWindowsFormsApplication_DatabaseVersionMismatch(object sender, DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs e) {
            e.Updater.Update();
            e.Handled = true;
        }
    }
}
