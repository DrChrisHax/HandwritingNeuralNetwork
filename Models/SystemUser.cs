using System;

namespace HandwritingNeuralNetwork.Models
{
    public class SystemUser : model_base
    {
        public int ID_SystemUser { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsAdmin { get; set; }


        public SystemUser() { }
        public SystemUser(int id) : base(id) { }


        public void LoadByUsername(string username)
        {
            this.LoadRecordWhere($"SystemUser.UserName = '{username}'");
        }



    }
}
