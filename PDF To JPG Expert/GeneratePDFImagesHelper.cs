using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.factories;
using System.Windows.Forms;

namespace PDFToJPGExpert
{
    public class GetPDFTotalPagesResult
    {
        public string ErrStr = "";
        public int TotalPages = -1;
        public string DecryptedFile = "";
        public string Password = "";

    }
    public class GeneratePDFImagesHelper
    {
        private static string DefaultPassword = "";

        public static GetPDFTotalPagesResult GetPDFTotalPages(string InputFile,string Password)
        {            
            PdfReader reader = null;
            iTextSharp.text.pdf.PdfStamper stamper = null;
            string tmpfile = string.Format("{0}\\{1}.{2}", System.IO.Path.GetTempPath(), System.DateTime.Now.ToString("yyyyMMddHHmmss") + System.DateTime.Now.Millisecond.ToString(), "pdf");

            GetPDFTotalPagesResult res = new GetPDFTotalPagesResult();

            while (true)
            {
                using (Stream input = new FileStream(InputFile, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    try
                    {
                        if (!String.IsNullOrEmpty(Password))
                        {
                            reader = new PdfReader(input, Encoding.Default.GetBytes(Password));
                            //reader = new PdfReader(input, Encoding.UTF8.GetBytes(Password));

                        }
                        else
                        {
                            reader = new PdfReader(input);
                        }

                        break;
                    }
                    catch (iTextSharp.text.pdf.BadPasswordException ex)
                    {
                        if (reader != null)
                        {
                            reader.Close();
                        }

                        if (input != null)
                        {
                            input.Close();
                        }

                        //frmMain.Instance.backgroundWorker1.CancelAsync();

                        //while (frmMain.Instance.backgroundWorker1.IsBusy)
                        //{
                        //Application.DoEvents();
                        //}

                        if (string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(DefaultPassword))
                        {
                            Password = DefaultPassword;
                        }
                        else
                        {
                            Module.ShowMessage("Please enter the correct User Password !");

                            frmPassword f2 = new frmPassword(InputFile);

                            DialogResult dres = f2.ShowDialog();

                            //frmMain.Instance.backgroundWorker1.RunWorkerAsync();

                            if (dres == DialogResult.OK)
                            {
                                Password = f2.txtPassword.Text;

                                if (f2.chkPassword.Checked)
                                {
                                    DefaultPassword = Password;
                                }

                            }
                            else
                            {
                                res.ErrStr = TranslateHelper.Translate("Error. Wrong User Password for File") + " : " + InputFile;
                                return res;
                            }
                        }
                    }
                }
            }

            res.TotalPages=reader.NumberOfPages;

            //frmProgress f = new frmProgress();
            //f.progressBar1.Style = ProgressBarStyle.Marquee;

            //frmMain.Instance.bwProgress.RunWorkerAsync();

            if (!string.IsNullOrEmpty(Password))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    stamper = new PdfStamper(reader, memoryStream);
                    stamper.Close();
                    reader.Close();

                    File.WriteAllBytes(tmpfile, memoryStream.ToArray());
                }

                res.DecryptedFile = tmpfile;
                res.Password = Password;
            }

            //f.Close();

            //frmMain.Instance.bwProgress.CancelAsync();

            //while (frmMain.Instance.bwProgress.CancellationPending)
            //{
              //  Application.DoEvents();
            //}

            return res;
        }

    }
}