using Gif.Components;
using ImageMagick;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifLib
{
    class ImageConversion : IImageConversion
    {
        public void SaveImagesAsGif(Stream stream, ICollection<Bitmap> images, int length, bool loop)
        {
            float lengthInSeconds = length / 1000;
            float fps = lengthInSeconds / images.ToArray().Length;
            SaveImagesAsGif(stream, images, fps, loop);
        }

        public void SaveImagesAsGif(Stream stream, ICollection<Bitmap> images, float fps, bool loop)
        {
            if (images == null || images.ToArray().Length == 0)
            {
                throw new ArgumentException("There are no images to add to animation");
            }

            ICollection<IMagickImage> magickImages = new System.Collections.ObjectModel.Collection<IMagickImage>();
            foreach (Bitmap bitmap in images)
            {
                MagickImage image = new MagickImage(bitmap);
                float exactDelay = 100 / fps;
                image.AnimationDelay = (int) exactDelay;
                if (!loop)
                {
                    image.AnimationIterations = 1;
                }

                magickImages.Add(image);
            }

            MagickReadSettings readSettings = new MagickReadSettings();
            readSettings.Format = MagickFormat.Bmp;
            using (MagickImageCollection collection = new MagickImageCollection(magickImages))
            {
                QuantizeSettings settings = new QuantizeSettings();
                settings.Colors = 256;
                collection.Quantize(settings);
                
                collection.Optimize();
                collection.Write(stream, MagickFormat.Gif);
            }
            stream.Position = 0;
        }

        public void SaveImagesAsGif(Stream stream, ICollection<Bitmap> images, int length, float fps, bool loop)
        {
            float lengthInSeconds = length / 1000;
            float calculatedFps = lengthInSeconds / images.ToArray().Length;
            if (calculatedFps == fps)
            {
                SaveImagesAsGif(stream, images, fps, loop);
            } else
            {
                float imageNumber = lengthInSeconds / fps;
            }
        }

        public async Task SaveImagesAsGifAsync(Stream stream, ICollection<Bitmap> images, int length, bool loop)
        {
            throw new NotImplementedException();
        }

        public async Task SaveImagesAsGifAsync(Stream stream, ICollection<Bitmap> images, float fps, bool loop)
        {
            throw new NotImplementedException();
        }

        public async Task SaveImagesAsGifAsync(Stream stream, ICollection<Bitmap> images, int length, float fps, bool loop)
        {
            throw new NotImplementedException();
        }
    }
}
