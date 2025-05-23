﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using HandwritingNeuralNetwork.AIModel.AIModels;
using HandwritingNeuralNetwork.AIModel.TrainingSuite;

namespace HandwritingNeuralNetwork.AIModel
{
    public class NeuralNetwork2 : AIModelBase
    {
        private int numOfLayers;
        private int[] layers; //Each element in the array represents the number of neurons in that layer
        private List<double[]> biases;
        private List<double[,]> weights;

        private static Random rand = new Random();

        public List<double[]> Biases => biases;
        public List<double[,]> Weights => weights;

        #region Inheirited Functions

        public override float[] AnalyzeProbablities(bool[,] cells)
        {
            //Flatten 16×16 bool grid to length‑256 double array
            double[] input = new double[256];
            for (int r = 0; r < 16; r++)
                for (int c = 0; c < 16; c++)
                    input[r * 16 + c] = cells[r, c] ? 1.0 : 0.0;

            //Run feed‑forward
            double[] output = FeedForward(input);

            //Convert to floats
            return output.Select(d => (float)d).ToArray();
        }

        public override int Analyze(bool[,] cells)
        {
            var probs = AnalyzeProbablities(cells);

            for (int i = 0; i < probs.Length; i++)
            {
                Debug.WriteLine($"{i}: {probs[i].ToString("R")}");
            }
            Debug.WriteLine("\n");

            //pick the index of the highest probability
            int idx = probs.Select((v, i) => (value: v, index: i))
                           .Aggregate((a, b) => a.value > b.value ? a : b)
                           .index;
            //index 0–9 => digit; index 10 => not‑a‑number
            idx = probs[idx] > 0.5f ? idx : -1;
            Debug.WriteLine($"Classified as {idx}");
            return idx;
        }

        public override void Train(bool[,] cells, int target)
        {
            throw new NotImplementedException();
        }

        public override void SetBias(int layerIndex, int neuronIndex, double value)
        {
            biases[layerIndex][neuronIndex] = value;
        }

        public override void SetWeight(int matrixIndex, int rowIndex, int colIndex, double value)
        {
            weights[matrixIndex][rowIndex, colIndex] = value;
        }

        #endregion

        #region Constructor

        public NeuralNetwork2(int[] layers)
        {
            this.numOfLayers = layers.Length;
            this.layers = layers;

            this.biases = new List<double[]>();
            this.weights = new List<double[,]>();

            for (int i = 1; i < layers.Length; i++)
            {
                //Biases need to be an array
                biases.Add(Enumerable.Range(0, layers[i]).Select(_ => RandomDouble()).ToArray());

                //Weights need to be a matrix
                int rows = layers[i], cols = layers[i - 1];
                var matrix = new double[rows, cols];
                for (int j = 0; j < rows; j++)
                {
                    for (int k = 0; k < cols; k++)
                    {
                        matrix[j, k] = RandomDouble();
                    }
                }
                weights.Add(matrix);
            }
        }

        #endregion

        #region Feed Forward

        public double[] FeedForward(double[] a)
        {
            for (int i = 0; i < biases.Count; i++)
            {
                double[] b = biases[i];
                double[,] w = weights[i];
                a = Sigmoid(Add(Dot(w, a), b));
            }
            return a;
        }

        #endregion

        #region Learning

        public void SGD(List<(double[] input, double[] output)> trainingData, int epochs, int miniBatchSize, double eta, IViewTrainingSuite view)
        {
            int n = trainingData.Count;

            // Start total timer
            var swTotal = Stopwatch.StartNew();

            for (int e = 0; e < epochs; e++)
            {
                var swEpoch = Stopwatch.StartNew();

                var shuffled = trainingData.OrderBy(x => rand.Next()).ToList();
                for (int k = 0; k < n; k += miniBatchSize)
                {
                    var miniBatch = shuffled.Skip(k).Take(miniBatchSize).ToList();
                    UpdateMiniBatch(miniBatch, eta);
                }

                swEpoch.Stop();

                Debug.WriteLine($"Epoch {e + 1} complete in {swEpoch.Elapsed.TotalSeconds:F2}s");
                view.SetOutput($"Epoch {e + 1} complete in {swEpoch.Elapsed.TotalSeconds:F2}s");
            }

            swTotal.Stop();
            Debug.WriteLine($"Total training time: {swTotal.Elapsed.TotalMinutes:F0}m {(swTotal.Elapsed.TotalSeconds % 60):F2}s");
            view.SetOutput($"Total training time: {swTotal.Elapsed.TotalMinutes:F0}m {(swTotal.Elapsed.TotalSeconds % 60):F2}s");
        }

        private void UpdateMiniBatch(List<(double[] input, double[] output)> miniBatch, double eta)
        {
            var nablaB = biases.Select(b => new double[b.Length]).ToList();
            var nablaW = weights.Select(w => new double[w.GetLength(0), w.GetLength(1)]).ToList();

            foreach (var (input, output) in miniBatch)
            {
                var (deltaNablaB, deltaNablaW) = BackPropagation(input, output);

                for (int i = 0; i < nablaB.Count; i++)
                {
                    for (int j = 0; j < nablaB[i].Length; j++)
                    {
                        nablaB[i][j] += deltaNablaB[i][j];
                    }
                }

                for (int i = 0; i < nablaW.Count; i++)
                {
                    for (int row = 0; row < nablaW[i].GetLength(0); row++)
                    {
                        for (int col = 0; col < nablaW[i].GetLength(1); col++)
                        {
                            nablaW[i][row, col] += deltaNablaW[i][row, col];
                        }
                    }
                }
            }

            for (int i = 0; i < weights.Count; i++)
            {
                for (int row = 0; row < weights[i].GetLength(0); row++)
                {
                    for (int col = 0; col < weights[i].GetLength(1); col++)
                    {
                        weights[i][row, col] -= (eta / miniBatch.Count) * nablaW[i][row, col];
                    }
                }
            }

            for (int i = 0; i < biases.Count; i++)
            {
                for (int j = 0; j < biases[i].Length; j++)
                {
                    biases[i][j] -= (eta / miniBatch.Count) * nablaB[i][j];
                }
            }
        }

        private (List<double[]> nablaB, List<double[,]> nablaW) BackPropagation(double[] input, double[] output)
        {
            var nablaB = biases.Select(b => new double[b.Length]).ToList();
            var nablaW = weights.Select(w => new double[w.GetLength(0), w.GetLength(1)]).ToList();

            //Forward Pass
            double[] activation = input;
            var activations = new List<double[]> { input };
            var zs = new List<double[]>();

            for (int i = 0; i < biases.Count; i++)
            {
                var z = Add(Dot(weights[i], activation), biases[i]);
                zs.Add(z);
                activation = Sigmoid(z);
                activations.Add(activation);
            }

            //Backwards Pass
            var delta = activations.Last().Zip(output, (a, b) => a - b).ToArray().Zip(SigmoidPrime(zs.Last()), (a, b) => a * b).ToArray();
            nablaB[nablaB.Count - 1] = delta;
            nablaW[nablaW.Count - 1] = OuterProduct(delta, activations[activations.Count - 2]);

            for (int l = 2; l < layers.Length; l++)
            {
                var z = zs[zs.Count - l];
                var sp = SigmoidPrime(z);
                var wt = Transpose(weights[weights.Count - l + 1]);
                delta = Dot(wt, delta).Zip(sp, (a, b) => a * b).ToArray();
                nablaB[nablaB.Count - l] = delta;
                nablaW[nablaW.Count - l] = OuterProduct(delta, activations[activations.Count - l - 1]);
            }

            return (nablaB, nablaW);
        }

        #endregion

        #region Support Functions (Math)

        private static double RandomDouble()
        {
            //Box-Muller transform to generate normal (Gaussian) distributed values
            double u = 1.0 - rand.NextDouble();
            double v = 1.0 - rand.NextDouble();
            return Math.Sqrt(-2.0 * Math.Log(u)) * Math.Cos(2.0 * Math.PI * v);
        }

        private static double[] Add(double[] a, double[] b) => a.Zip(b, (x, y) => x + y).ToArray();

        private static double[] Dot(double[,] m, double[] v)
        {
            int rows = m.GetLength(0);
            int cols = m.GetLength(1);
            var result = new double[rows];
            for (int i = 0; i < rows; i++)
            {
                double sum = 0;
                for (int j = 0; j < cols; j++)
                    sum += m[i, j] * v[j];
                result[i] = sum;
            }
            return result;
        }

        private static double[,] OuterProduct(double[] a, double[] b)
        {
            var result = new double[a.Length, b.Length];
            for (int i = 0; i < a.Length; i++)
                for (int j = 0; j < b.Length; j++)
                    result[i, j] = a[i] * b[j];
            return result;
        }

        private static double[,] Transpose(double[,] matrix)
        {
            int m = matrix.GetLength(0), n = matrix.GetLength(1);
            double[,] result = new double[n, m];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    result[j, i] = matrix[i, j];
                }
            }
            return result;
        }

        #region Activation Functions

        private static double[] Sigmoid(double[] z) => z.Select(v => 1.0 / (1.0 + Math.Exp(-v))).ToArray(); //Sigmoid Function - 1 / (1 + e^-z) for each element in z
        private static double[] SigmoidPrime(double[] z)
        {
            var sig = Sigmoid(z);
            return sig.Zip(sig, (s, t) => s * (1 - t)).ToArray();
        }

        

        #endregion

        #endregion

    }
}

