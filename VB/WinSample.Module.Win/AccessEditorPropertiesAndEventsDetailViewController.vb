Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Editors
Imports System.Windows.Forms

Namespace WinSample.Module.Win
	Public Class AccessEditorPropertiesAndEventsDetailViewController
		Inherits ViewController
		Public Sub New()
			TargetViewType = ViewType.DetailView
			TargetObjectType = GetType(DomainObject1)
		End Sub
		Protected Overrides Sub OnActivated()
			MyBase.OnActivated()
			For Each editor As PropertyEditor In (CType(View, DetailView)).GetItems(Of PropertyEditor)()
				RemoveHandler editor.ValueRead, AddressOf editor_ValueRead
				RemoveHandler editor.ValueStored, AddressOf editor_ValueStored
				RemoveHandler editor.ValueStoring, AddressOf editor_ValueStoring
			Next editor
			AddHandler View.ControlsCreated, AddressOf View_ControlsCreated
			AddHandler ObjectSpace.ObjectChanged, AddressOf ObjectSpace_ObjectChanged
		End Sub
		Protected Overrides Sub OnDeactivating()
			RemoveHandler View.ControlsCreated, AddressOf View_ControlsCreated
			MyBase.OnDeactivating()
		End Sub
		Private Sub View_ControlsCreated(ByVal sender As Object, ByVal e As EventArgs)
			For Each editor As PropertyEditor In (CType(View, DetailView)).GetItems(Of PropertyEditor)()
				AddHandler editor.ValueRead, AddressOf editor_ValueRead
				AddHandler editor.ValueStored, AddressOf editor_ValueStored
				AddHandler editor.ValueStoring, AddressOf editor_ValueStoring
				' You can access the corresponding property editor control by the following code:
				' Control editorControl = (editor.Control as Control);
			Next editor
		End Sub
		Private Sub editor_ValueRead(ByVal sender As Object, ByVal e As EventArgs)
			'1)	Before a user enters the field (with the current value set for the respective BO property)
			' Occurs when the control reads a value from the BO property.
		End Sub
		Private Sub editor_ValueStoring(ByVal sender As Object, ByVal e As EventArgs)
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
	End Class
End Namespace
