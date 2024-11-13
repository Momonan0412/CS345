namespace DIP_Coin
{
    partial class CoinDetection
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBoxLoadedImage = new PictureBox();
            menuStrip1 = new MenuStrip();
            openToolStripMenuItem = new ToolStripMenuItem();
            loadImageToolStripMenuItem = new ToolStripMenuItem();
            saveImageToolStripMenuItem = new ToolStripMenuItem();
            openFileDialogForImageDIP = new OpenFileDialog();
            saveFileDialogForImageDIP = new SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLoadedImage).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBoxLoadedImage
            // 
            pictureBoxLoadedImage.Location = new Point(12, 31);
            pictureBoxLoadedImage.Name = "pictureBoxLoadedImage";
            pictureBoxLoadedImage.Size = new Size(725, 505);
            pictureBoxLoadedImage.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxLoadedImage.TabIndex = 0;
            pictureBoxLoadedImage.TabStop = false;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { openToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(749, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadImageToolStripMenuItem, saveImageToolStripMenuItem });
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(59, 24);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // loadImageToolStripMenuItem
            // 
            loadImageToolStripMenuItem.Name = "loadImageToolStripMenuItem";
            loadImageToolStripMenuItem.Size = new Size(171, 26);
            loadImageToolStripMenuItem.Text = "Load Image";
            loadImageToolStripMenuItem.Click += loadImageToolStripMenuItem_Click;
            // 
            // saveImageToolStripMenuItem
            // 
            saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            saveImageToolStripMenuItem.Size = new Size(171, 26);
            saveImageToolStripMenuItem.Text = "Save Image";
            saveImageToolStripMenuItem.Click += saveImageToolStripMenuItem_Click;
            // 
            // openFileDialogForImageDIP
            // 
            openFileDialogForImageDIP.FileName = "openFileDialogForImageDIP";
            openFileDialogForImageDIP.FileOk += openFileDialog1_FileOk;
            // 
            // saveFileDialogForImageDIP
            // 
            saveFileDialogForImageDIP.FileOk += saveFileDialog1_FileOk;
            // 
            // CoinDetection
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(749, 548);
            Controls.Add(pictureBoxLoadedImage);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "CoinDetection";
            Text = "CoinDetection";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxLoadedImage).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxLoadedImage;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem loadImageToolStripMenuItem;
        private ToolStripMenuItem saveImageToolStripMenuItem;
        private OpenFileDialog openFileDialogForImageDIP;
        private SaveFileDialog saveFileDialogForImageDIP;
    }
}
