Imports System
Imports System.Windows.Forms
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Security

Namespace WinSample.Win

    Friend Module Program

        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        <STAThread>
        Sub Main()
            Call Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            EditModelPermission.AlwaysGranted = System.Diagnostics.Debugger.IsAttached
            Dim _application As WinSampleWindowsFormsApplication = New WinSampleWindowsFormsApplication()
            _application.ConnectionString = Demo.CodeCentralExampleInMemoryDataStoreProvider.ConnectionString
            Try
                Xpo.InMemoryDataStoreProvider.Register()
                _application.ConnectionString = Xpo.InMemoryDataStoreProvider.ConnectionString
                _application.Setup()
                _application.Start()
            Catch e As Exception
                _application.HandleException(e)
            End Try
        End Sub
    End Module
End Namespace
