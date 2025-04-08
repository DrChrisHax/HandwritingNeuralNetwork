using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HandwritingNeuralNetwork.AIModel.AIModels
{
    public class MNIST : AIModelBase
    {

        private InferenceSession _session;

        public MNIST() {
            var modelPath = Path.Combine(AppContext.BaseDirectory, "Resources", "mnist-8.onnx");
            _session = new InferenceSession(modelPath);
        }

        #region Analyze / Train

        public override int Analyze(bool[,] cells)
        {
            float[] input64 = new float[64 * 64];
            for (int y = 0; y < 64; y++)
            {
                for (int x = 0; x < 64; x++)
                {
                    input64[y * 64 + x] = cells[x, y] ? 1f : 0f;
                }
            }

            // Downscale to 28x28
            float[] input28 = Downscale64to28(input64);

            // Build input tensor: shape [1, 1, 28, 28]
            var tensor = new DenseTensor<float>(new[] { 1, 1, 28, 28 });
            for (int i = 0; i < 28 * 28; i++)
            {
                tensor[0, 0, i / 28, i % 28] = input28[i];
            }

            var input = NamedOnnxValue.CreateFromTensor("Input3", tensor);
            var results = _session.Run(new[] { input });
            var output = results.First().AsEnumerable<float>().ToArray();

            int predictedDigit = Array.IndexOf(output, output.Max());
            return predictedDigit;
        }

        public override float[] AnalyzeProbablities(bool[,] cells)
        {
            throw new NotImplementedException();
        }

        public override void Train(bool[,] cells, int target)
        {
            throw new NotImplementedException();
        }

        #endregion


        public static float[] Downscale64to28(float[] input)
        {
            int inputSize = 64;
            int outputSize = 28;
            float scale = (float)inputSize / outputSize;

            float[] output = new float[outputSize * outputSize];

            for (int y = 0; y < outputSize; y++)
            {
                for (int x = 0; x < outputSize; x++)
                {
                    float startX = x * scale;
                    float startY = y * scale;
                    float endX = (x + 1) * scale;
                    float endY = (y + 1) * scale;

                    int x0 = (int)Math.Floor(startX);
                    int x1 = (int)Math.Ceiling(endX);
                    int y0 = (int)Math.Floor(startY);
                    int y1 = (int)Math.Ceiling(endY);

                    float sum = 0f;
                    float count = 0f;

                    for (int iy = y0; iy < y1; iy++)
                    {
                        for (int ix = x0; ix < x1; ix++)
                        {
                            if (ix >= 0 && ix < inputSize && iy >= 0 && iy < inputSize)
                            {
                                sum += input[iy * inputSize + ix];
                                count += 1f;
                            }
                        }
                    }

                    output[y * outputSize + x] = (count > 0) ? (sum / count) : 0f;
                }
            }

            return output;
        }


    }
}
