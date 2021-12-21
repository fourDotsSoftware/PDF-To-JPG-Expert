using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace PDFToJPGExpert
{ 
    class ArgsHelper
    {        
        public static bool ExamineArgs(string[] args)
        {
            if (args.Length == 0) return true;
                        
            Module.args = args;

            try
            {
                if (args[0].ToLower().Trim().StartsWith("-tempfile:"))
                {                                       
                    string tempfile = GetParameter(args[0]);

                    //MessageBox.Show(tempfile);

                    using (StreamReader sr = new StreamReader(tempfile, Encoding.Unicode))
                    {
                        string scont = sr.ReadToEnd();

                        //args = scont.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                        args = SplitArguments(scont);
                        Module.args = args;

                        // MessageBox.Show(scont);
                    }
                }
                else if (args.Length>0 && (Module.args.Length==1 && (System.IO.File.Exists(Module.args[0]) || System.IO.Directory.Exists(Module.args[0]))))
                {

                }
                else
                {
                    Module.IsCommandLine = true;

                    //"PDFToJPGExpert.exe [[file|directory]]\n" +
                    //"[/password:APPLICATION_PASSWORD]\n" +
                    //"[/pagerange:PAGE_RANGE_VALUE]\n" +
                    //"[/resolution:RESOLUTION_VALUE]\n" +
                    //"[/quality:JPEG_QUALITY_VALUE]\n" +
                    //"[/fitpage:True|False]\n" +
                    //"[/oneimage:True|False]\n" +
                    //"[/asis]\n" +
                    //"[/width800]\n" +
                    //"[/width1024]\n" +
                    //"[/width1280\n" +
                    //"[/width:WIDTH_VALUE\n" +
                    //"[/height:HEIGHT_VALUE\n" +
                    //"[/listcodes]\n" +
                    //"[/outputformat:OUTPUT_FORMAT_CODE]\n" +
                    //"[/keepstructure:True|False]\n" +
                    //"[/keepcreation:True|False]\n" +
                    //"[/keeplastmod:True|False]\n" +
                    //"[outputfolder:OUTPUT_FOLDER_VALUE]\n" +

                    int width = -1;
                    int height = -1;

                    for (int k = 0; k < Module.args.Length; k++)
                    {
                        if (System.IO.File.Exists(Module.args[k]))
                        {
                            frmMain.Instance.AddFile(Module.args[k]);

                        }
                        else if (System.IO.Directory.Exists(Module.args[k]))
                        {
                            frmMain.Instance.AddFolder(Module.args[k]);

                        }
                        else if (Module.args[k].ToLower().StartsWith("/password:") ||
Module.args[k].ToLower().StartsWith("-password:"))
                        {
                            string pwd = GetParameter(Module.args[k]);

                            for (int m = 0; m < frmMain.Instance.dt.Rows.Count; m++)
                            {
                                frmMain.Instance.dt.Rows[m]["password"] = pwd;
                            }
                        }
                        else if (Module.args[k].ToLower().StartsWith("/pagerange:") ||
Module.args[k].ToLower().StartsWith("-pagerange:"))
                        {
                            string pwd = GetParameter(Module.args[k]);

                            for (int m = 0; m < frmMain.Instance.dt.Rows.Count; m++)
                            {
                                frmMain.Instance.dt.Rows[m]["pagerange"] = pwd;
                            }
                        }
                        else if (Module.args[k].ToLower().StartsWith("/resolution:") ||
        Module.args[k].ToLower().StartsWith("-resolution:"))
                        {
                            string res = GetParameter(Module.args[k]);

                            frmMain.Instance.nudDPI.Value = decimal.Parse(res.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture);
                        }
                        else if (Module.args[k].ToLower().StartsWith("/quality:") ||
Module.args[k].ToLower().StartsWith("-quality:"))
                        {
                            string res = GetParameter(Module.args[k]);

                            frmMain.Instance.nudQuality.Value = decimal.Parse(res.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture);
                        }
                        else if (Module.args[k].ToLower().StartsWith("/outputformat:") ||
Module.args[k].ToLower().StartsWith("-outputformat:"))
                        {
                            string res = GetParameter(Module.args[k]);

                            frmMain.Instance.SelectedOutputFormatCode = res;

                            frmMain.Instance.SelectedOutputFormatExtension = frmOutputFormatSelect.GetExtensionFromOutputFormatCode(res);
                        }
                        else if (Module.args[k].ToLower().StartsWith("/fitpage:") ||
        Module.args[k].ToLower().StartsWith("-fitpage:"))
                        {
                            string res = GetParameter(Module.args[k]);

                            frmMain.Instance.chkFitPage.Checked = bool.Parse(res);
                        }
                        else if (Module.args[k].ToLower().StartsWith("/oneimage:") ||
Module.args[k].ToLower().StartsWith("-oneimage:"))
                        {
                            string res = GetParameter(Module.args[k]);

                            frmMain.Instance.chkOneImage.Checked = bool.Parse(res);
                        }
                        else if (Module.args[k].ToLower().StartsWith("/keepstructure:") ||
Module.args[k].ToLower().StartsWith("-keepstructure:"))
                        {
                            string res = GetParameter(Module.args[k]);

                            frmMain.Instance.keepFolderStructureToolStripMenuItem.Checked = bool.Parse(res);
                        }
                        else if (Module.args[k].ToLower().StartsWith("/keepcreation:") ||
Module.args[k].ToLower().StartsWith("-keepcreation:"))
                        {
                            string res = GetParameter(Module.args[k]);

                            frmMain.Instance.keepCreationDateToolStripMenuItem.Checked = bool.Parse(res);
                        }
                        else if (Module.args[k].ToLower().StartsWith("/keeplastmod:") ||
Module.args[k].ToLower().StartsWith("-keeplastmod:"))
                        {
                            string res = GetParameter(Module.args[k]);

                            frmMain.Instance.keepLastModificationDateToolStripMenuItem.Checked = bool.Parse(res);
                        }
                        else if (Module.args[k].ToLower().StartsWith("/importlist:") ||
Module.args[k].ToLower().StartsWith("-importlist:"))
                        {
                            string res = GetParameter(Module.args[k]);

                            ImportListHelper.ImportList(res);

                            if (ImportListHelper.SilentAddErr!=string.Empty)
                            {
                                Module.ShowMessage(ImportListHelper.SilentAddErr);
                                Environment.Exit(1);
                            }
                        }
                        else if (Module.args[k].ToLower().Trim() == "-asis"
                            || Module.args[k].ToLower().Trim() == "/asis")
                        {
                            frmMain.Instance.rdDimensionsAsIs.Checked = true;
                        }
                        else if (Module.args[k].ToLower().Trim() == "-width800"
                            || Module.args[k].ToLower().Trim() == "/width800")
                        {
                            frmMain.Instance.rd800600.Checked = true;
                        }
                        else if (Module.args[k].ToLower().Trim() == "-width1024"
                            || Module.args[k].ToLower().Trim() == "/width1024")
                        {
                            frmMain.Instance.rd1024768.Checked = true;
                        }
                        else if (Module.args[k].ToLower().Trim() == "-width1280"
                            || Module.args[k].ToLower().Trim() == "/width1280")
                        {
                            frmMain.Instance.rd12801024.Checked = true;
                        }
                        else if (Module.args[k].ToLower().StartsWith("/width:") ||
Module.args[k].ToLower().StartsWith("-width:"))
                        {                            
                            string res = GetParameter(Module.args[k]);
                                                        
                            width = int.Parse(res);
                            
                            if (height==-1)
                            {
                                frmMain.Instance.rdWidth.Checked = true;
                                frmMain.Instance.txtWidth.Text = res;
                            }
                            else
                            {
                                frmMain.Instance.rdDimensionsOther.Checked = true;
                                frmMain.Instance.txtDimensionsW.Text = width.ToString();
                                frmMain.Instance.txtDimensionsH.Text = height.ToString();
                            }
                        }
                        else if (Module.args[k].ToLower().StartsWith("/height:") ||
Module.args[k].ToLower().StartsWith("-height:"))
                        {
                            Module.ShowMessage("b");

                            string res = GetParameter(Module.args[k]);

                            height= int.Parse(res);

                            if (width == -1)
                            {
                                frmMain.Instance.rdHeight.Checked = true;
                                frmMain.Instance.txtHeight.Text = res;
                            }
                            else
                            {
                                frmMain.Instance.rdDimensionsOther.Checked = true;
                                frmMain.Instance.txtDimensionsW.Text = width.ToString();
                                frmMain.Instance.txtDimensionsH.Text = height.ToString();
                            }
                        }                        
                        else if (Module.args[k].ToLower().StartsWith("/outputfolder:") ||
        Module.args[k].ToLower().StartsWith("-outputfolder:"))
                        {
                            string outfolder = GetParameter(Module.args[k]);

                            frmMain.Instance.cmbOutputDir.Text = outfolder;
                            
                        }
                        else if (Module.args[k].ToLower() == "/listcodes" ||
                        Module.args[k].ToLower() == "-listcodes")
                        {
                            Module.ShowMessage(frmOutputFormatSelect.ListOutputFormatCodes());
                            Environment.Exit(1);
                            return true;
                        }
                        else if (Module.args[k].ToLower() == "/h" ||
                        Module.args[k].ToLower() == "-h" ||
                        Module.args[k].ToLower() == "-?" ||
                        Module.args[k].ToLower() == "/?")
                        {
                            ShowCommandUsage();
                            Environment.Exit(1);
                            return true;
                        }
                    }                                      
                }
            }
            catch (Exception ex)
            {
                Module.ShowError("Error could not parse Arguments !", ex.ToString());
                return false;
            }

            return true;
        }

        private static string GetParameter(string arg)
        {
            int spos = arg.IndexOf(":");
            if (spos == arg.Length - 1) return "";
            else
            {
                string str=arg.Substring(spos + 1);

                if ((str.StartsWith("\"") && str.EndsWith("\"")) ||
                    (str.StartsWith("'") && str.EndsWith("'")))
                {
                    if (str.Length > 2)
                    {
                        str = str.Substring(1, str.Length - 2);
                    }
                    else
                    {
                        str = "";
                    }
                }

                return str;
            }
        }

        public static string[] SplitArguments(string commandLine)
        {
            char[] parmChars = commandLine.ToCharArray();
            bool inSingleQuote = false;
            bool inDoubleQuote = false;
            for (int index = 0; index < parmChars.Length; index++)
            {
                if (parmChars[index] == '"' && !inSingleQuote)
                {
                    inDoubleQuote = !inDoubleQuote;
                    parmChars[index] = '\n';
                }
                if (parmChars[index] == '\'' && !inDoubleQuote)
                {
                    inSingleQuote = !inSingleQuote;
                    parmChars[index] = '\n';
                }
                if (!inSingleQuote && !inDoubleQuote && parmChars[index] == ' ')
                    parmChars[index] = '\n';
            }
            return (new string(parmChars)).Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        }
        public static void ShowCommandUsage()
        {
            string msg = GetCommandUsage();

            Module.ShowMessage(msg);

            Environment.Exit(0);
        }
        public static string GetCommandUsage()
        {
            string msg = "Convert PDF Files to Images.\n\n" +
            "PDFToJPGExpert.exe [[file|directory]]\n" +
            "[/password:APPLICATION_PASSWORD]\n" +
            "[/pagerange:PAGE_RANGE_VALUE]\n" +
            "[/resolution:RESOLUTION_VALUE]\n" +
            "[/quality:JPEG_QUALITY_VALUE]\n" +
            "[/fitpage:True|False]\n" +
            "[/oneimage:True|False]\n" +
            "[/asis]\n" +
            "[/width800]\n" +
            "[/width1024]\n" +
            "[/width1280\n" +
            "[/width:WIDTH_VALUE\n" +
            "[/height:HEIGHT_VALUE\n" +
            "[/listcodes]\n" +
            "[/outputformat:OUTPUT_FORMAT_CODE]\n" +
            "[/keepstructure:True|False]\n" +
            "[/keepcreation:True|False]\n" +
            "[/keeplastmod:True|False]\n" +
            "[importlist:IMPORT_LIST_TEXT_FILE]\n" +
            "[outputfolder:OUTPUT_FOLDER_VALUE]\n" +
            "[/?]\n\n\n" +
            "file : one or more files to be processed.\n" +
            "directory : one or more directories containing files to be processed.\n" +
            "password : PDF user password for open.\n" +
            "pagerange : PDF page ranges.\n" +
            "resolution : DPI image resolution.\n" +
            "quality : JPEG quality.\n" +
            "fitpage : Fit page.\n" +
            "oneimage : Create one image as output\n" +
            "asis : keep image dimensions as is.\n" +
            "width800 : output width should be 800 pixels.\n" +
            "width1024 : output width should be 1024 pixels.\n" +
            "width1280 : output width should be 1280 pixels.\n" +
            "width : output width should be WIDTH_VALUE pixels.\n" +
            "height : output height should be HEIGHT_VALUE pixels.\n" +
            "listcodes : list output format codes.\n" +
            "outputformat : select output format from code.\n" +
            "keepstructure : keep folder structure.\n" +
            "keepcreation : keep creation date.\n" +
            "keeplastmod : keep last modification date.\n" +
            "importlist : import PDF file list from text file.\n"+
            "outputfolder : use specfified output folder.\n" +
            "/? : show help\n\n\n" +
            "Example :\n" +
            "PDFToJPGExpert.exe \"c:\\documents\\invoice.pdf\" /password:\"12345\" /asis /outputfomat:png16m /outputfolder:\"c:\\invoiceImages\"\n\n" +
            "PDFToJPGExpert.exe \"c:\\documents\\invoice.pdf\" /width:1024 /height:780 /outputfomat:png16m /outputfolder:\"c:\\invoiceImages\"\n\n" +
            "PDFToJPGExpert.exe /listcodes";
            ;

            return msg;
        }

        //public static bool IsFromFolderWatcher
        //{
        //    get
        //    {                
        //        // new
        //        if (Module.args.Length > 0 && Module.args[0].ToLower().Trim() == "/cmdfw")
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //}

        public static bool IsFromWindowsExplorer
        {
            get
            {
                if (Module.IsFromWindowsExplorer) return true;

                // new
                if (Module.args.Length > 0 && (Module.args[0].ToLower().Trim().Contains("-tempfile:")
                    || (Module.args.Length==1 && (System.IO.File.Exists(Module.args[0]) || System.IO.Directory.Exists(Module.args[0])))))
                {
                    Module.IsFromWindowsExplorer = true;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool IsFromCommandLine
        {
            get
            {
                if (Module.args == null || Module.args.Length == 0)
                {
                    return false;
                }

                if (ArgsHelper.IsFromWindowsExplorer)
                {
                    Module.IsCommandLine = false;
                    return false;
                }
                else
                {
                    Module.IsCommandLine = true;
                    return true;
                }
            }
        }

        /*
        public static bool IsFromWindowsExplorer()
        {
            if (Module.args == null || Module.args.Length == 0)
            {
                return false;
            }

            for (int k = 0; k < Module.args.Length; k++)
            {
                if (Module.args[k] == "-visual")
                {
                    Module.IsFromWindowsExplorer = true;
                    return true;
                }
            }

            Module.IsFromWindowsExplorer = false;
            return false;
        }
        */

        public static void ExecuteCommandLine()
        {
            string err = "";
            bool finished = false;

            try
            {                
                if (frmMain.Instance.dt.Rows.Count == 0)
                {
                    Module.ShowMessage("Please specify Files !");
                    ShowCommandUsage();
                    Environment.Exit(0);
                    return;
                }

                Console.Clear();

                Module.ShowMessage("Please wait...\nPress ^C (Control + C) to cancel operation.");

                Console.CancelKeyPress += Console_CancelKeyPress;

                bwMsg.DoWork += BwMsg_DoWork;
                bwMsg.WorkerReportsProgress = true;
                bwMsg.WorkerSupportsCancellation = true;
                bwMsg.ProgressChanged += BwMsg_ProgressChanged;
                bwMsg.RunWorkerAsync();

                frmMain.Instance.tsbConvert_Click_1(null, null);

                bwMsg.CancelAsync();

                Application.Exit();                             
            }
            finally
            {
                
            }
            Environment.Exit(0);
        }

        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            Console.WriteLine("Operation cancelled !");

            try
            {
                //3frmMain.Instance.OperationStopped = true;
            }
            catch { }

            Environment.Exit(1);
        }

        private static void BwMsg_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            Console.Write(".");
        }

        private static void BwMsg_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (true)
            {
                if (bwMsg.CancellationPending)
                {
                    return;
                }
                else
                {
                    bwMsg.ReportProgress(0);
                    System.Threading.Thread.Sleep(1500);
                }
            }
        }

        public static System.ComponentModel.BackgroundWorker bwMsg = new System.ComponentModel.BackgroundWorker();





    }

    public class ReadListsResult
    {
        public bool Success = true;
        public string err = "";
    }
}
