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

        public TrainingSuiteController(IViewTrainingSuite view) : base(view)
        {

        }

        #region Controller Actions

        public void SaveGrid(bool[,] cells, int classification)
        {
            //Here we need to save the cells and classification in the db
            //Then update the UI to display the count of each classification digit
        }


        #endregion 


    }
}
