using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using AForge.Video;
using AForge.Video.DirectShow;
using Microsoft.VisualBasic;
using System.Diagnostics.Metrics;
using System.Reflection;
using ChrisAliacConvolutionFilter;
namespace Image_Processing
{
    public partial class ImageProcessingForm : Form
    {
        Bitmap _loadedImage, _processedImage;
        BitmapData loadedData, processedData;

        string webcamText;

        FilterInfoCollection _filterInfoCollection;
        VideoCaptureDevice _videoCaptureDevice;

        int height;
        int width;
        int stride;
        int[] histogram;

        // Rotation
        float angleRadians;
        int xCenter;
        int yCenter;
        int xs, ys, x0, y0;
        float cosA, sinA;
        public ImageProcessingForm()
        {
            InitializeComponent();
        }
        private void setProcessedImage()
        {
            // Create a new bitmap rather than modifying _loadedImage directly,
            // you ensure that the original image remains unchanged. 
            //_processedImage = new Bitmap(_loadedImage.Width, _loadedImage.Height);
            this._processedImage = new Bitmap(_loadedImage.Width, _loadedImage.Height);
        }
        private void setUnlockedBitmapData()
        {
            // Unlock the bits
            // Locking the image with LockBits allows you to work with the image data directly
            // using pointers, making it more efficient than methods like GetPixel/SetPixel,
            // especially in large-scale or high-performance tasks. This is often done in an unsafe { } block because it involves direct memory access, which allows you to bypass some of the overhead and perform more intensive pixel manipulation.
            try
            {
                _loadedImage.UnlockBits(loadedData);
                _processedImage.UnlockBits(processedData);
            }
            catch (Exception e) { Console.WriteLine(e); }
        }
        private void setLockedBitmapData()
        {
            // https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap.lockbits?view=net-8.0&redirectedfrom=MSDN#System_Drawing_Bitmap_LockBits_System_Drawing_Rectangle_System_Drawing_Imaging_ImageLockMode_System_Drawing_Imaging_PixelFormat_
            // Locks a `Bitmap` in memory for direct pixel access,
            // making it faster to read/write pixel data.
            // Useful for high-performance image processing, allowing direct access to pixel data.
            try
            {
                this.loadedData = _loadedImage.LockBits(
                    new Rectangle(0, 0, _loadedImage.Width, _loadedImage.Height),
                    ImageLockMode.ReadOnly,
                    PixelFormat.Format24bppRgb
                    );
                this.processedData = _processedImage.LockBits(
                    new Rectangle(0, 0, _processedImage.Width, _processedImage.Height),
                    ImageLockMode.WriteOnly,
                    PixelFormat.Format24bppRgb
                    );
            }
            catch (Exception e)
            {
            }
        }
        private void setDefaults()
        {
            this.height = _loadedImage.Height;
            this.width = _loadedImage.Width;
            if (loadedData != null)
            {
                this.stride = loadedData.Stride;
            }
        }
        private void setPictureBoxTwoImage()
        {
            this.processedPictureBox.Image = _processedImage;
        }
        private void imagePointerHandler(string processDefiner, int? value)
        {

            if (_loadedImage == null)
            {
                return;
            }
            this.setProcessedImage();
            this.setLockedBitmapData();
            this.setDefaults();

            //if (processDefiner == "Rotation" && value != null)
            //{
            //    angleRadians = (float)(value * Math.PI / 180);
            //    xCenter = (width / 2);
            //    yCenter = (height / 2);
            //    cosA = (float)Math.Cos(angleRadians);
            //    sinA = (float)Math.Sin(angleRadians);
            //}

            unsafe
            {
                // Scan0 gives the memory address of the first byte in the bitmap data
                // for each locked bitmap(_loadedImage and _processedImage).
                // loadedData.Scan0 and processedData.Scan0 are converted to byte* pointers,
                // allowing us to navigate each byte in the images’ pixel data.
                // With byte* pointers to the bitmap data, you can perform low-level,
                // efficient operations on the raw bytes that represent pixel colors.
                byte* sourcePointer = (byte*)loadedData.Scan0;
                byte* destinationPointer = (byte*)processedData.Scan0;

                // https://stackoverflow.com/questions/12405938/save-time-with-parallel-for-loop
                if (processDefiner == "MirrorHori" || processDefiner == "MirrorVerti")
                {
                    // The Parallel.For(0, height, y => { ... }) loop allows each row (y)
                    // to be processed independently by different threads.
                    // This means that multiple rows can be handled simultaneously,
                    // leading to faster processing, especially for large images.
                    if (processDefiner == "MirrorHori")
                        Parallel.For(0, height, y =>
                        {
                            for (int x = 0; x < width / 2; x++)
                            {
                                // Inside the inner loop, the code calculates the left and
                                // right pixel indices for mirroring.
                                // The left pixel is at (y * stride + x * 3),
                                // while the right pixel is at (y * stride + (width - x - 1) * 3).
                                int indexLeft = y * stride + x * 3; // Left pixel index
                                int indexRight = y * stride + (width - x - 1) * 3; // Right pixel index

                                // Swap the pixel data for Blue, Green, and Red
                                byte tempBlue = sourcePointer[indexLeft];
                                byte tempGreen = sourcePointer[indexLeft + 1];
                                byte tempRed = sourcePointer[indexLeft + 2];

                                // Assign the left pixel to the right pixel
                                destinationPointer[indexLeft] = sourcePointer[indexRight];       // Blue
                                destinationPointer[indexLeft + 1] = sourcePointer[indexRight + 1]; // Green
                                destinationPointer[indexLeft + 2] = sourcePointer[indexRight + 2]; // Red

                                // Assign the right pixel to the left pixel
                                destinationPointer[indexRight] = tempBlue;       // Blue
                                destinationPointer[indexRight + 1] = tempGreen;  // Green
                                destinationPointer[indexRight + 2] = tempRed;     // Red
                            }
                        });
                    else
                        Parallel.For(0, height / 2, y =>
                        {
                            for (int x = 0; x < width; x++)
                            {
                                // Inside the inner loop, the code calculates the left and
                                // right pixel indices for mirroring.
                                // The left pixel is at (y * stride + x * 3),
                                // while the right pixel is at (y * stride + (width - x - 1) * 3).
                                int indexLeft = y * stride + x * 3; // Left pixel index
                                int indexRight = (height - y - 1) * stride + x * 3; // Right pixel index

                                // Swap the pixel data for Blue, Green, and Red
                                byte tempBlue = sourcePointer[indexLeft];
                                byte tempGreen = sourcePointer[indexLeft + 1];
                                byte tempRed = sourcePointer[indexLeft + 2];

                                // Assign the left pixel to the right pixel
                                destinationPointer[indexLeft] = sourcePointer[indexRight];       // Blue
                                destinationPointer[indexLeft + 1] = sourcePointer[indexRight + 1]; // Green
                                destinationPointer[indexLeft + 2] = sourcePointer[indexRight + 2]; // Red

                                // Assign the right pixel to the left pixel
                                destinationPointer[indexRight] = tempBlue;       // Blue
                                destinationPointer[indexRight + 1] = tempGreen;  // Green
                                destinationPointer[indexRight + 2] = tempRed;     // Red
                            }
                        });
                }
                else
                {
                    Parallel.For(0, height, y =>
                    //for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            int index = y * stride + x * 3;

                            // Copy pixel data
                            // In 24bpp images, each pixel is represented by 3 bytes (for RGB).
                            // In 32bpp images, each pixel is represented by 4 bytes(for ARGB).

                            byte blue = sourcePointer[index];
                            byte green = sourcePointer[index + 1];
                            byte red = sourcePointer[index + 2];
                            switch (processDefiner)
                            {
                                //case "Rotation":
                                //    // Translate coordinates based on center
                                //    x0 = x - xCenter;
                                //    y0 = y - yCenter;
                                //    xs = (int)(x0 * cosA - y0 * sinA + xCenter);  // x rotation transformation
                                //    ys = (int)(x0 * sinA + y0 * cosA + yCenter);  // y rotation transformation
                                //    // Clamp to image boundaries
                                //    xs = Math.Max(0, Math.Min(width - 1, xs));
                                //    ys = Math.Max(0, Math.Min(height - 1, ys));
                                //    // Calculate source pixel index in the original image
                                //    int sourceIndex = ys * stride + xs * 3;
                                //    // Set destination pixel using source pixel values
                                //    destinationPointer[index] = sourcePointer[sourceIndex];         // Blue
                                //    destinationPointer[index + 1] = sourcePointer[sourceIndex + 1]; // Green
                                //    destinationPointer[index + 2] = sourcePointer[sourceIndex + 2]; // Red
                                //    break;

                                case "PixelCopy":
                                    destinationPointer[index] = sourcePointer[index];         // Blue
                                    destinationPointer[index + 1] = sourcePointer[index + 1]; // Green
                                    destinationPointer[index + 2] = sourcePointer[index + 2]; // Red
                                    break;
                                case "Brightness":
                                    if (value != null)
                                    {
                                        int blueValue = blue + (int)value;
                                        int greenValue = green + (int)value;
                                        int redValue = red + (int)value;
                                        byte brightBlue = (value > 0)
                                        ? (byte)(Math.Min(blueValue, 255))
                                        : (byte)(Math.Max(blueValue, 0));
                                        byte brightGreen = (value > 0)
                                        ? (byte)(Math.Min(greenValue, 255))
                                        : (byte)(Math.Max(greenValue, 0));
                                        byte brightRed = (value > 0)
                                        ? (byte)(Math.Min(redValue, 255))
                                        : (byte)(Math.Max(redValue, 0));
                                        destinationPointer[index] = brightBlue;
                                        destinationPointer[index + 1] = brightGreen;
                                        destinationPointer[index + 2] = brightRed;
                                    }
                                    break;
                                case "Inversion":
                                    byte deductBlue = (byte)Math.Max(0, 255 - blue);
                                    byte deductGreen = (byte)Math.Max(0, 255 - green);
                                    byte deductRed = (byte)Math.Max(0, 255 - red);
                                    destinationPointer[index] = deductBlue;
                                    destinationPointer[index + 1] = deductGreen;
                                    destinationPointer[index + 2] = deductRed;
                                    break;
                                case "Sepia":
                                    // https://stackoverflow.com/questions/1061093/how-is-a-sepia-tone-created
                                    // int outputRed = (inputRed * .393) + (inputGreen *.769) + (inputBlue * .189);
                                    // int outputGreen = (inputRed * .349) + (inputGreen * .686) + (inputBlue * .168);
                                    // int outputBlue = (inputRed * .272) + (inputGreen * .534) + (inputBlue * .131);
                                    byte outputRed = (byte)((red * .393) + (green * .769) + (blue * .189));
                                    byte outputGreen = (byte)((red * .349) + (green * .686) + (blue * .168));
                                    byte outputBlue = (byte)((red * .272) + (green * .534) + (blue * .131));
                                    destinationPointer[index] = outputBlue;
                                    destinationPointer[index + 1] = outputGreen;
                                    destinationPointer[index + 2] = outputRed;
                                    break;
                                case "Equalization":
                                case "Histogram":
                                case "Grayscale":
                                    byte grayValue = (byte)((red + green + blue) / 3);
                                    destinationPointer[index] = grayValue;
                                    destinationPointer[index + 1] = grayValue;
                                    destinationPointer[index + 2] = grayValue;
                                    if ((processDefiner == "Equalization" | processDefiner == "Histogram") && histogram != null)
                                    {
                                        histogram[grayValue]++;
                                    }
                                    break;
                                default:
                                    return;
                            }
                        }
                    });
                }
            }
            this.setUnlockedBitmapData();
            this.setPictureBoxTwoImage();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openFileDialogForImageDIP.ShowDialog();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialogForImageDIP.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            rotationTrackBar.Enabled = true;
            equalizationTrackBar.Enabled = true;
            brightnessTrackBar.Enabled = true;
            dIPPartTwoForImageToolStripMenuItem.Enabled = true;
            useWebcamButton.Enabled = true;
            _loadedImage = new Bitmap(openFileDialogForImageDIP.FileName);
            sourcePictureBox.Image = _loadedImage;
        }

        // Pointer Function
        private void pixelCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.imagePointerHandler("PixelCopy", null);
        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _processedImage.Save(saveFileDialogForImageDIP.FileName, _loadedImage.RawFormat);
        }

        private void grayscallingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.imagePointerHandler("Grayscale", null);
        }

        private void mirrorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.imagePointerHandler("Inversion", null);

        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.imagePointerHandler("Sepia", null);
        }

        private void mirrorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.imagePointerHandler("MirrorHori", null);
        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.histogram = new int[256];
            // Gets the histogram Frequency Using Grayscaling
            this.imagePointerHandler("Histogram", null);
            Bitmap _newProcessedImage = new Bitmap(256, 256 * 2, PixelFormat.Format24bppRgb);

            BitmapData newProcessedData = _newProcessedImage.LockBits(
                new Rectangle(0, 0, _newProcessedImage.Width, _newProcessedImage.Height),
                ImageLockMode.WriteOnly,
                PixelFormat.Format24bppRgb
                );
            int newStride = newProcessedData.Stride;
            int width = _newProcessedImage.Width;
            int height = _newProcessedImage.Height;
            unsafe
            {
                byte* bitptr = (byte*)newProcessedData.Scan0;
                // Draw histogram bars based on frequency
                Parallel.For(0, width, x =>
                {
                    for (int y = 0; y < height; y++)
                    {
                        int index = y * newStride + x * 3; // Correctly calculate the index using newStride
                        bitptr[index] = 255;      // Blue
                        bitptr[index + 1] = 255;  // Green
                        bitptr[index + 2] = 255;  // Red
                    }
                });
                // Now draw the histogram bars based on frequency
                Parallel.For(0, 256, x =>
                {
                    int barHeight = Math.Min(histogram[x] / 5, height); // Scale down the height of the bar
                    for (int y = 0; y < barHeight; y++) // Start from the top
                    {
                        int index = (height - 1 - y) * newStride + x * 3;
                        // 44,62,117
                        bitptr[index] = 117;         // Blue
                        bitptr[index + 1] = 62;      // Green
                        bitptr[index + 2] = 44;      // Red
                    }
                });
            }
            _newProcessedImage.UnlockBits(newProcessedData);
            this.processedPictureBox.Image = _newProcessedImage;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.imagePointerHandler("Brightness", brightnessTrackBar.Value);
        }

        private void trackBar2_Scroll_1(object sender, EventArgs e)
        {
            // TODO: Implement This
            // RGB Contrast Method
            // https://stackoverflow.com/questions/3115076/adjust-the-contrast-of-an-image-in-c-sharp-efficiently

            this.histogram = new int[256];
            // Histogram and Grayscale Image Getter
            // histogram Contains Frequency
            // _processedImage is Grayscaled
            int percent = equalizationTrackBar.Value;
            this.imagePointerHandler("Equalization", percent);
            int[] yMap = CalculateYMap(histogram, percent, _processedImage.Width * _processedImage.Height);
            Bitmap _newProcessedImage = new Bitmap(_loadedImage.Width, _loadedImage.Height, PixelFormat.Format24bppRgb);
            BitmapData newProcessedData = _newProcessedImage.LockBits(
                new Rectangle(0, 0, _newProcessedImage.Width, _newProcessedImage.Height),
                ImageLockMode.WriteOnly,
                PixelFormat.Format24bppRgb
                );
            try
            {
                this.loadedData = _processedImage.LockBits(
                    new Rectangle(0, 0, _loadedImage.Width, _loadedImage.Height),
                    ImageLockMode.ReadOnly,
                    PixelFormat.Format24bppRgb
                    );
            }
            catch (Exception ex) { Console.WriteLine(ex); }
            int newStride = newProcessedData.Stride;
            int width = _newProcessedImage.Width;
            int height = _newProcessedImage.Height;
            unsafe
            {
                byte* newProcessedBitPtr = (byte*)newProcessedData.Scan0;
                byte* sourceBitPtr = (byte*)loadedData.Scan0;
                this.equalizationHelper(newProcessedBitPtr, sourceBitPtr, newStride, yMap, width, height);
            }
            _newProcessedImage.UnlockBits(newProcessedData);
            this.processedPictureBox.Image = _newProcessedImage;
        }
        // Calculate the yMap for intensity mapping with potential parallelization
        private int[] CalculateYMap(int[] histogram, int percent, int numSamples)
        {
            int[] yMap = new int[256];
            int histSum = 0;
            for (int h = 0; h < 256; h++)
            {
                histSum += histogram[h];
                yMap[h] = histSum * 255 / numSamples;
            }

            if (percent < 100)
            {
                Parallel.For(0, 256, h =>
                {
                    yMap[h] = h + ((int)yMap[h] - h) * percent / 100;
                });
            }

            return yMap;
        }
        private unsafe void equalizationHelper(byte* newProcessedBitPtr, byte* sourceBitPtr, int newStride, int[] yMap, int width, int height)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int index = y * newStride + x * 3;
                    newProcessedBitPtr[index] = (byte)yMap[sourceBitPtr[index]];
                    newProcessedBitPtr[index + 1] = (byte)yMap[sourceBitPtr[index + 1]];
                    newProcessedBitPtr[index + 2] = (byte)yMap[sourceBitPtr[index + 2]];
                }
            }
        }
        private void mirrorVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.imagePointerHandler("MirrorVerti", null);
        }

        private void rotationTrackBar_Scroll(object sender, EventArgs e)
        {
            this.setProcessedImage();
            this.setDefaults();
            this.setLockedBitmapData();

            angleRadians = (rotationTrackBar.Value * (float)Math.PI / 180);
            xCenter = _loadedImage.Width / 2;
            yCenter = _loadedImage.Height / 2;
            cosA = (float)Math.Cos(angleRadians);
            sinA = (float)Math.Sin(angleRadians);

            int sourceStride = loadedData.Stride;
            int targetStride = processedData.Stride;

            unsafe
            {
                byte* sourcePtr = (byte*)loadedData.Scan0;
                byte* targetPtr = (byte*)processedData.Scan0;

                for (int xp = 0; xp < width; xp++)
                {
                    for (int yp = 0; yp < height; yp++)
                    {
                        x0 = xp - xCenter;
                        y0 = yp - yCenter;

                        int xs = (int)(x0 * cosA + y0 * sinA) + xCenter;
                        int ys = (int)(-x0 * sinA + y0 * cosA) + yCenter;

                        xs = Math.Max(0, Math.Min(width - 2, xs));
                        ys = Math.Max(0, Math.Min(height - 2, ys));

                        if (xs >= 0 && xs < width && ys >= 0 && ys < height)
                        {
                            int sourcePixel = ys * sourceStride + xs * 3;
                            int targetPixel = yp * targetStride + xp * 3;
                            targetPtr[targetPixel] = sourcePtr[sourcePixel];
                            targetPtr[targetPixel + 1] = sourcePtr[sourcePixel + 1];
                            targetPtr[targetPixel + 2] = sourcePtr[sourcePixel + 2];
                        }
                    }
                }
            }

            _loadedImage.UnlockBits(loadedData);
            _processedImage.UnlockBits(processedData);

            processedPictureBox.Image = _processedImage;
        }

        private void useWebcamButton_Click(object sender, EventArgs e)
        {
            rotationTrackBar.Enabled = false;
            equalizationTrackBar.Enabled = false;
            brightnessTrackBar.Enabled = false;

            webcamText = webcamCopyChanger.Text;
            if (webcamText != "")
            {
                if (_filterInfoCollection == null)
                {
                    _filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                    foreach (FilterInfo device in _filterInfoCollection)
                    {
                        comboBoxDeviceList.Items.Add(device.Name);
                    }
                    comboBoxDeviceList.SelectedIndex = 0;
                }

                if (_videoCaptureDevice == null)
                {
                    _videoCaptureDevice = new VideoCaptureDevice(_filterInfoCollection[comboBoxDeviceList.SelectedIndex].MonikerString);
                    _videoCaptureDevice.NewFrame += FinalFrame_NewFrame;
                    _videoCaptureDevice.Start();
                }
            }
        }
        private unsafe void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            using (Bitmap frameOne = (Bitmap)eventArgs.Frame.Clone())
            using (Bitmap frameTwo = (Bitmap)eventArgs.Frame.Clone())
            {
                BitmapData bmpDataOne = frameOne.LockBits(
                    new Rectangle(0, 0, frameOne.Width, frameOne.Height),
                    System.Drawing.Imaging.ImageLockMode.ReadWrite,
                    PixelFormat.Format24bppRgb);
                BitmapData bmpDataTwo = frameTwo.LockBits(
                    new Rectangle(0, 0, frameTwo.Width, frameTwo.Height),
                    System.Drawing.Imaging.ImageLockMode.ReadWrite,
                    PixelFormat.Format24bppRgb);

                int stride = bmpDataOne.Stride;
                byte* ptrOne = (byte*)bmpDataOne.Scan0;
                byte* ptrTwo = (byte*)bmpDataTwo.Scan0;
                int height = frameOne.Height;
                //if (webcamText == "Mirror Horizontal")
                //    height /= 2;
                int width = frameOne.Width;
                //if (webcamText == "Mirror Vertical")
                //    width /= 2;

                for (int y = 0; y < height; y++)
                {
                    byte* rowOne = ptrOne;
                    byte* rowTwo = ptrTwo;
                    for (int x = 0; x < width; x++)
                    {
                        int pixelIndex = y * stride + x * 3;

                        rowOne[pixelIndex] = (byte)(rowOne[pixelIndex]);     // Blue
                        rowOne[pixelIndex + 1] = (byte)(rowOne[pixelIndex + 1]); // Green
                        rowOne[pixelIndex + 2] = (byte)(rowOne[pixelIndex + 2]); // Red

                        if (webcamText == "Pixel Copy")
                        {
                            rowTwo[pixelIndex] = (byte)(rowTwo[pixelIndex]);     // Blue
                            rowTwo[pixelIndex + 1] = (byte)(rowTwo[pixelIndex + 1]); // Green
                            rowTwo[pixelIndex + 2] = (byte)(rowTwo[pixelIndex + 2]); // Red
                        }
                        else if (webcamText == "Inversion")
                        {
                            byte deductBlue = (byte)Math.Max(0, 255 - rowTwo[pixelIndex]);
                            byte deductGreen = (byte)Math.Max(0, 255 - rowTwo[pixelIndex + 1]);
                            byte deductRed = (byte)Math.Max(0, 255 - rowTwo[pixelIndex + 2]);
                            rowTwo[pixelIndex] = (byte)(deductBlue);     // Blue
                            rowTwo[pixelIndex + 1] = (byte)(deductGreen); // Green
                            rowTwo[pixelIndex + 2] = (byte)(deductRed); // Red
                        }
                        else if (webcamText == "Grayscale")
                        {
                            //byte grayValue = (byte)((red + green + blue) / 3);
                            //destinationPointer[index] = grayValue;
                            //destinationPointer[index + 1] = grayValue;
                            //destinationPointer[index + 2] = grayValue;
                            byte grayValue = (byte)((rowTwo[pixelIndex] + rowTwo[pixelIndex + 1] + rowTwo[pixelIndex + 2]) / 3);
                            rowTwo[pixelIndex] = grayValue;    // Blue
                            rowTwo[pixelIndex + 1] = grayValue; // Green
                            rowTwo[pixelIndex + 2] = grayValue; // Red
                        }
                        else if (webcamText == "Sepia")
                        {
                            int red = (rowTwo[pixelIndex + 2]);
                            int green = (rowTwo[pixelIndex + 1]);
                            int blue = (rowTwo[pixelIndex]);
                            byte outputRed = (byte)((red * .393) + (green * .769) + (blue * .189));
                            byte outputGreen = (byte)((red * .349) + (green * .686) + (blue * .168));
                            byte outputBlue = (byte)((red * .272) + (green * .534) + (blue * .131));
                            rowTwo[pixelIndex] = outputBlue;
                            rowTwo[pixelIndex + 1] = outputGreen;
                            rowTwo[pixelIndex + 2] = outputRed;
                        }
                        else if (webcamText == "Mirror Vertical")
                        {
                            int indexLeft = y * stride + x * 3; // Left pixel index
                            int indexRight = (height - y - 1) * stride + x * 3; // Right pixel index

                            byte tempBlue = rowOne[indexLeft];
                            byte tempGreen = rowOne[indexLeft + 1];
                            byte tempRed = rowOne[indexLeft + 2];

                            rowTwo[indexLeft] = rowOne[indexRight];       // Blue
                            rowTwo[indexLeft + 1] = rowOne[indexRight + 1]; // Green
                            rowTwo[indexLeft + 2] = rowOne[indexRight + 2]; // Red

                            rowTwo[indexRight] = tempBlue;       // Blue
                            rowTwo[indexRight + 1] = tempGreen;  // Green
                            rowTwo[indexRight + 2] = tempRed;     // Red
                        }
                        else if (webcamText == "Mirror Horizontal")
                        {
                            int indexLeft = y * stride + x * 3; // Left pixel index
                            int indexRight = y * stride + (width - x - 1) * 3; // Right pixel index

                            byte tempBlue = rowOne[indexLeft];
                            byte tempGreen = rowOne[indexLeft + 1];
                            byte tempRed = rowOne[indexLeft + 2];

                            rowTwo[indexLeft] = rowOne[indexRight];       // Blue
                            rowTwo[indexLeft + 1] = rowOne[indexRight + 1]; // Green
                            rowTwo[indexLeft + 2] = rowOne[indexRight + 2]; // Red

                            rowTwo[indexRight] = tempBlue;       // Blue
                            rowTwo[indexRight + 1] = tempGreen;  // Green
                            rowTwo[indexRight + 2] = tempRed;     // Red
                        }
                    }
                }

                frameOne.UnlockBits(bmpDataOne);
                frameTwo.UnlockBits(bmpDataTwo);
                sourcePictureBox.Image = (Bitmap)frameOne.Clone(); // Show modified frame
                processedPictureBox.Image = (Bitmap)frameTwo.Clone(); // Show modified frame
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dIPToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.setLockedBitmapData();
            this.setDefaults();
            Bitmap bitmap = new Bitmap(_loadedImage.Width, _loadedImage.Height, PixelFormat.Format24bppRgb);
            BitmapData bitmapData = bitmap.LockBits(
                    new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                    ImageLockMode.WriteOnly,
                    PixelFormat.Format24bppRgb
                    );

            int threshold = 50;
            unsafe
            {
                byte* loadedByte = (byte*)loadedData.Scan0;
                byte* processedByte = (byte*)processedData.Scan0;
                byte* resultByte = (byte*)bitmapData.Scan0;
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        int index = y * stride + x * 3;
                        byte loadBlue = loadedByte[index];
                        byte loadGreen = loadedByte[index + 1];
                        byte loadRed = loadedByte[index + 2];

                        byte processedBlue = processedByte[index];
                        byte processedGreen = processedByte[index + 1];
                        byte processedRed = processedByte[index + 2];
                        byte grayValue = (byte)((loadRed + loadGreen + loadBlue) / 3);

                        int subtract = (Math.Abs(grayValue - loadGreen));
                        if (subtract > threshold)
                        {
                            resultByte[index] = processedByte[index];
                            resultByte[index + 1] = processedByte[index + 1];
                            resultByte[index + 2] = processedByte[index + 2];
                        }
                        else
                        {
                            resultByte[index] = loadedByte[index];
                            resultByte[index + 1] = loadedByte[index + 1];
                            resultByte[index + 2] = loadedByte[index + 2];
                        }
                    }
                }
                _loadedImage.UnlockBits(loadedData);
                _processedImage.UnlockBits(processedData);
                bitmap.UnlockBits(bitmapData);
            }
            Form newForm = new Form
            {
                Text = "New Form with PictureBox",
                Size = new Size(width, height),
                StartPosition = FormStartPosition.CenterScreen
            };
            PictureBox pictureBox = new PictureBox
            {
                Size = new Size(width, height),  // Set the PictureBox size
                Location = new Point(10, 10), // Set position (optional)
                BorderStyle = BorderStyle.FixedSingle // Optional: add a border
            };
            newForm.Controls.Add(pictureBox);
            pictureBox.Image = bitmap;
            newForm.ShowDialog();
        }

        private void loadImageOneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialogPicOne.ShowDialog();
        }

        private void loadImageTwoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialogPicTwo.ShowDialog();
        }

        private void openFileDialogPicOne_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            rotationTrackBar.Enabled = false;
            equalizationTrackBar.Enabled = false;
            brightnessTrackBar.Enabled = false;
            useWebcamButton.Enabled = false;
            _loadedImage = new Bitmap(openFileDialogPicOne.FileName);
            sourcePictureBox.Image = _loadedImage;
        }

        private void openFileDialogPicTwo_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            rotationTrackBar.Enabled = false;
            equalizationTrackBar.Enabled = false;
            brightnessTrackBar.Enabled = false;
            useWebcamButton.Enabled = false;
            _processedImage = new Bitmap(openFileDialogPicTwo.FileName);
            processedPictureBox.Image = _processedImage;
        }

        private void openFileDialog1_FileOk_1(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void dIPPartTwoForImageToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void smoothToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChrisAliacConvolutionFilter.BitmapFilter.Smooth(_loadedImage, 1);
            processedPictureBox.Image = _loadedImage;
        }

        private void gaussianBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChrisAliacConvolutionFilter.BitmapFilter.GaussianBlur(_loadedImage, 1);
            processedPictureBox.Image = _loadedImage;
        }

        private void sharpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChrisAliacConvolutionFilter.BitmapFilter.Sharpen(_loadedImage, 1);
            processedPictureBox.Image = _loadedImage;

        }

        private void meanRemovalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChrisAliacConvolutionFilter.BitmapFilter.MeanRemoval(_loadedImage, 1);
            processedPictureBox.Image = _loadedImage;

        }

        private void embossingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChrisAliacConvolutionFilter.BitmapFilter.EmbossLaplacian(_loadedImage);
            processedPictureBox.Image = _loadedImage;

        }

        private void embossHorzVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChrisAliacConvolutionFilter.BitmapFilter.EmbossHorzVertical(_loadedImage);
            processedPictureBox.Image = _loadedImage;

        }

        private void embossAllDirectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChrisAliacConvolutionFilter.BitmapFilter.EmbossAllDirections(_loadedImage);
            processedPictureBox.Image = _loadedImage;

        }

        private void embossLossyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChrisAliacConvolutionFilter.BitmapFilter.EmbossLossy(_loadedImage);
            processedPictureBox.Image = _loadedImage;

        }

        private void embossHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChrisAliacConvolutionFilter.BitmapFilter.EmbossHorizontal(_loadedImage);
            processedPictureBox.Image = _loadedImage;

        }

        private void embossVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChrisAliacConvolutionFilter.BitmapFilter.EmbossVertical(_loadedImage);
            processedPictureBox.Image = _loadedImage;

        }

        private void applyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _processedImage = new Bitmap(_loadedImage);
            int halfWidth = _processedImage.Width / 2;
            int halfHeight = _processedImage.Height / 2;
            Color pixel;
            for (int y = 0; y < _loadedImage.Height; y++) {
                for (int x = 0; x < _loadedImage.Width; x++) {
                    // First Quadrant
                    if (x > halfWidth && y < halfHeight)
                    {
                        pixel = _loadedImage.GetPixel(x, y);
                        _processedImage.SetPixel(x, y, Color.FromArgb(255 - pixel.R, 255 - pixel.G, 255 - pixel.B));
                    }
                    // Second Quadrant
                    else if (x < halfWidth && y < halfHeight)
                    {
                        pixel = _loadedImage.GetPixel(x, y);
                        double color = pixel.R * .114 + pixel.G * .587 + pixel.B * .299;
                        _processedImage.SetPixel(x, y, Color.FromArgb((int)color, (int)color, (int)color));
                    }
                    else if (x < halfWidth && y > halfHeight)
                    {
                        pixel = _loadedImage.GetPixel(x, y);
                        int outputRed = (int)(pixel.R * .393 + pixel.G * .769 + pixel.B * .189);
                        int outputGreen = (int)(pixel.R * .349 + pixel.G * .686 + pixel.B * .168);
                        int outputBlue = (int)(pixel.R * .272 + pixel.G * .534 + pixel.B * .131);
                        _processedImage.SetPixel(x, y, Color.FromArgb(Math.Min(outputRed,255), Math.Min(outputGreen, 255),Math.Min(outputBlue, 255)));
                    }
                }
            }
            {
            for (int x = 0; x < _loadedImage.Width; x++)
                for (int y = 0; y < _loadedImage.Height; y++)
                {
                    if (x > halfWidth && y > halfHeight)
                    {
                        pixel = _loadedImage.GetPixel(x, _loadedImage.Height - 1 - (y - halfHeight));
                        _processedImage.SetPixel(x, y, pixel);
                    }
                }
            }
            //_processedImage = new Bitmap(_loadedImage.Width, _loadedImage.Height);
            //Rectangle rectForImageOne = new Rectangle(0, 0, _processedImage.Width, _processedImage.Height);
            //BitmapData bitmapDataOne = _processedImage.LockBits(rectForImageOne, ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

            //Rectangle rectForImageTwo = new Rectangle(0, 0, _loadedImage.Width, _loadedImage.Height);
            //BitmapData bitmapDataTwo = _loadedImage.LockBits(rectForImageTwo, ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);


            //int imageWidth = bitmapDataOne.Width;
            //int imageHeight = bitmapDataOne.Height;
            //int stride = bitmapDataOne.Stride;
            //unsafe {
            //    int halfOfHeight = imageHeight / 2;
            //    int halfOfWidth = imageWidth / 2;

            //    byte* ptrOne = (byte*)bitmapDataOne.Scan0;
            //    byte* ptrTwo = (byte*)bitmapDataTwo.Scan0;

            //    int addedHeight = imageHeight - halfOfHeight;

            //    Parallel.For(0, imageHeight, y => {
            //        for (int x = 0; x < imageWidth; x++) { 
            //            int index = y * stride + x * 3;
            //            if (x > halfOfWidth && y > halfOfHeight) // Vertical Mirror
            //            {
            //                int mirrorIndex = (imageHeight - 1 - (y - halfOfHeight)) * stride + x * 3;
            //                ptrOne[index] = ptrTwo[mirrorIndex];
            //                ptrOne[index + 1] = ptrTwo[mirrorIndex + 1];
            //                ptrOne[index + 2] = ptrTwo[mirrorIndex + 2];
            //            }
            //            else if (x < halfOfWidth && y < halfOfHeight) // Inversion
            //            {
            //                ptrOne[index] = (byte)Math.Max((255 - ptrTwo[index]), 0);
            //                ptrOne[index + 1] = (byte)Math.Max((255 - ptrTwo[index + 1]), 0);
            //                ptrOne[index + 2] = (byte)Math.Max((255 - ptrTwo[index + 2]), 0);
            //            }
            //            else if (x > halfOfWidth && y < halfOfHeight) // Greyscale
            //            {
            //                byte grey = (byte)((ptrTwo[index] + ptrTwo[index + 1] + ptrTwo[index + 2]) / 3);
            //                ptrOne[index] = grey;
            //                ptrOne[index + 1] = grey;
            //                ptrOne[index + 2] = grey;
            //            }
            //            else if (x < halfOfWidth && y > halfOfHeight) // Pixel Copy
            //            {
            //                ptrOne[index] = ptrTwo[index];
            //                ptrOne[index + 1] = ptrTwo[index + 1];
            //                ptrOne[index + 2] = ptrTwo[index + 2];
            //            }
            //        }
            //    });
            //}
            //_processedImage.UnlockBits(bitmapDataOne);
            //_loadedImage.UnlockBits(bitmapDataTwo);
            this.processedPictureBox.Image = _processedImage;
        }

        private void openFileDialog1_FileOk_2(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        // The rotation matrix is given by the following form:
        // | cos(theta) -sin(theta) |
        // | sin(theta)  cos(theta)  |
        // This matrix is used to rotate a point (x, y) in a 2D plane by an angle theta counterclockwise.
        // When applying the rotation matrix to the point (x, y), the new coordinates (x', y') can be calculated
        // as follows:
        // x' = x * cos(theta) - y * sin(theta)  // New x-coordinate after rotation
        // y' = x * sin(theta) + y * cos(theta)  // New y-coordinate after rotation
        // This conversion from matrix form to algebraic form allows us to compute the new coordinates
        // of the point after the rotation, maintaining the properties of the transformation.

    }
}
