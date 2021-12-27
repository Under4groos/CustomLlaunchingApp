using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using UcAutoClicker.Lib;
using static UcAutoClicker.Lib.WinApi;

namespace CustomLlaunchingApp.lib
{
 
    public class Win32Icon
    {
        public enum IconSize
        {
            s_16_16 = 0,
            s_32_32 = 1,          
        }


        public const uint SHGFI_ICON = 0x100;
        public const uint SHGFI_LARGEICON = 0x0; // 'Large icon
        public const uint SHGFI_SMALLICON = 0x1; // 'Small icon
        

       
        public static System.Drawing.Bitmap GetFileIcon(string fName , IconSize iconSize = IconSize.s_16_16)
        {
            IntPtr hImgSmall; //the handle to the system image list
            SHFILEINFO shinfo = new SHFILEINFO();

            // hImgSmall = WinApi.SHGetFileInfo(fName, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), SHGFI_ICON | SHGFI_SMALLICON);
            // SHGFI_ICON | SHGFI_LARGEICON
            hImgSmall = WinApi.SHGetFileInfo(
                fName, 0, 
                ref shinfo, 
                (uint)Marshal.SizeOf(shinfo), 
                iconSize == IconSize.s_16_16 ? SHGFI_ICON | SHGFI_SMALLICON : SHGFI_ICON | SHGFI_LARGEICON



                );
            return Icon.FromHandle(shinfo.hIcon).ToBitmap();
        }
    }
}
