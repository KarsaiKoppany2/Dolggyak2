using System;
using System.Collections.Generic;
using System.Text;

namespace Dolggyak2
{
    public class Csomag
    {
        private int sulyKg;
        private int tavolsagKm;
        private static int osszesCsomagSzam = 0;
        public string CsomagKod { get; set; }
        public string Cimzett { get; set; }
        public int SulyKg 
        { 
            get{ return sulyKg; }
            set
            {
                if (value < 1) sulyKg = 1;
                else sulyKg = value;
            }
        }
        public int TavolsagKm 
        {
            get { return tavolsagKm; }
            set 
            {
                if (value < 1) tavolsagKm = 1;
                else tavolsagKm = value;
            }
        }
        public static int OsszesCsomagSzam { get { return osszesCsomagSzam; } }
        public Csomag(string csomagKod, string cimzett, int sulyKg) :this(csomagKod, cimzett, sulyKg, 10) { }
        public Csomag(string csomagKod, string cimzett,int sulyKg, int tavolsagKm) 
        {
            CsomagKod = csomagKod;
            Cimzett = cimzett;
            SulyKg = sulyKg;
            TavolsagKm = tavolsagKm;
            osszesCsomagSzam++;
        }
    }
}
