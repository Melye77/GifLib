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
            if (length <= 0)
            {
                throw new ArgumentException("Length has to be higher than 0. Found " + length);
            }

            float fps = images.Count * 1000f / length;
            SaveImagesAsGif(stream, images, fps, loop);
        }

        public void SaveImagesAsGif(Stream stream, ICollection<Bitmap> images, float fps, bool loop)
        {
            if (fps <= 0)
            {
                throw new ArgumentException("Fps has to be higher than 0. Found " + fps);
            }
            if (!ImagesAreValid(images))
            {
                throw new ArgumentException("Images of multiple sizes found or no images found");
            }

            // Converting all bitmaps to MagickImages
            ICollection<IMagickImage> magickImages = new System.Collections.ObjectModel.Collection<IMagickImage>();
            foreach (Bitmap bitmap in images)
            {
                MagickImage image = new MagickImage(bitmap);
                // MagickImage delay is required to be in 1/100 seconds
                float exactDelay = 100 / fps;
                image.AnimationDelay = (int) exactDelay;
                if (!loop)
                {
                    image.AnimationIterations = 1;
                }

                magickImages.Add(image);
            }

            using (MagickImageCollection collection = new MagickImageCollection(magickImages))
            {
                QuantizeSettings settings = new QuantizeSettings();
                settings.Colors = 256;
                collection.Quantize(settings);

                collection.Optimize();
                collection.Write(stream, MagickFormat.Gif);
            }
        }

        public void SaveImagesAsGif(Stream stream, ICollection<Bitmap> images, int length, float fps, bool loop)
        {
            if (fps <= 0)
            {
                throw new ArgumentException("Fps has to be higher than 0. Found " + fps);
            }
            if (length <= 0)
            {
                throw new ArgumentException("Length has to be higher than 0. Found " + length);
            }

            float lengthInSeconds = length / 1000;
            float aproximateNumberOfImages = lengthInSeconds * fps;
            int acceptedNumberOfImages = (int)aproximateNumberOfImages;

            int numberOfImages = images.Count;
            if (acceptedNumberOfImages == numberOfImages)
            {
                SaveImagesAsGif(stream, images, fps, loop);
            }
            else
            {
                IList<Bitmap> selectedImages = new List<Bitmap>();
                int numberOfImagesToRemove = numberOfImages - acceptedNumberOfImages;
                int groupsOfImages = numberOfImages / numberOfImagesToRemove;

                selectedImages.Add(images.First());
                for (int i = 1; i < numberOfImages; i++)
                {
                    if (!(i % groupsOfImages == 0))
                    {
                        selectedImages.Add(images.ElementAt(i));
                    }
                }

                SaveImagesAsGif(stream, selectedImages, fps, loop);
            }
        }

        public async Task SaveImagesAsGifAsync(Stream stream, ICollection<Bitmap> images, int length, bool loop)
        {
            await Task.Run(() => SaveImagesAsGif(stream, images, length, loop));
        }

        public async Task SaveImagesAsGifAsync(Stream stream, ICollection<Bitmap> images, float fps, bool loop)
        {
            await Task.Run(() => SaveImagesAsGif(stream, images, fps, loop));
        }

        public async Task SaveImagesAsGifAsync(Stream stream, ICollection<Bitmap> images, int length, float fps, bool loop)
        {
            await Task.Run(() =>SaveImagesAsGif(stream, images, length, fps, loop));
        }

        private static bool ImagesAreValid(ICollection<Bitmap> images)
        {
            if (images == null || images.Count == 0)
            {
                return false;
            }
            
            float height = images.First().Height ;
            float width = images.First().Width;
            foreach(Bitmap image in images)
            {
                if (!(height.Equals(image.Height)) || !(width.Equals(image.Width)))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
