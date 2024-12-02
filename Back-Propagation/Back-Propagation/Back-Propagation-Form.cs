using Backprop;
using System.Diagnostics;
namespace Back_Propagation
{
    public partial class Form1 : Form
    {
        NeuralNet NeuralNet;
        int sum;
        private Button btnOpenInput;
        int neuronCount;
        public Form1()
        {

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            buttonNumberOfNeuron.Enabled = false;

            TrainBPNN.Enabled = false;
            TestBPNN.Enabled = false;
            textBox4.ReadOnly = true;
            textBox4.Enabled = false;
            textBox4.Text = "x";

            Output.ReadOnly = true;
            Output.Enabled = false;
            sum = 0;
            InputText1.Enabled = false;
            InputText2.Enabled = false;
            InputText3.Enabled = false;
            InputText4.Enabled = false;

            CreateBPNN.Enabled = false;

            InputText1.BackColor = Color.Yellow;
            InputText2.BackColor = Color.Yellow;
            InputText3.BackColor = Color.Yellow;
            InputText4.BackColor = Color.Yellow;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NeuralNet = new NeuralNet(4, neuronCount, 1);


            CreateBPNN.BackColor = Color.Yellow;
            CreateBPNN.Enabled = false;

            InputText1.Enabled = true;
            InputText2.Enabled = true;
            InputText3.Enabled = true;
            InputText4.Enabled = true;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            double[,] inputs = {
                {0, 0, 0, 0}, {0, 0, 0, 1}, {0, 0, 1, 0}, {0, 0, 1, 1},
                {0, 1, 0, 0}, {0, 1, 0, 1}, {0, 1, 1, 0}, {0, 1, 1, 1},
                {1, 0, 0, 0}, {1, 0, 0, 1}, {1, 0, 1, 0}, {1, 0, 1, 1},
                {1, 1, 0, 0}, {1, 1, 0, 1}, {1, 1, 1, 0}, {1, 1, 1, 1}
            };

            double[] desiredOutputs = {
                0, 0, 0, 0,
                0, 0, 0, 0,
                0, 0, 0, 0,
                0, 0, 0, 1
            };
            await Task.Run(() =>
            {
                while (true)
                {
                    for (int i = 0; i < 16; i++)
                    {
                        NeuralNet.setInputs(0, inputs[i, 0]);
                        NeuralNet.setInputs(1, inputs[i, 1]);
                        NeuralNet.setInputs(2, inputs[i, 2]);
                        NeuralNet.setInputs(3, inputs[i, 3]);
                        NeuralNet.setDesiredOutput(0, desiredOutputs[i]);
                        try
                        {
                            string result = (double.Parse(Output.Text) + desiredOutputs[i]).ToString();
                            string firstFourChars = result.Length > 4 ? result.Substring(0, 4) : result;
                            if (double.Parse(firstFourChars) == 0.03
                             || double.Parse(firstFourChars) == 0.87)
                            {
                                MessageBox.Show("Success! Target Value: ", desiredOutputs[i].ToString());
                                return;
                            }
                        }
                        catch (Exception ex) { }
                        NeuralNet.learn();
                    }
                    sum++;
                    // Invoke is used to update the UI from a non-UI thread
                    Invoke((MethodInvoker)(() =>
                    {
                        textBox4.Text = "x " + sum.ToString();
                        button3_Click(sender, e);
                    }));
                }

            }
            );
            TrainBPNN.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NeuralNet.setInputs(0, Convert.ToDouble(InputText1.Text));
            NeuralNet.setInputs(1, Convert.ToDouble(InputText2.Text));
            NeuralNet.setInputs(2, Convert.ToDouble(InputText3.Text));
            NeuralNet.setInputs(3, Convert.ToDouble(InputText4.Text));
            NeuralNet.run();
            Output.Text = NeuralNet.getOuputData(0).ToString();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (InputText1.Text == "0" || InputText1.Text == "1" && InputText2.Text != "" && InputText3.Text != "" && InputText4.Text != "")
            {
                TestBPNN.Enabled = true;

                TrainBPNN.Enabled = true;
            }
            else
            {
                TestBPNN.Enabled = false;
                TrainBPNN.Enabled = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (InputText2.Text == "0" || InputText2.Text == "1" && InputText1.Text != "" && InputText3.Text != "" && InputText4.Text != "")
            {
                TestBPNN.Enabled = true;
                TrainBPNN.Enabled = true;
            }
            else
            {
                TestBPNN.Enabled = false;
                TrainBPNN.Enabled = false;
            }
        }

        private void InputText3_TextChanged(object sender, EventArgs e)
        {
            if (InputText3.Text == "0" || InputText3.Text == "1" && InputText1.Text != "" && InputText2.Text != "" && InputText4.Text != "")
            {
                TestBPNN.Enabled = true;
                TrainBPNN.Enabled = true;
            }
            else
            {
                TestBPNN.Enabled = false;
                TrainBPNN.Enabled = false;
            }

        }

        private void InputText4_TextChanged(object sender, EventArgs e)
        {
            if (InputText4.Text == "0" || InputText4.Text == "1" && InputText1.Text != "" && InputText2.Text != "" && InputText3.Text != "")
            {
                TestBPNN.Enabled = true;
                TrainBPNN.Enabled = true;
            }
            else
            {
                TestBPNN.Enabled = false;
                TrainBPNN.Enabled = false;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonNumberOfNeuron_Click(object sender, EventArgs e)
        {
            CreateBPNN.Enabled = true;
        }

        private void textBoxNumberOfNeuron_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxNumberOfNeuron.Text, out neuronCount))
            {
                buttonNumberOfNeuron.Enabled = true;
                MessageBox.Show($"The Neuron value is: {neuronCount}", "Success");
            }
            else
            {
                // Conversion failed
                MessageBox.Show("Invalid input! Please enter a valid integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
