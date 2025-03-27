using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Film_V_CLI.Classes
{
    class Film
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }

        public string Studio { get; set; }

        public int LengthMin { get; set; }

        public Film(string row)
        {
            string[] data = row.Split(';');
            Name = data[0];
            Year = int.Parse(data[1]);
            Genre = data[2];
            Studio = data[3];
            LengthMin = int.Parse(data[4]);

        }

        public override string ToString()
        {
            return $" \n\tCím:{Name}\n \tBemutató éve: {Year}\n  \tMűfaj: {Genre}\n  \t Gyártó/Forgalamzó: {Studio}\n  \tHossza: {LengthMin} perc";
        }

    }
}
