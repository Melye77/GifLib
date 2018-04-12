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
		/// <param name="stream">An <see cref="System.IO.Stream"/> object where the gif image should be saved to.</param>
        /// <param name="images">An <see cref="System.Collections.Generic.ICollection{T}"/> containing <see cref="System.Drawing.Bitmap"/> images to be converted.</param>
        /// <param name="length">An <see cref="int"/> value representing the final length of the animation in milliseconds.</param>
		/// <param name="loop">An <see cref="bool"/> value representing whether the animation should loop and continue endlessly.</param>
        void SaveImagesAsGif(System.IO.Stream stream, System.Collections.Generic.ICollection<System.Drawing.Bitmap> images, int length, bool loop);

        /// <summary>
        /// 
        /// </summary>
		/// <param name="stream">An <see cref="System.IO.Stream"/> object where the gif image should be saved to.</param>
        /// <param name="images">An <see cref="System.Collections.Generic.ICollection{T}"/> containing <see cref="System.Drawing.Bitmap"/> images to be converted.</param>
        /// <param name="fps">A <see cref="float"/> value representing the frames per second of the final animation.</param>
		/// <param name="loop">An <see cref="bool"/> value representing whether the animation should loop and continue endlessly.</param>
        void SaveImagesAsGif(System.IO.Stream stream, System.Collections.Generic.ICollection<System.Drawing.Bitmap> images, float fps, bool loop);

        /// <summary>
        /// 
        /// </summary>
		/// <param name="stream">An <see cref="System.IO.Stream"/> object where the gif image should be saved to.</param>
        /// <param name="images">An <see cref="System.Collections.Generic.ICollection{T}"/> containing <see cref="System.Drawing.Bitmap"/> images to be converted.</param>
        /// <param name="length">An <see cref="int"/> value representing the final length of the animation in milliseconds.</param>
        /// <param name="fps">A <see cref="float"/> value representing the maximum frames per second of the final animation.</param>
		/// <param name="loop">An <see cref="bool"/> value representing whether the animation should loop and continue endlessly.</param>
        void SaveImagesAsGif(System.IO.Stream stream, System.Collections.Generic.ICollection<System.Drawing.Bitmap> images, int length, float fps, bool loop);

        /// <summary>
        /// 
        /// </summary>
		/// <param name="stream">An <see cref="System.IO.Stream"/> object where the gif image should be saved to.</param>
        /// <param name="images">An <see cref="System.Collections.Generic.ICollection{T}"/> containing <see cref="System.Drawing.Bitmap"/> images to be converted.</param>
        /// <param name="length">An <see cref="int"/> value representing the final length of the animation in milliseconds.</param>
		/// <param name="loop">An <see cref="bool"/> value representing whether the animation should loop and continue endlessly.</param>
        /// <returns>An awaitable <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        System.Threading.Tasks.Task SaveImagesAsGifAsync(System.IO.Stream stream, System.Collections.Generic.ICollection<System.Drawing.Bitmap> images, int length, bool loop);

        /// <summary>
        /// 
        /// </summary>
		/// <param name="stream">An <see cref="System.IO.Stream"/> object where the gif image should be saved to.</param>
        /// <param name="images">An <see cref="System.Collections.Generic.ICollection{T}"/> containing <see cref="System.Drawing.Bitmap"/> images to be converted.</param>
        /// <param name="fps">A <see cref="float"/> value representing the frames per second of the final animation.</param>
		/// <param name="loop">An <see cref="bool"/> value representing whether the animation should loop and continue endlessly.</param>
        /// <returns>An awaitable <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        System.Threading.Tasks.Task SaveImagesAsGifAsync(System.IO.Stream stream, System.Collections.Generic.ICollection<System.Drawing.Bitmap> images, float fps, bool loop);

        /// <summary>
        /// 
        /// </summary>
		/// <param name="stream">An <see cref="System.IO.Stream"/> object where the gif image should be saved to.</param>
        /// <param name="images">An <see cref="System.Collections.Generic.ICollection{T}"/> containing <see cref="System.Drawing.Bitmap"/> images to be converted.</param>
        /// <param name="length">An <see cref="int"/> value representing the final length of the animation in milliseconds.</param>
        /// <param name="fps">A <see cref="float"/> value representing the maximum frames per second of the final animation.</param>
		/// <param name="loop">An <see cref="bool"/> value representing whether the animation should loop and continue endlessly.</param>
        /// <returns>An awaitable <see cref="System.Threading.Tasks.Task"/> that represents the asynchronous operation.</returns>
        System.Threading.Tasks.Task SaveImagesAsGifAsync(System.IO.Stream stream, System.Collections.Generic.ICollection<System.Drawing.Bitmap> images, int length, float fps, bool loop);
    }
}
