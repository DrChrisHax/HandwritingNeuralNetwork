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


        // Loads all records from the TrainingData table.
        

        public static List<TrainingData> LoadAll()
        {
            // Implementation will be added in the appropriate location.
            throw new NotImplementedException();
        }

       
        public static string ConvertBoolArrayToString(bool[] arr)
        {
            if (arr == null)
                throw new ArgumentNullException(nameof(arr));
            if (arr.Length != 4096)
                throw new ArgumentException("The bool array must have exactly 4096 elements.", nameof(arr));

            int charCount = arr.Length / 8;
            char[] result = new char[charCount];

            for (int i = 0; i < charCount; i++)
            {
                int baseIndex = i * 8;
                int value = 0;
                // Unrolled loop: Each true value sets the corresponding bit.
                if (arr[baseIndex]) value |= 1;    // 2^0
                if (arr[baseIndex + 1]) value |= 2;    // 2^1
                if (arr[baseIndex + 2]) value |= 4;    // 2^2
                if (arr[baseIndex + 3]) value |= 8;    // 2^3
                if (arr[baseIndex + 4]) value |= 16;   // 2^4
                if (arr[baseIndex + 5]) value |= 32;   // 2^5
                if (arr[baseIndex + 6]) value |= 64;   // 2^6
                if (arr[baseIndex + 7]) value |= 128;  // 2^7

                result[i] = (char)value;
            }

            return new string(result);
        }

       
        public static bool[] ConvertStringToBoolArray(string str)
        {
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            if (str.Length != 4096 / 8)
                throw new ArgumentException("The string must have exactly 512 characters for a 4096-element bool array.", nameof(str));

            bool[] result = new bool[str.Length * 8];

            for (int i = 0; i < str.Length; i++)
            {
                int baseIndex = i * 8;
                int value = str[i]; // each character is treated as a byte value.
                // Unpack each bit into a bool.
                result[baseIndex] = (value & 1) != 0;    // 2^0
                result[baseIndex + 1] = (value & 2) != 0;    // 2^1
                result[baseIndex + 2] = (value & 4) != 0;    // 2^2
                result[baseIndex + 3] = (value & 8) != 0;    // 2^3
                result[baseIndex + 4] = (value & 16) != 0;   // 2^4
                result[baseIndex + 5] = (value & 32) != 0;   // 2^5
                result[baseIndex + 6] = (value & 64) != 0;   // 2^6
                result[baseIndex + 7] = (value & 128) != 0;  // 2^7
            }

            return result;
        }
    }
}
