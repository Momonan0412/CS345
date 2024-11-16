namespace Image_Processing
{
    partial class ImageProcessingForm
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
            menuStrip1 = new MenuStrip();
            openToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem1 = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            dIPToolStripMenuItem = new ToolStripMenuItem();
            pixelCopyToolStripMenuItem = new ToolStripMenuItem();
            grayscallingToolStripMenuItem = new ToolStripMenuItem();
            mirrorToolStripMenuItem = new ToolStripMenuItem();
            sepiaToolStripMenuItem = new ToolStripMenuItem();
            mirrorToolStripMenuItem1 = new ToolStripMenuItem();
            mirrorVerticalToolStripMenuItem = new ToolStripMenuItem();
            histogramToolStripMenuItem = new ToolStripMenuItem();
            addImageForPictureBoxOneToolStripMenuItem = new ToolStripMenuItem();
            loadImageOneToolStripMenuItem = new ToolStripMenuItem();
            addImageForPictureBoxTwoToolStripMenuItem = new ToolStripMenuItem();
            loadImageTwoToolStripMenuItem = new ToolStripMenuItem();
            dIPPartTwoForImageToolStripMenuItem = new ToolStripMenuItem();
            smoothToolStripMenuItem = new ToolStripMenuItem();
            gaussianBlurToolStripMenuItem = new ToolStripMenuItem();
            sharpenToolStripMenuItem = new ToolStripMenuItem();
            meanRemovalToolStripMenuItem = new ToolStripMenuItem();
            embossingToolStripMenuItem = new ToolStripMenuItem();
            embossHorzVerticalToolStripMenuItem = new ToolStripMenuItem();
            embossAllDirectionsToolStripMenuItem = new ToolStripMenuItem();
            embossLossyToolStripMenuItem = new ToolStripMenuItem();
            embossHorizontalToolStripMenuItem = new ToolStripMenuItem();
            embossVerticalToolStripMenuItem = new ToolStripMenuItem();
            prefinalDIPToolStripMenuItem = new ToolStripMenuItem();
            applyToolStripMenuItem = new ToolStripMenuItem();
            openFileDialogForImageDIP = new OpenFileDialog();
            saveFileDialogForImageDIP = new SaveFileDialog();
            sourcePictureBox = new PictureBox();
            processedPictureBox = new PictureBox();
            brightnessTrackBar = new TrackBar();
            label1 = new Label();
            equalizationTrackBar = new TrackBar();
            label2 = new Label();
            rotationTrackBar = new TrackBar();
            useWebcamButton = new Button();
            comboBoxDeviceList = new ComboBox();
            label3 = new Label();
            webcamCopyChanger = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            openFileDialogPicOne = new OpenFileDialog();
            openFileDialogPicTwo = new OpenFileDialog();
            buttonSubtract = new Button();
            openFileDialogForImageTwoDIP = new OpenFileDialog();
            openFileDialogPreFinalDIP = new OpenFileDialog();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sourcePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)processedPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)brightnessTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)equalizationTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)rotationTrackBar).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { openToolStripMenuItem, dIPToolStripMenuItem, addImageForPictureBoxOneToolStripMenuItem, addImageForPictureBoxTwoToolStripMenuItem, dIPPartTwoForImageToolStripMenuItem, prefinalDIPToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1124, 32);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem1, saveToolStripMenuItem });
            openToolStripMenuItem.Font = new Font("Agency FB", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(166, 28);
            openToolStripMenuItem.Text = "Open/Save Image Here";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // openToolStripMenuItem1
            // 
            openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            openToolStripMenuItem1.Size = new Size(124, 28);
            openToolStripMenuItem1.Text = "Open";
            openToolStripMenuItem1.Click += openToolStripMenuItem1_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(124, 28);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // dIPToolStripMenuItem
            // 
            dIPToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { pixelCopyToolStripMenuItem, grayscallingToolStripMenuItem, mirrorToolStripMenuItem, sepiaToolStripMenuItem, mirrorToolStripMenuItem1, mirrorVerticalToolStripMenuItem, histogramToolStripMenuItem });
            dIPToolStripMenuItem.Font = new Font("Agency FB", 12F, FontStyle.Bold | FontStyle.Italic);
            dIPToolStripMenuItem.Name = "dIPToolStripMenuItem";
            dIPToolStripMenuItem.Size = new Size(166, 28);
            dIPToolStripMenuItem.Text = "DIP Part One For Image";
            dIPToolStripMenuItem.Click += dIPToolStripMenuItem_Click;
            // 
            // pixelCopyToolStripMenuItem
            // 
            pixelCopyToolStripMenuItem.Name = "pixelCopyToolStripMenuItem";
            pixelCopyToolStripMenuItem.Size = new Size(197, 28);
            pixelCopyToolStripMenuItem.Text = "Pixel Copy";
            pixelCopyToolStripMenuItem.Click += pixelCopyToolStripMenuItem_Click;
            // 
            // grayscallingToolStripMenuItem
            // 
            grayscallingToolStripMenuItem.Name = "grayscallingToolStripMenuItem";
            grayscallingToolStripMenuItem.Size = new Size(197, 28);
            grayscallingToolStripMenuItem.Text = "Grayscaling";
            grayscallingToolStripMenuItem.Click += grayscallingToolStripMenuItem_Click;
            // 
            // mirrorToolStripMenuItem
            // 
            mirrorToolStripMenuItem.Name = "mirrorToolStripMenuItem";
            mirrorToolStripMenuItem.Size = new Size(197, 28);
            mirrorToolStripMenuItem.Text = "Inversion";
            mirrorToolStripMenuItem.Click += mirrorToolStripMenuItem_Click;
            // 
            // sepiaToolStripMenuItem
            // 
            sepiaToolStripMenuItem.Name = "sepiaToolStripMenuItem";
            sepiaToolStripMenuItem.Size = new Size(197, 28);
            sepiaToolStripMenuItem.Text = "Sepia";
            sepiaToolStripMenuItem.Click += sepiaToolStripMenuItem_Click;
            // 
            // mirrorToolStripMenuItem1
            // 
            mirrorToolStripMenuItem1.Name = "mirrorToolStripMenuItem1";
            mirrorToolStripMenuItem1.Size = new Size(197, 28);
            mirrorToolStripMenuItem1.Text = "Mirror Horizontal";
            mirrorToolStripMenuItem1.Click += mirrorToolStripMenuItem1_Click;
            // 
            // mirrorVerticalToolStripMenuItem
            // 
            mirrorVerticalToolStripMenuItem.Name = "mirrorVerticalToolStripMenuItem";
            mirrorVerticalToolStripMenuItem.Size = new Size(197, 28);
            mirrorVerticalToolStripMenuItem.Text = "Mirror Vertical";
            mirrorVerticalToolStripMenuItem.Click += mirrorVerticalToolStripMenuItem_Click;
            // 
            // histogramToolStripMenuItem
            // 
            histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
            histogramToolStripMenuItem.Size = new Size(197, 28);
            histogramToolStripMenuItem.Text = "Histogram";
            histogramToolStripMenuItem.Click += histogramToolStripMenuItem_Click;
            // 
            // addImageForPictureBoxOneToolStripMenuItem
            // 
            addImageForPictureBoxOneToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadImageOneToolStripMenuItem });
            addImageForPictureBoxOneToolStripMenuItem.Font = new Font("Agency FB", 12F, FontStyle.Bold | FontStyle.Italic);
            addImageForPictureBoxOneToolStripMenuItem.Name = "addImageForPictureBoxOneToolStripMenuItem";
            addImageForPictureBoxOneToolStripMenuItem.Size = new Size(211, 28);
            addImageForPictureBoxOneToolStripMenuItem.Text = "Add Image For Picture Box One";
            // 
            // loadImageOneToolStripMenuItem
            // 
            loadImageOneToolStripMenuItem.Name = "loadImageOneToolStripMenuItem";
            loadImageOneToolStripMenuItem.Size = new Size(188, 28);
            loadImageOneToolStripMenuItem.Text = "Load Image One";
            loadImageOneToolStripMenuItem.Click += loadImageOneToolStripMenuItem_Click;
            // 
            // addImageForPictureBoxTwoToolStripMenuItem
            // 
            addImageForPictureBoxTwoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadImageTwoToolStripMenuItem });
            addImageForPictureBoxTwoToolStripMenuItem.Font = new Font("Agency FB", 12F, FontStyle.Bold | FontStyle.Italic);
            addImageForPictureBoxTwoToolStripMenuItem.Name = "addImageForPictureBoxTwoToolStripMenuItem";
            addImageForPictureBoxTwoToolStripMenuItem.Size = new Size(214, 28);
            addImageForPictureBoxTwoToolStripMenuItem.Text = "Add Image For Picture Box Two";
            // 
            // loadImageTwoToolStripMenuItem
            // 
            loadImageTwoToolStripMenuItem.Name = "loadImageTwoToolStripMenuItem";
            loadImageTwoToolStripMenuItem.Size = new Size(191, 28);
            loadImageTwoToolStripMenuItem.Text = "Load Image Two";
            loadImageTwoToolStripMenuItem.Click += loadImageTwoToolStripMenuItem_Click;
            // 
            // dIPPartTwoForImageToolStripMenuItem
            // 
            dIPPartTwoForImageToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { smoothToolStripMenuItem, gaussianBlurToolStripMenuItem, sharpenToolStripMenuItem, meanRemovalToolStripMenuItem, embossingToolStripMenuItem, embossHorzVerticalToolStripMenuItem, embossAllDirectionsToolStripMenuItem, embossLossyToolStripMenuItem, embossHorizontalToolStripMenuItem, embossVerticalToolStripMenuItem });
            dIPPartTwoForImageToolStripMenuItem.Font = new Font("Agency FB", 12F, FontStyle.Bold | FontStyle.Italic);
            dIPPartTwoForImageToolStripMenuItem.Name = "dIPPartTwoForImageToolStripMenuItem";
            dIPPartTwoForImageToolStripMenuItem.Size = new Size(169, 28);
            dIPPartTwoForImageToolStripMenuItem.Text = "DIP Part Two For Image";
            dIPPartTwoForImageToolStripMenuItem.Click += dIPPartTwoForImageToolStripMenuItem_Click;
            // 
            // smoothToolStripMenuItem
            // 
            smoothToolStripMenuItem.Name = "smoothToolStripMenuItem";
            smoothToolStripMenuItem.Size = new Size(214, 28);
            smoothToolStripMenuItem.Text = "Smooth";
            smoothToolStripMenuItem.Click += smoothToolStripMenuItem_Click;
            // 
            // gaussianBlurToolStripMenuItem
            // 
            gaussianBlurToolStripMenuItem.Name = "gaussianBlurToolStripMenuItem";
            gaussianBlurToolStripMenuItem.Size = new Size(214, 28);
            gaussianBlurToolStripMenuItem.Text = "Gaussian Blur ";
            gaussianBlurToolStripMenuItem.Click += gaussianBlurToolStripMenuItem_Click;
            // 
            // sharpenToolStripMenuItem
            // 
            sharpenToolStripMenuItem.Name = "sharpenToolStripMenuItem";
            sharpenToolStripMenuItem.Size = new Size(214, 28);
            sharpenToolStripMenuItem.Text = "Sharpen";
            sharpenToolStripMenuItem.Click += sharpenToolStripMenuItem_Click;
            // 
            // meanRemovalToolStripMenuItem
            // 
            meanRemovalToolStripMenuItem.Name = "meanRemovalToolStripMenuItem";
            meanRemovalToolStripMenuItem.Size = new Size(214, 28);
            meanRemovalToolStripMenuItem.Text = "Mean Removal ";
            meanRemovalToolStripMenuItem.Click += meanRemovalToolStripMenuItem_Click;
            // 
            // embossingToolStripMenuItem
            // 
            embossingToolStripMenuItem.Name = "embossingToolStripMenuItem";
            embossingToolStripMenuItem.Size = new Size(214, 28);
            embossingToolStripMenuItem.Text = "Emboss Laplascian";
            embossingToolStripMenuItem.Click += embossingToolStripMenuItem_Click;
            // 
            // embossHorzVerticalToolStripMenuItem
            // 
            embossHorzVerticalToolStripMenuItem.Name = "embossHorzVerticalToolStripMenuItem";
            embossHorzVerticalToolStripMenuItem.Size = new Size(214, 28);
            embossHorzVerticalToolStripMenuItem.Text = "EmbossHorzVertical";
            embossHorzVerticalToolStripMenuItem.Click += embossHorzVerticalToolStripMenuItem_Click;
            // 
            // embossAllDirectionsToolStripMenuItem
            // 
            embossAllDirectionsToolStripMenuItem.Name = "embossAllDirectionsToolStripMenuItem";
            embossAllDirectionsToolStripMenuItem.Size = new Size(214, 28);
            embossAllDirectionsToolStripMenuItem.Text = "EmbossAllDirections";
            embossAllDirectionsToolStripMenuItem.Click += embossAllDirectionsToolStripMenuItem_Click;
            // 
            // embossLossyToolStripMenuItem
            // 
            embossLossyToolStripMenuItem.Name = "embossLossyToolStripMenuItem";
            embossLossyToolStripMenuItem.Size = new Size(214, 28);
            embossLossyToolStripMenuItem.Text = "EmbossLossy";
            embossLossyToolStripMenuItem.Click += embossLossyToolStripMenuItem_Click;
            // 
            // embossHorizontalToolStripMenuItem
            // 
            embossHorizontalToolStripMenuItem.Name = "embossHorizontalToolStripMenuItem";
            embossHorizontalToolStripMenuItem.Size = new Size(214, 28);
            embossHorizontalToolStripMenuItem.Text = "EmbossHorizontal";
            embossHorizontalToolStripMenuItem.Click += embossHorizontalToolStripMenuItem_Click;
            // 
            // embossVerticalToolStripMenuItem
            // 
            embossVerticalToolStripMenuItem.Name = "embossVerticalToolStripMenuItem";
            embossVerticalToolStripMenuItem.Size = new Size(214, 28);
            embossVerticalToolStripMenuItem.Text = "EmbossVertical";
            embossVerticalToolStripMenuItem.Click += embossVerticalToolStripMenuItem_Click;
            // 
            // prefinalDIPToolStripMenuItem
            // 
            prefinalDIPToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { applyToolStripMenuItem });
            prefinalDIPToolStripMenuItem.Font = new Font("Agency FB", 12F, FontStyle.Bold | FontStyle.Italic);
            prefinalDIPToolStripMenuItem.Name = "prefinalDIPToolStripMenuItem";
            prefinalDIPToolStripMenuItem.Size = new Size(95, 28);
            prefinalDIPToolStripMenuItem.Text = "Prefinal DIP";
            // 
            // applyToolStripMenuItem
            // 
            applyToolStripMenuItem.Name = "applyToolStripMenuItem";
            applyToolStripMenuItem.Size = new Size(224, 28);
            applyToolStripMenuItem.Text = "Apply";
            applyToolStripMenuItem.Click += applyToolStripMenuItem_Click;
            // 
            // openFileDialogForImageDIP
            // 
            openFileDialogForImageDIP.FileName = "openFileDialogForImageOneDIP";
            openFileDialogForImageDIP.FileOk += openFileDialog1_FileOk;
            // 
            // saveFileDialogForImageDIP
            // 
            saveFileDialogForImageDIP.FileName = "saveFileDialogForImageDIP";
            saveFileDialogForImageDIP.FileOk += saveFileDialog1_FileOk;
            // 
            // sourcePictureBox
            // 
            sourcePictureBox.BackColor = SystemColors.ActiveCaption;
            sourcePictureBox.Location = new Point(12, 44);
            sourcePictureBox.Name = "sourcePictureBox";
            sourcePictureBox.Size = new Size(545, 451);
            sourcePictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            sourcePictureBox.TabIndex = 1;
            sourcePictureBox.TabStop = false;
            // 
            // processedPictureBox
            // 
            processedPictureBox.BackColor = SystemColors.ActiveCaption;
            processedPictureBox.Location = new Point(573, 44);
            processedPictureBox.Name = "processedPictureBox";
            processedPictureBox.Size = new Size(545, 451);
            processedPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            processedPictureBox.TabIndex = 2;
            processedPictureBox.TabStop = false;
            // 
            // brightnessTrackBar
            // 
            brightnessTrackBar.BackColor = SystemColors.ActiveCaption;
            brightnessTrackBar.Cursor = Cursors.Hand;
            brightnessTrackBar.Location = new Point(988, 527);
            brightnessTrackBar.Maximum = 50;
            brightnessTrackBar.Minimum = -50;
            brightnessTrackBar.Name = "brightnessTrackBar";
            brightnessTrackBar.Size = new Size(130, 56);
            brightnessTrackBar.TabIndex = 3;
            brightnessTrackBar.Scroll += trackBar1_Scroll;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Agency FB", 12F, FontStyle.Bold | FontStyle.Italic);
            label1.Location = new Point(1015, 499);
            label1.Name = "label1";
            label1.Size = new Size(74, 24);
            label1.TabIndex = 4;
            label1.Text = "Brightness";
            label1.Click += label1_Click;
            // 
            // equalizationTrackBar
            // 
            equalizationTrackBar.BackColor = SystemColors.ActiveCaption;
            equalizationTrackBar.Cursor = Cursors.Hand;
            equalizationTrackBar.Location = new Point(852, 527);
            equalizationTrackBar.Maximum = 100;
            equalizationTrackBar.Minimum = -100;
            equalizationTrackBar.Name = "equalizationTrackBar";
            equalizationTrackBar.Size = new Size(130, 56);
            equalizationTrackBar.TabIndex = 5;
            equalizationTrackBar.Scroll += trackBar2_Scroll_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Agency FB", 12F, FontStyle.Bold | FontStyle.Italic);
            label2.Location = new Point(877, 499);
            label2.Name = "label2";
            label2.Size = new Size(79, 24);
            label2.TabIndex = 6;
            label2.Text = "Equalization";
            // 
            // rotationTrackBar
            // 
            rotationTrackBar.BackColor = SystemColors.ActiveCaption;
            rotationTrackBar.Cursor = Cursors.Hand;
            rotationTrackBar.Location = new Point(573, 527);
            rotationTrackBar.Maximum = 360;
            rotationTrackBar.Minimum = -360;
            rotationTrackBar.Name = "rotationTrackBar";
            rotationTrackBar.Size = new Size(273, 56);
            rotationTrackBar.TabIndex = 7;
            rotationTrackBar.Scroll += rotationTrackBar_Scroll;
            // 
            // useWebcamButton
            // 
            useWebcamButton.BackColor = SystemColors.ActiveCaption;
            useWebcamButton.Font = new Font("Agency FB", 12F, FontStyle.Bold | FontStyle.Italic);
            useWebcamButton.Location = new Point(170, 522);
            useWebcamButton.Name = "useWebcamButton";
            useWebcamButton.Size = new Size(118, 40);
            useWebcamButton.TabIndex = 9;
            useWebcamButton.Text = "Use Webcam";
            useWebcamButton.UseVisualStyleBackColor = false;
            useWebcamButton.Click += useWebcamButton_Click;
            // 
            // comboBoxDeviceList
            // 
            comboBoxDeviceList.FormattingEnabled = true;
            comboBoxDeviceList.Location = new Point(293, 529);
            comboBoxDeviceList.Name = "comboBoxDeviceList";
            comboBoxDeviceList.Size = new Size(151, 28);
            comboBoxDeviceList.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Agency FB", 12F, FontStyle.Bold | FontStyle.Italic);
            label3.Location = new Point(323, 502);
            label3.Name = "label3";
            label3.Size = new Size(91, 24);
            label3.TabIndex = 11;
            label3.Text = "Select Device";
            label3.Click += label3_Click;
            // 
            // webcamCopyChanger
            // 
            webcamCopyChanger.FormattingEnabled = true;
            webcamCopyChanger.Items.AddRange(new object[] { "Pixel Copy", "Grayscale", "Inversion", "Sepia", "Mirror Horizontal", "Mirror Vertical" });
            webcamCopyChanger.Location = new Point(12, 529);
            webcamCopyChanger.Name = "webcamCopyChanger";
            webcamCopyChanger.Size = new Size(151, 28);
            webcamCopyChanger.TabIndex = 12;
            webcamCopyChanger.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Agency FB", 12F, FontStyle.Bold | FontStyle.Italic);
            label4.Location = new Point(50, 502);
            label4.Name = "label4";
            label4.Size = new Size(73, 24);
            label4.TabIndex = 13;
            label4.Text = "Select DIP";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Agency FB", 12F, FontStyle.Bold | FontStyle.Italic);
            label5.Location = new Point(680, 500);
            label5.Name = "label5";
            label5.Size = new Size(58, 24);
            label5.TabIndex = 14;
            label5.Text = "Rotation";
            // 
            // openFileDialogPicOne
            // 
            openFileDialogPicOne.FileName = "openFileDialogPicOne";
            openFileDialogPicOne.FileOk += openFileDialogPicOne_FileOk;
            // 
            // openFileDialogPicTwo
            // 
            openFileDialogPicTwo.FileName = "openFileDialogPicTwo";
            openFileDialogPicTwo.FileOk += openFileDialogPicTwo_FileOk;
            // 
            // buttonSubtract
            // 
            buttonSubtract.BackColor = SystemColors.ActiveCaption;
            buttonSubtract.Font = new Font("Agency FB", 12F, FontStyle.Bold | FontStyle.Italic);
            buttonSubtract.Location = new Point(1024, 44);
            buttonSubtract.Name = "buttonSubtract";
            buttonSubtract.Size = new Size(94, 29);
            buttonSubtract.TabIndex = 15;
            buttonSubtract.Text = "Subtract";
            buttonSubtract.UseVisualStyleBackColor = false;
            buttonSubtract.Click += button1_Click;
            // 
            // openFileDialogForImageTwoDIP
            // 
            openFileDialogForImageTwoDIP.FileOk += openFileDialog1_FileOk_1;
            // 
            // openFileDialogPreFinalDIP
            // 
            openFileDialogPreFinalDIP.FileName = "openFileDialogPreFinalDIP";
            openFileDialogPreFinalDIP.FileOk += openFileDialog1_FileOk_2;
            // 
            // ImageProcessingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1124, 589);
            Controls.Add(buttonSubtract);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(webcamCopyChanger);
            Controls.Add(label3);
            Controls.Add(comboBoxDeviceList);
            Controls.Add(useWebcamButton);
            Controls.Add(rotationTrackBar);
            Controls.Add(label2);
            Controls.Add(equalizationTrackBar);
            Controls.Add(label1);
            Controls.Add(brightnessTrackBar);
            Controls.Add(processedPictureBox);
            Controls.Add(sourcePictureBox);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "ImageProcessingForm";
            Text = "CS345 Image Processing";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)sourcePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)processedPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)brightnessTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)equalizationTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)rotationTrackBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem1;
        private ToolStripMenuItem dIPToolStripMenuItem;
        private ToolStripMenuItem pixelCopyToolStripMenuItem;
        private ToolStripMenuItem grayscallingToolStripMenuItem;
        private ToolStripMenuItem mirrorToolStripMenuItem;
        private OpenFileDialog openFileDialogForImageDIP;
        private SaveFileDialog saveFileDialogForImageDIP;
        private PictureBox sourcePictureBox;
        private PictureBox processedPictureBox;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem sepiaToolStripMenuItem;
        private ToolStripMenuItem mirrorToolStripMenuItem1;
        private ToolStripMenuItem histogramToolStripMenuItem;
        private TrackBar brightnessTrackBar;
        private Label label1;
        private TrackBar equalizationTrackBar;
        private Label label2;
        private ToolStripMenuItem mirrorVerticalToolStripMenuItem;
        private TrackBar rotationTrackBar;
        private Button useWebcamButton;
        private ComboBox comboBoxDeviceList;
        private Label label3;
        private ComboBox webcamCopyChanger;
        private Label label4;
        private Label label5;
        private ToolStripMenuItem addImageForPictureBoxOneToolStripMenuItem;
        private ToolStripMenuItem addImageForPictureBoxTwoToolStripMenuItem;
        private ToolStripMenuItem loadImageOneToolStripMenuItem;
        private ToolStripMenuItem loadImageTwoToolStripMenuItem;
        private OpenFileDialog openFileDialogPicOne;
        private OpenFileDialog openFileDialogPicTwo;
        private Button buttonSubtract;
        private ToolStripMenuItem dIPPartTwoForImageToolStripMenuItem;
        private OpenFileDialog openFileDialogForImageTwoDIP;
        private ToolStripMenuItem smoothToolStripMenuItem;
        private ToolStripMenuItem gaussianBlurToolStripMenuItem;
        private ToolStripMenuItem sharpenToolStripMenuItem;
        private ToolStripMenuItem meanRemovalToolStripMenuItem;
        private ToolStripMenuItem embossingToolStripMenuItem;
        private ToolStripMenuItem embossHorzVerticalToolStripMenuItem;
        private ToolStripMenuItem embossAllDirectionsToolStripMenuItem;
        private ToolStripMenuItem embossLossyToolStripMenuItem;
        private ToolStripMenuItem embossHorizontalToolStripMenuItem;
        private ToolStripMenuItem embossVerticalToolStripMenuItem;
        private ToolStripMenuItem prefinalDIPToolStripMenuItem;
        private ToolStripMenuItem applyToolStripMenuItem;
        private OpenFileDialog openFileDialogPreFinalDIP;
    }
}
