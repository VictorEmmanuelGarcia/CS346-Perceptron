using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GarciaPerceptron
{
    public class PerceptronLogic
    {
        private double[] weights;
        private double bias;
        private double learningRate;

        public PerceptronLogic(int inputCount, double learningRate = 0.1)
        {
            weights = new double[inputCount];
            var x = new Random();
            for (int i = 0; i < inputCount; i++)
            {
                weights[i] = x.NextDouble() * 2 - 1;
            }

            bias = 0;
            this.learningRate = learningRate;
        }

        public int Predict(double[] inputs)
        {
            double weightSum = 0;
            for (int i = 0; i < weights.Length; i++)
            {
                weightSum += weights[i] * inputs[i];
            }
            weightSum += bias;
            return weightSum >= 0 ? 1 : 0;
        }

        public void Train(double[][] inputs, int[] targets, int numEpochs)
        {
            for (int epoch = 0; epoch < numEpochs; epoch++)
            {
                for (int i = 0; i < inputs.Length; i++)
                {
                    double prediction = Predict(inputs[i]);
                    double error = targets[i] - prediction;
                    for (int j = 0; j < weights.Length; j++)
                    {
                        weights[j] += error * inputs[i][j] * learningRate;
                    }
                    bias += learningRate * error;
                }
            }
        }
    }
}
