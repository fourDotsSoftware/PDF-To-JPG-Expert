using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace PDFToJPGExpert
{
    class ResizeHelper
    {
        public static bool ResizeImage(string filepath, string outputFormatCode, int width, int height,int iquality)
        {
            Bitmap img = new Bitmap(filepath);

            Bitmap img2 = Resize(img, (float)width, (float)height, true, true, false, false, false, false, false, false, 0);

            img.Dispose();
            img = null;

            SaveImage(filepath, img2, outputFormatCode,iquality);

            return true;
        }
        private static Bitmap Resize(Bitmap img,float width, float height, bool keepratio, bool pixels,bool percentage,bool inches,bool cm,bool mm,bool points,bool aspectRatio,float aspectRatioValue)
        {            
            float ratio = (float)img.Width / (float)img.Height;

            if (aspectRatio)
            {
                ratio = aspectRatioValue;

                keepratio = false;
            }

            if (pixels)
            {                
                if (aspectRatio) ratio = aspectRatioValue;

                if (width >0 && height >0)
                {
                    return ResizePixels(img,(int) width, (int)height);
                }
                else if (width <=0)
                {
                    int newwidth = (int)(height * ratio);
                    return ResizePixels(img, newwidth,(int) height);
                }
                else if (height <= 0)
                {
                    int newheight = (int)((float)width / ratio);
                    return ResizePixels(img, (int)width, newheight);
                }
            }
            else if (percentage)
            {
                if (aspectRatio)
                {
                    ratio = aspectRatioValue;

                    keepratio = false;
                }

                if (keepratio)
                {                    
                    if (width >0)
                    {
                        return ResizePercentage(img, (float)width, (float)width);
                    }
                    else if (height>0)
                    {
                        return ResizePercentage(img, (float)height, (float)height);
                    }
                }
                else if (aspectRatio)
                {
                    if (width == 0)
                    {
                        return ResizePercentage(img, (float)height*aspectRatioValue, (float)height);
                    }
                    else if (height == 0)
                    {
                        return ResizePercentage(img, (float)width, (float)(width/aspectRatioValue));
                    }
                }
                else
                {
                    return ResizePercentage(img, (float)width, (float)height);
                }
            }
            else if (inches)
            {                
                float height_inches = (float)height * img.VerticalResolution;

                float width_inches = (float)width * img.HorizontalResolution;
                
                if (width >0 && height >0)
                {
                    return ResizePixels(img, (int)width_inches, (int)height_inches);
                }
                else if (width <=0)
                {
                    int newwidth = (int)(height_inches * ratio);
                    return ResizePixels(img, newwidth, (int)height_inches);
                }
                else if (height <=0)
                {
                    int newheight = (int)((float)width_inches / ratio);
                    return ResizePixels(img, (int)width_inches, newheight);
                }
            }
            else if (cm)
            {                
                float height_cm = (float)0.393700787*((float)height * img.VerticalResolution);

                float width_cm = (float)0.393700787*((float)width * img.HorizontalResolution);

                if (width >0 && height >0)
                {
                    return ResizePixels(img, (int)width_cm, (int)height_cm);
                }
                else if (width <=0)
                {
                    int newwidth = (int)(height_cm * ratio);
                    return ResizePixels(img, newwidth, (int)height_cm);
                }
                else if (height <=0)
                {
                    int newheight = (int)((float)width_cm / ratio);
                    return ResizePixels(img, (int)width_cm, newheight);
                }
            }
            else if (mm)
            {                
                float height_cm = (float)0.393700787 * ((float)height * img.VerticalResolution);

                float width_cm = (float)0.393700787 * ((float)width * img.HorizontalResolution);

                height_cm = 10 * height_cm;

                width_cm = 10 * width_cm;

                if (width > 0 && height > 0)
                {
                    return ResizePixels(img, (int)width_cm, (int)height_cm);
                }
                else if (width <= 0)
                {
                    int newwidth = (int)(height_cm * ratio);
                    return ResizePixels(img, newwidth, (int)height_cm);
                }
                else if (height <= 0)
                {
                    int newheight = (int)((float)width_cm / ratio);
                    return ResizePixels(img, (int)width_cm, newheight);
                }
            }
            else if (points)
            {                
                float height_points = ((float)height * (float)img.VerticalResolution) / (float)72;                         

                float width_points = ((float)width*(float)img.HorizontalResolution)/(float)72;

                if (width >0 && height >0)
                {
                    return ResizePixels(img, (int)width_points, (int)height_points);
                }
                else if (width <=0)
                {
                    int newwidth = (int)(height_points * ratio);
                    return ResizePixels(img, newwidth, (int)height_points);
                }
                else if (height <=0)
                {
                    int newheight = (int)((float)width_points / ratio);
                    return ResizePixels(img, (int)width_points, newheight);
                }
            }

            return img;
        }

        public static Bitmap ResizePixels(Bitmap img,int width, int height)
        {
            Bitmap result = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage((Bitmap)result))
                g.DrawImage(img, 0, 0, width, height);
            return result;

        }

        public static Bitmap ResizePercentage(Bitmap img, float percw,float perch)
        {
            int width = (int)((float)percw/(float)100 * img.Width);
            int height = (int)((float)perch/(float)100 * img.Height);
            
            Bitmap result = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(result))
                g.DrawImage(img, 0, 0, width, height);
            return result;
        }

        public static bool SaveImage(string filepath, System.Drawing.Image bmp,string outputFormatCode,int jpegQuality)
        {
            /*
            if (Properties.Settings.Default.ORotateEXIF)
            {
                bmp = RotateImageEXIF.RotateImageBasedOnExif(bmp);
            }
            */

            //string ext = System.IO.Path.GetExtension(filepath).ToLower().Substring(1);

            //if (ext == "png")
            if (outputFormatCode== "png16m")
            {
                bmp.Save(filepath, System.Drawing.Imaging.ImageFormat.Png);
            }
            //else if (ext == "jpg" || ext == "jpeg")
            else if (outputFormatCode=="jpeg")
            {
                ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);

                System.Drawing.Imaging.Encoder myEncoder =
                System.Drawing.Imaging.Encoder.Quality;

                // Create an EncoderParameters object.
                // An EncoderParameters object has an array of EncoderParameter
                // objects. In this case, there is only one
                // EncoderParameter object in the array.
                EncoderParameters myEncoderParameters = new EncoderParameters(1);

                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, (long)jpegQuality);

                myEncoderParameters.Param[0] = myEncoderParameter;
                bmp.Save(filepath, jgpEncoder, myEncoderParameters);
            }
            /*
            else if (ext == "gif")
            {
                bmp.Save(filepath, System.Drawing.Imaging.ImageFormat.Gif);
            }*/
            //else if (ext == "bmp")
            else if (outputFormatCode== "bmp16m")
            {
                bmp.Save(filepath, System.Drawing.Imaging.ImageFormat.Bmp);
            }
            /*
            else if (ext == "tiff")
            {
                bmp.Save(filepath, System.Drawing.Imaging.ImageFormat.Tiff);
            }
            */

            return true;
        }

        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }


        #region Get Values from Pixels

        public static float GetPercentageFromPixels(Bitmap bmp, bool width, int current)
        {
            // size 100
            // current x

            float fcurrent = (float)current;
            float fsize;

            if (width)
            {
                fsize = (float)bmp.Width;
            }
            else
            {
                fsize = (float)bmp.Height;
            }

            float f100 = (float)100;

            return (fcurrent * f100) / fsize;
        }

        public static float GetInchesFromPixels(Bitmap bmp, bool width, int current)
        {
            if (width)
            {
                return (float)current / bmp.HorizontalResolution;
            }
            else
            {
                return (float)current / bmp.VerticalResolution;
            }
        }

        public static float GetCmFromPixels(Bitmap bmp, bool width, int current)
        {
            if (width)
            {
                return ((float)current) / (bmp.HorizontalResolution * (float)0.393700787);
            }
            else
            {
                return ((float)current) / (bmp.VerticalResolution * (float)0.393700787);
            }
        }

        public static float GetMmFromPixels(Bitmap bmp, bool width, int current)
        {
            if (width)
            {
                return ((float)10 * (float)current) / (bmp.HorizontalResolution * (float)0.393700787);
            }
            else
            {
                return ((float)10 * (float)current) / (bmp.VerticalResolution * (float)0.393700787);
            }
        }

        public static float GetPointsFromPixels(Bitmap bmp, bool width, int current)
        {
            if (width)
            {
                return ((float)72 * (float)current) / bmp.HorizontalResolution;
            }
            else
            {
                return ((float)72 * (float)current) / bmp.VerticalResolution;
            }
        }

        #endregion

        #region Get Pixels from Values

        public static int GetPixelsFromPercentage(Bitmap bmp, bool width, float x)
        {
            // size 100
            // current x

            float fsize;

            if (width)
            {
                fsize = (float)bmp.Width;
            }
            else
            {
                fsize = (float)bmp.Height;
            }

            float f100 = (float)100;

            return (int)((x * fsize) / f100);
        }

        public static int GetPixelsFromInches(Bitmap bmp, bool width, float x)
        {
            if (width)
            {
                return (int)(x * bmp.HorizontalResolution);
            }
            else
            {
                return (int)(x * bmp.VerticalResolution);
            }
        }

        public static int GetPixelsFromCm(Bitmap bmp, bool width, float x)
        {
            if (width)
            {
                return (int)(x * ((float)0.393700787 * bmp.HorizontalResolution));
            }
            else
            {
                return (int)(x * ((float)0.393700787 * bmp.VerticalResolution));
            }
        }

        public static int GetPixelsFromMm(Bitmap bmp, bool width, float x)
        {
            if (width)
            {
                return (int)(x * ((float)0.0393700787 * bmp.HorizontalResolution));
            }
            else
            {
                return (int)(x * ((float)0.0393700787 * bmp.VerticalResolution));
            }
        }

        public static int GetPixelsFromPoints(Bitmap bmp, bool width, float x)
        {
            if (width)
            {
                return (int)((x * bmp.HorizontalResolution / (float)72));
            }
            else
            {
                return (int)((x * bmp.VerticalResolution / (float)72));
            }
        }

        #endregion

    }
}
