using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace PDFToJPGExpert
{    
    static class Program
    {
        [DllImport("kernel32.dll")]
        public static extern Boolean FreeConsole();

        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        [DllImport("kernel32.dll")]
        public static extern Boolean AllocConsole();

        const int ATTACH_PARENT_PROCESS = -1;
        const int ERROR_ACCESS_DENIED = 5;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            ExceptionHandlersHelper.AddUnhandledExceptionHandlers();

            frmLanguage.SetLanguages();
            SetLanguage();

            Module.args = args;


            if (args.Length > 0 && args[0].StartsWith("/uninstall"))
            {
                Module.DeleteApplicationSettingsFile();

                /*
                frmUninstallQuestionnaire fq = new frmUninstallQuestionnaire();
                fq.ShowDialog();
                */

                System.Diagnostics.Process.Start("https://www.4dots-software.com/support/bugfeature.php?uninstall=true&app=" + System.Web.HttpUtility.UrlEncode(Module.ShortApplicationTitle));

                Environment.Exit(0);
                return;
            }            

            if (ArgsHelper.IsFromCommandLine)
            {                
                if (!AttachConsole(ATTACH_PARENT_PROCESS) && Marshal.GetLastWin32Error() == ERROR_ACCESS_DENIED)
                {
                    AllocConsole();
                }
                // remove commments for trial                
            }

            Application.Run(new frmMain());
        }        
        public static void SetLanguage()
        {
            string lang = Properties.Settings.Default.Language;

            if (Properties.Settings.Default.LastVersion != Module.ApplicationTitle)
            {
                Properties.Settings.Default.LanguagesDownloaded = "";
                Properties.Settings.Default.LastVersion = Module.ApplicationTitle;
                Properties.Settings.Default.Save();
            }
            
            bool setlang = false;

            if (Properties.Settings.Default.Language == string.Empty)
            {
                frmLanguage fl = new frmLanguage();
                fl.ShowDialog();
                Properties.Settings.Default.Language = frmLanguage.SelectedLanguageCode;
                lang = frmLanguage.SelectedLanguageCode;
                setlang = true;
            }
            
            Module.SelectedLanguage = lang;

            if (lang != "en-US")
            {
                if (!frmLanguage.DownloadLanguage(lang))
                {
                    lang = "en-US";
                    Properties.Settings.Default.Language = "en-US";
                }
            }
            
            if (lang == "en-US")
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture =
                    System.Globalization.CultureInfo.InvariantCulture;

                //Application.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            }
            else
            {               
                try
                {
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new
                    System.Globalization.CultureInfo(lang);

                    //Application.CurrentCulture = new System.Globalization.CultureInfo(lang);
                }
                catch (Exception ex)
                {
                    Module.ShowError(ex);
                }
            }

            /*
            if (setlang)
            {
                key.SetValue("Menu Item Caption", TranslateHelper.Translate("Remove PDF Password"));
            }
            */
        }         
    }
}
