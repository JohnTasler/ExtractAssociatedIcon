namespace ExtractAssociatedIcon
{
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this._extractButton = new System.Windows.Forms.Button();
            this._exePathTextBox = new System.Windows.Forms.TextBox();
            this._iconPictureBox = new System.Windows.Forms.PictureBox();
            this._imagesListBox = new System.Windows.Forms.ListBox();
            this._saveAsButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._iconPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this._extractButton);
            this.panel1.Controls.Add(this._exePathTextBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(636, 54);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "&File name:";
            // 
            // _extractButton
            // 
            this._extractButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._extractButton.Enabled = false;
            this._extractButton.Location = new System.Drawing.Point(549, 13);
            this._extractButton.Name = "_extractButton";
            this._extractButton.Size = new System.Drawing.Size(75, 23);
            this._extractButton.TabIndex = 2;
            this._extractButton.Text = "&Extract";
            this._extractButton.UseVisualStyleBackColor = true;
            this._extractButton.Click += new System.EventHandler(this.ExtractButton_Click);
            // 
            // _exePathTextBox
            // 
            this._exePathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._exePathTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this._exePathTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this._exePathTextBox.Location = new System.Drawing.Point(73, 15);
            this._exePathTextBox.Name = "_exePathTextBox";
            this._exePathTextBox.Size = new System.Drawing.Size(470, 20);
            this._exePathTextBox.TabIndex = 1;
            this._exePathTextBox.TextChanged += new System.EventHandler(this.ExePathTextBox_TextChanged);
            // 
            // _iconPictureBox
            // 
            this._iconPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._iconPictureBox.Location = new System.Drawing.Point(211, 54);
            this._iconPictureBox.Name = "_iconPictureBox";
            this._iconPictureBox.Size = new System.Drawing.Size(413, 381);
            this._iconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this._iconPictureBox.TabIndex = 1;
            this._iconPictureBox.TabStop = false;
            // 
            // _imagesListBox
            // 
            this._imagesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._imagesListBox.DisplayMember = "DisplayText";
            this._imagesListBox.FormattingEnabled = true;
            this._imagesListBox.Location = new System.Drawing.Point(12, 54);
            this._imagesListBox.Name = "_imagesListBox";
            this._imagesListBox.Size = new System.Drawing.Size(193, 381);
            this._imagesListBox.TabIndex = 1;
            this._imagesListBox.SelectedIndexChanged += new System.EventHandler(this.ImagesListBox_SelectedIndexChanged);
            // 
            // _saveAsButton
            // 
            this._saveAsButton.Enabled = false;
            this._saveAsButton.Location = new System.Drawing.Point(549, 412);
            this._saveAsButton.Name = "_saveAsButton";
            this._saveAsButton.Size = new System.Drawing.Size(75, 23);
            this._saveAsButton.TabIndex = 2;
            this._saveAsButton.Text = "Save &as...";
            this._saveAsButton.UseVisualStyleBackColor = true;
            this._saveAsButton.Click += new System.EventHandler(this.SaveAsButton_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this._extractButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 443);
            this.Controls.Add(this._saveAsButton);
            this.Controls.Add(this._imagesListBox);
            this.Controls.Add(this._iconPictureBox);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._iconPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button _extractButton;
        private System.Windows.Forms.TextBox _exePathTextBox;
        private System.Windows.Forms.PictureBox _iconPictureBox;
        private System.Windows.Forms.ListBox _imagesListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _saveAsButton;
    }
}

