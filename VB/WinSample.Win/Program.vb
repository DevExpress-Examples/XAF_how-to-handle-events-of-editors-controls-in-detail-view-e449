Imports Microsoft.VisualBasic
Imports System
Imports System.Configuration
Imports System.Windows.Forms

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Security
Imports DevExpress.ExpressApp.Win
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl

Namespace WinSample.Win
	Friend NotInheritable Class Program
		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		Private Sub New()
		End Sub
		<STAThread> _
		Shared Sub Main()
			Application.EnableVisualStyles()
			Application.SetCompatibleTextRenderingDefault(False)
			EditModelPermission.AlwaysGranted = System.Diagnostics.Debugger.IsAttached
			Dim _application As New WinSampleWindowsFormsApplication()
			_application.ConnectionString = Demo.CodeCentralExampleInMemoryDataStoreProvider.ConnectionString
			Try
    DevExpress.ExpressApp.InMemoryDataStoreProvider.Register()
    				_application.ConnectionString = DevExpress.ExpressApp.InMemoryDataStoreProvider.ConnectionString
				_application.Setup()
				_application.Start()
			Catch e As Exception
				_application.HandleException(e)
			End Try
		End Sub
	End Class
End Namespace
