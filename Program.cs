using Film_V_CLI.Classes;

List<Film> films = new List<Film>();
using (StreamReader be = new(path: @"..\..\..\src\filmekCLI_adatok.csv", encoding: System.Text.Encoding.UTF8))
{
    while (!be.EndOfStream)
    {
        films.Add(new Film(be.ReadLine()));
    }
}

//3) Írassa ki, hogy hány film található a tárhelyünkön!

Console.WriteLine($"3. feladat: A tárhelyen {films.Count()} db film van.");

//4) Határozza meg és írassa ki a minta szerint, hogy gyártónként hány film van a tárhelyünkön! foreachel és Igrouppal

Console.WriteLine("4. feladat: Stúdiók filmjeinek száma:");
foreach (var item in films.GroupBy(x => x.Studio))
{
    Console.WriteLine($"\t{item.Key}: {item.Count()} db");
}

//5) Kérjen be a felhasználótól egy műfajt!

Console.Write("5. feladat: Adjon meg egy műfaj nevét: ");

//6) Ha az előző feladatban bekért műfajú film szerepel a tárhelyen, akkor azok címét és hosszát tabulátorral elválasztva írassa ki a keresettmufaj.txt fájlba a minta szerint! Ha nem létezik ilyen műfajú film a tárhelyen, akkor a fájlba a következő szöveget írja be a minta szerint: „Nincs a tárhelyen …(műfaj) műfajú film!” A fájl mentése után írja ki a konzolra, hogy „A keresettmufaj.txt elkészült”!


string mufaj = Console.ReadLine().Trim();
List<Film> keresettMufajuFilmek = films.Where(x => x.Genre == mufaj).ToList();

if (keresettMufajuFilmek.Count > 0)
{
    using (StreamWriter ki = new(path: @"..\..\..\src\keresettmufaj.txt", append: false, encoding: System.Text.Encoding.UTF8))
    {
        foreach (var item in keresettMufajuFilmek)
        {
            ki.WriteLine($"{item.Name}\t{item.LengthMin}");
        }
    }

}
else
{
    using (StreamWriter ki = new(path: @"..\..\..\src\keresettmufaj.txt", append: false, encoding: System.Text.Encoding.UTF8))
    {
        ki.WriteLine($"Nincs a tárhelyen {mufaj} műfajú film!");
    }
}
Console.WriteLine("6.feladat: A keresettmufaj.txt elkészült");

//7) Határozza meg, hogy melyik filmet mutatták be a legkorábban és annak adatait írassa a képernyőre!

Film legkorabbiFilm = films.OrderBy(x => x.Year).First();
Console.WriteLine($"7. feladat: A legkorábban bemutatott film adatai:{legkorabbiFilm.ToString()}");