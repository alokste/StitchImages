﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace StitchImages
{
   
    public class StitchImages
    {
        private string outPutPath;
        private int FullHeight = 0;
        private int FullWidth = 0;
        private int MaxHeight = 0;
        private int MaxWidth = 0;
        private Bitmap[] Images;       

        public StitchImages(List<string> ImagePathList)
        {            
            //calculating dimensions of the final image
            Images = new Bitmap[ImagePathList.Count];


            //creating Images out of the image path ,calculating Fullwidth , FullHeight, MaxWidth ,MaxHeight 
            for (int i = 0; i < ImagePathList.Count; i++)
            {
                Images[i] = new Bitmap(ImagePathList[i]);
                FullHeight = FullHeight + Images[i].Height;
                FullWidth = FullWidth + Images[i].Width;
                if (MaxWidth < Images[i].Width)
                { MaxWidth = Images[i].Width; }
                if (MaxHeight < Images[i].Height)
                { MaxHeight = Images[i].Height; }
            }

        }

       /// <summary>
       /// Method to join the images in the list in a given orientation and save the finalImage in provided filepath
       /// </summary>
       /// <param name="outPutFile">The name of the final joined image file</param>
       /// <param name="Orientation">Vertically,Horizontally</param>
        public void JoinImages(string outPutFile ,string Orientation)
        {
           Bitmap fullImage = new Bitmap(1, 1);
           switch(Orientation)
            {
               
                case "Horizontally":
                    fullImage = JoinImages("Horizontally");
                    fullImage.Save(outPutFile, ImageFormat.Jpeg);        
                break;

                case "Vertically" :
                    fullImage = JoinImages("Vertically");
                    fullImage.Save(outPutFile, ImageFormat.Jpeg);             
               
                 break;

                default:
                    fullImage = JoinImages("Vertically");
                    fullImage.Save(outPutFile, ImageFormat.Jpeg);                               
                break;
            }         
                        
        }

        /// <summary>
        /// Method to join images and return the bitmap of the final image 
        /// </summary>
        /// <param name="Orientation">Horizontally,Vertically</param>
        /// <returns>Bitmap</returns>
        public Bitmap JoinImages(string Orientation)
        {
            Bitmap fullImage;
            switch (Orientation)
            {
                case "Horizontally":
                    fullImage = new Bitmap(FullWidth, MaxHeight);
                    {
                        Graphics fullPage = Graphics.FromImage(fullImage);
                        {
                            int yPosition = 0;
                            int xPosition = 0;
                            fullPage.DrawImage(Images[0], xPosition, yPosition);
                            for (int i = 1; i < Images.Length; i++)
                            {
                                xPosition = xPosition + Images[i - 1].Width;
                                fullPage.DrawImage(Images[i], xPosition, yPosition);

                            }                           
                        }
                    }                   
                    break;

                case "Vertically":
                    fullImage = new Bitmap(MaxWidth, FullHeight);
                    {
                        Graphics fullPage = Graphics.FromImage(fullImage);
                        {
                            int yPosition = 0;
                            int xPosition = 0;
                            fullPage.DrawImage(Images[0], xPosition, yPosition);
                            for (int i = 1; i < Images.Length; i++)
                            {
                                yPosition = yPosition + Images[i - 1].Height;
                                fullPage.DrawImage(Images[i], xPosition, yPosition);

                            }
                           
                        }
                    }

                    break;

                default:
                    fullImage = new Bitmap(MaxWidth, FullHeight);
                    {
                        Graphics fullPage = Graphics.FromImage(fullImage);
                        {
                            int yPosition = 0;
                            int xPosition = 0;
                            fullPage.DrawImage(Images[0], xPosition, yPosition);
                            for (int i = 1; i < Images.Length; i++)
                            {
                                yPosition = yPosition + Images[i - 1].Height;
                                fullPage.DrawImage(Images[i], xPosition, yPosition);

                            }
                           
                        }
                    }
                    break;
            }

            return fullImage;

        }
    }
}
