using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_13
{
    [Serializable]
    public class Bank
    {
        public static Bank bdBank { get; private set; }
        public string Name { get; set; }
        public ObservableCollection<Client> Clients { get; set; }

        public Bank(string name)
        {
            Name = name;
            //Clients = new ObservableCollection<Client>();
            bdBank = this;
        }
    }
}
