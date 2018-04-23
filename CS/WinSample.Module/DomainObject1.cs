using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace WinSample.Module {
    [DefaultClassOptions]
    public class DomainObject1 : BaseObject {
        public DomainObject1(Session session) : base(session) { }
        private string _dependentProperty;
        public string DependentProperty {
            get { return _dependentProperty; }
            set { SetPropertyValue("DependentProperty", ref _dependentProperty, value); }
        }
        private bool _independentProperty;
        [ImmediatePostData]
        public bool IndependentProperty {
            get { return _independentProperty; }
            set { SetPropertyValue("IndependentProperty", ref _independentProperty, value); }
        }
    }
}
