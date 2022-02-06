using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.String;

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

        
        public static string TraducirForma(int tipo, int cantidad, int idioma)
        {
            switch (tipo)
            {
                case 1:
                    {
                        switch (idioma)
                        {
                            case (int)enuIdioma.Castellano: return cantidad == 1 ? "Cuadrado" : "Cuadrados";
                            case (int)enuIdioma.Portuges: return cantidad == 1 ? "quadrado" : "quadrados";
                            case (int)enuIdioma.Ingles: return cantidad == 1 ? "Square" : "Squares";
                        }
                    }
                    break;
                case 2: 
                    {
                        switch (idioma)
                        {
                            case (int)enuIdioma.Castellano: return cantidad == 1 ? "Círculo" : "Círculos";
                            case (int)enuIdioma.Portuges: return cantidad == 1 ? "Círculo" : "Círculos";
                            case (int)enuIdioma.Ingles: return cantidad == 1 ? "Circle" : "Circles";
                        }
                    }
                    break;
                case 3:
                    {
                        switch (idioma)
                        {
                           case (int)enuIdioma.Castellano: return cantidad == 1 ? "Triángulo" : "Triángulos";
                           case (int)enuIdioma.Portuges: return cantidad == 1 ? "Triángulo" : "Triángulos";
                            case (int)enuIdioma.Ingles: return cantidad == 1 ? "Triangle" : "Triangles";

                        }

                        break;
                    }
                case 4:
                    {
                        switch (idioma)
                        {
                            case (int)enuIdioma.Castellano: return cantidad == 1 ? "Trapecio" : "Trapecios";
                            case (int)enuIdioma.Portuges: return cantidad == 1 ? "Trapézio" : "Trapézios";
                            case (int)enuIdioma.Ingles: return cantidad == 1 ? "trapezoid" : "trapezoids";

                        }

                        break;
                    }
                case 5:
                    {
                        switch (idioma)
                        {
                           case (int)enuIdioma.Castellano: return cantidad == 1 ? "Rectangulo" : "Rectangulos";
                           case (int)enuIdioma.Portuges: return cantidad == 1 ? "Rectangulo" : "Rectangulos";
                            case (int)enuIdioma.Ingles: return cantidad == 1 ? "rectangle" : "rectangles";

                        }

                        break;
                    }
            }


            return Empty;
        }
        public static string ExisteAlguno(bool existe, int idioma)
        {
            if (!existe)
            {
                switch (idioma)
                {
                    case (int)enuIdioma.Castellano: return "<h1>Lista vacía de formas!</h1>";
                    case (int)enuIdioma.Ingles: return "<h1>Empty list of shapes!</h1>";
                    case (int)enuIdioma.Portuges: return "<h1>Lista vazia de formas!</h1>";
                
                }
            }
            else
            {
                switch (idioma)
                {
                    case (int)enuIdioma.Castellano: return "<h1>Reporte de Formas</h1>";
                    case (int)enuIdioma.Ingles: return "<h1>Shapes report</h1>";
                    case (int)enuIdioma.Portuges: return "<h1>Relatório de formas</h1>";

                }

            }

             return "idioma desconocido";
        }
    }

        
    
}
