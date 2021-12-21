using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PDFToJPGExpert
{
    public partial class frmEditPDF : PDFToJPGExpert.CustomForm
    {
        public frmEditPDF(string file,string password,string pagerange,string totalpages)
        {
            InitializeComponent();

            txtFile.Text = file;
            txtPassword.Text = password;
            cmbPageRange.Text = pagerange;
            txtTotalPages.Text = totalpages;
        }

        private void frmEditPDF_Load(object sender, EventArgs e)
        {
            cmbPageRange.Items.Add(TranslateHelper.Translate("All Pages"));
            cmbPageRange.Items.Add(TranslateHelper.Translate("<Page Range>"));
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
