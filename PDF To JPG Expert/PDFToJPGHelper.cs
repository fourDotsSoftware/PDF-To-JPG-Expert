using System;
using System.Collections.Generic;
using System.Text;
using PdfToImage;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;

namespace PDFToJPGExpert
{
    class PDFToJPGHelper
    {
        //static BackgroundWorker bwProcess = null;
        static int CurrentPage = 0;
        public static string CurrentProcessingFilepathWithoutExtension = "";
        public static string CurrentProcessingFileExtension = "";
        public static string FirstOutputFilepath = "";

        public static PDFConvert LastConvert = null;
        public static bool CANCELLED = false;

        public static string errstr="";

        public static string CurrentInputFile = "";
        
        public static string Convert()
        {
            //bwProcess=new BackgroundWorker();
            //bwProcess.DoWork += bwProcess_DoWork;
            //bwProcess.RunWorkerCompleted += bwProcess_RunWorkerCompleted;

            errstr = "";
            CANCELLED = false;

            FirstOutputFilepath = "";

            string outformat = frmMain.Instance.SelectedOutputFormatCode;
            string outext = frmMain.Instance.SelectedOutputFormatExtension;

            int idpi = (int)frmMain.Instance.nudDPI.Value;
            int iquality = (int)frmMain.Instance.nudQuality.Value;

            int iwidth = 0;
            int iheight = 0;

            if (frmMain.Instance.rd1024768.Checked)
            {
                iwidth = 1024;
                //iheight = 768;
            }
            else if (frmMain.Instance.rd12801024.Checked)
            {
                iwidth = 1280;
                //iheight = 1024;
            }
            else if (frmMain.Instance.rd800600.Checked)
            {
                iwidth = 800;
                //iheight = 600;
            }
            else if (frmMain.Instance.rdWidth.Checked)
            {
                try
                {
                    iwidth = int.Parse(frmMain.Instance.txtWidth.Text);

                    if (iwidth <= 0)
                    {
                        throw new Exception("error");
                    }
                }
                catch
                {
                    frmMain.Instance.EnableDisableForm(true);

                    Module.ShowMessage("Error.Please specify a valid Width !");
                    return null;
                }
            }
            else if (frmMain.Instance.rdHeight.Checked)
            {
                try
                {
                    iheight = int.Parse(frmMain.Instance.txtHeight.Text);

                    if (iheight <= 0)
                    {
                        throw new Exception("error");
                    }
                }
                catch
                {
                    frmMain.Instance.EnableDisableForm(true);

                    Module.ShowMessage("Error.Please specify a valid Height !");
                    return null;
                }
            }
            else if (frmMain.Instance.rdDimensionsOther.Checked)
            {
                try
                {
                    iwidth = int.Parse(frmMain.Instance.txtDimensionsW.Text);

                    if (iwidth<=0)
                    {
                        throw new Exception("error");
                    }
                }
                catch (Exception exw)
                {
                    frmMain.Instance.EnableDisableForm(true);

                    Module.ShowMessage("1Error.Please specify a valid Width !"+exw.ToString());
                    return null;
                }

                try
                {
                    iheight = int.Parse(frmMain.Instance.txtDimensionsH.Text);

                    if (iheight <= 0)
                    {
                        throw new Exception("error");
                    }
                }
                catch
                {
                    frmMain.Instance.EnableDisableForm(true);

                    Module.ShowMessage("Error.Please specify a valid Height !");
                    return null;
                }
            }

            if ((iwidth==0 && iheight!=0) || (iwidth!=0 && iheight==0))
            {
                if (outformat!= "png16m" && outformat!= "jpeg" && outformat!= "bmp16m")
                {
                    frmMain.Instance.EnableDisableForm(true);

                    Module.ShowMessage("This Output Dimension Option is available only for Output Formats \"PNG\", \"JPEG\" or \"BMP\"");
                    return null;
                }
            }

            if (frmMain.Instance.cmbOutputDir.Text.Trim() != TranslateHelper.Translate("Same as Document Folder")
              && (frmMain.Instance.cmbOutputDir.Text.StartsWith(TranslateHelper.Translate("Subfolder")))
                && (frmMain.Instance.cmbOutputDir.Text.StartsWith("======")))
            {
                if (!System.IO.Directory.Exists(frmMain.Instance.cmbOutputDir.Text))
                {
                    frmMain.Instance.EnableDisableForm(true);

                    Module.ShowMessage("Please specify a valid Output Folder !");
                    return null;                    
                }
            }

            if (frmMain.Instance.cmbOutputDir.Text.Trim() != TranslateHelper.Translate("Same as Document Folder")
              && (!frmMain.Instance.cmbOutputDir.Text.StartsWith(TranslateHelper.Translate("Subfolder")))
                && (!frmMain.Instance.cmbOutputDir.Text.StartsWith("======")))
            {
                try
                {
                    if (!System.IO.Directory.Exists(frmMain.Instance.cmbOutputDir.Text))
                    {
                        System.IO.Directory.CreateDirectory(frmMain.Instance.cmbOutputDir.Text);
                    }
                }
                catch
                {
                    frmMain.Instance.EnableDisableForm(true);

                    Module.ShowMessage("Please specify a valid Output Folder !");
                    return null;
                }
            }
            DataTable dt = frmMain.Instance.dt;

            int itotalpages = 0;                                              

            List<Object> lstpar=new List<Object>();
            List<string> filepaths = new List<string>();
            List<string> outfolders = new List<string>();

            for (int k = 0; k < dt.Rows.Count; k++)
            {
            startfor:

                string filepath = "";
                filepaths.Add("");
                outfolders.Add("");
                lstpar.Add(null);

                if (!string.IsNullOrEmpty(dt.Rows[k]["password"].ToString()))
                {
                    filepath = dt.Rows[k]["decryptedfile"].ToString();
                }
                else
                {
                    filepath = dt.Rows[k]["fullfilepath"].ToString();
                }

                CurrentInputFile = filepath;

                if (!System.IO.File.Exists(filepath))
                {
                    errstr += TranslateHelper.Translate("PDF Document does not exist !") + " : " + dt.Rows[k]["fullfilepath"].ToString()+"\n\n";
                    continue;
                }

                string rootfolder = dt.Rows[k]["rootfolder"].ToString();

                string outfolder = "";

                string OutputDir = frmMain.Instance.cmbOutputDir.Text;
                                
                if (OutputDir.Trim() == TranslateHelper.Translate("Same Folder of PDF Document"))
                {
                    string dirpath = System.IO.Path.GetDirectoryName(filepath);
                    outfolder = dirpath;
                }
                else if (OutputDir.StartsWith(TranslateHelper.Translate("Subfolder") + " : "))
                {
                    int subfolderspos = (TranslateHelper.Translate("Subfolder") + " : ").Length;
                    string subfolder = OutputDir.Substring(subfolderspos);
                                        
                    outfolder = System.IO.Path.GetDirectoryName(filepath) + "\\" + subfolder;

                    if (!System.IO.Directory.Exists(outfolder))
                    {
                        try
                        {
                            System.IO.Directory.CreateDirectory(outfolder);
                        }
                        catch
                        {
                            errstr += TranslateHelper.Translate("Error could not create Directory") + " : " + outfolder;
                        }
                    }
                }                
                else
                {
                    if (rootfolder != string.Empty && Properties.Settings.Default.KeepFolderStructure)
                    {
                        string dep = System.IO.Path.GetDirectoryName(filepath).Substring(rootfolder.Length);

                        string outdfp = OutputDir + dep;                        

                        if (!System.IO.Directory.Exists(outdfp))
                        {
                            System.IO.Directory.CreateDirectory(outdfp);
                        }

                        outfolder = outdfp;
                    }
                    else
                    {
                        outfolder = OutputDir;
                    }
                }                               

                if (!outfolder.EndsWith("\\"))
                {
                    outfolder += "\\";
                }

                filepaths[k] = filepath;
                outfolders[k] = outfolder;

                List<PageRange> lst = new List<PageRange>();

                if (dt.Rows[k]["pagerange"].ToString() == TranslateHelper.Translate("All Pages"))
                {
                    lst.Add(new PageRange(1, (int)dt.Rows[k]["totalpages"]));
                }
                else
                {
                    string[] str = dt.Rows[k]["pagerange"].ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                    for (int m = 0; m < str.Length; m++)
                    {
                        int epos = str[m].IndexOf("-");
                        try
                        {
                            int ifrom = int.Parse(str[m].Substring(0, epos));
                            int ito = int.Parse(str[m].Substring(epos + 1));

                            lst.Add(new PageRange(ifrom, ito));

                        }
                        catch
                        {
                            errstr += TranslateHelper.Translate("Please specify a valid Page Range for PDF Document") + " : " + dt.Rows[k]["fullfilepath"].ToString() + "\n\n";
                            filepaths[k] = "";
                            k++;
                            goto startfor;
                        }
                    }
                }

                for (int m = 0; m < lst.Count; m++)
                {
                    int ipages = lst[m].To - lst[m].From;

                    if (frmMain.Instance.chkOneImage.Checked)
                    {
                        // one image for the whole document
                        itotalpages++;
                    }
                    else
                    {
                        itotalpages += ipages;
                    }
                }

                lstpar[k] = lst;
            }

            //MessageBox.Show("TOTAL PAGES="+itotalpages.ToString());
               
                
                //frmProgress.Instance.progressBar1.Maximum = itotalpages;

                /*
                for (int m = 0; m < lst.Count; m++)
                {                    
                    GhostscriptPngDevice dev = new GhostscriptPngDevice(GhostscriptPngDeviceType.Png16m);
                    dev.GraphicsAlphaBits = GhostscriptImageDeviceAlphaBits.V_4;
                    dev.TextAlphaBits = GhostscriptImageDeviceAlphaBits.V_4;
                    dev.ResolutionXY = new GhostscriptImageDeviceResolution(96, 96);
                    dev.InputFiles.Add(dt.Rows[k]["filename"].ToString());
                    dev.Pdf.FirstPage = lst[m].From;
                    dev.Pdf.LastPage = lst[m].To + 1;
                    dev.OutputPath = System.IO.Path.Combine(outfolder, dt.Rows[k]["filename"] + "." + m.ToString() + "%03d." + outext);

                    //@"E:\gss_test\output\indispensable_color_page_%03d.png";

                    bwProcess.RunWorkerAsync(dev);

                    int lastpage = CurrentPage;

                    while (bwProcess.IsBusy)
                    {
                        if (CurrentPage != lastpage)
                        {
                            MessageBox.Show(CurrentPage.ToString());
                            lastpage = CurrentPage;
                        }

                        Application.DoEvents();
                    }

                    
                   
                }
                */

            bool progress_initiated = false;                       

            for (int k=0;k<lstpar.Count;k++)
            {
                if (CANCELLED)
                {
                    break;
                }

                if (filepaths[k] != string.Empty)
                {
                    try
                    {
                        if (!progress_initiated)
                        {
                            progress_initiated = true;
                            frmProgress f = new frmProgress();
                            f.progressBar1.Maximum = itotalpages;
                            f.TimValue = 0;
                            f.timProgress.Enabled = true;
                            
                        }

                        List<PageRange> lst = (List<PageRange>)lstpar[k];

                        for (int m = 0; m < lst.Count; m++)
                        {
                            if (CANCELLED)
                            {
                                break;
                            }

                            PDFConvert con = new PDFConvert();
                            LastConvert = con;

                            string firstpage = "";

                            if (frmMain.Instance.chkOneImage.Checked)
                            {
                                con.OutputToMultipleFile = false;
                            }
                            else
                            {
                                con.OutputToMultipleFile = true;
                                //firstpage = lst[m].From.ToString();
                                firstpage = "1";
                            }

                            con.FitPage = frmMain.Instance.chkFitPage.Checked;

                            con.OutputFormat = outformat;
                            
                            con.ResolutionX = idpi;
                            con.ResolutionY = idpi;
                            

                            con.FirstPageToConvert = lst[m].From;
                            con.LastPageToConvert = lst[m].To;
                            
                            con.JPEGQuality = iquality;

                            if ((iwidth == 0 && iheight != 0) || (iwidth != 0 && iheight == 0))
                            {

                            }
                            else  if (!(iwidth == 0 && iheight == 0))
                            {
                                con.Width = iwidth;
                                con.Height = iheight;
                            }                                                        
                            
                            /*                            
                            if (iwidth!=0)
                            {
                                con.Width = iwidth;
                            }
                            else
                            {
                                con.Width = 0;
                            }

                            if (iheight!=0)
                            {
                                con.Height = iheight;
                            }
                            else
                            {
                                con.Height = 0;
                            }
                            */

                            CurrentProcessingFilepathWithoutExtension = System.IO.Path.Combine(outfolders[k], dt.Rows[k]["filename"] + "." + m.ToString());
                            CurrentProcessingFileExtension = "." + outext;                            

                            frmMain.fs.Path = outfolders[k];                                                        
                            frmMain.fs.NotifyFilter = System.IO.NotifyFilters.FileName | System.IO.NotifyFilters.Size;
                            frmMain.fs.Filter = "*.*";
                            frmMain.fs.EnableRaisingEvents = true;

                            string outfile=System.IO.Path.Combine(outfolders[k], dt.Rows[k]["filename"] + "." + m.ToString() + "." + outext);

                            if (FirstOutputFilepath == string.Empty)
                            {
                                //1FirstOutputFilepath = System.IO.Path.Combine(outfolders[k], dt.Rows[k]["filename"] + ".01." + outext);
                                FirstOutputFilepath = System.IO.Path.Combine(outfolders[k], dt.Rows[k]["filename"] + "." + m.ToString() + firstpage + "." + outext);
                            }

                            frmMain.Instance.bwProgress.RunWorkerAsync(new PDFConvertArgs(con,filepaths[k],outfile,iwidth,iheight,outformat,iquality));                                                         

                            while (frmMain.Instance.bwProgress.IsBusy)
                            {
                                Application.DoEvents();
                            }                            
                        }
                    }
                    catch (Exception exf)
                    {
                        errstr += TranslateHelper.Translate("Error while converting file") + ": " + dt.Rows[k]["filename"] + "\r\n" + exf.Message+"\r\n";
                    }
                }                                
            }

            if (!Module.IsCommandLine)
            {
                if (frmProgress.Instance != null)
                {
                    frmProgress.Instance.Close();
                }
            }

            while (frmMain.Instance.bwProgress.CancellationPending)
            {
                Application.DoEvents();
            }

            return errstr;
        }

        /*
        static void bwProcess_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
        }

        static void bwProcess_DoWork(object sender, DoWorkEventArgs e)
        {
            
            GhostscriptDevice dev = (GhostscriptDevice)e.Argument;
            dev.Process();
           
           
        }*/
    }

    public class PDFConvertArgs
    {
        public PDFConvert con = null;
        public string InputFile = "";
        public string OutFile = "";
        public int iwidth = 0;
        public int iheight = 0;
        public string outputFormatCode = "";
        public int jpegQuality = 0;

        public PDFConvertArgs(PDFConvert mcon,string mInputFile,string mOutFile,int mwidth,int mheight,string moutputFormatCode,int mjpegQuality)
        {
            con = mcon;
            InputFile = mInputFile;
            OutFile = mOutFile;

            iwidth = mwidth;
            iheight = mheight;
            outputFormatCode = moutputFormatCode;
            jpegQuality = mjpegQuality;
        }

    }
    public class ProgressBarArgs
    {              
        public int TotalPages = 0;        
        public string OutFolder = "";

        public ProgressBarArgs()
        {

        }
    }

    public class PageRange
    {
        public int From = 0;
        public int To = 0;

        public PageRange(int ifrom, int ito)
        {
            From = ifrom;
            To = ito;
        }
    }
}
