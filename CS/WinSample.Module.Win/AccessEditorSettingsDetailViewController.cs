using System;
using System.Windows.Forms;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Editors;

namespace WinSample.Module.Win {
    public class AccessEditorSettingsDetailViewController : ViewController<DetailView> {
        public AccessEditorSettingsDetailViewController() {
            TargetViewType = ViewType.DetailView;
            TargetObjectType = typeof(DemoObject);
        }
        protected override void OnActivated() {
            base.OnActivated();
            foreach (PropertyEditor editor in ((DetailView)View).GetItems<PropertyEditor>()) {
                editor.ValueRead += new EventHandler(editor_ValueRead);
                editor.ValueStored += new EventHandler(editor_ValueStored);
                editor.ValueStoring += new EventHandler<ValueStoringEventArgs>(editor_ValueStoring);
                editor.ControlCreated += new EventHandler<EventArgs>(editor_ControlCreated);
            }
            View.ObjectSpace.ObjectChanged += new EventHandler<ObjectChangedEventArgs>(ObjectSpace_ObjectChanged);
            View.ControlsCreated += new EventHandler(View_ControlsCreated);
        }
        protected override void OnDeactivated() {
            foreach (PropertyEditor editor in ((DetailView)View).GetItems<PropertyEditor>()) {
                editor.ValueRead -= new EventHandler(editor_ValueRead);
                editor.ValueStored -= new EventHandler(editor_ValueStored);
                editor.ValueStoring -= new EventHandler<ValueStoringEventArgs>(editor_ValueStoring);
                editor.ControlCreated -= new EventHandler<EventArgs>(editor_ControlCreated);
            }
            View.ObjectSpace.ObjectChanged -= new EventHandler<ObjectChangedEventArgs>(ObjectSpace_ObjectChanged);
            View.ControlsCreated -= new EventHandler(View_ControlsCreated);
            base.OnDeactivated();
        }
        void View_ControlsCreated(object sender, EventArgs e) {
            // You can access View control here.
        }
        void editor_ValueRead(object sender, EventArgs e) {
            //1)	Before a user enters the field (with the current value set for the respective BO property)
            // Occurs when the control reads a value from the BO property.
        }
        void editor_ValueStoring(object sender, EventArgs e) {
            // Occurs before the control writes a value from the control to the BO propetry
        }
        void editor_ValueStored(object sender, EventArgs e) {
            //2)	After a user exits the field (with previous and current BO values)
            // Occurs after the the control writes a value from the control to the BO property
        }
        void ObjectSpace_ObjectChanged(object sender, ObjectChangedEventArgs e) {
            //3)When the field's value is changed (with previous and current BO values)
            // Occurs in the setter of BO properties
            // See the ObjectChangedEventArgs arguments
        }
        void editor_ControlCreated(object sender, EventArgs e) {
            // You can access the corresponding property editor control by the following code:
            Control editorControl = ((PropertyEditor)sender).Control as Control;
            editorControl.HandleCreated += editorControl_HandleCreated;
        }
        void editorControl_HandleCreated(object sender, EventArgs e) {
            // Sometimes it is necessary to access editor's control after it is visible (its handle is created).
            ((Control)sender).HandleCreated -= editorControl_HandleCreated;
        }
    }
}
