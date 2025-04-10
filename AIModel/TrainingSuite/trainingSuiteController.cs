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
            
            // Step 1: Save the grid of cells and the classification label to the database
            var cellData = ConvertCellsToDatabaseFormat(cells);

            // Save the data to the database
            SaveToDatabase(cellData, classification);

            // Step 2: Update the classification counts in the database
            var classificationCounts = GetClassificationCountsFromDatabase();

            // Increment the count for the given classification
            if (classificationCounts.ContainsKey(classification))
            {
                classificationCounts[classification]++;
            }
            else
            {
                classificationCounts[classification] = 1;
            }

            // Update the counts in the database
            UpdateClassificationCountsInDatabase(classificationCounts);

            // Step 3: Update the UI to display the new counts for each classification digit
            View.UpdateClassificationCounts(classificationCounts);
        }


        #endregion 


    }
}
