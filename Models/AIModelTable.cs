using System;

namespace HandwritingNeuralNetwork.Models
{
    public class AIModelTable : model_base
    {
        public int ID_AIModelTable;
        public string ModelName;
        public bool Trainable;
        public bool Deployed;
        public DateTime CreatedOn;

        public AIModelTable() { }

        public void GetDeployed()
        {
            this.LoadRecordWhere($"AIModelTable.Deployed = 1");
        }
    }
}
