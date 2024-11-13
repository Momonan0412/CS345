using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;

namespace DIP_Coin
{
    internal class HoughCircle
    {   
        Mat _loadedImage;
        Mat _grayImage;
        List<double> diameters = new List<double>();
        public HoughCircle(Mat _loadedImage)
        {
            this._loadedImage = _loadedImage;
            this._grayImage = new Mat();
        }
        public Bitmap DetectCircles() {
            CvInvoke.CvtColor(_loadedImage, _grayImage, ColorConversion.Bgr2Gray);
            CvInvoke.GaussianBlur(_grayImage, _grayImage, new Size(9, 9), 2, 2);


            // Prepare parameters for Hough Circle Transform
            double dp = 1; // The inverse ratio of the accumulator resolution to the image resolution
            double minDist = _grayImage.Rows / 32; // Minimum distance between detected centers
            double param1 = 120; // Higher threshold for the Canny edge detector
            double param2 = 30; // Accumulator threshold for the circle centers
            int minRadius = 5; // Minimum radius of the circle to detect
            int maxRadius = 100; // Maximum radius of the circle to detect

            // Detect circles using Hough Circle Transform
            CircleF[] circles = CvInvoke.HoughCircles(
                _grayImage,
                HoughModes.Gradient,
                dp,
                minDist,
                param1,
                param2,
                minRadius,
                maxRadius
            );

            // Draw each detected circle on the original image
            foreach (CircleF circle in circles)
            {
                if (circle.Radius >= minRadius && circle.Radius <= maxRadius)
                {
                    // Draw the circle in the original color image
                    CvInvoke.Circle(_loadedImage, Point.Round(circle.Center), (int)circle.Radius, new MCvScalar(0, 255, 0), 2); // Green circle
                                                                                                                                // Draw the center of the circle
                    CvInvoke.Circle(_loadedImage, Point.Round(circle.Center), 3, new MCvScalar(0, 0, 255), -1); // Red center point

                    // Print the radius of the circle
                    // Optionally, display the diameter as well
                    //double diameter = 2 * circle.Radius;
                    //Console.WriteLine($"Diameter: {diameter}");
                    //diameters.Add(diameter);

                    // Calculate the diameter of the circle
                    double diameter = 2 * circle.Radius;
                    Console.WriteLine($"Diameter: {diameter}");
                    diameters.Add(diameter);

                    // Display the diameter as text on the image
                    string diameterText = $"D: {diameter:F2}"; // Format to two decimal places
                    Point textPosition = new Point((int)circle.Center.X + 10, (int)circle.Center.Y); // Positioning text a little to the right of the center

                    // Put the diameter text on the image
                    CvInvoke.PutText(
                        _loadedImage,
                        diameterText,
                        textPosition,
                        Emgu.CV.CvEnum.FontFace.HersheySimplex,
                        0.5, // Font size
                        new MCvScalar(0, 0, 0), // Blue color for the text
                        1); // Thickness of the text


                    // Create a mask for the circle
                    Mat mask = new Mat(_loadedImage.Size, Emgu.CV.CvEnum.DepthType.Cv8U, 1); // Single-channel mask
                    mask.SetTo(new MCvScalar(0)); // Initialize mask to black

                    // Draw the filled circle in the mask
                    CvInvoke.Circle(mask, Point.Round(circle.Center), (int)circle.Radius, new MCvScalar(255), -1); // White filled circle

                    // Count the number of white pixels (pixels inside the circle)
                    int pixelCount = CvInvoke.CountNonZero(mask);
                    Console.WriteLine($"Number of pixels inside the circle: {pixelCount}");

                    // Optionally, display the pixel count on the image as well
                    string pixelCountText = $"Pixels: {pixelCount}";
                    Point pixelTextPosition = new Point((int)circle.Center.X + 10, (int)circle.Center.Y + 20); // Position slightly below the diameter text
                    CvInvoke.PutText(
                        _loadedImage,
                        pixelCountText,
                        pixelTextPosition,
                        Emgu.CV.CvEnum.FontFace.HersheySimplex,
                        0.5,
                        new MCvScalar(0, 0, 0), // Yellow color for the text
                        1);
                }

            }
            //string diametersString = string.Join(Environment.NewLine, diameters.Select(d => d.ToString()));

            //MessageBox.Show(diametersString.ToString());
            return _loadedImage.ToBitmap();
        }
    }
}
