using NUnit.Framework;
using System;
using System.Collections.Generic;
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

        [Test]
        public void SaveImagesAsGifTest()
        {
            IImageConversion imageConvertor = new ImageConversion();
            System.Drawing.Bitmap image1 = (Bitmap)Bitmap.FromFile(@"D:\blndr\GifLib\GifLib\GifLib\bin\Debug\image1.jpg");
            System.Drawing.Bitmap image2 = (Bitmap)Bitmap.FromFile(@"D:\blndr\GifLib\GifLib\GifLib\bin\Debug\image2.jpg");
            System.Drawing.Bitmap image3 = (Bitmap)Bitmap.FromFile(@"D:\blndr\GifLib\GifLib\GifLib\bin\Debug\image3.jpg");
            IList<Bitmap> bitmapList = new List<Bitmap>();
            bitmapList.Add(image1);
            bitmapList.Add(image2);
            bitmapList.Add(image3);
            Stream stream = new MemoryStream();
            imageConvertor.SaveImagesAsGif(stream, bitmapList, 3f, true);

            using (var fileStream = new FileStream(@"D:\blndr\test.gif", FileMode.Create, FileAccess.Write))
            {
                stream.CopyTo(fileStream);
            }

            Image image = System.Drawing.Image.FromStream(stream);
            Assert.That(image.RawFormat, Is.EqualTo(ImageFormat.Gif));
        }
    }
}
