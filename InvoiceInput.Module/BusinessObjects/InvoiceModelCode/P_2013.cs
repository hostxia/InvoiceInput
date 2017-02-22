using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.Persistent.Base;

namespace InvoiceInput.Module.BusinessObjects.Database
{
    [DefaultClassOptions]
    public partial class P_2013
    {
        public P_2013(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
