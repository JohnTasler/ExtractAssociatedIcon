using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ExtractAssociatedIcon.Properties;

namespace ExtractAssociatedIcon;

public partial class Form1 : Form
{
	private string _previousIconPath = Settings.Default.PreviouslySelectedListItemName;

	public Form1()
	{
		this.InitializeComponent();
		_showBorderCheckBox.Checked = Settings.Default.ShowBorderCheckBox_IsChecked;
		Settings.Default.PreviousFiles ??= [];

		foreach (var file in Settings.Default.PreviousFiles)
		{
			_filePathComboBox.Items.Add(file);
		}
	}

	private void FilePathComboBox_TextChanged(object sender, EventArgs e)
	{
		_extractButton.Enabled = !string.IsNullOrWhiteSpace(_filePathComboBox.Text);
	}

	private void ExtractButton_Click(object sender, EventArgs e)
	{
		// Clear current contents
		if (_imagesListBox.DataSource is not null)
		{
			foreach (var imageItem in (BindingList<ImageItem>)_imagesListBox.DataSource)
			{
				imageItem.Dispose();
			}
		}

		try
		{
			var exePath = _filePathComboBox.Text;
			var items = new BindingList<ImageItem>();

			Interop.SHFILEINFOW sfi = new Interop.SHFILEINFOW();
			var a = Interop.SHGetFileInfo(exePath, 0, ref sfi, (uint)Marshal.SizeOf(sfi), Interop.SHGFI.SysIconIndex);

			if (!Settings.Default.PreviousFiles.Contains(exePath))
			{
				_filePathComboBox.Items.Add(exePath);
				Settings.Default.PreviousFiles.Add(exePath);
				Settings.Default.Save();
			}

			ImageItem selectedImageItem = null;
			foreach (var imageListIndex in new[] { Interop.SHIL.Small, Interop.SHIL.SysSmall, Interop.SHIL.Large, Interop.SHIL.ExtraLarge, Interop.SHIL.Jumbo })
			{
				var imageList = Interop.SHGetImageList((Interop.SHIL)imageListIndex);
				if (imageList is not null)
				{
					var hIcon = imageList.GetIcon(sfi.iIcon, 1);
					var item = new ImageItem(hIcon, imageListIndex);
					items.Add(item);

					if (item.DisplayText == _previousIconPath)
						selectedImageItem = item;
				}
			}

			_imagesListBox.DataSource = items;
			_imagesListBox.SelectedItem = selectedImageItem ?? items.FirstOrDefault();
			_imagesListBox.Focus();
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
			return;
		}
	}

	private void CenterIconPictureFrame()
	{
		if (_iconPictureBox.Image is not null)
		{
			int centerX = _imagePanel.Width / 2 - (_iconPictureBox.Image.Width + 2) / 2;
			int centerY = _imagePanel.Height / 2 - (_iconPictureBox.Image.Height + 2) / 2;
			_borderPanel.SetBounds(centerX, centerY, _iconPictureBox.Image.Width, _iconPictureBox.Image.Height);
		}
	}

	private void ImagesListBox_SelectedIndexChanged(object sender, EventArgs e)
	{
		var selectedItem = (ImageItem)_imagesListBox.SelectedItem;
		if (selectedItem is not null)
		{
			_previousIconPath = selectedItem.DisplayText;
			_iconPictureBox.Image = selectedItem?.Icon.ToBitmap();
			this.ShowBorderCheckBox_CheckedChanged(_showBorderCheckBox, EventArgs.Empty);
			_borderPanel.Visible = true;
			_saveAsButton.Enabled
				= _imagesListBox.Enabled
				= _imagesListBox.Enabled
				= _showBorderCheckBox.Enabled
				=  _iconPictureBox.Image is not null;
			this.CenterIconPictureFrame();

			Settings.Default.PreviouslySelectedListItemName = _previousIconPath;
			Settings.Default.Save();
		}
		else
		{
			_iconPictureBox.Image = null;
			_borderPanel.Visible = false;
			_iconPictureBox.Width = _iconPictureBox.Height = 0;
			_saveAsButton.Enabled
				= _imagesListBox.Enabled
				= _imagesListBox.Enabled
				= _showBorderCheckBox.Enabled
				= false;
		}
	}

	private void SaveAsButton_Click(object sender, EventArgs e)
	{
		var selectedItem = (ImageItem)_imagesListBox.SelectedItem;
		if (selectedItem is null)
		{
			return;
		}

		var fileName = $"{Path.GetFileNameWithoutExtension(_filePathComboBox.Text)}_{selectedItem.ImageIndex}.png";

		var saveFileDialog = new SaveFileDialog
		{
			Filter = "Portable Network Graphic (*.png)|*.png|All Files (*.*)|*.*",
			FilterIndex	= Settings.Default.PreviousSelectedSaveFilter,
			FileName = fileName,
			OverwritePrompt = true,
			Title = "Save Icon As",
			InitialDirectory = Path.GetDirectoryName(_filePathComboBox.Text) ?? Settings.Default.PreviousSaveFilePath,
			ClientGuid = new Guid("25653A1A-B87A-4C81-AB3A-CEB8C0E44D74"),
		};

		var result = saveFileDialog.ShowDialog(this);
		if (result == DialogResult.OK)
		{
			Settings.Default.PreviousSelectedSaveFilter = saveFileDialog.FilterIndex;

			selectedItem.Icon.ToBitmap().Save(saveFileDialog.FileName, ImageFormat.Png);
		}
	}

	private void BrowseButton_Click(object sender, EventArgs e)
	{
		var openFileDialog = new OpenFileDialog
		{
			Filter = "Executable files (*.exe)|*.exe|Dynamic Link Libraries (*.dll)|*.dll|Icon files (*.ico)|*.ico|Shortcut files (*.lnk)|*.lnk|All files (*.*)|*.*",
			Multiselect = false,
			FilterIndex = Settings.Default.PreviousSelectedOpenFilter,
			CheckFileExists = true,
			CheckPathExists = true,
			Title = "Select an executable, DLL, icon, or shortcut file",
			InitialDirectory = Settings.Default.PreviousOpenFilePath,
			ClientGuid = new Guid("A1B2C3D4-E5F6-7890-ABCD-EF1234567890"),
		};

		var result = openFileDialog.ShowDialog(this);
		if (result == DialogResult.OK)
		{
			Settings.Default.PreviousSelectedOpenFilter = openFileDialog.FilterIndex;

			_filePathComboBox.Text = openFileDialog.FileName;
			_filePathComboBox.SelectionStart = _filePathComboBox.Text.Length;
			_filePathComboBox.SelectionLength = 0;
			_filePathComboBox.Focus();
			this.ExtractButton_Click(this, EventArgs.Empty);
		}
	}

	private void ImagePanel_Resize(object sender, EventArgs e) => this.CenterIconPictureFrame();

	private void ShowBorderCheckBox_CheckedChanged(object sender, EventArgs e)
	{
		_borderPanel.BackColor = _showBorderCheckBox.Checked
			? SystemColors.ControlText
			: Color.Transparent;

		Settings.Default.ShowBorderCheckBox_IsChecked = _showBorderCheckBox.Checked;
		Settings.Default.Save();
	}
}
