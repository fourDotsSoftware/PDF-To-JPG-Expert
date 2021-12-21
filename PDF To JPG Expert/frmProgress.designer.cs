namespace PDFToJPGExpert
{
    partial class frmProgress
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProgress));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.timPaint = new System.Windows.Forms.Timer(this.components);
            this.lblTimer = new System.Windows.Forms.Label();
            this.timProgress = new System.Windows.Forms.Timer(this.components);
            this.lblApp = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.Name = "progressBar1";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Name = "label1";
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // timPaint
            // 
            this.timPaint.Interval = 300;
            this.timPaint.Tick += new System.EventHandler(this.timPaint_Tick);
            // 
            // lblTimer
            // 
            resources.ApplyResources(this.lblTimer, "lblTimer");
            this.lblTimer.BackColor = System.Drawing.Color.Transparent;
            this.lblTimer.Name = "lblTimer";
            // 
            // timProgress
            // 
            this.timProgress.Interval = 1000;
            this.timProgress.Tick += new System.EventHandler(this.timProgress_Tick);
            // 
            // lblApp
            // 
            resources.ApplyResources(this.lblApp, "lblApp");
            this.lblApp.BackColor = System.Drawing.Color.Transparent;
            this.lblApp.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblApp.Name = "lblApp";
            // 
            // frmProgress
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.lblApp);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmProgress";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmProgress_FormClosed);
            this.Load += new System.EventHandler(this.frmProgress_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Timer timPaint;
        private System.Windows.Forms.Label lblTimer;
        public System.Windows.Forms.Timer timProgress;
        private System.Windows.Forms.Label lblApp;
    }
}
