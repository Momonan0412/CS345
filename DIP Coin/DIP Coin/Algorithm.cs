using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace DIP_Coin
{
    internal class Algorithm
    {
        public static Bitmap breadthFirstSearchAlgorithm(Bitmap loadedImage) {
            Queue<Tuple<int, int>> fringe = new Queue<Tuple<int, int>>();
            Rectangle rectParam = new Rectangle(0, 0, loadedImage.Width, loadedImage.Height);
            // public Bitmap(int width, int height, Graphics g)
            Bitmap matrix = new Bitmap(loadedImage.Width, loadedImage.Height);
            BitmapData matrixData = matrix.LockBits(rectParam, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData imageData = loadedImage.LockBits(rectParam, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int heightImage = loadedImage.Height;
            int widthImage = loadedImage.Width;
            int stride = imageData.Stride; // stride for both bitmapdata
            int thresholdNearBlack = 40;
            fringe.Enqueue(new Tuple<int, int>(0, 0)); 
            List<int> circlePixelCounts = new List<int>();
            unsafe {
                byte* ptrImage = (byte*)imageData.Scan0;
                byte* ptrMatrix = (byte*)matrixData.Scan0;
                for(int y = 0; y < heightImage; y++) {
                    for (int x = 0; x < widthImage; x++)
                    {
                        int index = y * stride + x * 3;
                        // Calculate the pixel intensity (greyscaled)
                        int pixel = ((ptrImage[index] + ptrImage[index + 1] + ptrImage[index + 2]) / 3);

                        if (pixel >= thresholdNearBlack)
                        {
                            // Pixel is white or near white
                            // Muchat ko? Pero ako raman malipay?
                            if (ptrMatrix[index] == 0)
                            { // If not visited
                              // Push to fringe for BFS
                              // Muchat ko? Pero ako raman malipay?
                                fringe.Enqueue(new Tuple<int, int>(x, y));
                                // Initial Point to 1
                                ptrMatrix[index] = 255; // Mark as visited
                                ptrMatrix[index + 1] = 255; // Mark as visited
                                ptrMatrix[index + 2] = 0; // Mark as visited
                                // Start BFS loop until encountering "near black" pixel
                                // Muchat ko? Pero ako raman malipay?
                                int pixelCount = 0; // Initialize counter for the current circle, hays T^T
                                pixelCount++;
                                // Goods basta happy siya! Cope!
                                // Cringe ++
                                while (fringe.Count > 0) { 
                                    var current = fringe.Dequeue();
                                    int nX = current.Item1;
                                    int nY = current.Item2;
                                    // Define 4-connected neighbors
                                    List<Tuple<int, int>> neighbors = new List<Tuple<int, int>> {
                                        new Tuple<int, int>(nX + 1, nY), // Right
                                        new Tuple<int, int>(nX - 1, nY), // Left
                                        new Tuple<int, int>(nX, nY + 1), // Bottom
                                        new Tuple<int, int>(nX, nY - 1)  // Top
                                    };
                                    foreach (var neighbor in neighbors)
                                    {
                                        int newX = neighbor.Item1;
                                        int newY = neighbor.Item2;
                                        // Check boundaries
                                        if (newX >= 0 && newX < widthImage && newY >= 0 && newY < heightImage)
                                        {
                                            // Correct index calculation
                                            int neighborIndex = newY * stride + newX * 3;
                                            // Muchat ko? Pero ako raman malipay?
                                            // Calculate the pixel intensity of the neighbor
                                            int neighborPixel = (ptrImage[neighborIndex] + ptrImage[neighborIndex + 1] + ptrImage[neighborIndex + 2]) / 3;

                                            // Check if not visited and not near-black
                                            if (ptrMatrix[neighborIndex] == 0 && neighborPixel >= thresholdNearBlack)
                                            {
                                                fringe.Enqueue(new Tuple<int, int>(newX, newY));
                                                ptrMatrix[neighborIndex] = 255; // Mark as visited
                                                ptrMatrix[neighborIndex + 1] = 255; // Mark as visited
                                                ptrMatrix[neighborIndex + 2] = 0; // Mark as visited
                                                pixelCount++;
                                            }
                                        }
                                    }
                                }
                                if (pixelCount > 500) { 
                                    circlePixelCounts.Add(pixelCount);
                                }
                            }
                        }
                    }
                }
            }
            matrix.UnlockBits(matrixData);
            loadedImage.UnlockBits(imageData);
            circlePixelCounts.Sort();
            MessageBox.Show("Count of Coins: " + (circlePixelCounts.Count).ToString());
            string output = "Circle Pixel Counts:\n";
            for (int i = 0; i < circlePixelCounts.Count; i++)
            {
                if (i % 16 == 0)
                {
                    output += $"Circle {i + 1}: {circlePixelCounts[i]} pixels \n";
                }
                else { 
                    output += $"Circle {i + 1}: {circlePixelCounts[i]} pixels ";
                }
            }
            double sum = 0;
            for (int i = 0; i < circlePixelCounts.Count; i++)
            {
                int pixelCount = circlePixelCounts[i];

                if (pixelCount >= 22000 && pixelCount <= 24000)
                {
                    sum += 5; // 5 pesos
                }
                else if (pixelCount >= 17000 && pixelCount <= 18500)
                {
                    sum += 1; // 1 peso
                }
                else if (pixelCount >= 12000 && pixelCount <= 14000)
                {
                    sum += 0.25; // 25 cents
                }
                else if (pixelCount >= 9000 && pixelCount <= 10000)
                {
                    sum += 0.10; // 10 cents
                }
                else if (pixelCount >= 7000 && pixelCount <= 8500)
                {
                    sum += 0.05; // 5 cents
                }
            }
            MessageBox.Show(output, "Pixel Counts");

            MessageBox.Show("Total Value of the coins is: " + sum);
            return matrix;
        }
    }
}
