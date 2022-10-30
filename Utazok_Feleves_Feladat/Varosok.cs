using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utazok_Feleves_Feladat
{
    class Varosok
    {
        public int ElsoNap
        {
            get; set;
        }
        public int UtolsoNap
        {
            get; set;
        }
        public string VarosNev
        {
            get; set;
        }
        public Varosok(string sor) //segitseg a beolvasashoz sorok splitelese
        {
            string[] darabok = sor.Split();
            this.ElsoNap = int.Parse(darabok[0]);
            this.UtolsoNap = int.Parse(darabok[1]);
            this.VarosNev = darabok[2];
        }
    }
}
