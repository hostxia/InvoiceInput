using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Win.Editors;
using DevExpress.XtraEditors;

namespace InvoiceInput.Module.Win.Editors
{
    [PropertyEditor(typeof(string), false)]
    public class MRUStringEditor : StringPropertyEditor
    {
        private IModelMemberViewItem _model;
        public MRUStringEditor(Type objectType, IModelMemberViewItem model) : base(objectType, model)
        {
            _model = model;
        }

        protected override object CreateControlCore()
        {

            if (_model.Caption == "卷号" || _model.Caption == "债方" || _model.Caption == "账单号")
                return new MRUEdit();
            return base.CreateControlCore();
        }
    }
}
