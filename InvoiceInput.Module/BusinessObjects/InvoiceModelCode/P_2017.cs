using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.Persistent.Base;

namespace InvoiceInput.Module.BusinessObjects.Database
{
    [DefaultClassOptions]
    public partial class P_2017
    {
        public P_2017(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
