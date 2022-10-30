using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utazok_Feleves_Feladat
{
    class Utazok
    {
        private Varosok[] varosok;

        public Utazok(int[] hossz, int meddigIteraljon, string melyikUtazo, string eleresiUtvonal)
        {
            varosok = new Varosok[0];
            StreamReader sr = new StreamReader(eleresiUtvonal);

            if (melyikUtazo == "elso")
            {
                sr.ReadLine();
                for (int i = 0; i < meddigIteraljon; i++)
                {
                    UjVaros(new Varosok(sr.ReadLine()));
                }
            }
            else
            {
                for (int i = 0; i < meddigIteraljon + 2; i++)
                {
                    if (i < hossz[0] + 2)
                    {
                        string seged = sr.ReadLine();
                    }
                    else
                    {
                        UjVaros(new Varosok(sr.ReadLine()));
                    }
                }
            }
            sr.Close();
        }

        private void UjVaros(Varosok ujvaros)
        {
            Varosok[] uj = new Varosok[varosok.Length + 1];
            for (int i = 0; i < varosok.Length; i++)
            {
                uj[i] = varosok[i];
            }
            uj[uj.Length - 1] = ujvaros;
            varosok = uj;
        }

        public string[] Talalkozasok(Utazok utazo1, Utazok utazo2)
        {
            // metszet tetel kiegeszitve egy metodussal ami az idopontokat ellenorzi
            string[] eredmeny = new string[utazo1.varosok.Length + utazo2.varosok.Length];
            int db = 1;
            for (int i = 0; i < utazo1.varosok.Length; i++)
            {
                int j = 0;
                while (j < utazo2.varosok.Length && utazo1.varosok[i].VarosNev != utazo2.varosok[j].VarosNev)
                {
                    j++;
                }
                if (j < utazo2.varosok.Length && TalalkozasokSeged(utazo1.varosok[i].ElsoNap, utazo1.varosok[i].UtolsoNap, utazo2.varosok[j].ElsoNap, utazo2.varosok[j].UtolsoNap))
                {
                    eredmeny[0] = Convert.ToString(db);
                    eredmeny[db] = utazo1.varosok[i].VarosNev;
                    db++;
                }
            }

            //Fajlba iras

            File.WriteAllLines(@"..\TesztKi\utazoKi.txt", eredmeny, Encoding.Default);
            
            return eredmeny;
        }

        // talalkozasi idopontok ellenorzese metodus segitsegevel
        private bool TalalkozasokSeged(int elsoUtazoErk, int elsoUtazoUtolsoN, int masodikUtazoErk, int masodikUtazoUtolsoN)
        {
            if (elsoUtazoErk == masodikUtazoErk || elsoUtazoErk == masodikUtazoUtolsoN || elsoUtazoUtolsoN == masodikUtazoUtolsoN)
            {
                return true;
            }
            if (elsoUtazoUtolsoN >= elsoUtazoErk && elsoUtazoUtolsoN < masodikUtazoUtolsoN)
            {
                return true;
            }
            if (elsoUtazoErk >= masodikUtazoErk && elsoUtazoUtolsoN <= masodikUtazoUtolsoN)
            {
                return true;
            }
            if (masodikUtazoErk >= elsoUtazoErk && masodikUtazoUtolsoN <= elsoUtazoUtolsoN)
            {
                return true;
            }
            return false;
        }

    }
}
