using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandwritingNeuralNetwork.Shared
{
    public class Types
    {
        public static DateTime SQLMinDate()
        {
            return new DateTime(1753, 1, 1);
        }

        public static DateTime SQLMaxDate()
        {
            return new DateTime(9999, 12, 31);
        }
    }
}
