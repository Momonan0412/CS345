namespace Back_Propagation
{
    partial class Form1
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
            InputText1 = new TextBox();
            InputText2 = new TextBox();
            Output = new TextBox();
            CreateBPNN = new Button();
            TrainBPNN = new Button();
            TestBPNN = new Button();
            textBox4 = new TextBox();
            InputText3 = new TextBox();
            InputText4 = new TextBox();
            textBoxNumberOfNeuron = new TextBox();
            label1 = new Label();
            buttonNumberOfNeuron = new Button();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // InputText1
            // 
            InputText1.Location = new Point(88, 111);
            InputText1.Name = "InputText1";
            InputText1.Size = new Size(125, 27);
            InputText1.TabIndex = 0;
            InputText1.TextChanged += textBox1_TextChanged;
            // 
            // InputText2
            // 
            InputText2.Location = new Point(88, 154);
            InputText2.Name = "InputText2";
            InputText2.Size = new Size(125, 27);
            InputText2.TabIndex = 1;
            InputText2.TextChanged += textBox2_TextChanged;
            // 
            // Output
            // 
            Output.Location = new Point(270, 177);
            Output.Name = "Output";
            Output.Size = new Size(125, 27);
            Output.TabIndex = 2;
            // 
            // CreateBPNN
            // 
            CreateBPNN.Location = new Point(104, 276);
            CreateBPNN.Name = "CreateBPNN";
            CreateBPNN.Size = new Size(94, 51);
            CreateBPNN.TabIndex = 3;
            CreateBPNN.Text = "Create BPNN";
            CreateBPNN.UseVisualStyleBackColor = true;
            CreateBPNN.Click += button1_Click;
            // 
            // TrainBPNN
            // 
            TrainBPNN.Location = new Point(194, 352);
            TrainBPNN.Name = "TrainBPNN";
            TrainBPNN.Size = new Size(94, 51);
            TrainBPNN.TabIndex = 4;
            TrainBPNN.Text = "Train BPNN";
            TrainBPNN.UseVisualStyleBackColor = true;
            TrainBPNN.Click += button2_Click;
            // 
            // TestBPNN
            // 
            TestBPNN.Location = new Point(286, 276);
            TestBPNN.Name = "TestBPNN";
            TestBPNN.Size = new Size(94, 51);
            TestBPNN.TabIndex = 5;
            TestBPNN.Text = "Test BPNN";
            TestBPNN.UseVisualStyleBackColor = true;
            TestBPNN.Click += button3_Click;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(294, 364);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(61, 27);
            textBox4.TabIndex = 6;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // InputText3
            // 
            InputText3.Location = new Point(88, 196);
            InputText3.Name = "InputText3";
            InputText3.Size = new Size(125, 27);
            InputText3.TabIndex = 7;
            InputText3.TextChanged += InputText3_TextChanged;
            // 
            // InputText4
            // 
            InputText4.Location = new Point(88, 243);
            InputText4.Name = "InputText4";
            InputText4.Size = new Size(125, 27);
            InputText4.TabIndex = 8;
            InputText4.TextChanged += InputText4_TextChanged;
            // 
            // textBoxNumberOfNeuron
            // 
            textBoxNumberOfNeuron.Location = new Point(12, 32);
            textBoxNumberOfNeuron.Name = "textBoxNumberOfNeuron";
            textBoxNumberOfNeuron.Size = new Size(125, 27);
            textBoxNumberOfNeuron.TabIndex = 9;
            textBoxNumberOfNeuron.TextChanged += textBoxNumberOfNeuron_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(172, 20);
            label1.TabIndex = 10;
            label1.Text = "Input Number of Neuron";
            label1.Click += label1_Click;
            // 
            // buttonNumberOfNeuron
            // 
            buttonNumberOfNeuron.Location = new Point(12, 65);
            buttonNumberOfNeuron.Name = "buttonNumberOfNeuron";
            buttonNumberOfNeuron.Size = new Size(94, 29);
            buttonNumberOfNeuron.TabIndex = 11;
            buttonNumberOfNeuron.Text = "Apply";
            buttonNumberOfNeuron.UseVisualStyleBackColor = true;
            buttonNumberOfNeuron.Click += buttonNumberOfNeuron_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(262, 143);
            label2.Name = "label2";
            label2.Size = new Size(141, 20);
            label2.TabIndex = 12;
            label2.Text = "STOP IF: 0.03 or 0.87";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(296, 342);
            label3.Name = "label3";
            label3.Size = new Size(56, 20);
            label3.TabIndex = 13;
            label3.Text = "EPOCH";
            label3.Click += label3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(502, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(buttonNumberOfNeuron);
            Controls.Add(label1);
            Controls.Add(textBoxNumberOfNeuron);
            Controls.Add(InputText4);
            Controls.Add(InputText3);
            Controls.Add(textBox4);
            Controls.Add(TestBPNN);
            Controls.Add(TrainBPNN);
            Controls.Add(CreateBPNN);
            Controls.Add(Output);
            Controls.Add(InputText2);
            Controls.Add(InputText1);
            Name = "Form1";
            Text = "Back-Propagation";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox InputText1;
        private TextBox InputText2;
        private TextBox Output;
        private Button CreateBPNN;
        private Button TrainBPNN;
        private Button TestBPNN;
        private TextBox textBox4;
        private TextBox InputText3;
        private TextBox InputText4;
        private TextBox textBoxNumberOfNeuron;
        private Label label1;
        private Button buttonNumberOfNeuron;
        private Label label2;
        private Label label3;
    }
}
