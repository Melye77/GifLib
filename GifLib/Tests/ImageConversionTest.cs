using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifLib.Tests
{
    [TestFixture]
    public class ImageConversionTest
    {
        private const String ValidImagesFolder = "TestImages";
        private const String InvalidImagesFolder = "TestImagesFail";

        [Test]
        public async Task SaveImagesAsGifOnLengthAsyncTest()
        {
            IList<Bitmap> bitmapList = GetBitmapImagesList(ValidImagesFolder, 61);
            IImageConversion imageConvertor = new ImageConversion();
            Stream stream = new MemoryStream();
         
            imageConvertor.SaveImagesAsGif(stream, bitmapList, 3630, true);
            stream.Position = 0;
            using (var fileStream = new FileStream(@"D:\blndr\test.gif", FileMode.Create, FileAccess.Write))
            {
                stream.CopyTo(fileStream);
            }

            Image image = Image.FromStream(stream);
            ImageValidation(image, 44, 80, true);
        }

        [Test]
        public async Task SaveImagesAsGifOnFpsAndLengthAsyncTest()
        {
            IList<Bitmap> bitmapList = GetBitmapImagesList(ValidImagesFolder, 11);
            IImageConversion imageConvertor = new ImageConversion();
            Stream stream = new MemoryStream();

            await imageConvertor.SaveImagesAsGifAsync(stream, bitmapList, 4000, 2f, true);
            stream.Position = 0;
            using (var fileStream = new FileStream(@"D:\blndr\test.gif", FileMode.Create, FileAccess.Write))
            {
                stream.CopyTo(fileStream);
            }

            Image image = Image.FromStream(stream);
            ImageValidation(image, 8, 500, true);
        }

        [Test]
        public async Task SaveImagesAsGidOnFpsAsyncTest()
        {
            IList<Bitmap> bitmapList = GetBitmapImagesList(ValidImagesFolder , 44);
            IImageConversion imageConvertor = new ImageConversion();
            Stream stream = new MemoryStream();

            await imageConvertor.SaveImagesAsGifAsync(stream, bitmapList, 3f, true);
            stream.Position = 0;
            using (var fileStream = new FileStream(@"D:\blndr\test.gif", FileMode.Create, FileAccess.Write))
            {
                stream.CopyTo(fileStream);
            }

            Image image = Image.FromStream(stream);
            ImageValidation(image, 44, 330, true);
        }

        [Test]
        public void SaveImagesAsGifOnFpsTest()
        {
            IList<Bitmap> bitmapList = GetBitmapImagesList(ValidImagesFolder, 44);
            IImageConversion imageConvertor = new ImageConversion();
            Stream stream = new MemoryStream();

            imageConvertor.SaveImagesAsGif(stream, bitmapList, 3f, true);
            stream.Position = 0;
            using (var fileStream = new FileStream(@"D:\blndr\test.gif", FileMode.Create, FileAccess.Write))
            {
                stream.CopyTo(fileStream);
            }

            Image image = Image.FromStream(stream);
            ImageValidation(image, 44, 330, true);
        }

        [Test]
        public void SaveImagesAsGifOnLengthTest()
        {
            IList<Bitmap> bitmapList = GetBitmapImagesList(ValidImagesFolder, 11);
            IImageConversion imageConvertor = new ImageConversion();
            Stream stream = new MemoryStream();

            int length = 3630;
            imageConvertor.SaveImagesAsGif(stream, bitmapList, length, false);
            stream.Position = 0;
            using (var fileStream = new FileStream(@"D:\blndr\test.gif", FileMode.Create, FileAccess.Write))
            {
                stream.CopyTo(fileStream);
            }

            Image image = Image.FromStream(stream);
            ImageValidation(image, 44, 80, false);
        }

        [Test]
        public void SaveImagesAsGifOnFpsAndLengthTest()
        {
            IList<Bitmap> bitmapList = GetBitmapImagesList(ValidImagesFolder, 11);
            IImageConversion imageConvertor = new ImageConversion();
            Stream stream = new MemoryStream();

            imageConvertor.SaveImagesAsGif(stream, bitmapList, 4000, 2f, true);
            stream.Position = 0;
            using (var fileStream = new FileStream(@"D:\blndr\test.gif", FileMode.Create, FileAccess.Write))
            {
                stream.CopyTo(fileStream);
            }

            Image image = Image.FromStream(stream);
            ImageValidation(image, 8, 500, true);
        }

        [Test]
        public void SaveImageAsGifImagesWithDifferentSizes()
        {
            IList<Bitmap> bitmapList = GetBitmapImagesList(InvalidImagesFolder, 10);
            IImageConversion imageConvertor = new ImageConversion();
            Stream stream = new MemoryStream();
            stream.Position = 0;
            Assert.Throws<ArgumentException>(() => imageConvertor.SaveImagesAsGif(stream, bitmapList, 3f, true));
        }

        [Test]
        public async Task SaveImageAsGifImagesWithDifferentSizesAsync()
        {
            IList<Bitmap> bitmapList = GetBitmapImagesList(InvalidImagesFolder, 10);
            IImageConversion imageConvertor = new ImageConversion();
            Stream stream = new MemoryStream();
            stream.Position = 0;
            Assert.ThrowsAsync<ArgumentException>(() => imageConvertor.SaveImagesAsGifAsync(stream, bitmapList, 3f, true));
        }

        private void ImageValidation(Image image, int numberOfImages, int expectedDelay, bool loop)
        {
            Assert.That(image.RawFormat, Is.EqualTo(ImageFormat.Gif));

            if (ImageAnimator.CanAnimate(image))
            {
                FrameDimension frameDimension = new FrameDimension(image.FrameDimensionsList[0]);
                int frameCount = image.GetFrameCount(frameDimension);
                Assert.That(frameCount, Is.EqualTo(numberOfImages));
                PropertyItem item = image.GetPropertyItem(0x5100); // FrameDelay in libgdiplus

                int delay = (item.Value[0] + item.Value[1] * 256) * 10;

                bool IsLooped = BitConverter.ToInt16(image.GetPropertyItem(20737).Value, 0) != 1;
                Assert.That(IsLooped, Is.EqualTo(loop));
                Assert.That(delay, Is.EqualTo(expectedDelay));
            }
        }

        private IList<Bitmap> GetBitmapImagesList(String folder, int numberOfImages)
        {
            String currentPath = System.AppDomain.CurrentDomain.BaseDirectory;
            String imagePath = currentPath + folder;
            var files = Directory.GetFiles(imagePath);
            
            IList<Bitmap> bitmapList = new List<Bitmap>();
            foreach (string file in files) 
            {
                System.Drawing.Bitmap image = (Bitmap)Bitmap.FromFile(file);
                bitmapList.Add(image);
            }

            return bitmapList;
        }
    }
}
