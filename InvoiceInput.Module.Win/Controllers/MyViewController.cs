using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.ExpressApp;
using DevExpress.Xpo;
using DevExpress.XtraEditors;
using InvoiceInput.Module.BusinessObjects.Database;

namespace InvoiceInput.Module.Win.Controllers
{
    public class MyViewController : ViewController<DetailView>
    {
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            var session = ((XPBaseObject)View.CurrentObject).Session;
            var itemCaseNo = View.Model.Items.FirstOrDefault(i => i.Caption == "卷号");
            if (itemCaseNo != null)
            {
                var control = View.FindItem(itemCaseNo.Id).Control;
                if (control is MRUEdit)
                    ((MRUEdit)control).Properties.Items.AddRange(GetListCaseNo(session));
            }
            var itemAgency = View.Model.Items.FirstOrDefault(i => i.Caption == "债方");
            if (itemAgency != null)
            {
                var control = View.FindItem(itemAgency.Id).Control;
                if (control is MRUEdit)
                    ((MRUEdit)control).Properties.Items.AddRange(GetListAgency(session));
            }
            var itemListInvoiceNo = View.Model.Items.FirstOrDefault(i => i.Caption == "账单号");
            if (itemListInvoiceNo != null)
            {
                var control = View.FindItem(itemListInvoiceNo.Id).Control;
                if (control is MRUEdit)
                    ((MRUEdit)control).Properties.Items.AddRange(GetListInvoiceNo(session));
            }

            var itemInvoiceDate = View.Model.Items.FirstOrDefault(i => i.Caption == "指定请款日");
            if (itemInvoiceDate != null)
            {
                var control = View.FindItem(itemInvoiceDate.Id).Control;
                if (control is DateEdit)
                    ((DateEdit)control).GotFocus += MyViewController_EditValueChanged;
            }
        }

        private void MyViewController_EditValueChanged(object sender, System.EventArgs e)
        {
            var itemRegDate = View.Model.Items.FirstOrDefault(i => i.Caption == "记账日期");
            if (itemRegDate == null) return;
            var control = View.FindItem(itemRegDate.Id).Control;
            if (!(control is DateEdit)) return;
            if (((DateEdit)sender).DateTime != DateTime.MinValue) return;
            ((DateEdit)sender).DateTime = ((DateEdit)control).DateTime.AddDays(60);
        }

        private List<string> GetListCaseNo(Session session)
        {
            var listCaseNo = new List<string>();
            listCaseNo = session.Query<P_2012>().Select(p => p.卷号).ToList();
            listCaseNo.AddRange(session.Query<P_2013>().Select(p => p.卷号).ToList());
            listCaseNo.AddRange(session.Query<P_2014>().Select(p => p.卷号).ToList());
            listCaseNo.AddRange(session.Query<P_2015>().Select(p => p.卷号).ToList());
            listCaseNo.AddRange(session.Query<P_2016>().Select(p => p.卷号).ToList());
            listCaseNo.AddRange(session.Query<P_2017>().Select(p => p.卷号).ToList());
            return listCaseNo.Where(a => !string.IsNullOrWhiteSpace(a)).Distinct().ToList();
        }

        private List<string> GetListAgency(Session session)
        {
            var listAgency = new List<string>();
            listAgency = session.Query<P_2012>().Select(p => p.债方).ToList();
            listAgency.AddRange(session.Query<P_2013>().Select(p => p.债方).ToList());
            listAgency.AddRange(session.Query<P_2014>().Select(p => p.债方).ToList());
            listAgency.AddRange(session.Query<P_2015>().Select(p => p.债方).ToList());
            listAgency.AddRange(session.Query<P_2016>().Select(p => p.债方).ToList());
            listAgency.AddRange(session.Query<P_2017>().Select(p => p.债方).ToList());
            return listAgency.Where(a => !string.IsNullOrWhiteSpace(a)).Distinct().ToList();
        }

        private List<string> GetListInvoiceNo(Session session)
        {
            var listInvoiceNo = new List<string>();
            listInvoiceNo = session.Query<P_2012>().Select(p => p.账单号).ToList();
            listInvoiceNo.AddRange(session.Query<P_2013>().Select(p => p.账单号).ToList());
            listInvoiceNo.AddRange(session.Query<P_2014>().Select(p => p.账单号).ToList());
            listInvoiceNo.AddRange(session.Query<P_2015>().Select(p => p.账单号).ToList());
            listInvoiceNo.AddRange(session.Query<P_2016>().Select(p => p.账单号).ToList());
            listInvoiceNo.AddRange(session.Query<P_2017>().Select(p => p.账单号).ToList());
            return listInvoiceNo.Where(a => !string.IsNullOrWhiteSpace(a)).Distinct().ToList();
        }
    }
}