using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace InvoiceInput.Module.BusinessObjects.Database
{

    public partial class 第三方账单
    {
        public 第三方账单(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
