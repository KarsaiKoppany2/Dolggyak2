using Dolggyak2;

List<Csomag> csomagok = new List<Csomag>();

if (File.Exists("Csomagok.txt")) 
{
    foreach (string sor in File.ReadAllLines("csomagok.txt")) 
    {
        string[] adatok = sor.Split(';');
        if (adatok.Count() == 3) 
        {
            if (int.TryParse(adatok[2], out int sulyKg))
            {
                if (!string.IsNullOrWhiteSpace(adatok[0]))
                {
                    Csomag aktualis = new Csomag(adatok[0], adatok[1], sulyKg);
                    csomagok.Add(aktualis);
                }
            }
            else
            {
                Console.WriteLine($"Hibás számadat a {adatok[0]} csomagnál");
            }
        }
        if (adatok.Count() == 4)
        {
            if (int.TryParse(adatok[2], out int sulyKg) && int.TryParse(adatok[3], out int tavolsagKm))
            {
                if (!string.IsNullOrWhiteSpace(adatok[0]))
                {
                    Csomag aktualis = new Csomag(adatok[0], adatok[1], sulyKg, tavolsagKm);
                    csomagok.Add(aktualis);
                }
            }
            else
            {
                Console.WriteLine($"Hibás számadat a {adatok[0]} csomagnál");
            }
        }

    }
}