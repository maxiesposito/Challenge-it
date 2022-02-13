/*
 * Refactorear la clase para respetar principios de programación orientada a objetos. Qué pasa si debemos soportar un nuevo idioma para los reportes, o
 * agregar más formas geométricas?
 *
 * Se puede hacer cualquier cambio que se crea necesario tanto en el código como en los tests. La única condición es que los tests pasen OK.
 *
 * TODO: Implementar Trapecio/Rectangulo, agregar otro idioma a reporting.
 * */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CodingChallenge.Data.Classes
{
    public class FormaGeometrica
    {
        #region Formas
        public enum enuFormas
        {
            Cuadrado = 1,
            TrianguloEquilatero = 3,
            Circulo = 2,
            Trapecio = 4,
            Rectangulo = 5
        }
        public enum enuIdioma
        {
            Castellano = 1,
            Ingles = 2,
            Portuges = 3
        }
        #endregion


        private readonly decimal _lado;
        private readonly decimal _alto;


        public int Tipo { get; set; }

        public FormaGeometrica()
        {

        }
        public FormaGeometrica(int tipo, decimal ancho)
        {
            Tipo = tipo;
            _lado = ancho;
        }
        public FormaGeometrica(int tipo, decimal _base, decimal alto)
        {
            Tipo = tipo;
            _lado = _base;
            _alto = alto;
        }

        public static string Imprimir(List<FormaGeometrica> formas, int idioma)
        {
            var sb = new StringBuilder();
            
            Idiomas Idioma = new Idiomas(idioma, (formas.Count > 1));
            if (!formas.Any())
            {
                sb.Append(Idioma._idi.ListaVacia);
            }
            else 
            {

                sb.Append(Idioma._idi.HeaderReporte);

                IEnumerable<FormaGeometrica> Cuadrados = from elemento in formas where elemento.Tipo == 1 select elemento;
                IEnumerable<FormaGeometrica> Circulos = from elemento in formas where elemento.Tipo == 2 select elemento;
                IEnumerable<FormaGeometrica> TrianguloEquilatero = from elemento in formas where elemento.Tipo == 3 select elemento;
                IEnumerable<FormaGeometrica> Trapecio = from elemento in formas where elemento.Tipo == 4  select elemento;
                IEnumerable<FormaGeometrica> Rectangulo = from elemento in formas where elemento.Tipo == 5 select elemento;
                
                Formas.Cuadrado oQuadrado= new Formas.Cuadrado();
                Formas.Circulo oCirculo = new Formas.Circulo();
                Formas.Trapecio oTrapecio = new Formas.Trapecio();
                Formas.Rectangulo oRectangulo = new Formas.Rectangulo();
                Formas.TrianguloEquilatero oTrianguloEquilatero = new Formas.TrianguloEquilatero();


                foreach (FormaGeometrica formageome in Cuadrados)
                {
                    
                    oQuadrado.Numeros++;
                    oQuadrado.perimetro = formageome._lado;
                    oQuadrado.Area = formageome._lado;
                    oQuadrado.Tipo = formageome.Tipo;
                  
                }
                foreach (FormaGeometrica formageome in Circulos)
                {
                    oCirculo.Numeros++;
                    oCirculo.Perimetro = formageome._lado;
                    oCirculo.Area = formageome._lado;
                    oCirculo.Tipo = formageome.Tipo;
                }
                foreach (FormaGeometrica formageome in TrianguloEquilatero)
                {
                   oTrianguloEquilatero.Numeros++;
                   oTrianguloEquilatero.Perimetro = formageome._lado;
                   oTrianguloEquilatero.Area = formageome._lado;
                   oTrianguloEquilatero.Tipo = formageome.Tipo;
                }
                foreach (FormaGeometrica formageome in Trapecio)
                {
                    oTrapecio.Numeros++;
                    oTrapecio.Alto = formageome._alto;
                    oTrapecio.Perimetro = formageome._lado;
                    oTrapecio.Area = formageome._lado;
                    oTrapecio.Tipo = formageome.Tipo;
                }
                foreach (FormaGeometrica formageome in Rectangulo)
                {
                   oRectangulo.Numeros++;
                   oRectangulo.Alto = formageome._alto;
                   oRectangulo.Perimetro = formageome._lado;
                   oRectangulo.Area = formageome._lado;
                   oRectangulo.Tipo = formageome.Tipo;
                }

                if (oQuadrado.Numeros != 0) sb.Append(oQuadrado.Numeros + " " + Idioma._idi.Cuadrado + " | Area " + oQuadrado.Area.ToString("#.##") + " | " + Idioma._idi.Perimetro + oQuadrado.perimetro.ToString("#.##") + " <br/>"); 
                if (oCirculo.Numeros != 0)sb.Append(oCirculo.Numeros + " " + Idioma._idi.Circulo + " | Area " + oCirculo.Area.ToString("#.##") + " | " + Idioma._idi.Perimetro + oCirculo.Perimetro.ToString("#.##") + " <br/>");
                if (oTrianguloEquilatero.Numeros != 0) sb.Append(oTrianguloEquilatero.Numeros + " " + Idioma._idi.Triangulo + " | Area " + oTrianguloEquilatero.Area.ToString("#.##") + " | " + Idioma._idi.Perimetro + oTrianguloEquilatero.Perimetro.ToString("#.##") + " <br/>");
                if (oTrapecio.Numeros != 0) sb.Append(oTrapecio.Numeros + " " + Idioma._idi.Trapecio + " | Area " + oTrapecio.Area.ToString("#.##") + " | " + Idioma._idi.Perimetro + oTrapecio.Perimetro.ToString("#.##") + " <br/>");
                if (oRectangulo.Numeros != 0) sb.Append(oRectangulo.Numeros + " " + Idioma._idi.Rectangulo + " | Area " + oRectangulo.Area.ToString("#.##") + " | " + Idioma._idi.Perimetro + oRectangulo.Perimetro.ToString("#.##") + " <br/>");
                

                // FOOTER
                sb.Append("TOTAL:<br/>");
                sb.Append(oQuadrado.Numeros + oCirculo.Numeros + oTrianguloEquilatero.Numeros + oTrapecio.Numeros + oRectangulo.Numeros + " " + Idioma._idi.Formas + " ");
                sb.Append(Idioma._idi.Perimetro + (oQuadrado.perimetro + oTrianguloEquilatero.Perimetro + oCirculo.Perimetro + oTrapecio.Perimetro + oRectangulo.Perimetro).ToString("#.##") + " ");
                sb.Append("Area " + (oQuadrado.Area + oCirculo.Area + oTrianguloEquilatero.Area + oTrapecio.Area + oRectangulo.Area).ToString("#.##"));
            }

            return sb.ToString();
        }

    }
}
