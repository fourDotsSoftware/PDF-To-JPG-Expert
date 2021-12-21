using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PDFToJPGExpert
{
    public partial class frmProgress : CustomForm
    {
        public static frmProgress Instance = null;
        
        public frmProgress()
        {
            InitializeComponent();
            Instance = this;

            if (!Module.IsCommandLine)
            {
                this.Owner = frmMain.Instance;
                this.Show();
            }
            else
            {
                this.Visible = false;
            }

            if (frmMain.Instance.chkOneImage.Checked)
            {
                progressBar1.Style = ProgressBarStyle.Marquee;
            }
            else
            {
                progressBar1.Style = ProgressBarStyle.Blocks;
            }
        }

        private delegate void UpdateDelegate();
        

        public void UpdateProgress()
        {
            if (this.InvokeRequired)
                this.Invoke((UpdateDelegate)UpdateProgress, null);
            else
            {
                if ((progressBar1.Value + 1) < progressBar1.Maximum)
                {
                    progressBar1.Value++;
                }
            }
        }

        private delegate void CloseDelegate();


        public void CloseForm()
        {
            if (this.InvokeRequired)
                this.Invoke((UpdateDelegate)CloseForm, null);
            else
            {
                this.Close();
            }
        }

        
        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //PDFToJPGHelper.LastConvert.DestroyInstance();
            //PdfToImage.PDFConvert.CANCEL = true;
            PDFToJPGHelper.LastConvert.CancelExecution();
            PDFToJPGHelper.CANCELLED = true;

        }

        private void frmProgress_Load(object sender, EventArgs e)
        {
            if (frmMain.fs.Path != string.Empty)
            {
                frmMain.fs.EnableRaisingEvents = true;
            }

            lblApp.Text = Module.ApplicationName;
            lblApp.Left = this.Width / 2 - lblApp.Width / 2;

        }

        private void frmProgress_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMain.fs.EnableRaisingEvents = false;
        }

        private void timPaint_Tick(object sender, EventArgs e)
        {
            Application.DoEvents();
        }

        public int TimValue = 0;

        private void timProgress_Tick(object sender, EventArgs e)
        {
            TimValue++;

            TimeSpan ts = new TimeSpan(0, 0, TimValue);

            lblTimer.Text = ts.Minutes.ToString("D2") + ":" + ts.Seconds.ToString("D2");
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.DrawRectangle(Pens.Gray, new Rectangle(2, 2, this.Width - 4, this.Height - 4));
        }

    }
}

