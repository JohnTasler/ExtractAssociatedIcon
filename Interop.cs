using System;
using System.Runtime.InteropServices;

namespace ExtractAssociatedIcon;

public static class Interop
{
	[DllImport("shell32.dll")]
	public static extern IntPtr SHGetFileInfo(string path, uint fileAttributes, ref SHFILEINFOW sfi, uint cbFileInfo, SHGFI flags);

	[DllImport("shell32.dll")]
	private static extern int SHGetImageList(SHIL iImageList, ref Guid iid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object imageList);

	public static IImageList SHGetImageList(SHIL iImageList)
	{
		var iid = typeof(IImageList).GUID;
		object imageList;
		int hr = SHGetImageList(iImageList, ref iid, out imageList);
		return hr >= 0
			? (IImageList)imageList
			: null;
	}

	[Guid("46EB5926-582E-4017-9FDF-E8998DAA0950")]
	[ComImport]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IImageList
	{
		int Add(IntPtr hbmImage, IntPtr hbmMask);

		int ReplaceIcon(int i, SafeIconHandle hIcon);

		void SetOverlayImage(int iImage, int iOverlay);

		void Replace(int i, IntPtr hbmImage, IntPtr hbmMask);

		int AddMasked(IntPtr hbmImage, COLORREF crMask);

		void Draw(ref IMAGELISTDRAWPARAMS imldp);

		void Remove(int i);

		SafeIconHandle GetIcon(int i, uint flags);

		IMAGEINFO GetImageInfo(int i);

		void Copy(int iDst, [MarshalAs(UnmanagedType.IUnknown)] object punkSrc, int iSrc, uint uFlags);

		[return: MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 5)]
		void Merge(int i1, [MarshalAs(UnmanagedType.IUnknown)] object punk2, int i2, int dx, int dy, ref Guid riid);

		[return: MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)]

		object Clone(ref Guid riid);

		RECT GetImageRect(int i);

		int GetIconSize(out int cx);

		void SetIconSize(int cx, int cy);

		int GetImageCount();

		void SetImageCount(uint uNewCount);

		COLORREF SetBkColor(COLORREF clrBk);

		COLORREF GetBkColor();

		void BeginDrag(int iTrack, int dxHotspot, int dyHotspot);

		void EndDrag();

		void DragEnter(IntPtr IntPtrLock, int x, int y);

		void DragLeave(IntPtr IntPtrLock);

		void DragMove(int x, int y);

		void SetDragCursorImage([MarshalAs(UnmanagedType.IUnknown)] object punk, int iDrag, int dxHotspot, int dyHotspot);

		void DragShowNolock(bool fShow);

		[return: MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)]
		object GetDragImage(out POINT ppt, out POINT pptHotspot, ref Guid riid);

		uint GetItemFlags(int i);

		int GetOverlayImage(int iOverlay);
	};

	[Flags]
	public enum SFGAO : uint
	{
		CanCopy         = 0x00000001, // Objects can be copied    (0x1)
		CanMove         = 0x00000002, // Objects can be moved     (0x2)
		CanLink         = 0x00000004, // Objects can be linked    (0x4)
		CanRename       = 0x00000010, // Objects can be renamed
		CanDelete       = 0x00000020, // Objects can be deleted
		HasPropSheet    = 0x00000040, // Objects have property sheets
		DropTarget      = 0x00000100, // Objects are drop target
		CapabilityMask  = 0x00000177,
		Link            = 0x00010000, // Shortcut (link)
		Share           = 0x00020000, // shared
		ReadOnly        = 0x00040000, // read-only
		Ghosted         = 0x00080000, // ghosted icon
		Hidden          = 0x00080000, // hidden object
		DisplayAttrMask = 0x000F0000,
		FileSysAncestor = 0x10000000, // It contains file system folder
		Folder          = 0x20000000, // It's a folder.
		FileSystem      = 0x40000000, // is a file system thing (file/folder/root)
		HasSubfolder    = 0x80000000, // Expandable in the map pane
		ContentsMask    = 0x80000000,
		Validate        = 0x01000000, // invalidate cached information
		Removable       = 0x02000000, // is this removeable media?
		Compressed      = 0x04000000, // Object is compressed (use alt color)
		Browsable       = 0x08000000, // is in-place browsable
		NonEnumerated   = 0x00100000, // is a non-enumerated object
		NewContent      = 0x00200000, // should show bold in explorer tree
		CanMoniker      = 0x00400000, // can create monikers for its objects
	}

	[Flags]
	public enum SHGFI : uint
	{
		/// <summary>get icon</summary>
		Icon              = 0x000000100,
		/// <summary>get display name</summary>
		DisplayName       = 0x000000200,
		/// <summary>get type name</summary>
		TypeName          = 0x000000400,
		/// <summary>get attributes</summary>
		Attributes        = 0x000000800,
		/// <summary>get icon location</summary>
		IconLocation      = 0x000001000,
		/// <summary>return exe type</summary>
		ExeType           = 0x000002000,
		/// <summary>get system icon index</summary>
		SysIconIndex      = 0x000004000,
		/// <summary>put a link overlay on icon</summary>
		LinkOverlay       = 0x000008000,
		/// <summary>show icon in selected state</summary>
		Selected          = 0x000010000,
		/// <summary>get only specified attributes</summary>
		AttrSpecified     = 0x000020000,
		/// <summary></summary>
		LargeIcon         = 0x000000000,
		/// <summary>get small icon</summary>
		SmallIcon         = 0x000000001,
		/// <summary>get open icon</summary>
		OpenIcon          = 0x000000002,
		/// <summary>get shell size icon</summary>
		ShellIconSize     = 0x000000004,
		/// <summary>pszPath is a pidl</summary>
		Pidl              = 0x000000008,
		/// <summary>use passed dwFileAttribute</summary>
		UseFileAttributes = 0x000000010,
		/// <summary>apply the appropriate overlays</summary>
		AddOverlays       = 0x000000020,
		/// <summary>Get the index of the overlay in the upper 8 bits of the iIcon</summary>
		OverlayIndex      = 0x000000040,
	}

	public enum SHIL
	{
		/// <summary>normally 32x32</summary>
		Large      = 0,
		/// <summary>normally 16x16</summary>
		Small = 1,
		/// <summary>normally 48x48?</summary>
		ExtraLarge = 2,
		/// <summary>like SHIL_SMALL, but tracks system small icon metric correctly</summary>
		SysSmall = 3,
		/// <summary>normally 256x256</summary>
		Jumbo = 4,
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct SHFILEINFOW
	{
		public IntPtr hIcon;
		public int iIcon;
		public SFGAO attributes;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
		public string displayName;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
		public string typeName;
	};

	[StructLayout(LayoutKind.Sequential)]
	public struct RECT
	{
		public int left;
		public int top;
		public int right;
		public int bottom;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct POINT
	{
		public int left;
		public int top;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct COLORREF
	{
		public uint value;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct IMAGEINFO
	{
		IntPtr hbmImage;
		IntPtr hbmMask;
		int Unused1;
		int Unused2;
		RECT rcImage;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct IMAGELISTDRAWPARAMS
	{
		uint cbSize;
		IntPtr himl;
		int i;
		IntPtr hdcDst;
		int x;
		int y;
		int cx;
		int cy;
		int xBitmap;        // x offest from the upperleft of bitmap
		int yBitmap;        // y offset from the upperleft of bitmap
		COLORREF rgbBk;
		COLORREF rgbFg;
		uint fStyle;
		uint dwRop;
		uint fState;
		uint Frame;
		COLORREF crEffect;
	}
}
