Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Editors

Namespace WinSample.Module.Win
	Public Class AccessEditorSettingsDetailViewController
		Inherits ViewController(Of DetailView)
		Public Sub New()
			TargetViewType = ViewType.DetailView
			TargetObjectType = GetType(DemoObject)
		End Sub
		Protected Overrides Overloads Sub OnActivated()
			MyBase.OnActivated()
			For Each editor As PropertyEditor In (CType(View, DetailView)).GetItems(Of PropertyEditor)()
				AddHandler editor.ValueRead, AddressOf editor_ValueRead
				AddHandler editor.ValueStored, AddressOf editor_ValueStored
				AddHandler editor.ValueStoring, AddressOf editor_ValueStoring
				AddHandler editor.ControlCreated, AddressOf editor_ControlCreated
			Next editor
			AddHandler View.ObjectSpace.ObjectChanged, AddressOf ObjectSpace_ObjectChanged
			AddHandler View.ControlsCreated, AddressOf View_ControlsCreated
		End Sub
		Protected Overrides Overloads Sub OnDeactivated()
			For Each editor As PropertyEditor In (CType(View, DetailView)).GetItems(Of PropertyEditor)()
				RemoveHandler editor.ValueRead, AddressOf editor_ValueRead
				RemoveHandler editor.ValueStored, AddressOf editor_ValueStored
				RemoveHandler editor.ValueStoring, AddressOf editor_ValueStoring
				RemoveHandler editor.ControlCreated, AddressOf editor_ControlCreated
			Next editor
			RemoveHandler View.ObjectSpace.ObjectChanged, AddressOf ObjectSpace_ObjectChanged
			RemoveHandler View.ControlsCreated, AddressOf View_ControlsCreated
			MyBase.OnDeactivated()
		End Sub
		Private Sub View_ControlsCreated(ByVal sender As Object, ByVal e As EventArgs)
			' You can access View control here.
		End Sub
		Private Sub editor_ValueRead(ByVal sender As Object, ByVal e As EventArgs)
			'1)	Before a user enters the field (with the current value set for the respective BO property)
			' Occurs when the control reads a value from the BO property.
		End Sub
		Private Sub editor_ValueStoring(ByVal sender As Object, ByVal e As ValueStoringEventArgs)
			' Occurs before the control writes a value from the control to the BO propetry
		End Sub
		Private Sub editor_ValueStored(ByVal sender As Object, ByVal e As EventArgs)
			'2)	After a user exits the field (with previous and current BO values)
			' Occurs after the the control writes a value from the control to the BO property
		End Sub
		Private Sub ObjectSpace_ObjectChanged(ByVal sender As Object, ByVal e As ObjectChangedEventArgs)
			'3)When the field's value is changed (with previous and current BO values)
			' Occurs in the setter of BO properties
			' See the ObjectChangedEventArgs arguments
		End Sub
		Private Sub editor_ControlCreated(ByVal sender As Object, ByVal e As EventArgs)
			' You can access the corresponding property editor control by the following code:
			Dim editorControl As Control = TryCast((CType(sender, PropertyEditor)).Control, Control)
			AddHandler editorControl.HandleCreated, AddressOf editorControl_HandleCreated
		End Sub
		Private Sub editorControl_HandleCreated(ByVal sender As Object, ByVal e As EventArgs)
			' Sometimes it is necessary to access editor's control after it is visible (its handle is created).
			RemoveHandler (CType(sender, Control)).HandleCreated, AddressOf editorControl_HandleCreated
		End Sub
	End Class
End Namespace
