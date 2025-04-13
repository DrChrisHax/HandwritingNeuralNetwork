using HandwritingNeuralNetwork.Models;
using HandwritingNeuralNetwork.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandwritingNeuralNetwork.AIModel.TrainingSuite
{
    public class TrainingSuiteController : ControllerBase<IViewTrainingSuite>
    {

        private int[] _dataCounts;
        private TrainingData _mgr;

        public TrainingSuiteController(IViewTrainingSuite view) : base(view)
        {
            _mgr = new TrainingData();
            _dataCounts = _mgr.TrainingDataCount();
            //_view.PopulateTraininigDataCounts(_dataCounts);
        }

        #region Controller Actions

        public void SaveGrid(bool[,] cells, int classification)
        {
            //Here we need to save the cells and classification in the db
            //Then update the UI to display the count of each classification digit

            TrainingData model = new TrainingData();
            model.Input = model.ConvertBoolArrayToString(cells);
            model.DataLabel = (classification == -1)? "n" : classification.ToString();
            model.LastUpdated = DateTime.Now;
            model.AddRecord();

            //Update the data counts
            if (classification == -1)
            {
                _dataCounts[10]++;
            } else
            {
                _dataCounts[classification]++;
            }
            //_view.PopulateTraininigDataCounts(_dataCounts);
        }


        #endregion 


    }
}
