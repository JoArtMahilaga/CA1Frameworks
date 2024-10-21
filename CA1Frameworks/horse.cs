using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA1
{
    internal class Horse
    {

        private string horseName;
        private int horseID;
        private String dob;


        public Horse(string name, String doB, int iD)
        {
            this.horseName = "";
            this.DoB = doB;
            this.horseID = iD;
        }

        public string HorseName
        {
            get { return horseName; }
            set { horseName = value; }
        }

        public int HorseID
        {
            get { return horseID; }
            set { horseID = value; }
        }

        public String DoB
        {
            get { return dob; }
            set { dob = value; }
        }
    }
}
