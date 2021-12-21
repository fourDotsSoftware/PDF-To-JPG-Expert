using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace PDFToJPGExpert
{
    public partial class frmMain : PDFToJPGExpert.CustomForm
    {
        public static frmMain Instance = null;
        public DataTable dt = new DataTable("pdfs");
        public static System.IO.FileSystemWatcher fs = new System.IO.FileSystemWatcher();

        public string SelectedOutputFormatCode = "";
        public string SelectedOutputFormatExtension = "";
        public List<string> cmbOutputFormatCodes = new List<string>();
        public List<string> cmbOutputFormatExtension = new List<string>();

        private string OutputDir = "";
        private bool OverwritePDF = false;
        private bool KeepBackup = false;

        public frmMain()
        {
            Instance = this;

            InitializeComponent();

            dt.Columns.Add("pagerange");
            dt.Columns.Add("totalpages", typeof(int));
            dt.Columns.Add("password");
            dt.Columns.Add("filedate");
            dt.Columns.Add("sizekb");
            dt.Columns.Add("fullfilepath");
            dt.Columns.Add("filename");
            dt.Columns.Add("decryptedfile");
            dt.Columns.Add("rootfolder");

            if (!Module.IsCommandLine)
            {
                if (Properties.Settings.Default.ShowPromotion)
                {
                    frmPromotion fp = new frmPromotion();
                    fp.Show(this);
                }
            }

            if (Module.IsCommandLine)
            {
                this.Visible = false;                                

                frmMain_Load(null, null);

                ArgsHelper.ExamineArgs(Module.args);

                ArgsHelper.ExecuteCommandLine();

                Environment.Exit(0);

                return;
            }

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            SetupOnLoad();

            frmMain.fs.Created += fs_Created;
            frmMain.fs.Changed += fs_Changed;

            if (Properties.Settings.Default.CheckWeek)
            {
                UpdateHelper.InitializeCheckVersionWeek();
            }

            // new
            if (Module.args.Length > 0 && System.IO.File.Exists(Module.args[0]))
            {
                AddFile(Module.args[0]);
            }
            else if (Module.args.Length > 0 && System.IO.Directory.Exists(Module.args[0]))
            {
                AddFolder(Module.args[0]);
            }

            ResizeControls();
        }

        private void SetupOnLoad()
        {
            dgFiles.AutoGenerateColumns = false;
            dgFiles.DataSource = dt;

            this.Text = Module.ApplicationTitle;

            AdjustSizeLocation();
            
            SetupOutputFormats();

            SetupOutputFolders();
            /*
            cmbOutputFolder.Items.Add(TranslateHelper.Translate("Same as Document Folder"));
            cmbOutputFolder.Items.Add(TranslateHelper.Translate("<Other>"));
            cmbOutputFolder.SelectedIndex = 0;
            */

            DownloadSuggestionsHelper ds = new DownloadSuggestionsHelper();
            ds.SetupDownloadMenuItems(tsiDownload);

            AddLanguageMenuItems();

            if (!ArgsHelper.IsFromCommandLine)
            {
                RecentFilesHelper.FillMenuRecentFile();
                RecentFilesHelper.FillMenuRecentFolder();
                RecentFilesHelper.FillMenuRecentImportList();
            }

            this.Icon = PDFToJPGExpert.Properties.Resources.pdftojpg_48x481;

            if (Properties.Settings.Default.OutputFolderIndex <= cmbOutputDir.Items.Count - 1)
            {
                cmbOutputDir.SelectedIndex = Properties.Settings.Default.OutputFolderIndex;
            }

            nudDPI.Value = Properties.Settings.Default.Resolution;
            nudQuality.Value = Properties.Settings.Default.JPEGQuality;
            chkFitPage.Checked = Properties.Settings.Default.FitPage;
            chkOneImage.Checked = Properties.Settings.Default.OneImage;

            if (Properties.Settings.Default.OutputDimensionsIndex == 0)
            {
                rdDimensionsAsIs.Checked = true;
            }
            else if (Properties.Settings.Default.OutputDimensionsIndex == 1)
            {
                rd800600.Checked = true;
            }
            else if (Properties.Settings.Default.OutputDimensionsIndex == 2)
            {
                rd1024768.Checked = true;
            }
            else if (Properties.Settings.Default.OutputDimensionsIndex == 3)
            {
                rd12801024.Checked = true;
            }
            else if (Properties.Settings.Default.OutputDimensionsIndex == 4)
            {
                rdDimensionsOther.Checked = true;
            }
            
            txtDimensionsH.Text = Properties.Settings.Default.OutputDimensionsOther1Y;

            txtDimensionsW.Text = Properties.Settings.Default.OutputDimensionsOther1X;
            
            if (Properties.Settings.Default.OutputFormat != string.Empty)
            {
                SelectedOutputFormatCode = Properties.Settings.Default.OutputFormatCode;
                SelectedOutputFormatExtension = Properties.Settings.Default.OutputFormatExtension;
                cmbOutputFormat.Text = Properties.Settings.Default.OutputFormat;
            }

            keepFolderStructureToolStripMenuItem.Checked = Properties.Settings.Default.KeepFolderStructure;

            checkForNewVersionEachWeekToolStripMenuItem.Checked = Properties.Settings.Default.CheckWeek;

            //=========

            exploreOutputFolderWhenDoneToolStripMenuItem.Checked =
                Properties.Settings.Default.ExploreOutputFolder;

            keepCreationDateToolStripMenuItem.Checked =
                Properties.Settings.Default.KeepCreationDate;

            keepLastModificationDateToolStripMenuItem.Checked =
                Properties.Settings.Default.KeepLastModificationDate;

            showMessageOnSucessToolStripMenuItem.Checked =
                Properties.Settings.Default.ShowMessageOnSucess;
        }

        private void SetupOutputFolders()
        {
            cmbOutputDir.Items.Add(TranslateHelper.Translate("Same Folder of PDF Document"));            
            cmbOutputDir.Items.Add(TranslateHelper.Translate("Subfolder of PDF Document"));
            cmbOutputDir.Items.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures).ToString());
            cmbOutputDir.Items.Add("---------------------------------------------------------------------------------------");

            OutputFolderHelper.LoadOutputFolders();
            cmbOutputDir.SelectedIndex = Properties.Settings.Default.OutputFolderIndex;

        }
        #region Localization

        private void AddLanguageMenuItems()
        {
            for (int k = 0; k < frmLanguage.LangCodes.Count; k++)
            {
                ToolStripMenuItem ti = new ToolStripMenuItem();
                ti.Text = frmLanguage.LangDesc[k];
                ti.Tag = frmLanguage.LangCodes[k];
                ti.Image = frmLanguage.LangImg[k];
                ti.Click += new EventHandler(tiLang_Click);

                if (ti.Tag.ToString() == Properties.Settings.Default.Language)
                {
                    ti.Checked = true;
                }

                languageToolStripMenuItem.DropDownItems.Add(ti);
            }
        }

        void tiLang_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem ti = (ToolStripMenuItem)sender;
            string langcode = ti.Tag.ToString();
            ChangeLanguage(langcode);

            for (int k = 0; k < frmLanguage.LangCodes.Count; k++)
            {
                if (frmLanguage.LangCodes[k] == langcode)
                {
                    ToolStripMenuItem til = (ToolStripMenuItem)languageToolStripMenuItem.DropDownItems[k];
                    til.Checked = true;
                }
            }

            /*
            for (int k = 0; k < languageToolStripMenuItem.DropDownItems.Count; k++)
            {
                ToolStripMenuItem til = (ToolStripMenuItem)languageToolStripMenuItem.DropDownItems[k];
                if (til == ti)
                {
                    til.Checked = true;
                }
                else
                {
                    til.Checked = false;
                }
            }*/
        }

        private void ChangeLanguage(string language_code)
        {
            Properties.Settings.Default.Language = language_code;
            Program.SetLanguage();

            bool maximized = (this.WindowState == FormWindowState.Maximized);
            this.WindowState = FormWindowState.Normal;

            this.Controls.Clear();

            InitializeComponent();

            SetupOnLoad();

            if (maximized)
            {
                this.WindowState = FormWindowState.Maximized;
            }

            this.ResumeLayout(true);
        }

        #endregion

        private void SetupOutputFormats()
        {
            cmbOutputFormat.Items.Add("PNG");
            cmbOutputFormatCodes.Add("png16m");
            cmbOutputFormatExtension.Add("png");

            cmbOutputFormat.Items.Add("JPEG");
            cmbOutputFormatCodes.Add("jpeg");
            cmbOutputFormatExtension.Add("jpg");
            cmbOutputFormat.Items.Add("BMP");
            cmbOutputFormatExtension.Add("bmp");
            cmbOutputFormatCodes.Add("bmp16m");
            cmbOutputFormat.Items.Add("PCX");
            cmbOutputFormatExtension.Add("pcx");
            cmbOutputFormatCodes.Add("pcx24b");
            cmbOutputFormat.Items.Add("PSD");
            cmbOutputFormatExtension.Add("psd");
            cmbOutputFormatCodes.Add("psdrgb");
            cmbOutputFormat.Items .Add("TIFF G4 FAX Encoding");
            cmbOutputFormatCodes.Add("tiffg4");
            cmbOutputFormatExtension.Add("tif");
            cmbOutputFormat.Items.Add("TIFF LZW Compression");
            cmbOutputFormatCodes.Add("tifflzw");
            cmbOutputFormatExtension.Add("tif");
            cmbOutputFormat.Items.Add("TIFF 24 Bit uncompressed");
            cmbOutputFormatCodes.Add("tiff24nc");
            cmbOutputFormatExtension.Add("tif");
            cmbOutputFormat.Items.Add("JPEG Grayscale");
            cmbOutputFormatCodes.Add("jpeggray");
            cmbOutputFormatExtension.Add("jpg");
            cmbOutputFormat.Items.Add("PNG Grayscale");
            cmbOutputFormatCodes.Add("pnggray");
            cmbOutputFormatExtension.Add("png");
            cmbOutputFormat.Items.Add("PNG 256 Colors (8-bit)");
            cmbOutputFormatCodes.Add("png256");
            cmbOutputFormatExtension.Add("png");
            cmbOutputFormat.Items.Add("PNG 16 Colors (4-bit)");
            cmbOutputFormatCodes.Add("png16");
            cmbOutputFormatExtension.Add("png");
            cmbOutputFormat.Items.Add("PNG Monochrome");
            cmbOutputFormatCodes.Add("pngmono");
            cmbOutputFormatExtension.Add("png");

            /*
            cmbColors.Items.Add("16 Million Colors (24-bit)");
            cmbColors.Items.Add("256 Colors (8-bit)");
            cmbColors.Items.Add("16 Colors (4-bit)");
            cmbColors.Items.Add("Grayscale");
            cmbColors.Items.Add("Black-White (Monochrome)");
            */

            cmbOutputFormat.SelectedIndex = 0;
        }

        private void tsbConvert_Click(object sender, EventArgs e)
        {
            PDFToJPGHelper.Convert();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout f = new frmAbout();
            f.ShowDialog();
        }

        private void tiHelpFeedback_Click(object sender, EventArgs e)
        {
            /*
            frmUninstallQuestionnaire f = new frmUninstallQuestionnaire(false);
            f.ShowDialog();
            */

            System.Diagnostics.Process.Start("https://www.4dots-software.com/support/bugfeature.php?app=" + System.Web.HttpUtility.UrlEncode(Module.ShortApplicationTitle));
        }

        private void visit4dotsSoftwareWebsiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.4dots-software.com");
        }

        private void helpGuideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Module.HelpURL);

            ///System.Diagnostics.Process.Start(Application.StartupPath + "\\PDF To JPG Expert - User's Manual.chm");

            /*
            if (Module.SelectedLanguage == "en-US")
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\PDF Password Remover Users Manual.chm");
            }
            else
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\" + Module.SelectedLanguage + "\\PDF Password Remover Users Manual.chm");
            }
            */
        }

        private void tsbAddFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = Module.DialogFilesFilter;
            openFileDialog1.Multiselect = true;

            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    for (int k = 0; k < openFileDialog1.FileNames.Length; k++)
                    {
                        AddFile(openFileDialog1.FileNames[k]);
                        RecentFilesHelper.AddRecentFile(openFileDialog1.FileNames[k]);
                    }
                }
                finally
                {
                    this.Cursor = null;
                }
            }
        }

        public bool AddFile(string filepath)
        {
            return AddFile(filepath, "");
        }

        public bool AddFile(string file, string password)
        {
            return AddFile(file, password, "");
        }

        public bool AddFile(string file,string password,string rootfolder)
        {
          GetPDFTotalPagesResult res= GeneratePDFImagesHelper.GetPDFTotalPages(file,password);

          if (res.ErrStr != string.Empty)
          {
              frmError f = new frmError(TranslateHelper.Translate("Error"), res.ErrStr);
              f.ShowDialog();
              return false;
          }
          else
          {
              DataRow dr = dt.NewRow();
              dr["totalpages"] = res.TotalPages;
              dr["decryptedfile"] = res.DecryptedFile;
              dr["filename"] = System.IO.Path.GetFileName(file);
              dr["fullfilepath"] = file;

              FileInfo fi = new FileInfo(file);
              
              long sizekb=fi.Length / 1024;
              dr["sizekb"] = sizekb.ToString() + " KB";
              dr["filedate"] = fi.LastWriteTime.ToString();
              dr["password"] = res.Password;
              dr["pagerange"] = TranslateHelper.Translate("All Pages");
              dr["rootfolder"] = rootfolder;

              dt.Rows.Add(dr);

          }

          return true;
        }

        private void tsbAddFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = "";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                AddFolder(folderBrowserDialog1.SelectedPath);
                RecentFilesHelper.AddRecentFolder(folderBrowserDialog1.SelectedPath);
            }
        }

        public void AddFolder(string folder_path)
        {
            AddFolder(folder_path, "");
        }

        public void AddFolder(string folder_path, string password)
        {
            string[] filez = null;

            if (Module.IsCommandLine)
            {
                if (Module.CmdAddSubdirectories)
                {
                    filez = System.IO.Directory.GetFiles(folder_path, "*.pdf", SearchOption.AllDirectories);
                }
                else
                {
                    filez = System.IO.Directory.GetFiles(folder_path, "*.pdf", SearchOption.TopDirectoryOnly);
                }
            }
            else
            {
                if (!ImportListHelper.SilentAdd)
                {
                    if (System.IO.Directory.GetDirectories(folder_path).Length > 0)
                    {
                        DialogResult dres = Module.ShowQuestionDialog("Would you like to add also Subdirectories ?", TranslateHelper.Translate("Add Subdirectories ?"));

                        if (dres == DialogResult.Yes)
                        {
                            filez = System.IO.Directory.GetFiles(folder_path, "*.pdf", SearchOption.AllDirectories);
                        }
                        else
                        {
                            filez = System.IO.Directory.GetFiles(folder_path, "*.pdf", SearchOption.TopDirectoryOnly);
                        }
                    }
                    else
                    {
                        filez = System.IO.Directory.GetFiles(folder_path, "*.pdf", SearchOption.TopDirectoryOnly);
                    }
                }
                else
                {
                    // silent add for import list
                    filez = System.IO.Directory.GetFiles(folder_path, "*.pdf", SearchOption.AllDirectories);
                }

            }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                for (int k = 0; k < filez.Length; k++)
                {
                    if (filez[k].ToLower().EndsWith(".pdf"))
                    {
                        AddFile(filez[k], password,folder_path);
                    }

                }
            }
            finally
            {
                this.Cursor = null;
            }
        }

        /*
        public void AddFolder(string folder_path)
        {
            string[] filez = null;

            
                if (System.IO.Directory.GetDirectories(folder_path).Length > 0)
                {
                    DialogResult dres = Module.ShowQuestionDialog("Would you like to add also Subdirectories ?", "Add Subdirectories ?");

                    if (dres == DialogResult.Yes)
                    {
                        filez = System.IO.Directory.GetFiles(folder_path, "*.pdf", SearchOption.AllDirectories);
                    }
                    else
                    {
                        filez = System.IO.Directory.GetFiles(folder_path, "*.pdf", SearchOption.TopDirectoryOnly);
                    }
                }
                else
                {
                    filez = System.IO.Directory.GetFiles(folder_path, "*.pdf", SearchOption.TopDirectoryOnly);
                }
            //}

            try
            {
                this.Cursor = Cursors.WaitCursor;

                for (int k = 0; k < filez.Length; k++)
                {
                    if (filez[k].ToLower().EndsWith(".pdf"))
                    {
                        AddFile(filez[k]);
                    }

                }
            }
            finally
            {
                this.Cursor = null;
            }

        }
        */
        private void tsbRemove_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedCellCollection cells = dgFiles.SelectedCells;
            List<DataGridViewRow> rows = new List<DataGridViewRow>();

            for (int k = 0; k < cells.Count; k++)
            {
                if (rows.IndexOf(dgFiles.Rows[cells[k].RowIndex]) < 0)
                {
                    rows.Add(dgFiles.Rows[cells[k].RowIndex]);
                }
            }

            for (int k = 0; k < rows.Count; k++)
            {
                dgFiles.Rows.Remove(rows[k]);
            }
        }

        private void tsbClear_Click(object sender, EventArgs e)
        {
            dt.Rows.Clear();                        
        }

        private void bwProgress_DoWork(object sender, DoWorkEventArgs e)
        {                                               
            LastFilepathFired = "";

            PDFConvertArgs args = (PDFConvertArgs)e.Argument;
            try
            {
                DateTime dtnow = DateTime.Now;

                bool suc=args.con.Convert(args.InputFile, args.OutFile);

                if (!suc)
                {
                    PDFToJPGHelper.errstr += TranslateHelper.Translate("Error while converting file") + " : " + args.InputFile + "\r\n";
                }
                else
                {
                    string dir = System.IO.Path.GetDirectoryName(args.OutFile);

                    string[] filez = System.IO.Directory.GetFiles(dir);

                    for (int k = 0; k < filez.Length; k++)
                    {
                        FileInfo fi = new FileInfo(filez[k]);

                        if (System.IO.Path.GetFileNameWithoutExtension(filez[k]).StartsWith(System.IO.Path.GetFileNameWithoutExtension(args.OutFile))
                            && fi.CreationTime>=dtnow)
                        {
                            if ((args.iwidth == 0 && args.iheight != 0) || (args.iwidth != 0 && args.iheight == 0))
                            {
                                ResizeHelper.ResizeImage(filez[k], args.outputFormatCode, args.iwidth, args.iheight, args.jpegQuality);
                            }
                        }

                        FileInfo fi2 = new FileInfo(PDFToJPGHelper.CurrentInputFile);

                        if (Properties.Settings.Default.KeepCreationDate)
                        {
                            fi.CreationTime = fi2.CreationTime;
                        }

                        if (Properties.Settings.Default.KeepLastModificationDate)
                        {
                            fi.LastWriteTime = fi2.LastWriteTime;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                PDFToJPGHelper.errstr += TranslateHelper.Translate("Error while converting file") + " : " + args.InputFile + "\r\n" + ex.Message + "\r\n";
            }
            /*
            while (!bwProgress.CancellationPending)
            {
                Application.DoEvents();
                
            }
            */
                                                                        
        }

        private string LastFilepathFired = "";

        void fs_Changed(object sender, FileSystemEventArgs e)
        {
            //avoid duplicate fired events....
            if (LastFilepathFired != e.FullPath)
            {
                if (e.FullPath.StartsWith(PDFToJPGHelper.CurrentProcessingFilepathWithoutExtension)
                    && System.IO.Path.GetExtension(e.FullPath) == PDFToJPGHelper.CurrentProcessingFileExtension)
                {
                    //frmMain.Instance.bwProgress.ReportProgress(1);
                    frmProgress.Instance.UpdateProgress();
                    //MessageBox.Show("CHANGED!");
                }

                LastFilepathFired = e.FullPath;
            }
        }

        void fs_Created(object sender, FileSystemEventArgs e)
        {
            //avoid duplicate fired events....
            if (LastFilepathFired != e.FullPath)
            {
                if (e.FullPath.StartsWith(PDFToJPGHelper.CurrentProcessingFilepathWithoutExtension)
                    && System.IO.Path.GetExtension(e.FullPath) == PDFToJPGHelper.CurrentProcessingFileExtension)
                {
                    frmProgress.Instance.UpdateProgress();
                    //frmMain.Instance.bwProgress.ReportProgress(1);
                    //MessageBox.Show("CREATED!");
                }
                LastFilepathFired = e.FullPath;
            }
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            dgFiles_CellContentDoubleClick(null, null);
        }

        private void dgFiles_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgFiles.SelectedCells == null || dgFiles.SelectedCells.Count == 0)
            {
                return;
            }

            DataRowView drv = (DataRowView)dgFiles.SelectedCells[0].OwningRow.DataBoundItem;
            DataRow dr = drv.Row;

            frmEditPDF f = new frmEditPDF(dr["filename"].ToString(), dr["password"].ToString(), dr["pagerange"].ToString(),dr["totalpages"].ToString());
            if (f.ShowDialog() == DialogResult.OK)
            {
                dr["password"] = f.txtPassword.Text;
                dr["pagerange"] = f.cmbPageRange.Text;
                //dr.AcceptChanges();
            }

        }

        private void btnOutputFolderSelect_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                OutputFolderHelper.SaveOutputFolder(folderBrowserDialog1.SelectedPath);
            }

            /*
            if (cmbOutputFolder.Text.Trim()!=string.Empty && System.IO.Directory.Exists(cmbOutputFolder.Text))
            {
                folderBrowserDialog1.SelectedPath=cmbOutputFolder.Text;
            }

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                bool found = false;

                for (int k = 0; k < cmbOutputFolder.Items.Count; k++)
                {
                    if (cmbOutputFolder.Items[k].ToString() == folderBrowserDialog1.SelectedPath)
                    {
                        found = true;
                        cmbOutputFolder.SelectedIndex = k;
                        return;
                    }
                }

                if (!found)
                {
                    cmbOutputFolder.Items.Add(folderBrowserDialog1.SelectedPath);
                    cmbOutputFolder.SelectedIndex = cmbOutputFolder.Items.Count - 1;
                }                
            }*/
        }

        private void btnOutputFolderOpen_Click(object sender, EventArgs e)
        {
            dgFiles.EndEdit();

            if (dt.Rows.Count == 0)
            {
                Module.ShowMessage("Please add a PDF File first !");

            }
            else
            {
                string dirpath = "";
                string filepath = "";
                //string outfilepath = "";

                string outdir = "";

                if (dgFiles.SelectedCells.Count == 0)
                {
                    filepath = dgFiles.Rows[0].Cells["colFullfilepath"].Value.ToString();
                }
                else
                {
                    filepath = dgFiles.SelectedCells[0].OwningRow.Cells["colFullfilepath"].Value.ToString();
                }

                if (frmMain.Instance.cmbOutputDir.Text.Trim() == TranslateHelper.Translate("Same Folder of PDF Document"))
                {
                    dirpath = System.IO.Path.GetDirectoryName(filepath);
                    //outfilepath = System.IO.Path.Combine(dirpath, System.IO.Path.GetFileNameWithoutExtension(filepath) + "_unprotected.pdf");

                    outdir = dirpath;
                }
                else if (frmMain.Instance.cmbOutputDir.Text.ToString().StartsWith(TranslateHelper.Translate("Subfolder") + " : "))
                {
                    int subfolderspos = (TranslateHelper.Translate("Subfolder") + " : ").Length;
                    string subfolder = frmMain.Instance.cmbOutputDir.Text.ToString().Substring(subfolderspos);

                    //outfilepath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(filepath) + "\\" + subfolder, System.IO.Path.GetFileName(filepath));

                    outdir = System.IO.Path.GetDirectoryName(filepath) + "\\" + subfolder;
                }                
                else
                {
                    //outfilepath = System.IO.Path.Combine(frmMain.Instance.cmbOutputDir.Text, System.IO.Path.GetFileName(filepath));

                    outdir = frmMain.Instance.cmbOutputDir.Text;
                }

                //string args = string.Format("/e, /select, \"{0}\"", outfilepath);
                /*
                string args = string.Format("/e, /select, \"{0}\"", outdir);
                ProcessStartInfo info = new ProcessStartInfo();
                info.FileName = "explorer";
                info.UseShellExecute = true;
                info.Arguments = args;
                Process.Start(info);
                */

                System.Diagnostics.Process.Start(outdir);
            }

            /*
            string outfolder = "";

            if (cmbOutputFolder.Text == TranslateHelper.Translate("Same as Document Folder"))
            {
                if (dgFiles.SelectedRows.Count == 0)
                {
                    Module.ShowMessage("Please select a PDF Document first !");
                    return;
                }

                string filepath = dgFiles.SelectedRows[0].Cells["colFullFilePath"].Value.ToString();
                outfolder = System.IO.Path.GetDirectoryName(filepath);

            }
            else if (cmbOutputFolder.Text.Trim() == string.Empty || !System.IO.Directory.Exists(cmbOutputFolder.Text))
            {
                Module.ShowMessage("Please specify a valid Output Folder !");
                return;
            }
            else
            {
                outfolder = cmbOutputFolder.Text;
            }
            
            //string args = string.Format("/e, /select, \"{0}\"", txtOutputFolder.Text);
            string args = string.Format("\"{0}\"", outfolder);
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "explorer";
            info.UseShellExecute = true;
            info.Arguments = args;
            Process.Start(info);
            */
        }

        private void rdDimensionsOther_CheckedChanged(object sender, EventArgs e)
        {
            txtDimensionsH.Visible = rdDimensionsOther.Checked;
            txtDimensionsW.Visible = rdDimensionsOther.Checked;
            lblDimensions.Visible = rdDimensionsOther.Checked;
                        
        }

        private bool IsDragging = false;

        private void dgFiles_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                string[] filez = (string[])e.Data.GetData(DataFormats.FileDrop);

                for (int k = 0; k < filez.Length; k++)
                {
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        AddFile(filez[k]);
                    }
                    finally
                    {
                        this.Cursor = null;
                    }
                }
            }

        }

        private void dgFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                IsDragging = true;
                e.Effect = DragDropEffects.All;

            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

        }

        private void dgFiles_DragOver(object sender, DragEventArgs e)
        {
            IsDragging = true;
            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void dgFiles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgFiles_CellContentDoubleClick(null, null);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnOutputFormatMore_Click(object sender, EventArgs e)
        {
            frmOutputFormatSelect f = new frmOutputFormatSelect();

            if (f.ShowDialog() == DialogResult.OK)
            {
                SelectedOutputFormatCode = f.SelectedOutputFormatCode;
                SelectedOutputFormatExtension = f.SelectedOutputFormatExtension;

                bool found = false;

                for (int k=0;k<cmbOutputFormat.Items.Count;k++)
                {
                    if (cmbOutputFormat.Items[k].ToString()== f.SelectedOutputFormat)
                    {
                        cmbOutputFormat.SelectedIndex = k;
                        found = true;
                        break;
                    }

                }

                if (!found)
                {
                    cmbOutputFormat.Items.Add(f.SelectedOutputFormat);
                    cmbOutputFormatCodes.Add(f.SelectedOutputFormatCode);
                    cmbOutputFormatExtension.Add(f.SelectedOutputFormatExtension);

                    cmbOutputFormat.SelectedIndex = cmbOutputFormat.Items.Count - 1;
                }

                //cmbOutputFormat.Text = f.SelectedOutputFormat;
            }
        }
        public void EnableDisableForm(bool enable)
        {
            foreach (Control co in this.Controls)
            {
                co.Enabled = enable;
            }
        }

        private void cmbOutputFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedOutputFormatCode = cmbOutputFormatCodes[cmbOutputFormat.SelectedIndex];
            SelectedOutputFormatExtension = cmbOutputFormatExtension[cmbOutputFormat.SelectedIndex];

        }

        public void tsbConvert_Click_1(object sender, EventArgs e)
        {
            try
            {
                //=========

                Properties.Settings.Default.ExploreOutputFolder = exploreOutputFolderWhenDoneToolStripMenuItem.Checked;

                Properties.Settings.Default.KeepCreationDate = keepCreationDateToolStripMenuItem.Checked;

                Properties.Settings.Default.KeepLastModificationDate = keepLastModificationDateToolStripMenuItem.Checked;

                Properties.Settings.Default.ShowMessageOnSucess = showMessageOnSucessToolStripMenuItem.Checked;

                toolStrip1.Enabled = false;

                EnableDisableForm(false);

                string errstr = PDFToJPGHelper.Convert();

                if (errstr==null)
                {
                    return;
                }

                EnableDisableForm(true);

                if (PDFToJPGHelper.CANCELLED)
                {
                    Module.ShowMessage("Operation Cancelled !");
                }
                else
                {
                    if (errstr == String.Empty)
                    {
                        if (Properties.Settings.Default.ShowMessageOnSucess)
                        {
                            Module.ShowMessage("Operation completed successfully !");
                        }
                    }
                    else
                    {
                        if (!Module.IsCommandLine)
                        {
                            frmError f = new frmError(TranslateHelper.Translate("Operation completed with Errors !"), errstr);
                            f.ShowDialog();
                        }
                        else
                        {
                            Module.ShowMessage(TranslateHelper.Translate("Operation completed with Errors !")+"\n\n"+ errstr);
                        }
                    }

                    if (!Module.IsCommandLine)
                    {
                        if (Properties.Settings.Default.ExploreOutputFolder)
                        {
                            ExploreFirstOutputFile();
                        }
                    }

                }
            }
            finally
            {
                EnableDisableForm(true);

                toolStrip1.Enabled = true;
            }
        }

        private void ExploreFirstOutputFile()
        {
            string args = string.Format("/e, /select, \"{0}\"", PDFToJPGHelper.FirstOutputFilepath);

            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "explorer";
            info.UseShellExecute = true;
            info.Arguments = args;
            Process.Start(info);
        }

        private void rd800600_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rd1024768_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rd12801024_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateHelper.CheckVersion(false);
        }

        private void AdjustSizeLocation()
        {
            if (Properties.Settings.Default.Maximized)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {

                if (Properties.Settings.Default.Width == -1)
                {
                    this.CenterToScreen();
                    return;
                }
                else
                {
                    this.Width = Properties.Settings.Default.Width;
                }
                if (Properties.Settings.Default.Height != 0)
                {
                    this.Height = Properties.Settings.Default.Height;
                }

                if (Properties.Settings.Default.Left != -1)
                {
                    this.Left = Properties.Settings.Default.Left;
                }

                if (Properties.Settings.Default.Top != -1)
                {
                    this.Top = Properties.Settings.Default.Top;
                }

                if (this.Width < 300)
                {
                    this.Width = 300;
                }

                if (this.Height < 300)
                {
                    this.Height = 300;
                }

                if (this.Left < 0)
                {
                    this.Left = 0;
                }

                if (this.Top < 0)
                {
                    this.Top = 0;
                }

            }

        }

        private void SaveSizeLocation()
        {
            Properties.Settings.Default.Maximized = (this.WindowState == FormWindowState.Maximized);
            Properties.Settings.Default.Left = this.Left;
            Properties.Settings.Default.Top = this.Top;
            Properties.Settings.Default.Width = this.Width;
            Properties.Settings.Default.Height = this.Height;
            Properties.Settings.Default.Save();

        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSizeLocation();

            Properties.Settings.Default.OutputFolderIndex = cmbOutputDir.SelectedIndex;

            Properties.Settings.Default.Resolution = nudDPI.Value;
            Properties.Settings.Default.JPEGQuality = nudQuality.Value;
            Properties.Settings.Default.FitPage = chkFitPage.Checked;
            Properties.Settings.Default.OneImage = chkOneImage.Checked;

            if (rdDimensionsAsIs.Checked)
            {
                Properties.Settings.Default.OutputDimensionsIndex = 0;
            }
            else if (rd800600.Checked)
            {
                Properties.Settings.Default.OutputDimensionsIndex = 1;
            }
            else if (rd1024768.Checked)
            {
                Properties.Settings.Default.OutputDimensionsIndex = 2;
            }
            else if (rd12801024.Checked)
            {
                Properties.Settings.Default.OutputDimensionsIndex = 3;
            }
            else if (rdDimensionsOther.Checked)
            {
                Properties.Settings.Default.OutputDimensionsIndex = 4;
            }

            Properties.Settings.Default.OutputDimensionsOther1Y = txtDimensionsH.Text;

            Properties.Settings.Default.OutputDimensionsOther1X = txtDimensionsW.Text;

            Properties.Settings.Default.OutputFormatCode = SelectedOutputFormatCode;
            Properties.Settings.Default.OutputFormatExtension = SelectedOutputFormatExtension;
            Properties.Settings.Default.OutputFormat = cmbOutputFormat.Text;

            Properties.Settings.Default.CheckWeek = checkForNewVersionEachWeekToolStripMenuItem.Checked;

            //=========

            Properties.Settings.Default.ExploreOutputFolder = exploreOutputFolderWhenDoneToolStripMenuItem.Checked;

            Properties.Settings.Default.KeepCreationDate = keepCreationDateToolStripMenuItem.Checked;

            Properties.Settings.Default.KeepLastModificationDate = keepLastModificationDateToolStripMenuItem.Checked;

            Properties.Settings.Default.ShowMessageOnSucess = showMessageOnSucessToolStripMenuItem.Checked;

            Properties.Settings.Default.Save();
        }

        private void bwProgress_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //MessageBox.Show("PROGRESS CHANGED");

            if ((frmProgress.Instance.progressBar1.Value + 1) < frmProgress.Instance.progressBar1.Maximum)
            {
                frmProgress.Instance.progressBar1.Value += 1;
            }
        }

        #region Share

        private void tsiFacebook_Click(object sender, EventArgs e)
        {
            ShareHelper.ShareFacebook();
        }

        private void tsiTwitter_Click(object sender, EventArgs e)
        {
            ShareHelper.ShareTwitter();
        }

        private void tsiGooglePlus_Click(object sender, EventArgs e)
        {
            ShareHelper.ShareGooglePlus();
        }

        private void tsiLinkedIn_Click(object sender, EventArgs e)
        {
            ShareHelper.ShareLinkedIn();
        }

        private void tsiEmail_Click(object sender, EventArgs e)
        {
            ShareHelper.ShareEmail();
        }

        #endregion

        private void tsdbImportList_ButtonClick(object sender, EventArgs e)
        {
            ImportListHelper.SilentAddErr = "";

            openFileDialog1.Filter = "Text Files (*.txt)|*.txt|CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ImportListHelper.ImportList(openFileDialog1.FileName);
                RecentFilesHelper.ImportListRecent(openFileDialog1.FileName);

                if (ImportListHelper.SilentAddErr != string.Empty)
                {
                    frmError f = new frmError(TranslateHelper.Translate("An error occured while Importing the List !"), ImportListHelper.SilentAddErr);
                    f.ShowDialog();                    
                }
            }
        }

        private void tsdbAddFile_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                AddFile(e.ClickedItem.Text);
                RecentFilesHelper.AddRecentFile(e.ClickedItem.Text);

            }
            finally
            {
                this.Cursor = null;
            }
        }
        
        private void tsdbAddFolder_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            AddFolder(e.ClickedItem.Text, "");
            RecentFilesHelper.AddRecentFolder(e.ClickedItem.Text);
        }

        private void tsdbImportList_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ImportListHelper.SilentAddErr = "";

            ImportListHelper.ImportList(e.ClickedItem.Text);
            RecentFilesHelper.ImportListRecent(e.ClickedItem.Text);

            if (ImportListHelper.SilentAddErr != string.Empty)
            {
                frmError f = new frmError(TranslateHelper.Translate("An error occured while Importing the List !"), ImportListHelper.SilentAddErr);
                f.ShowDialog();
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            Point p = dgFiles.PointToClient(new Point(Control.MousePosition.X, Control.MousePosition.Y));
            DataGridView.HitTestInfo hit = dgFiles.HitTest(p.X, p.Y);

            if (hit.Type == DataGridViewHitTestType.Cell)
            {
                dgFiles.CurrentCell = dgFiles.Rows[hit.RowIndex].Cells[hit.ColumnIndex];
            }

            if (dgFiles.CurrentRow == null)
            {
                e.Cancel = true;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgFiles.CurrentRow == null) return;

            System.Diagnostics.Process.Start(dgFiles.CurrentRow.Cells["colFullFilepath"].Value.ToString());


        }

        private void exploreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgFiles.CurrentRow == null) return;

            string filepath = dgFiles.CurrentRow.Cells["colFullFilepath"].Value.ToString();

            string args = string.Format("/e, /select, \"{0}\"", filepath);
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "explorer";
            info.UseShellExecute = true;
            info.Arguments = args;
            Process.Start(info);

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgFiles_CellContentDoubleClick(null, null);
        }

        private void cmbOutputDir_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if (cmbOutputDir.SelectedIndex == 3)
            {
                Module.ShowMessage("Please specify another option as the Output Folder !");
                cmbOutputDir.SelectedIndex = Properties.Settings.Default.OutputFolderIndex;
            }
            else if (cmbOutputDir.SelectedIndex == 1)
            {
                frmOutputSubFolder fob = new frmOutputSubFolder();

                if (fob.ShowDialog() == DialogResult.OK)
                {
                    OutputFolderHelper.SaveOutputFolder(TranslateHelper.Translate("Subfolder") + " : " + fob.txtSubfolder.Text);
                }
                else
                {
                    return;
                }
            }
            
        }

        private void setUpdateProxyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process pr = new System.Diagnostics.Process();
            pr.StartInfo.FileName = Application.StartupPath + "\\4dotsLanguageDownloader.exe";
            pr.StartInfo.Arguments = "-setproxy";
            pr.Start();

            System.Threading.Thread.Sleep(300);

            while (!pr.HasExited)
            {
                Application.DoEvents();
            }

            if (pr.ExitCode != 0)
            {
                Module.ShowMessage("Error Could not set Update Proxy !");
            }
        }

        private void dotsSoftwarePRODUCTCATALOGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.4dots-software.com/downloads/4dots-Software-PRODUCT-CATALOG.pdf");
        }

        private void followUsOnTwitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.twitter.com/4dotsSoftware");
        }

        private void pleaseDonateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.4dots-software.com/donate.php");
        }

        private void keepFolderStructureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            keepFolderStructureToolStripMenuItem.Checked = !keepFolderStructureToolStripMenuItem.Checked;

            Properties.Settings.Default.KeepFolderStructure = keepFolderStructureToolStripMenuItem.Checked;
        }        
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int k=0;k<dgFiles.Rows.Count;k++)
            {
                dgFiles.Rows[k].Selected = true;
            }
        }

        private void selectNoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int k = 0; k < dgFiles.Rows.Count; k++)
            {
                dgFiles.Rows[k].Selected = false;
            }
        }

        private void invertSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int k = 0; k < dgFiles.Rows.Count; k++)
            {
                dgFiles.Rows[k].Selected = !dgFiles.Rows[k].Selected;
            }
        }

        private void enterFileListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string txt = "";

            for (int k = 0; k < dt.Rows.Count; k++)
            {
                txt += dt.Rows[k]["fullfilepath"].ToString() + "\r\n";
            }

            frmMultipleFiles f = new frmMultipleFiles(false, txt);

            if (f.ShowDialog() == DialogResult.OK)
            {
                dt.Rows.Clear();

                for (int k = 0; k < f.txtFiles.Lines.Length; k++)
                {
                    if (System.IO.File.Exists(f.txtFiles.Lines[k].Trim()))
                    {
                        AddFile(f.txtFiles.Lines[k].Trim());
                    }
                    else if (System.IO.Directory.Exists(f.txtFiles.Lines[k].Trim()))
                    {
                        AddFolder(f.txtFiles.Lines[k].Trim());
                    }
                }
            }

        }

        private void saveFileListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            if (dt.Rows.Count == 0)
            {
                Module.ShowMessage("Current Selection is Empty !");
                return;
            }

            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "Text Files (*.txt)|*.txt";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName, false, Encoding.Default))
                {
                    for (int k = 0; k < dt.Rows.Count; k++)
                    {
                        sw.WriteLine(dt.Rows[k]["fullfilepath"].ToString());
                    }
                }
            }

        }

        private void importListFromExcelFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Excel Files (*.xls;*.xlsx;*.xlt)|*.xls;*.xlsx;*.xlt";
            openFileDialog1.Multiselect = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ExcelImporter xl = new ExcelImporter();
                xl.ImportListExcel(openFileDialog1.FileName);
            }
        }

        private void youtubeChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/channel/UCovA-lld9Q79l08K-V1QEng");
        }

        private void tryOnlineVersionAtOnlinepdfappscomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://onlinepdfapps.com");
        }

        private void commandLineArgumentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMessage fm = new frmMessage(true);
            fm.ShowDialog(this);
        }
    }
}
