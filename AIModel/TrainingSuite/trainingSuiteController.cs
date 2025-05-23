﻿using HandwritingNeuralNetwork.Models;
using HandwritingNeuralNetwork.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace HandwritingNeuralNetwork.AIModel.TrainingSuite
{
    public class TrainingSuiteController : ControllerBase<IViewTrainingSuite>
    {

        private int[] _dataCounts;
        private TrainingData16 _mgr;
        private NNModel _modelRecord;

        private NeuralNetwork2 _lastNetwork;
        private int[] _lastLayers;
        private int _lastTrainSize;
        private int _lastTestSize;
        private double _lastAccuracy;

        public TrainingSuiteController(IViewTrainingSuite view) : base(view)
        {
            _mgr = new TrainingData16();
            _dataCounts = _mgr.TrainingDataCount();
            _modelRecord = new NNModel();
            //List<TrainingData> lst = _mgr.SelectAll(); //Use this line when you need to load in all the training data
            _view.PopulateTraininigDataCounts(_dataCounts);
        }

        #region Controller Actions

        public void SaveGrid(bool[,] cells, int classification)
        {
            //Here we need to save the cells and classification in the db
            //Then update the UI to display the count of each classification digit

            TrainingData16 model = new TrainingData16();
            model.InputData = TrainingData16.PackBoolMatrix(cells);
            model.DataLabel = (classification == -1) ? "n" : classification.ToString();
            model.LastUpdated = DateTime.Now;
            model.AddRecord();

            //Update the data counts
            if (classification == -1)
            {
                _dataCounts[10]++;
            }
            else
            {
                _dataCounts[classification]++;
            }
            _view.PopulateTraininigDataCounts(_dataCounts);
        }


        ///<summary>
        ///Trains the network on a balanced sample (under-sampled to the smallest class).
        ///Uses an 80/20 split after balancing.
        ///Architecture: 256-128-64-10
        ///</summary>
        public void TrainModel(double learningRate = 4.0, int epochs = 128, int miniBatchSize = 20)
        {
            var allData = _mgr.SelectAll()
                              .Where(r => char.IsDigit(r.DataLabel.First()))
                              .ToList();
            var rnd = new Random();
            var grouped = allData.GroupBy(r => r.DataLabel)
                                 .ToDictionary(g => g.Key, g => g.ToList());
            int minCount = grouped.Values.Min(list => list.Count);
            var balanced = grouped.SelectMany(kvp => kvp.Value.OrderBy(_ => rnd.Next()).Take(minCount))
                                   .OrderBy(_ => rnd.Next())
                                   .ToList();
            int total = balanced.Count;
            int trainSize = (int)(total * 0.8);
            var trainSet = balanced.Take(trainSize).ToList();
            var testSet = balanced.Skip(trainSize).ToList();

            var trainingData = trainSet.Select(r => (
                input: FlattenMatrix(TrainingData16.UnpackBoolMatrix(r.InputData)),
                output: CreateOutputVector(r.DataLabel.First())
            )).ToList();

            int[] layers = {256, 128, 64, 10};
            _lastLayers = layers;
            var nn = new NeuralNetwork2(layers);

            nn.SGD(trainingData, epochs, miniBatchSize, learningRate, _view);

            int correct = testSet.Count(r =>
                ArgMax(nn.FeedForward(FlattenMatrix(TrainingData16.UnpackBoolMatrix(r.InputData))))
                == LabelToIndex(r.DataLabel.First())
            );
            double accuracy = (double)correct / testSet.Count;

            _lastNetwork = nn;
            _lastTrainSize = trainSize;
            _lastTestSize = testSet.Count;
            _lastAccuracy = accuracy;

            _view.SetOutput($"Balanced training complete.{Environment.NewLine} Test accuracy: {_lastAccuracy:P2}");
            Debug.WriteLine($"Balanced training complete.{Environment.NewLine} Test accuracy: {_lastAccuracy:P2}");
        }

        /// <summary>
        /// Persists the last trained model to the database (biases & weights).
        /// Call this only after Train().
        /// </summary>
        public bool SaveModel(string modelName = "HWNN v0.5")
        {
            if (_lastNetwork == null)
            {
                _view.SetOutput("Please train the model before saving.");
                return false;
            }

            _modelRecord.Layers = "[" + string.Join(",", _lastLayers) + "]";
            _modelRecord.InputSize = _lastLayers[0];
            _modelRecord.OutputSize = _lastLayers.Last();
            _modelRecord.LastUpdated = DateTime.Now;

            bool bResult = false;
            if (_modelRecord.ModelId == 0)
            {
                _modelRecord.ModelName = modelName;
                bResult = _modelRecord.AddRecord();
            }
            else
            {
                bResult = _modelRecord.UpdateRecord();
            }

            _modelRecord.SaveNeuralNetwork(_lastNetwork);
            _lastNetwork = null; //Reset to prevent double saving the same model

            return bResult;
        }

        #endregion

        #region Support Functions
        private static double[] FlattenMatrix(bool[,] matrix)
        {
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
            var arr = new double[rows * cols];
            int idx = 0;
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                    arr[idx++] = matrix[r, c] ? 1.0 : 0.0;
            return arr;
        }

        private static double[] CreateOutputVector(char label)
        {
            var vec = new double[11];
            vec[LabelToIndex(label)] = 1.0;
            return vec;
        }

        private static int LabelToIndex(char label)
        {
            return (label >= '0' && label <= '9') ? label - '0' : 10;
        }

        private static int ArgMax(double[] arr)
        {
            int best = 0;
            for (int i = 1; i < arr.Length; i++)
                if (arr[i] > arr[best]) best = i;
            return best;
        }
        #endregion

    }
}
