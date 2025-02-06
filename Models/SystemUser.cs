namespace HandwritingNeuralNetwork.Models
{
    public class SystemUser : model_base
    {
        public int ID_SystemUser { get; set; }
        public string UserName { get; set; }


        public SystemUser() { }
        public SystemUser(int id) : base(id) { }
    }
}
