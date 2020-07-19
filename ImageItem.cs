using System;
using System.Drawing;

namespace ExtractAssociatedIcon
{
    public class ImageItem : IDisposable
    {
        public ImageItem(SafeIconHandle hIcon, Interop.SHIL imageIndex)
        {
            _hIcon = hIcon;
            this.Icon = Icon.FromHandle(hIcon.DangerousGetHandle());
            this.DisplayText = $"{imageIndex} {this.Icon.Width}x{this.Icon.Height}";
            this.ImageIndex = imageIndex;
        }

        public Icon Icon { get; }

        public Interop.SHIL ImageIndex { get; }

        public string DisplayText { get; }

        public override string ToString()
        {
            return this.DisplayText;
        }

        private SafeIconHandle _hIcon;

        public void Dispose()
        {
            _hIcon.Dispose();
            GC.SuppressFinalize(this);
        }

        ~ImageItem()
        {
            this.Dispose();
        }
    }
}
