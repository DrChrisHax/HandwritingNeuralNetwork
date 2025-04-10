using System;
using System.Collections.Generic;
using System.Text;

namespace HandwritingNeuralNetwork.Models
{
    public class TrainingData : model_base
    {
        // Public member properties
        public int ID_TrainingData { get; set; }
        public string Input { get; set; }
        public string DataLabel { get; set; }
        public DateTime LastUpdated { get; set; }

        // Parameterless constructor
        public TrainingData() { }

        // Constructor to load a record based on the primary key
        public TrainingData(int id) : base(id) { }

       
        /// Loads all records from the TrainingData table.
        /// <returns>A list of TrainingData objects.</returns>
        public static List<TrainingData> LoadAll()
        {
            // Implementation will be added in the appropriate location.
            throw new NotImplementedException();
        }

        
        /// Converts a bool array to a raw binary string.
      
        public static string BoolArrayToString(bool[] boolArray)
        {
            if (boolArray == null || boolArray.Length == 0)
                return string.Empty;

            StringBuilder sb = new StringBuilder();
            int index = 0;

            // Process complete groups of 8 bits
            while (index + 8 <= boolArray.Length)
            {
                byte b = 0;
                for (int bit = 0; bit < 8; bit++)
                {
                    if (boolArray[index + bit])
                    {
                        b |= (byte)(1 << (7 - bit));
                    }
                }
                sb.Append((char)b);
                index += 8;
            }

            // Process any remaining bits (pad the remaining bits with zeroes)
            if (index < boolArray.Length)
            {
                byte b = 0;
                int remaining = boolArray.Length - index;
                for (int bit = 0; bit < remaining; bit++)
                {
                    if (boolArray[index + bit])
                    {
                        b |= (byte)(1 << (7 - bit));
                    }
                }
                sb.Append((char)b);
            }

            return sb.ToString();
        }
    }
}
