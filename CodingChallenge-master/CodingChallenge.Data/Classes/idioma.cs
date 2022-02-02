using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public enum enuIdioma
    {
        Castellano = 1,
     Ingles = 2,
     Portuges = 3
    }

public class idioma
    {
        public static string traduccionFormas(int idioma)
        {
            switch (idioma)
            {
                case (int)enuIdioma.Castellano: return "Formas";
                case (int)enuIdioma.Ingles: return "Shapes";
                case (int)enuIdioma.Portuges: return "Formas";
                default: return "idioma desconocido";
            }
        }
        public static string traduccionPerimetro(int idioma)
        {
            switch (idioma)
            {
                case (int)enuIdioma.Castellano: return "Perimetro ";
                case (int)enuIdioma.Ingles: return "Perimeter ";
                case (int)enuIdioma.Portuges: return "Perimetro";
                default: return "idioma desconocido";
            }
        }
        public static string TraducirIdioma ()
    }

        
    
}
