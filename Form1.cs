using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32.SafeHandles;

namespace ExtractAssociatedIcon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.InitializeComponent();
        }

        private void ExePathTextBox_TextChanged(object sender, EventArgs e)
        {
            _extractButton.Enabled = !string.IsNullOrWhiteSpace(_exePathTextBox.Text);
        }

        private void ExtractButton_Click(object sender, EventArgs e)
        {
            // Clear current contents
            if (_imagesListBox.DataSource != null)
            {
                foreach (var imageItem in (BindingList<ImageItem>)_imagesListBox.DataSource)
                {
                    imageItem.Dispose();
                }
            }

            try
            {
                var exePath = _exePathTextBox.Text;
                var items = new BindingList<ImageItem>();

                Interop.SHFILEINFOW sfi = new Interop.SHFILEINFOW();
                var a = Interop.SHGetFileInfo(exePath, 0, ref sfi, (uint)Marshal.SizeOf(sfi), Interop.SHGFI.SysIconIndex);

                foreach (var imageListIndex in new[] { Interop.SHIL.Small, Interop.SHIL.SysSmall, Interop.SHIL.Large, Interop.SHIL.ExtraLarge, Interop.SHIL.Jumbo })
                {
                    var imageList = Interop.SHGetImageList((Interop.SHIL)imageListIndex);
                    if (imageList != null)
                    {
                        var hIcon = imageList.GetIcon(sfi.iIcon, 1);
                        var item = new ImageItem(hIcon, imageListIndex);
                        items.Add(item);
                    }
                }

                _imagesListBox.DataSource = items;
                _imagesListBox.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void ImagesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = (ImageItem)_imagesListBox.SelectedItem;
            _iconPictureBox.Image = selectedItem?.Icon.ToBitmap();
            _saveAsButton.Enabled = _iconPictureBox.Image != null;
        }

        private void SaveAsButton_Click(object sender, EventArgs e)
        {
            var selectedItem = (ImageItem)_imagesListBox.SelectedItem;
            if (selectedItem == null)
            {
                return;
            }

            var fileName = $"{Path.GetFileNameWithoutExtension(_exePathTextBox.Text)}_{selectedItem.ImageIndex}.ico";

            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Icon files (*.ico)|*.ico|Portable Network Graphic (*.png)|*.png",
                FilterIndex = 0,
                DefaultExt = "ico",
                FileName = fileName,
                OverwritePrompt = true,
            };

            var result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (saveFileDialog.FilterIndex == 0)
                {
                    selectedItem.Icon.ToBitmap().Save(saveFileDialog.FileName, ImageFormat.Icon);
                }
                else
                {
                    selectedItem.Icon.ToBitmap().Save(saveFileDialog.FileName, ImageFormat.Png);
                }
            }
        }
    }
}
