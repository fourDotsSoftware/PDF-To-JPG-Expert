namespace PDFToJPGExpert
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.bwProgress = new System.ComponentModel.BackgroundWorker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnOutputFormatMore = new System.Windows.Forms.Button();
            this.btnOutputFolderOpen = new System.Windows.Forms.Button();
            this.btnOutputFolderSelect = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exploreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chkOneImage = new System.Windows.Forms.CheckBox();
            this.cmbOutputDir = new System.Windows.Forms.ComboBox();
            this.nudDPI = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.rdHeight = new System.Windows.Forms.RadioButton();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.rdWidth = new System.Windows.Forms.RadioButton();
            this.chkFitPage = new System.Windows.Forms.CheckBox();
            this.rdDimensionsAsIs = new System.Windows.Forms.RadioButton();
            this.lblDimensions = new System.Windows.Forms.Label();
            this.txtDimensionsH = new System.Windows.Forms.TextBox();
            this.txtDimensionsW = new System.Windows.Forms.TextBox();
            this.rdDimensionsOther = new System.Windows.Forms.RadioButton();
            this.rd12801024 = new System.Windows.Forms.RadioButton();
            this.rd1024768 = new System.Windows.Forms.RadioButton();
            this.rd800600 = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudQuality = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbOutputFormat = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgFiles = new System.Windows.Forms.DataGridView();
            this.colFilename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalPages = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPageRange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFileDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFullFilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsdbAddFile = new System.Windows.Forms.ToolStripSplitButton();
            this.tsbRemove = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsdbAddFolder = new System.Windows.Forms.ToolStripSplitButton();
            this.tsdbImportList = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbShare = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsiFacebook = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiTwitter = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiGooglePlus = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiLinkedIn = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbConvert = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.importListFromTextFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importListFromExcelFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enterFileListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectNoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keepFolderStructureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exploreOutputFolderWhenDoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keepCreationDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keepLastModificationDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showMessageOnSucessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiDownload = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpGuideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tryOnlineVersionAtOnlinepdfappscomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandLineArgumentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pleaseDonateToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setUpdateProxyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForNewVersionEachWeekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiHelpFeedback = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.followUsOnTwitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visit4dotsSoftwareWebsiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.youtubeChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDPI)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgFiles)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // bwProgress
            // 
            this.bwProgress.WorkerReportsProgress = true;
            this.bwProgress.WorkerSupportsCancellation = true;
            this.bwProgress.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwProgress_DoWork);
            this.bwProgress.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwProgress_ProgressChanged);
            // 
            // btnOutputFormatMore
            // 
            resources.ApplyResources(this.btnOutputFormatMore, "btnOutputFormatMore");
            this.btnOutputFormatMore.Name = "btnOutputFormatMore";
            this.toolTip1.SetToolTip(this.btnOutputFormatMore, resources.GetString("btnOutputFormatMore.ToolTip"));
            this.btnOutputFormatMore.UseVisualStyleBackColor = true;
            this.btnOutputFormatMore.Click += new System.EventHandler(this.btnOutputFormatMore_Click);
            // 
            // btnOutputFolderOpen
            // 
            resources.ApplyResources(this.btnOutputFolderOpen, "btnOutputFolderOpen");
            this.btnOutputFolderOpen.Image = global::PDFToJPGExpert.Properties.Resources.folder;
            this.btnOutputFolderOpen.Name = "btnOutputFolderOpen";
            this.toolTip1.SetToolTip(this.btnOutputFolderOpen, resources.GetString("btnOutputFolderOpen.ToolTip"));
            this.btnOutputFolderOpen.UseVisualStyleBackColor = true;
            this.btnOutputFolderOpen.Click += new System.EventHandler(this.btnOutputFolderOpen_Click);
            // 
            // btnOutputFolderSelect
            // 
            resources.ApplyResources(this.btnOutputFolderSelect, "btnOutputFolderSelect");
            this.btnOutputFolderSelect.Name = "btnOutputFolderSelect";
            this.toolTip1.SetToolTip(this.btnOutputFolderSelect, resources.GetString("btnOutputFolderSelect.ToolTip"));
            this.btnOutputFolderSelect.UseVisualStyleBackColor = true;
            this.btnOutputFolderSelect.Click += new System.EventHandler(this.btnOutputFolderSelect_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.openToolStripMenuItem,
            this.exploreToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::PDFToJPGExpert.Properties.Resources.edit;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            resources.ApplyResources(this.editToolStripMenuItem, "editToolStripMenuItem");
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::PDFToJPGExpert.Properties.Resources.folder;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exploreToolStripMenuItem
            // 
            this.exploreToolStripMenuItem.Name = "exploreToolStripMenuItem";
            resources.ApplyResources(this.exploreToolStripMenuItem, "exploreToolStripMenuItem");
            this.exploreToolStripMenuItem.Click += new System.EventHandler(this.exploreToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Image = global::PDFToJPGExpert.Properties.Resources.delete;
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            resources.ApplyResources(this.removeToolStripMenuItem, "removeToolStripMenuItem");
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.tsbRemove_Click);
            // 
            // chkOneImage
            // 
            resources.ApplyResources(this.chkOneImage, "chkOneImage");
            this.chkOneImage.BackColor = System.Drawing.Color.Transparent;
            this.chkOneImage.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkOneImage.Name = "chkOneImage";
            this.chkOneImage.UseVisualStyleBackColor = false;
            // 
            // cmbOutputDir
            // 
            resources.ApplyResources(this.cmbOutputDir, "cmbOutputDir");
            this.cmbOutputDir.FormattingEnabled = true;
            this.cmbOutputDir.Name = "cmbOutputDir";
            this.cmbOutputDir.SelectedIndexChanged += new System.EventHandler(this.cmbOutputDir_SelectedIndexChanged);
            // 
            // nudDPI
            // 
            resources.ApplyResources(this.nudDPI, "nudDPI");
            this.nudDPI.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudDPI.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudDPI.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDPI.Name = "nudDPI";
            this.nudDPI.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.DarkBlue;
            this.label7.Name = "label7";
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtHeight);
            this.groupBox1.Controls.Add(this.rdHeight);
            this.groupBox1.Controls.Add(this.txtWidth);
            this.groupBox1.Controls.Add(this.rdWidth);
            this.groupBox1.Controls.Add(this.chkFitPage);
            this.groupBox1.Controls.Add(this.rdDimensionsAsIs);
            this.groupBox1.Controls.Add(this.lblDimensions);
            this.groupBox1.Controls.Add(this.txtDimensionsH);
            this.groupBox1.Controls.Add(this.txtDimensionsW);
            this.groupBox1.Controls.Add(this.rdDimensionsOther);
            this.groupBox1.Controls.Add(this.rd12801024);
            this.groupBox1.Controls.Add(this.rd1024768);
            this.groupBox1.Controls.Add(this.rd800600);
            this.groupBox1.ForeColor = System.Drawing.Color.DarkBlue;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txtHeight
            // 
            resources.ApplyResources(this.txtHeight, "txtHeight");
            this.txtHeight.Name = "txtHeight";
            // 
            // rdHeight
            // 
            resources.ApplyResources(this.rdHeight, "rdHeight");
            this.rdHeight.Name = "rdHeight";
            this.rdHeight.UseVisualStyleBackColor = true;
            // 
            // txtWidth
            // 
            resources.ApplyResources(this.txtWidth, "txtWidth");
            this.txtWidth.Name = "txtWidth";
            // 
            // rdWidth
            // 
            resources.ApplyResources(this.rdWidth, "rdWidth");
            this.rdWidth.Name = "rdWidth";
            this.rdWidth.UseVisualStyleBackColor = true;
            // 
            // chkFitPage
            // 
            resources.ApplyResources(this.chkFitPage, "chkFitPage");
            this.chkFitPage.BackColor = System.Drawing.Color.Transparent;
            this.chkFitPage.Name = "chkFitPage";
            this.chkFitPage.UseVisualStyleBackColor = false;
            // 
            // rdDimensionsAsIs
            // 
            resources.ApplyResources(this.rdDimensionsAsIs, "rdDimensionsAsIs");
            this.rdDimensionsAsIs.Checked = true;
            this.rdDimensionsAsIs.Name = "rdDimensionsAsIs";
            this.rdDimensionsAsIs.TabStop = true;
            this.rdDimensionsAsIs.UseVisualStyleBackColor = true;
            // 
            // lblDimensions
            // 
            resources.ApplyResources(this.lblDimensions, "lblDimensions");
            this.lblDimensions.BackColor = System.Drawing.Color.Transparent;
            this.lblDimensions.Name = "lblDimensions";
            // 
            // txtDimensionsH
            // 
            resources.ApplyResources(this.txtDimensionsH, "txtDimensionsH");
            this.txtDimensionsH.Name = "txtDimensionsH";
            // 
            // txtDimensionsW
            // 
            resources.ApplyResources(this.txtDimensionsW, "txtDimensionsW");
            this.txtDimensionsW.Name = "txtDimensionsW";
            // 
            // rdDimensionsOther
            // 
            resources.ApplyResources(this.rdDimensionsOther, "rdDimensionsOther");
            this.rdDimensionsOther.Name = "rdDimensionsOther";
            this.rdDimensionsOther.UseVisualStyleBackColor = true;
            this.rdDimensionsOther.CheckedChanged += new System.EventHandler(this.rdDimensionsOther_CheckedChanged);
            // 
            // rd12801024
            // 
            resources.ApplyResources(this.rd12801024, "rd12801024");
            this.rd12801024.Name = "rd12801024";
            this.rd12801024.UseVisualStyleBackColor = true;
            this.rd12801024.CheckedChanged += new System.EventHandler(this.rd12801024_CheckedChanged);
            // 
            // rd1024768
            // 
            resources.ApplyResources(this.rd1024768, "rd1024768");
            this.rd1024768.Name = "rd1024768";
            this.rd1024768.UseVisualStyleBackColor = true;
            this.rd1024768.CheckedChanged += new System.EventHandler(this.rd1024768_CheckedChanged);
            // 
            // rd800600
            // 
            resources.ApplyResources(this.rd800600, "rd800600");
            this.rd800600.Name = "rd800600";
            this.rd800600.UseVisualStyleBackColor = true;
            this.rd800600.CheckedChanged += new System.EventHandler(this.rd800600_CheckedChanged);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Name = "label3";
            // 
            // nudQuality
            // 
            resources.ApplyResources(this.nudQuality, "nudQuality");
            this.nudQuality.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuality.Name = "nudQuality";
            this.nudQuality.Value = new decimal(new int[] {
            75,
            0,
            0,
            0});
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Name = "label2";
            // 
            // cmbOutputFormat
            // 
            resources.ApplyResources(this.cmbOutputFormat, "cmbOutputFormat");
            this.cmbOutputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOutputFormat.FormattingEnabled = true;
            this.cmbOutputFormat.Name = "cmbOutputFormat";
            this.cmbOutputFormat.SelectedIndexChanged += new System.EventHandler(this.cmbOutputFormat_SelectedIndexChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Name = "label1";
            // 
            // dgFiles
            // 
            this.dgFiles.AllowDrop = true;
            this.dgFiles.AllowUserToAddRows = false;
            this.dgFiles.AllowUserToDeleteRows = false;
            this.dgFiles.AllowUserToResizeRows = false;
            resources.ApplyResources(this.dgFiles, "dgFiles");
            this.dgFiles.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(240)))), ((int)(((byte)(227)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgFiles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFilename,
            this.colPassword,
            this.colTotalPages,
            this.colPageRange,
            this.colSize,
            this.colFileDate,
            this.colFullFilePath});
            this.dgFiles.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(231)))), ((int)(((byte)(228)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgFiles.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgFiles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgFiles.GridColor = System.Drawing.Color.Black;
            this.dgFiles.Name = "dgFiles";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgFiles.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgFiles.RowHeadersVisible = false;
            this.dgFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgFiles.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgFiles_CellContentDoubleClick);
            this.dgFiles.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgFiles_CellDoubleClick);
            this.dgFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgFiles_DragDrop);
            this.dgFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgFiles_DragEnter);
            this.dgFiles.DragOver += new System.Windows.Forms.DragEventHandler(this.dgFiles_DragOver);
            // 
            // colFilename
            // 
            this.colFilename.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colFilename.DataPropertyName = "filename";
            resources.ApplyResources(this.colFilename, "colFilename");
            this.colFilename.Name = "colFilename";
            this.colFilename.ReadOnly = true;
            // 
            // colPassword
            // 
            this.colPassword.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colPassword.DataPropertyName = "password";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            this.colPassword.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.colPassword, "colPassword");
            this.colPassword.Name = "colPassword";
            this.colPassword.ReadOnly = true;
            // 
            // colTotalPages
            // 
            this.colTotalPages.DataPropertyName = "totalpages";
            resources.ApplyResources(this.colTotalPages, "colTotalPages");
            this.colTotalPages.Name = "colTotalPages";
            this.colTotalPages.ReadOnly = true;
            // 
            // colPageRange
            // 
            this.colPageRange.DataPropertyName = "pagerange";
            resources.ApplyResources(this.colPageRange, "colPageRange");
            this.colPageRange.Name = "colPageRange";
            this.colPageRange.ReadOnly = true;
            // 
            // colSize
            // 
            this.colSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colSize.DataPropertyName = "sizekb";
            resources.ApplyResources(this.colSize, "colSize");
            this.colSize.Name = "colSize";
            this.colSize.ReadOnly = true;
            // 
            // colFileDate
            // 
            this.colFileDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colFileDate.DataPropertyName = "filedate";
            resources.ApplyResources(this.colFileDate, "colFileDate");
            this.colFileDate.Name = "colFileDate";
            this.colFileDate.ReadOnly = true;
            // 
            // colFullFilePath
            // 
            this.colFullFilePath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colFullFilePath.DataPropertyName = "fullfilepath";
            resources.ApplyResources(this.colFullFilePath, "colFullFilePath");
            this.colFullFilePath.Name = "colFullFilePath";
            this.colFullFilePath.ReadOnly = true;
            // 
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsdbAddFile,
            this.tsbRemove,
            this.toolStripSeparator2,
            this.tsdbAddFolder,
            this.tsdbImportList,
            this.toolStripSeparator4,
            this.tsbEdit,
            this.toolStripSeparator1,
            this.tsbShare,
            this.toolStripSeparator3,
            this.tsbConvert});
            this.toolStrip1.Name = "toolStrip1";
            // 
            // tsdbAddFile
            // 
            resources.ApplyResources(this.tsdbAddFile, "tsdbAddFile");
            this.tsdbAddFile.Image = global::PDFToJPGExpert.Properties.Resources.add1;
            this.tsdbAddFile.Name = "tsdbAddFile";
            this.tsdbAddFile.ButtonClick += new System.EventHandler(this.tsbAddFile_Click);
            this.tsdbAddFile.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsdbAddFile_DropDownItemClicked);
            // 
            // tsbRemove
            // 
            resources.ApplyResources(this.tsbRemove, "tsbRemove");
            this.tsbRemove.Image = global::PDFToJPGExpert.Properties.Resources.delete1;
            this.tsbRemove.Name = "tsbRemove";
            this.tsbRemove.Click += new System.EventHandler(this.tsbRemove_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // tsdbAddFolder
            // 
            resources.ApplyResources(this.tsdbAddFolder, "tsdbAddFolder");
            this.tsdbAddFolder.Image = global::PDFToJPGExpert.Properties.Resources.folder_add1;
            this.tsdbAddFolder.Name = "tsdbAddFolder";
            this.tsdbAddFolder.ButtonClick += new System.EventHandler(this.tsbAddFolder_Click);
            this.tsdbAddFolder.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsdbAddFolder_DropDownItemClicked);
            // 
            // tsdbImportList
            // 
            resources.ApplyResources(this.tsdbImportList, "tsdbImportList");
            this.tsdbImportList.Image = global::PDFToJPGExpert.Properties.Resources.import1;
            this.tsdbImportList.Name = "tsdbImportList";
            this.tsdbImportList.ButtonClick += new System.EventHandler(this.tsdbImportList_ButtonClick);
            this.tsdbImportList.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsdbImportList_DropDownItemClicked);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // tsbEdit
            // 
            resources.ApplyResources(this.tsbEdit, "tsbEdit");
            this.tsbEdit.Image = global::PDFToJPGExpert.Properties.Resources.edit1;
            this.tsbEdit.Name = "tsbEdit";
            this.tsbEdit.Click += new System.EventHandler(this.tsbEdit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // tsbShare
            // 
            resources.ApplyResources(this.tsbShare, "tsbShare");
            this.tsbShare.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiFacebook,
            this.tsiTwitter,
            this.tsiGooglePlus,
            this.tsiLinkedIn,
            this.tsiEmail});
            this.tsbShare.Image = global::PDFToJPGExpert.Properties.Resources.facebook_24;
            this.tsbShare.Name = "tsbShare";
            // 
            // tsiFacebook
            // 
            this.tsiFacebook.Image = global::PDFToJPGExpert.Properties.Resources.facebook_24;
            this.tsiFacebook.Name = "tsiFacebook";
            resources.ApplyResources(this.tsiFacebook, "tsiFacebook");
            this.tsiFacebook.Click += new System.EventHandler(this.tsiFacebook_Click);
            // 
            // tsiTwitter
            // 
            this.tsiTwitter.Image = global::PDFToJPGExpert.Properties.Resources.twitter_24;
            this.tsiTwitter.Name = "tsiTwitter";
            resources.ApplyResources(this.tsiTwitter, "tsiTwitter");
            this.tsiTwitter.Click += new System.EventHandler(this.tsiTwitter_Click);
            // 
            // tsiGooglePlus
            // 
            this.tsiGooglePlus.Image = global::PDFToJPGExpert.Properties.Resources.googleplus_24;
            this.tsiGooglePlus.Name = "tsiGooglePlus";
            resources.ApplyResources(this.tsiGooglePlus, "tsiGooglePlus");
            this.tsiGooglePlus.Click += new System.EventHandler(this.tsiGooglePlus_Click);
            // 
            // tsiLinkedIn
            // 
            this.tsiLinkedIn.Image = global::PDFToJPGExpert.Properties.Resources.linkedin_24;
            this.tsiLinkedIn.Name = "tsiLinkedIn";
            resources.ApplyResources(this.tsiLinkedIn, "tsiLinkedIn");
            this.tsiLinkedIn.Click += new System.EventHandler(this.tsiLinkedIn_Click);
            // 
            // tsiEmail
            // 
            this.tsiEmail.Image = global::PDFToJPGExpert.Properties.Resources.mail;
            this.tsiEmail.Name = "tsiEmail";
            resources.ApplyResources(this.tsiEmail, "tsiEmail");
            this.tsiEmail.Click += new System.EventHandler(this.tsiEmail_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // tsbConvert
            // 
            resources.ApplyResources(this.tsbConvert, "tsbConvert");
            this.tsbConvert.ForeColor = System.Drawing.Color.DarkBlue;
            this.tsbConvert.Image = global::PDFToJPGExpert.Properties.Resources.flash1;
            this.tsbConvert.Name = "tsbConvert";
            this.tsbConvert.Click += new System.EventHandler(this.tsbConvert_Click_1);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem1,
            this.optionsToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.tsiDownload,
            this.languageToolStripMenuItem,
            this.helpToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFilesToolStripMenuItem,
            this.addFolderToolStripMenuItem,
            this.toolStripMenuItem2,
            this.importListFromTextFileToolStripMenuItem,
            this.importListFromExcelFileToolStripMenuItem,
            this.enterFileListToolStripMenuItem,
            this.saveFileListToolStripMenuItem,
            this.toolStripMenuItem3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // addFilesToolStripMenuItem
            // 
            this.addFilesToolStripMenuItem.Image = global::PDFToJPGExpert.Properties.Resources.add;
            this.addFilesToolStripMenuItem.Name = "addFilesToolStripMenuItem";
            resources.ApplyResources(this.addFilesToolStripMenuItem, "addFilesToolStripMenuItem");
            this.addFilesToolStripMenuItem.Click += new System.EventHandler(this.tsbAddFile_Click);
            // 
            // addFolderToolStripMenuItem
            // 
            this.addFolderToolStripMenuItem.Image = global::PDFToJPGExpert.Properties.Resources.folder_add;
            this.addFolderToolStripMenuItem.Name = "addFolderToolStripMenuItem";
            resources.ApplyResources(this.addFolderToolStripMenuItem, "addFolderToolStripMenuItem");
            this.addFolderToolStripMenuItem.Click += new System.EventHandler(this.tsbAddFolder_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // importListFromTextFileToolStripMenuItem
            // 
            this.importListFromTextFileToolStripMenuItem.Image = global::PDFToJPGExpert.Properties.Resources.import1;
            this.importListFromTextFileToolStripMenuItem.Name = "importListFromTextFileToolStripMenuItem";
            resources.ApplyResources(this.importListFromTextFileToolStripMenuItem, "importListFromTextFileToolStripMenuItem");
            this.importListFromTextFileToolStripMenuItem.Click += new System.EventHandler(this.tsdbImportList_ButtonClick);
            // 
            // importListFromExcelFileToolStripMenuItem
            // 
            this.importListFromExcelFileToolStripMenuItem.Image = global::PDFToJPGExpert.Properties.Resources.import1;
            this.importListFromExcelFileToolStripMenuItem.Name = "importListFromExcelFileToolStripMenuItem";
            resources.ApplyResources(this.importListFromExcelFileToolStripMenuItem, "importListFromExcelFileToolStripMenuItem");
            this.importListFromExcelFileToolStripMenuItem.Click += new System.EventHandler(this.importListFromExcelFileToolStripMenuItem_Click);
            // 
            // enterFileListToolStripMenuItem
            // 
            this.enterFileListToolStripMenuItem.Name = "enterFileListToolStripMenuItem";
            resources.ApplyResources(this.enterFileListToolStripMenuItem, "enterFileListToolStripMenuItem");
            this.enterFileListToolStripMenuItem.Click += new System.EventHandler(this.enterFileListToolStripMenuItem_Click);
            // 
            // saveFileListToolStripMenuItem
            // 
            this.saveFileListToolStripMenuItem.Image = global::PDFToJPGExpert.Properties.Resources.disk_blue;
            this.saveFileListToolStripMenuItem.Name = "saveFileListToolStripMenuItem";
            resources.ApplyResources(this.saveFileListToolStripMenuItem, "saveFileListToolStripMenuItem");
            this.saveFileListToolStripMenuItem.Click += new System.EventHandler(this.saveFileListToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::PDFToJPGExpert.Properties.Resources.exit;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem1
            // 
            this.editToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem1,
            this.clearToolStripMenuItem,
            this.selectAllToolStripMenuItem,
            this.selectNoneToolStripMenuItem,
            this.invertSelectionToolStripMenuItem});
            this.editToolStripMenuItem1.Name = "editToolStripMenuItem1";
            resources.ApplyResources(this.editToolStripMenuItem1, "editToolStripMenuItem1");
            // 
            // removeToolStripMenuItem1
            // 
            this.removeToolStripMenuItem1.Image = global::PDFToJPGExpert.Properties.Resources.delete;
            this.removeToolStripMenuItem1.Name = "removeToolStripMenuItem1";
            resources.ApplyResources(this.removeToolStripMenuItem1, "removeToolStripMenuItem1");
            this.removeToolStripMenuItem1.Click += new System.EventHandler(this.tsbRemove_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Image = global::PDFToJPGExpert.Properties.Resources.brush2;
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            resources.ApplyResources(this.clearToolStripMenuItem, "clearToolStripMenuItem");
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.tsbClear_Click);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            resources.ApplyResources(this.selectAllToolStripMenuItem, "selectAllToolStripMenuItem");
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // selectNoneToolStripMenuItem
            // 
            this.selectNoneToolStripMenuItem.Name = "selectNoneToolStripMenuItem";
            resources.ApplyResources(this.selectNoneToolStripMenuItem, "selectNoneToolStripMenuItem");
            this.selectNoneToolStripMenuItem.Click += new System.EventHandler(this.selectNoneToolStripMenuItem_Click);
            // 
            // invertSelectionToolStripMenuItem
            // 
            this.invertSelectionToolStripMenuItem.Name = "invertSelectionToolStripMenuItem";
            resources.ApplyResources(this.invertSelectionToolStripMenuItem, "invertSelectionToolStripMenuItem");
            this.invertSelectionToolStripMenuItem.Click += new System.EventHandler(this.invertSelectionToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.keepFolderStructureToolStripMenuItem,
            this.exploreOutputFolderWhenDoneToolStripMenuItem,
            this.keepCreationDateToolStripMenuItem,
            this.keepLastModificationDateToolStripMenuItem,
            this.showMessageOnSucessToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            resources.ApplyResources(this.optionsToolStripMenuItem, "optionsToolStripMenuItem");
            // 
            // keepFolderStructureToolStripMenuItem
            // 
            this.keepFolderStructureToolStripMenuItem.Name = "keepFolderStructureToolStripMenuItem";
            resources.ApplyResources(this.keepFolderStructureToolStripMenuItem, "keepFolderStructureToolStripMenuItem");
            this.keepFolderStructureToolStripMenuItem.Click += new System.EventHandler(this.keepFolderStructureToolStripMenuItem_Click);
            // 
            // exploreOutputFolderWhenDoneToolStripMenuItem
            // 
            this.exploreOutputFolderWhenDoneToolStripMenuItem.CheckOnClick = true;
            this.exploreOutputFolderWhenDoneToolStripMenuItem.Name = "exploreOutputFolderWhenDoneToolStripMenuItem";
            resources.ApplyResources(this.exploreOutputFolderWhenDoneToolStripMenuItem, "exploreOutputFolderWhenDoneToolStripMenuItem");
            // 
            // keepCreationDateToolStripMenuItem
            // 
            this.keepCreationDateToolStripMenuItem.CheckOnClick = true;
            this.keepCreationDateToolStripMenuItem.Name = "keepCreationDateToolStripMenuItem";
            resources.ApplyResources(this.keepCreationDateToolStripMenuItem, "keepCreationDateToolStripMenuItem");
            // 
            // keepLastModificationDateToolStripMenuItem
            // 
            this.keepLastModificationDateToolStripMenuItem.CheckOnClick = true;
            this.keepLastModificationDateToolStripMenuItem.Name = "keepLastModificationDateToolStripMenuItem";
            resources.ApplyResources(this.keepLastModificationDateToolStripMenuItem, "keepLastModificationDateToolStripMenuItem");
            // 
            // showMessageOnSucessToolStripMenuItem
            // 
            this.showMessageOnSucessToolStripMenuItem.CheckOnClick = true;
            this.showMessageOnSucessToolStripMenuItem.Name = "showMessageOnSucessToolStripMenuItem";
            resources.ApplyResources(this.showMessageOnSucessToolStripMenuItem, "showMessageOnSucessToolStripMenuItem");
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.convertToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            resources.ApplyResources(this.toolsToolStripMenuItem, "toolsToolStripMenuItem");
            // 
            // convertToolStripMenuItem
            // 
            this.convertToolStripMenuItem.Image = global::PDFToJPGExpert.Properties.Resources.flash;
            this.convertToolStripMenuItem.Name = "convertToolStripMenuItem";
            resources.ApplyResources(this.convertToolStripMenuItem, "convertToolStripMenuItem");
            this.convertToolStripMenuItem.Click += new System.EventHandler(this.tsbConvert_Click_1);
            // 
            // tsiDownload
            // 
            this.tsiDownload.Name = "tsiDownload";
            resources.ApplyResources(this.tsiDownload, "tsiDownload");
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpGuideToolStripMenuItem,
            this.tryOnlineVersionAtOnlinepdfappscomToolStripMenuItem,
            this.commandLineArgumentsToolStripMenuItem,
            this.pleaseDonateToolStripMenuItem1,
            this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem,
            this.setUpdateProxyToolStripMenuItem,
            this.checkForNewVersionEachWeekToolStripMenuItem,
            this.tiHelpFeedback,
            this.toolStripMenuItem1,
            this.followUsOnTwitterToolStripMenuItem,
            this.visit4dotsSoftwareWebsiteToolStripMenuItem,
            this.youtubeChannelToolStripMenuItem,
            this.checkVersionToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // helpGuideToolStripMenuItem
            // 
            this.helpGuideToolStripMenuItem.Image = global::PDFToJPGExpert.Properties.Resources.help2;
            this.helpGuideToolStripMenuItem.Name = "helpGuideToolStripMenuItem";
            resources.ApplyResources(this.helpGuideToolStripMenuItem, "helpGuideToolStripMenuItem");
            this.helpGuideToolStripMenuItem.Click += new System.EventHandler(this.helpGuideToolStripMenuItem_Click);
            // 
            // tryOnlineVersionAtOnlinepdfappscomToolStripMenuItem
            // 
            resources.ApplyResources(this.tryOnlineVersionAtOnlinepdfappscomToolStripMenuItem, "tryOnlineVersionAtOnlinepdfappscomToolStripMenuItem");
            this.tryOnlineVersionAtOnlinepdfappscomToolStripMenuItem.Name = "tryOnlineVersionAtOnlinepdfappscomToolStripMenuItem";
            this.tryOnlineVersionAtOnlinepdfappscomToolStripMenuItem.Click += new System.EventHandler(this.tryOnlineVersionAtOnlinepdfappscomToolStripMenuItem_Click);
            // 
            // commandLineArgumentsToolStripMenuItem
            // 
            this.commandLineArgumentsToolStripMenuItem.Name = "commandLineArgumentsToolStripMenuItem";
            resources.ApplyResources(this.commandLineArgumentsToolStripMenuItem, "commandLineArgumentsToolStripMenuItem");
            this.commandLineArgumentsToolStripMenuItem.Click += new System.EventHandler(this.commandLineArgumentsToolStripMenuItem_Click);
            // 
            // pleaseDonateToolStripMenuItem1
            // 
            this.pleaseDonateToolStripMenuItem1.BackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.pleaseDonateToolStripMenuItem1, "pleaseDonateToolStripMenuItem1");
            this.pleaseDonateToolStripMenuItem1.Name = "pleaseDonateToolStripMenuItem1";
            this.pleaseDonateToolStripMenuItem1.Click += new System.EventHandler(this.pleaseDonateToolStripMenuItem1_Click);
            // 
            // dotsSoftwarePRODUCTCATALOGToolStripMenuItem
            // 
            resources.ApplyResources(this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem, "dotsSoftwarePRODUCTCATALOGToolStripMenuItem");
            this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem.ForeColor = System.Drawing.Color.DarkBlue;
            this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem.Name = "dotsSoftwarePRODUCTCATALOGToolStripMenuItem";
            this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem.Click += new System.EventHandler(this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem_Click);
            // 
            // setUpdateProxyToolStripMenuItem
            // 
            this.setUpdateProxyToolStripMenuItem.Name = "setUpdateProxyToolStripMenuItem";
            resources.ApplyResources(this.setUpdateProxyToolStripMenuItem, "setUpdateProxyToolStripMenuItem");
            this.setUpdateProxyToolStripMenuItem.Click += new System.EventHandler(this.setUpdateProxyToolStripMenuItem_Click);
            // 
            // checkForNewVersionEachWeekToolStripMenuItem
            // 
            this.checkForNewVersionEachWeekToolStripMenuItem.CheckOnClick = true;
            this.checkForNewVersionEachWeekToolStripMenuItem.Name = "checkForNewVersionEachWeekToolStripMenuItem";
            resources.ApplyResources(this.checkForNewVersionEachWeekToolStripMenuItem, "checkForNewVersionEachWeekToolStripMenuItem");
            // 
            // tiHelpFeedback
            // 
            this.tiHelpFeedback.Image = global::PDFToJPGExpert.Properties.Resources.edit;
            this.tiHelpFeedback.Name = "tiHelpFeedback";
            resources.ApplyResources(this.tiHelpFeedback, "tiHelpFeedback");
            this.tiHelpFeedback.Click += new System.EventHandler(this.tiHelpFeedback_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // followUsOnTwitterToolStripMenuItem
            // 
            resources.ApplyResources(this.followUsOnTwitterToolStripMenuItem, "followUsOnTwitterToolStripMenuItem");
            this.followUsOnTwitterToolStripMenuItem.Name = "followUsOnTwitterToolStripMenuItem";
            this.followUsOnTwitterToolStripMenuItem.Click += new System.EventHandler(this.followUsOnTwitterToolStripMenuItem_Click);
            // 
            // visit4dotsSoftwareWebsiteToolStripMenuItem
            // 
            this.visit4dotsSoftwareWebsiteToolStripMenuItem.Image = global::PDFToJPGExpert.Properties.Resources.earth;
            this.visit4dotsSoftwareWebsiteToolStripMenuItem.Name = "visit4dotsSoftwareWebsiteToolStripMenuItem";
            resources.ApplyResources(this.visit4dotsSoftwareWebsiteToolStripMenuItem, "visit4dotsSoftwareWebsiteToolStripMenuItem");
            this.visit4dotsSoftwareWebsiteToolStripMenuItem.Click += new System.EventHandler(this.visit4dotsSoftwareWebsiteToolStripMenuItem_Click);
            // 
            // youtubeChannelToolStripMenuItem
            // 
            this.youtubeChannelToolStripMenuItem.Image = global::PDFToJPGExpert.Properties.Resources.youtube_32;
            this.youtubeChannelToolStripMenuItem.Name = "youtubeChannelToolStripMenuItem";
            resources.ApplyResources(this.youtubeChannelToolStripMenuItem, "youtubeChannelToolStripMenuItem");
            this.youtubeChannelToolStripMenuItem.Click += new System.EventHandler(this.youtubeChannelToolStripMenuItem_Click);
            // 
            // checkVersionToolStripMenuItem
            // 
            this.checkVersionToolStripMenuItem.Name = "checkVersionToolStripMenuItem";
            resources.ApplyResources(this.checkVersionToolStripMenuItem, "checkVersionToolStripMenuItem");
            this.checkVersionToolStripMenuItem.Click += new System.EventHandler(this.checkVersionToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::PDFToJPGExpert.Properties.Resources.about;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.chkOneImage);
            this.Controls.Add(this.cmbOutputDir);
            this.Controls.Add(this.btnOutputFormatMore);
            this.Controls.Add(this.nudDPI);
            this.Controls.Add(this.btnOutputFolderOpen);
            this.Controls.Add(this.btnOutputFolderSelect);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudQuality);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbOutputFormat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgFiles);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.ShowInTaskbar = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudDPI)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgFiles)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgFiles;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbRemove;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbConvert;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsiDownload;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpGuideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiHelpFeedback;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem visit4dotsSoftwareWebsiteToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        public System.ComponentModel.BackgroundWorker bwProgress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDimensions;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnOutputFolderSelect;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnOutputFolderOpen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFilename;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPassword;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalPages;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPageRange;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFileDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullFilePath;
        private System.Windows.Forms.Button btnOutputFormatMore;
        public System.Windows.Forms.ComboBox cmbOutputFormat;
        public System.Windows.Forms.NumericUpDown nudQuality;
        public System.Windows.Forms.TextBox txtDimensionsH;
        public System.Windows.Forms.TextBox txtDimensionsW;
        public System.Windows.Forms.RadioButton rdDimensionsOther;
        public System.Windows.Forms.RadioButton rd12801024;
        public System.Windows.Forms.RadioButton rd1024768;
        public System.Windows.Forms.RadioButton rd800600;
        public System.Windows.Forms.NumericUpDown nudDPI;
        public System.Windows.Forms.RadioButton rdDimensionsAsIs;
        private System.Windows.Forms.ToolStripMenuItem checkVersionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        public System.Windows.Forms.ToolStripSplitButton tsdbAddFile;
        public System.Windows.Forms.ToolStripSplitButton tsdbAddFolder;
        public System.Windows.Forms.ToolStripSplitButton tsdbImportList;
        private System.Windows.Forms.ToolStripDropDownButton tsbShare;
        private System.Windows.Forms.ToolStripMenuItem tsiFacebook;
        private System.Windows.Forms.ToolStripMenuItem tsiTwitter;
        private System.Windows.Forms.ToolStripMenuItem tsiGooglePlus;
        private System.Windows.Forms.ToolStripMenuItem tsiLinkedIn;
        private System.Windows.Forms.ToolStripMenuItem tsiEmail;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exploreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        public System.Windows.Forms.ComboBox cmbOutputDir;
        public System.Windows.Forms.CheckBox chkOneImage;
        public System.Windows.Forms.CheckBox chkFitPage;
        private System.Windows.Forms.ToolStripMenuItem dotsSoftwarePRODUCTCATALOGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setUpdateProxyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem followUsOnTwitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pleaseDonateToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectNoneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertSelectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem importListFromTextFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importListFromExcelFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enterFileListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFileListToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem youtubeChannelToolStripMenuItem;
        public System.Windows.Forms.TextBox txtHeight;
        public System.Windows.Forms.RadioButton rdHeight;
        public System.Windows.Forms.TextBox txtWidth;
        public System.Windows.Forms.RadioButton rdWidth;
        private System.Windows.Forms.ToolStripMenuItem checkForNewVersionEachWeekToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exploreOutputFolderWhenDoneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showMessageOnSucessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tryOnlineVersionAtOnlinepdfappscomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commandLineArgumentsToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem keepFolderStructureToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem keepCreationDateToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem keepLastModificationDateToolStripMenuItem;
    }
}
