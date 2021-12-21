using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PDFToJPGExpert
{
    public partial class frmError : PDFToJPGExpert.CustomForm
    {
        public frmError(string lbl,string txt)
        {
            InitializeComponent();

            lblError.Text = lbl;
            txtError.Text = txt;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
