using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PDFToJPGExpert
{
    public partial class frmOutputFormatSelect : PDFToJPGExpert.CustomForm
    {
        public string SelectedOutputFormat = "";
        public string SelectedOutputFormatCode="";
        public string SelectedOutputFormatExtension = "";

        private static List<string> OutputFormatCodes=new List<string>();
        private static List<string> OutputFormatExtension = new List<string>();

        public frmOutputFormatSelect()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            /*
            MessageBox.Show(lstOutputFormat.Items.Count.ToString());

            string str = "";
            for (int k = 0; k < lstOutputFormat.Items.Count; k++)
            {
                str += lstOutputFormat.Items[k].ToString() + "\n";
            }

            MessageBox.Show(str);
            */
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SelectedOutputFormat = lstOutputFormat.SelectedItem.ToString();
            SelectedOutputFormatCode = OutputFormatCodes[lstOutputFormat.SelectedIndex];
            SelectedOutputFormatExtension = OutputFormatExtension[lstOutputFormat.SelectedIndex];
            this.DialogResult = DialogResult.OK;
        }

        private void FillOutputFormats()
        {
            OutputFormatCodes.Clear();
            OutputFormatExtension.Clear();

            lstOutputFormat.Items.Add("PNG 16 Million Colors");
            OutputFormatCodes.Add("png16m");
            OutputFormatExtension.Add("png");
            lstOutputFormat.Items.Add("PNG Grayscale");
            OutputFormatCodes.Add("pnggray");
            OutputFormatExtension.Add("png");
            lstOutputFormat.Items.Add("PNG 256 Colors (8-bit)");
            OutputFormatCodes.Add("png256");
            OutputFormatExtension.Add("png");
            lstOutputFormat.Items.Add("PNG 16 Colors (4-bit)");
            OutputFormatCodes.Add("png16");
            OutputFormatExtension.Add("png");
            lstOutputFormat.Items.Add("PNG Monochrome");
            OutputFormatCodes.Add("pngmono");
            OutputFormatExtension.Add("png");
            lstOutputFormat.Items.Add("PNG Monochrome Error Difused");
            OutputFormatCodes.Add("pngmonod ");
            OutputFormatExtension.Add("png");
            lstOutputFormat.Items.Add("JPEG");
            OutputFormatCodes.Add("jpeg");
            OutputFormatExtension.Add("jpg");
            lstOutputFormat.Items.Add("JPEG Grayscale");
            OutputFormatCodes.Add("jpeggray");
            OutputFormatExtension.Add("jpg");

            lstOutputFormat.Items.Add("TIFF 48-bit RGB Color");
            OutputFormatCodes.Add("tiff48nc");
            OutputFormatExtension.Add("tif");
            lstOutputFormat.Items.Add("TIFF 24-bit RGB Color");
            OutputFormatCodes.Add("tiff24nc");
            OutputFormatExtension.Add("tif");

            lstOutputFormat.Items.Add("TIFF 12-bit RGB Color");
            OutputFormatCodes.Add("tiff12nc");
            OutputFormatExtension.Add("tif");
            lstOutputFormat.Items.Add("TIFF 8-bit Grayscale");
            OutputFormatCodes.Add("tiffgray");
            OutputFormatExtension.Add("tif");

            lstOutputFormat.Items.Add("TIFF 32-bit CMYK Color");
            OutputFormatCodes.Add("tiff32nc"); 
            OutputFormatExtension.Add("tif");
            lstOutputFormat.Items.Add("TIFF 64-bit CMYK Color");
            OutputFormatCodes.Add("tiff64nc");
            OutputFormatExtension.Add("tif");

            lstOutputFormat.Items.Add("TIFF G3 fax encoding with no EOLs");
            OutputFormatCodes.Add("tiffcrle");
            OutputFormatExtension.Add("tif");
            lstOutputFormat.Items.Add("TIFF G3 fax encoding with EOLs ");
            OutputFormatCodes.Add("tiffg3");
            OutputFormatExtension.Add("tif");

            lstOutputFormat.Items.Add("TIFF 2-D G3 fax encoding");
            OutputFormatCodes.Add("tiffg32d");
            OutputFormatExtension.Add("tif");
            lstOutputFormat.Items.Add("TIFF G4 fax encoding");
            OutputFormatCodes.Add("tiffg4");
            OutputFormatExtension.Add("tif");
            lstOutputFormat.Items.Add("TIFF LZW-compatible compression");
            OutputFormatCodes.Add("tifflzw");
            OutputFormatExtension.Add("tif");
            lstOutputFormat.Items.Add("TIFF PackBits compression");
            OutputFormatCodes.Add("tiffpack");
            OutputFormatExtension.Add("tif");
            lstOutputFormat.Items.Add("RAW FAX G3");
            OutputFormatCodes.Add("faxg3");
            OutputFormatExtension.Add("tif");
            lstOutputFormat.Items.Add("RAW FAX 2-D G3");
            OutputFormatCodes.Add("faxg32d");
            OutputFormatExtension.Add("tif");
            lstOutputFormat.Items.Add("RAW FAX G4");
            OutputFormatCodes.Add("faxg4");
            OutputFormatExtension.Add("tif");
            lstOutputFormat.Items.Add("BMP 16 Million Colors");
            OutputFormatCodes.Add("bmp16m");
            OutputFormatExtension.Add("bmp");
            lstOutputFormat.Items.Add("BMP Grayscale");
            OutputFormatCodes.Add("bmpgray");
            OutputFormatExtension.Add("bmp");
            lstOutputFormat.Items.Add("BMP 16 Colors (4-bit)");
            OutputFormatCodes.Add("bmp16");
            OutputFormatExtension.Add("bmp");
            lstOutputFormat.Items.Add("BMP 256 Colors (8-bit)");
            OutputFormatCodes.Add("bmp256");
            OutputFormatExtension.Add("bmp");
            lstOutputFormat.Items.Add("BMP 32-bit Color");
            OutputFormatCodes.Add("bmp32b");
            OutputFormatExtension.Add("bmp");
            lstOutputFormat.Items.Add("PCX 24-bit Color");
            OutputFormatCodes.Add("pcx24b");
            OutputFormatExtension.Add("pcx");
            lstOutputFormat.Items.Add("PCX Grayscale");
            OutputFormatCodes.Add("pcxgray");
            OutputFormatExtension.Add("pcx");
            lstOutputFormat.Items.Add("PCX 256 Colors (8-bit)");
            OutputFormatCodes.Add("pcx256");
            OutputFormatExtension.Add("pcx");
            lstOutputFormat.Items.Add("PCX 16 Colors (4-bit)");
            OutputFormatCodes.Add("pcx16");
            OutputFormatExtension.Add("pcx");
            lstOutputFormat.Items.Add("PCX CMYK Color");
            OutputFormatCodes.Add("pcxcmyk");
            OutputFormatExtension.Add("pcx");

            lstOutputFormat.Items.Add("Photoshop PSD RGB Color");
            OutputFormatCodes.Add("psdrgb");
            OutputFormatExtension.Add("psd");
            lstOutputFormat.Items.Add("Photoshop PSD CMYK Color");
            OutputFormatCodes.Add("psdcmyk");
            OutputFormatExtension.Add("psd");
            
        
        }

        public static string ListOutputFormatCodes()
        {
            FillOutputFormatCodes();

            var sb = new StringBuilder();

            for (int k=0;k<OutputFormatCodes.Count;k++)
            {
                sb.AppendLine(OutputFormatCodes[k]);
            }

            return sb.ToString();
        }

        public static string GetExtensionFromOutputFormatCode(string outputFormatCode)
        {
            FillOutputFormatCodes();

            int ind = OutputFormatCodes.IndexOf(outputFormatCode.ToLower());

            if (ind<0)
            {
                throw new ArgumentException("Please specify a valid Output Format Code !");
            }

            return OutputFormatExtension[ind];
        }

        private static void FillOutputFormatCodes()
        {
            OutputFormatCodes.Clear();
            OutputFormatExtension.Clear();

            OutputFormatCodes.Add("png16m");
            OutputFormatExtension.Add("png");
            
            OutputFormatCodes.Add("pnggray");
            OutputFormatExtension.Add("png");
            
            OutputFormatCodes.Add("png256");
            OutputFormatExtension.Add("png");
            
            OutputFormatCodes.Add("png16");
            OutputFormatExtension.Add("png");
            
            OutputFormatCodes.Add("pngmono");
            OutputFormatExtension.Add("png");
            
            OutputFormatCodes.Add("pngmonod ");
            OutputFormatExtension.Add("png");
            
            OutputFormatCodes.Add("jpeg");
            OutputFormatExtension.Add("jpg");
            
            OutputFormatCodes.Add("jpeggray");
            OutputFormatExtension.Add("jpg");
            
            OutputFormatCodes.Add("tiff48nc");
            OutputFormatExtension.Add("tif");
            
            OutputFormatCodes.Add("tiff24nc");
            OutputFormatExtension.Add("tif");
            
            OutputFormatCodes.Add("tiff12nc");
            OutputFormatExtension.Add("tif");
            
            OutputFormatCodes.Add("tiffgray");
            OutputFormatExtension.Add("tif");
            
            OutputFormatCodes.Add("tiff32nc");
            OutputFormatExtension.Add("tif");
            
            OutputFormatCodes.Add("tiff64nc");
            OutputFormatExtension.Add("tif");
            
            OutputFormatCodes.Add("tiffcrle");
            OutputFormatExtension.Add("tif");
            
            OutputFormatCodes.Add("tiffg3");
            OutputFormatExtension.Add("tif");
            
            OutputFormatCodes.Add("tiffg32d");
            OutputFormatExtension.Add("tif");
            
            OutputFormatCodes.Add("tiffg4");
            OutputFormatExtension.Add("tif");
            
            OutputFormatCodes.Add("tifflzw");
            OutputFormatExtension.Add("tif");
            
            OutputFormatCodes.Add("tiffpack");
            OutputFormatExtension.Add("tif");
            
            OutputFormatCodes.Add("faxg3");
            OutputFormatExtension.Add("tif");
            
            OutputFormatCodes.Add("faxg32d");
            OutputFormatExtension.Add("tif");
            
            OutputFormatCodes.Add("faxg4");
            OutputFormatExtension.Add("tif");
            
            OutputFormatCodes.Add("bmp16m");
            OutputFormatExtension.Add("bmp");
            
            OutputFormatCodes.Add("bmpgray");
            OutputFormatExtension.Add("bmp");
            
            OutputFormatCodes.Add("bmp16");
            OutputFormatExtension.Add("bmp");
            
            OutputFormatCodes.Add("bmp256");
            OutputFormatExtension.Add("bmp");
            
            OutputFormatCodes.Add("bmp32b");
            OutputFormatExtension.Add("bmp");
            
            OutputFormatCodes.Add("pcx24b");
            OutputFormatExtension.Add("pcx");
            
            OutputFormatCodes.Add("pcxgray");
            OutputFormatExtension.Add("pcx");
            
            OutputFormatCodes.Add("pcx256");
            OutputFormatExtension.Add("pcx");
            
            OutputFormatCodes.Add("pcx16");
            OutputFormatExtension.Add("pcx");
            
            OutputFormatCodes.Add("pcxcmyk");
            OutputFormatExtension.Add("pcx");
            
            OutputFormatCodes.Add("psdrgb");
            OutputFormatExtension.Add("psd");
            
            OutputFormatCodes.Add("psdcmyk");
            OutputFormatExtension.Add("psd");
        }

        private void frmOutputFormatSelect_Load(object sender, EventArgs e)
        {
            FillOutputFormats();
        }
    }
}
