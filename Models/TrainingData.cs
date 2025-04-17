using HandwritingNeuralNetwork.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace HandwritingNeuralNetwork.Models
{
    public class TrainingData : model_base
    {
        // Public member properties 
        public int ID_TrainingData { get; set; }
        public string Input { get; set; }
        public string DataLabel { get; set; } //0-9 or n for not a number 
        public DateTime LastUpdated { get; set; }

        //Parameterless constructor
        public TrainingData() { }

        //Constructor to load a record based on the primary key
        public TrainingData(int id) : base(id) { }


        //Loads all records from the TrainingData table.
        

        public List<TrainingData> SelectAll()
        {
            List<model_base> baseResults = this.SelectWhereOrderBy("", "");
            return baseResults.Cast<TrainingData>().ToList();
        }

        public int[] TrainingDataCount()
        {
            string sql = "SELECT DataLabel, COUNT(*) AS RecordCount FROM TrainingData GROUP BY DataLabel";

            DataTable dt = ExecuteSQLAsDataTable(sql);

            int[] counts = new int[11];

            foreach (DataRow row in dt.Rows)
            {
                string label = row["DataLabel"].ToString().Trim().ToLower();
                int recordCount = Convert.ToInt32(row["RecordCount"]);

                if (label == "n")
                {
                    counts[10] = recordCount;
                }
                else if (int.TryParse(label, out int digit) && digit >= 0 && digit <= 9)
                {
                    counts[digit] = recordCount;
                }
                else
                {
                    throw new Exception($"Invaild Data Label Returned: {label}");
                }
            }

            return counts;
        }

       
        public string ConvertBoolArrayToString(bool[,] arr)
        {
            bool[] flatArray = arr.Cast<bool>().ToArray();
            return ConvertBoolArrayToString(flatArray);
        }
        public string ConvertBoolArrayToString(bool[] arr)
        {
            if (arr == null)
                throw new ArgumentNullException(nameof(arr));
            if (arr.Length != AppConstants.GRID_COLUMNS * AppConstants.GRID_ROWS)
                throw new ArgumentException($"The bool array must have exactly {AppConstants.GRID_COLUMNS * AppConstants.GRID_ROWS} elements.", nameof(arr));

            int charCount = arr.Length >> 3;
            char[] result = new char[charCount];

            for (int i = 0; i < charCount; i++)
            {
                int baseIndex = i << 3;
                int value = 0;
                //Unrolled loop: Each true value sets the corresponding bit.
                if (arr[baseIndex]) value |= 1;    //2^0
                if (arr[baseIndex + 1]) value |= 2;    //2^1
                if (arr[baseIndex + 2]) value |= 4;    //2^2
                if (arr[baseIndex + 3]) value |= 8;    //2^3
                if (arr[baseIndex + 4]) value |= 16;   //2^4
                if (arr[baseIndex + 5]) value |= 32;   //2^5
                if (arr[baseIndex + 6]) value |= 64;   //2^6
                if (arr[baseIndex + 7]) value |= 128;  //2^7

                result[i] = (char)value;
            }

            return new string(result);
        }

       
        public bool[,] ConvertStringToBoolArray(string str)
        {
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            if (str.Length != AppConstants.GRID_COLUMNS << 3)
                throw new ArgumentException($"The string must have exactly {AppConstants.GRID_COLUMNS << 3} characters for a {AppConstants.GRID_COLUMNS * AppConstants.GRID_ROWS}-element bool array.", nameof(str));

            bool[,] result = new bool[AppConstants.GRID_COLUMNS, AppConstants.GRID_ROWS];

            for (int i = 0; i < str.Length; i++)
            {
                int baseIndex = i << 3;
                int value = str[i];


                for (int bit = 0; bit < 8; bit++)
                {
                    int overallIndex = baseIndex + bit;
                    int row = overallIndex >> 6;
                    int col = overallIndex & 63;
                    result[row, col] = ((value >> bit) & 1) != 0;
                }
            }

            return result;
        }
    }
}
