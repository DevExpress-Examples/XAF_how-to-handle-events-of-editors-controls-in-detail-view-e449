using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Editors;
using System.Windows.Forms;

namespace WinSample.Module.Win {
    public class AccessEditorPropertiesAndEventsDetailViewController : ViewController {
        public AccessEditorPropertiesAndEventsDetailViewController() {
            TargetViewType = ViewType.DetailView;
            TargetObjectType = typeof(DomainObject1);
        }
        protected override void OnActivated() {
            base.OnActivated();
            foreach (PropertyEditor editor in ((DetailView)View).GetItems<PropertyEditor>()) {
                editor.ValueRead -= new EventHandler(editor_ValueRead);
                editor.ValueStored -= new EventHandler(editor_ValueStored);
                editor.ValueStoring -= new EventHandler(editor_ValueStoring);
            }
            View.ControlsCreated += new EventHandler(View_ControlsCreated);
            ObjectSpace.ObjectChanged += new EventHandler<ObjectChangedEventArgs>(ObjectSpace_ObjectChanged);
        }
        protected override void OnDeactivating() {
            View.ControlsCreated -= new EventHandler(View_ControlsCreated);
            base.OnDeactivating();
        }
        void View_ControlsCreated(object sender, EventArgs e) {
            foreach (PropertyEditor editor in ((DetailView)View).GetItems<PropertyEditor>()) {
                editor.ValueRead += new EventHandler(editor_ValueRead);
                editor.ValueStored += new EventHandler(editor_ValueStored);
                editor.ValueStoring += new EventHandler(editor_ValueStoring);
                // You can access the corresponding property editor control by the following code:
                // Control editorControl = (editor.Control as Control);
            }
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
    }
}
