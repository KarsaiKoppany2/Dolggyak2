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
        else if (adatok.Count() == 4)
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
    foreach (Csomag aktcsomag in csomagok) Console.WriteLine(aktcsomag.ToString());
    Console.WriteLine($"Rendszerben regisztrált csomagok száma: {Csomag.OsszesCsomagSzam}");
    int osszKM = 0;
    foreach (Csomag aktcsomag in csomagok) osszKM += aktcsomag.TavolsagKm;
    Console.WriteLine($"Becsült üzemeanyagköltség: {UzemanyagKalkulator.BecsultUzemanyagKoltseg(osszKM)} Ft");
    Csomag legmagasabb = csomagok[0];
    foreach (Csomag aktcsomag in csomagok) 
    {
        if (aktcsomag.KiszallitasiDij() > legmagasabb.KiszallitasiDij()) legmagasabb = aktcsomag;
    }
    Console.WriteLine($"Legmagasabb szállítási díjú csomag: {legmagasabb}");
}