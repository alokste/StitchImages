using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StitchImages;
using System.Drawing;

namespace ConsoleApplication1
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<string> ImagePaths = new List<string>();
            ImagePaths.Add(@"C:\Users\Public\Pictures\Sample Pictures\Chrysanthemum.jpg");
            ImagePaths.Add(@"C:\Users\Public\Pictures\Sample Pictures\Desert.jpg");
            ImagePaths.Add(@"C:\Users\Public\Pictures\Sample Pictures\Hydrangeas.jpg");

            StitchImages.StitchImages SIV = new StitchImages.StitchImages(ImagePaths);
            StitchImages.StitchImages SIVP = new StitchImages.StitchImages(ImagePaths);
            StitchImages.StitchImages SIH = new StitchImages.StitchImages(ImagePaths);
            StitchImages.StitchImages SIHP = new StitchImages.StitchImages(ImagePaths);
            SIV.JoinImages("Vertically").Save(@"D:\bTestV.jpeg");
            SIH.JoinImages("Horizontally").Save(@"D:\bTestH.jpeg");
            SIVP.JoinImages(@"D:\Testv.jpeg", "Vertically");
            SIHP.JoinImages(@"D:\Testh.jpeg", "Horizontally");
            
        }
    }
}
