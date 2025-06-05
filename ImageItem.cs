using System;
using System.Drawing;

namespace ExtractAssociatedIcon;

public class ImageItem : IDisposable
{
	public ImageItem(SafeIconHandle hIcon, Interop.SHIL imageIndex)
	{
		_hIcon = hIcon;
		this.Icon = Icon.FromHandle(hIcon.DangerousGetHandle());
		this.DisplayText = $"{imageIndex} {this.Width}x{this.Height}";
		this.ImageIndex = imageIndex;
	}

	public Icon Icon { get; }

	public Interop.SHIL ImageIndex { get; }

	public int Width => this.Icon.Width;

	public int Height => this.Icon.Height;

	public string DisplayText { get; }

	public override string ToString() => this.DisplayText;

	private SafeIconHandle _hIcon;

	public void Dispose()
	{
		if (!_hIcon.IsInvalid)
			_hIcon.Dispose();
		GC.SuppressFinalize(this);
	}

	~ImageItem()
	{
		this.Dispose();
	}
}
