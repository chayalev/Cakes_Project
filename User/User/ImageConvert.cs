using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;
using System.Runtime.InteropServices.WindowsRuntime;


namespace User
{
    public class ImageConvert
    {
        public static async void ConvertByteArrayToImage(byte[] myByteArray, BitmapImage img)
        {
            using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
            {
                await stream.WriteAsync(myByteArray.AsBuffer());
                stream.Seek(0);
                await img.SetSourceAsync(stream);
            }
        }

    }
}
