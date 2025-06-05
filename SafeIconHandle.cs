using System;
using System.Runtime.InteropServices;

namespace ExtractAssociatedIcon;

public class SafeIconHandle : SafeHandle
{
	public SafeIconHandle() : base(IntPtr.Zero, true)
	{
	}

	public override bool IsInvalid => this.handle == IntPtr.Zero;

	protected override bool ReleaseHandle()
	{
		if (DestroyIcon(this.handle))
		{
			this.handle = IntPtr.Zero;
			return true;
		}
		return false;
	}

	[DllImport("user32.dll", ExactSpelling = true)]
	private static extern bool DestroyIcon(IntPtr handle);
}
