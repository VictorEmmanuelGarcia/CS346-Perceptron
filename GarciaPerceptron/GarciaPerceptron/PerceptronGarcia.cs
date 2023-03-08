using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GarciaPerceptron
{
    public partial class PerceptronGarcia : Form
    {
        PerceptronLogic perceptron;
        public PerceptronGarcia()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int input1 = Convert.ToInt32(textBox1.Text);
            int input2 = Convert.ToInt32(textBox2.Text);
            int epochs = Convert.ToInt32(textBox3.Text);

            perceptron = new PerceptronLogic(inputCount: 2);
            double[][] inputs = new double[][]
            {
                new double[] { 0, 0 },
                new double[] { 0, 1 },
                new double[] { 1, 0 },
                new double[] { 1, 1 }
            };
            int[] targets = new int[] { 1, 1, 1, 0 };
            perceptron.Train(inputs, targets, epochs);
            string output = perceptron.Predict(new double[] { input1, input2 }).ToString();

            label5.Text = output;
        }
    }
}
