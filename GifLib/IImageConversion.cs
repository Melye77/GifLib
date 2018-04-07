using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifLib
{
    public interface IImageConversion
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="images">An <see cref="System.Collections.Generic.ICollection{T}"/> containing <see cref="System.Drawing.Bitmap"/> images to be converted.</param>
        /// <param name="length">An <see cref="int"/> value representing the final length of the animation in milliseconds.</param>
        /// <returns>A <see cref="System.IO.Stream"/> object where the gif image has been saved to.</returns>
        System.IO.Stream SaveImagesAsGif(System.Collections.Generic.ICollection<System.Drawing.Bitmap> images, int length);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="images">An <see cref="System.Collections.Generic.ICollection{T}"/> containing <see cref="System.Drawing.Bitmap"/> images to be converted.</param>
        /// <param name="fps">A <see cref="float"/> value representing the frames per second of the final animation.</param>
        /// <returns>A <see cref="System.IO.Stream"/> object where the gif image has been saved to.</returns>
        System.IO.Stream SaveImagesAsGif(System.Collections.Generic.ICollection<System.Drawing.Bitmap> images, float fps);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="images">An <see cref="System.Collections.Generic.ICollection{T}"/> containing <see cref="System.Drawing.Bitmap"/> images to be converted.</param>
        /// <param name="length">An <see cref="int"/> value representing the final length of the animation in milliseconds.</param>
        /// <param name="fps">A <see cref="float"/> value representing the frames per second of the final animation.</param>
        /// <returns>A <see cref="System.IO.Stream"/> object where the gif image has been saved to.</returns>
        System.IO.Stream SaveImagesAsGif(System.Collections.Generic.ICollection<System.Drawing.Bitmap> images, int length, float fps);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="images">An <see cref="System.Collections.Generic.ICollection{T}"/> containing <see cref="System.Drawing.Bitmap"/> images to be converted.</param>
        /// <param name="length">An <see cref="int"/> value representing the final length of the animation in milliseconds.</param>
        /// <returns>An awaitable <see cref="System.Threading.Tasks.Task{TResult}"/> that represents the asynchronous operation, the task result contains a <see cref="System.IO.Stream"/> object where the gif image has been saved to.</returns>
        System.Threading.Tasks.Task<System.IO.Stream> SaveImagesAsGifAsync(System.Collections.Generic.ICollection<System.Drawing.Bitmap> images, int length);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="images">An <see cref="System.Collections.Generic.ICollection{T}"/> containing <see cref="System.Drawing.Bitmap"/> images to be converted.</param>
        /// <param name="fps">A <see cref="float"/> value representing the frames per second of the final animation.</param>
        /// <returns>An awaitable <see cref="System.Threading.Tasks.Task{TResult}"/> that represents the asynchronous operation, the task result contains a <see cref="System.IO.Stream"/> object where the gif image has been saved to.</returns>
        System.Threading.Tasks.Task<System.IO.Stream> SaveImagesAsGifAsync(System.Collections.Generic.ICollection<System.Drawing.Bitmap> images, float fps);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="images">An <see cref="System.Collections.Generic.ICollection{T}"/> containing <see cref="System.Drawing.Bitmap"/> images to be converted.</param>
        /// <param name="length">An <see cref="int"/> value representing the final length of the animation in milliseconds.</param>
        /// <param name="fps">A <see cref="float"/> value representing the frames per second of the final animation.</param>
        /// <returns>An awaitable <see cref="System.Threading.Tasks.Task{TResult}"/> that represents the asynchronous operation, the task result contains a <see cref="System.IO.Stream"/> object where the gif image has been saved to.</returns>
        System.Threading.Tasks.Task<System.IO.Stream> SaveImagesAsGifAsync(System.Collections.Generic.ICollection<System.Drawing.Bitmap> images, int length, float fps);
    }
}
