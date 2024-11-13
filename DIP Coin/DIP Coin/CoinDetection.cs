using Emgu.CV;
using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using ChrisAliacConvolutionFilter;
namespace DIP_Coin
{
    public partial class CoinDetection : Form
    {
        Mat _loadedImage;
        public CoinDetection()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string filePath = openFileDialogForImageDIP.FileName;
            MessageBox.Show("Selected file: " + filePath);

            if (File.Exists(filePath))
            {
                try
                {
                    // Load the image into a Mat object
                    _loadedImage = new Mat(filePath);

                    // Check if the Mat is empty
                    if (_loadedImage.IsEmpty)
                    {
                        MessageBox.Show("The loaded image is empty.");
                    }
                    else
                    {
                        MessageBox.Show("Image loaded successfully.");
                        HoughCircle houghCircle = new HoughCircle(_loadedImage);
                        //Bitmap newImage = _loadedImage.ToBitmap();
                        //ChrisAliacConvolutionFilter.BitmapFilter.GrayScale(newImage);
                        pictureBoxLoadedImage.Image = houghCircle.DetectCircles();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("File does not exist.");
            }
        }
        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Bitmap bitmapImage = _loadedImage.ToBitmap();
            //bitmapImage.Save(saveFileDialogForImageDIP.FileName, ImageFormat.Png);
        }
        private void loadImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialogForImageDIP.ShowDialog();
        }
        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialogForImageDIP.ShowDialog();

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
