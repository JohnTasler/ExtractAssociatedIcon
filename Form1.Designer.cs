namespace ExtractAssociatedIcon;

partial class Form1
{
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	/// <summary>
	/// Clean up any resources being used.
	/// </summary>
	/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	protected override void Dispose(bool disposing)
	{
		if (disposing && (components != null))
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	#region Windows Form Designer generated code

	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
		_filePanel = new System.Windows.Forms.Panel();
		_fileNameLabel = new System.Windows.Forms.Label();
		_browseButton = new System.Windows.Forms.Button();
		_extractButton = new System.Windows.Forms.Button();
		_filePathComboBox = new System.Windows.Forms.ComboBox();
		_iconPictureBox = new System.Windows.Forms.PictureBox();
		_imagesListBox = new System.Windows.Forms.ListBox();
		_saveAsButton = new System.Windows.Forms.Button();
		_imagePanel = new System.Windows.Forms.Panel();
		_borderPanel = new System.Windows.Forms.Panel();
		_showBorderCheckBox = new System.Windows.Forms.CheckBox();
		_filePanel.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)_iconPictureBox).BeginInit();
		_imagePanel.SuspendLayout();
		_borderPanel.SuspendLayout();
		this.SuspendLayout();
		// 
		// _filePanel
		// 
		_filePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
		_filePanel.Controls.Add(_fileNameLabel);
		_filePanel.Controls.Add(_browseButton);
		_filePanel.Controls.Add(_filePathComboBox);
		_filePanel.Controls.Add(_extractButton);
		_filePanel.Dock = System.Windows.Forms.DockStyle.Top;
		_filePanel.Location = new System.Drawing.Point(0, 0);
		_filePanel.Margin = new System.Windows.Forms.Padding(15);
		_filePanel.Name = "_filePanel";
		_filePanel.Size = new System.Drawing.Size(524, 53);
		_filePanel.TabIndex = 0;
		// 
		// _fileNameLabel
		// 
		_fileNameLabel.AutoSize = true;
		_fileNameLabel.Location = new System.Drawing.Point(14, 19);
		_fileNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		_fileNameLabel.Name = "_fileNameLabel";
		_fileNameLabel.Size = new System.Drawing.Size(61, 15);
		_fileNameLabel.TabIndex = 1;
		_fileNameLabel.Text = "&File name:";
		// 
		// _browseButton
		// 
		_browseButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		_browseButton.Location = new System.Drawing.Point(378, 13);
		_browseButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		_browseButton.Name = "_browseButton";
		_browseButton.Size = new System.Drawing.Size(33, 27);
		_browseButton.TabIndex = 3;
		_browseButton.Text = "...";
		_browseButton.UseVisualStyleBackColor = true;
		_browseButton.Click += this.BrowseButton_Click;
		// 
		// _extractButton
		// 
		_extractButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		_extractButton.Enabled = false;
		_extractButton.Location = new System.Drawing.Point(423, 13);
		_extractButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		_extractButton.Name = "_extractButton";
		_extractButton.Size = new System.Drawing.Size(88, 27);
		_extractButton.TabIndex = 4;
		_extractButton.Text = "&Extract";
		_extractButton.UseVisualStyleBackColor = true;
		_extractButton.Click += this.ExtractButton_Click;
		// 
		// _filePathComboBox
		// 
		_filePathComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		_filePathComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
		_filePathComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
		_filePathComboBox.Location = new System.Drawing.Point(85, 15);
		_filePathComboBox.Margin = new System.Windows.Forms.Padding(0);
		_filePathComboBox.Name = "_filePathComboBox";
		_filePathComboBox.Size = new System.Drawing.Size(294, 23);
		_filePathComboBox.Sorted = true;
		_filePathComboBox.TabIndex = 2;
		_filePathComboBox.TextChanged += this.FilePathComboBox_TextChanged;
		// 
		// _iconPictureBox
		// 
		_iconPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		_iconPictureBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
		_iconPictureBox.Location = new System.Drawing.Point(1, 1);
		_iconPictureBox.Margin = new System.Windows.Forms.Padding(0);
		_iconPictureBox.Name = "_iconPictureBox";
		_iconPictureBox.Size = new System.Drawing.Size(96, 96);
		_iconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
		_iconPictureBox.TabIndex = 6;
		_iconPictureBox.TabStop = false;
		// 
		// _imagesListBox
		// 
		_imagesListBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		_imagesListBox.DisplayMember = "DisplayText";
		_imagesListBox.Enabled = false;
		_imagesListBox.FormattingEnabled = true;
		_imagesListBox.Location = new System.Drawing.Point(14, 52);
		_imagesListBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		_imagesListBox.Name = "_imagesListBox";
		_imagesListBox.Size = new System.Drawing.Size(224, 289);
		_imagesListBox.TabIndex = 1;
		_imagesListBox.SelectedIndexChanged += this.ImagesListBox_SelectedIndexChanged;
		// 
		// _saveAsButton
		// 
		_saveAsButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		_saveAsButton.Enabled = false;
		_saveAsButton.Location = new System.Drawing.Point(423, 323);
		_saveAsButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		_saveAsButton.Name = "_saveAsButton";
		_saveAsButton.Size = new System.Drawing.Size(88, 27);
		_saveAsButton.TabIndex = 4;
		_saveAsButton.Text = "Save &as...";
		_saveAsButton.UseVisualStyleBackColor = true;
		_saveAsButton.Click += this.SaveAsButton_Click;
		// 
		// _imagePanel
		// 
		_imagePanel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		_imagePanel.Controls.Add(_borderPanel);
		_imagePanel.Location = new System.Drawing.Point(252, 52);
		_imagePanel.Margin = new System.Windows.Forms.Padding(0);
		_imagePanel.Name = "_imagePanel";
		_imagePanel.Size = new System.Drawing.Size(258, 258);
		_imagePanel.TabIndex = 2;
		_imagePanel.Resize += this.ImagePanel_Resize;
		// 
		// _borderPanel
		// 
		_borderPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
		_borderPanel.BackColor = System.Drawing.SystemColors.ControlText;
		_borderPanel.Controls.Add(_iconPictureBox);
		_borderPanel.Location = new System.Drawing.Point(0, 0);
		_borderPanel.Margin = new System.Windows.Forms.Padding(0);
		_borderPanel.Name = "_borderPanel";
		_borderPanel.Size = new System.Drawing.Size(98, 98);
		_borderPanel.TabIndex = 0;
		_borderPanel.Visible = false;
		// 
		// _showBorderCheckBox
		// 
		_showBorderCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		_showBorderCheckBox.AutoSize = true;
		_showBorderCheckBox.Enabled = false;
		_showBorderCheckBox.Location = new System.Drawing.Point(252, 328);
		_showBorderCheckBox.Name = "_showBorderCheckBox";
		_showBorderCheckBox.Size = new System.Drawing.Size(93, 19);
		_showBorderCheckBox.TabIndex = 3;
		_showBorderCheckBox.Text = "Show &border";
		_showBorderCheckBox.UseVisualStyleBackColor = true;
		_showBorderCheckBox.CheckedChanged += this.ShowBorderCheckBox_CheckedChanged;
		// 
		// Form1
		// 
		this.AcceptButton = _extractButton;
		this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.ClientSize = new System.Drawing.Size(524, 363);
		this.Controls.Add(_showBorderCheckBox);
		this.Controls.Add(_imagePanel);
		this.Controls.Add(_saveAsButton);
		this.Controls.Add(_imagesListBox);
		this.Controls.Add(_filePanel);
		this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
		this.MinimumSize = new System.Drawing.Size(540, 402);
		this.Name = "Form1";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Extract Associated Icon";
		_filePanel.ResumeLayout(false);
		_filePanel.PerformLayout();
		((System.ComponentModel.ISupportInitialize)_iconPictureBox).EndInit();
		_imagePanel.ResumeLayout(false);
		_borderPanel.ResumeLayout(false);
		this.ResumeLayout(false);
		this.PerformLayout();

	}

	#endregion

	private System.Windows.Forms.Panel _filePanel;
	private System.Windows.Forms.Button _extractButton;
	private System.Windows.Forms.ComboBox _filePathComboBox;
	private System.Windows.Forms.PictureBox _iconPictureBox;
	private System.Windows.Forms.ListBox _imagesListBox;
	private System.Windows.Forms.Label _fileNameLabel;
	private System.Windows.Forms.Button _saveAsButton;
	private System.Windows.Forms.Button _browseButton;
	private System.Windows.Forms.Panel _imagePanel;
	private System.Windows.Forms.CheckBox _showBorderCheckBox;
	private System.Windows.Forms.Panel _borderPanel;
}

