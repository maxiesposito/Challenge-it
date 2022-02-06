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
            FormaGeometrica formasGeometrica = new FormaGeometrica();
            
            if (!formas.Any())
            {
               sb.Append(Classes.idioma.ExisteAlguno(false,idioma));
            }
            else
            {
                var numeroCuadrados = 0;
                var numeroCirculos = 0;
                var numeroTriangulos = 0;
                var numeroTrapecio = 0;
                var numeroRectangulo = 0;

                var areaCuadrados = 0m;
                var areaCirculos = 0m;
                var areaTriangulos = 0m;
                var areaTrapecio = 0m;
                var areaRectangulo = 0m;

                var perimetroCuadrados = 0m;
                var perimetroCirculos = 0m;
                var perimetroTriangulos = 0m;
                var perimetroTrapecio = 0m;
                var perimetroRectangulo = 0m;

                sb.Append(Classes.idioma.ExisteAlguno(true, idioma));


              

                for (var i = 0; i < formas.Count; i++)
                {
                    if (formas[i].Tipo == (int)enuFormas.Cuadrado)
                    {
                        numeroCuadrados++;
                        areaCuadrados += formas[i].CalcularArea();
                        perimetroCuadrados += formas[i].CalcularPerimetro();
                    }
                    if (formas[i].Tipo == (int)enuFormas.Circulo)
                    {
                        numeroCirculos++;
                        areaCirculos += formas[i].CalcularArea();
                        perimetroCirculos += formas[i].CalcularPerimetro();
                    }
                    if (formas[i].Tipo == (int)enuFormas.TrianguloEquilatero)
                    {
                        numeroTriangulos++;
                        areaTriangulos += formas[i].CalcularArea();
                        perimetroTriangulos += formas[i].CalcularPerimetro();
                    }
                    if (formas[i].Tipo == (int)enuFormas.Trapecio)
                    {
                        numeroTrapecio++;
                        areaTrapecio += formas[i].CalcularArea();
                        perimetroTrapecio += formas[i].CalcularPerimetro();
                    }
                    if (formas[i].Tipo == (int)enuFormas.Rectangulo)
                    {
                        numeroRectangulo++;
                        areaRectangulo += formas[i].CalcularArea();
                        perimetroRectangulo += formas[i].CalcularPerimetro();
                    }
                }
                
                sb.Append(ObtenerLinea(numeroCuadrados, areaCuadrados, perimetroCuadrados, (int)enuFormas.Cuadrado, idioma));
                sb.Append(ObtenerLinea(numeroCirculos, areaCirculos, perimetroCirculos, (int)enuFormas.Circulo, idioma));
                sb.Append(ObtenerLinea(numeroTriangulos, areaTriangulos, perimetroTriangulos, (int)enuFormas.TrianguloEquilatero, idioma));
                sb.Append(ObtenerLinea(numeroTrapecio, areaTrapecio, perimetroTrapecio, (int)enuFormas.Trapecio, idioma));
                sb.Append(ObtenerLinea(numeroRectangulo, areaRectangulo, perimetroRectangulo, (int)enuFormas.Rectangulo, idioma));


                // FOOTER
                sb.Append("TOTAL:<br/>");
                sb.Append(numeroCuadrados + numeroCirculos + numeroTriangulos +numeroTrapecio + numeroRectangulo + " " + Classes.idioma.traduccionFormas(idioma) + " ");
                sb.Append(Classes.idioma.traduccionPerimetro(idioma) + (perimetroCuadrados + perimetroTriangulos + perimetroCirculos + perimetroTrapecio + perimetroRectangulo).ToString("#.##") + " ");
                sb.Append("Area " + (areaCuadrados + areaCirculos + areaTriangulos +areaTrapecio + areaRectangulo).ToString("#.##"));
            }

            return sb.ToString();
        }

        private static string ObtenerLinea(int cantidad, decimal area, decimal perimetro, int tipo, int idioma)
        {
            if (cantidad > 0)
            {
                if (idioma == (int)enuIdioma.Castellano)
                    return $"{cantidad} {Classes.idioma.TraducirForma(tipo, cantidad, idioma)} | Area {area:#.##} | Perimetro {perimetro:#.##} <br/>";
                else if (idioma== (int)enuIdioma.Ingles)
                return $"{cantidad} {Classes.idioma.TraducirForma(tipo, cantidad, idioma)} | Area {area:#.##} | Perimeter {perimetro:#.##} <br/>";
                else
                    return $"{cantidad} {Classes.idioma.TraducirForma(tipo, cantidad, idioma)} | Area {area:#.##} | Perimetro {perimetro:#.##} <br/>";
            }

            return string.Empty;
        }


        public decimal CalcularArea()
        {
            switch (Tipo)
            {
                case (int)enuFormas.Cuadrado: return _lado * _lado;
                case (int)enuFormas.Circulo: return (decimal)Math.PI * (_lado / 2) * (_lado / 2);
                case (int)enuFormas.TrianguloEquilatero: return ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
                case (int)enuFormas.Trapecio: return (_alto * ((_lado + _lado) / 2));
                case (int)enuFormas.Rectangulo: return _lado * _alto;
                default:
                    throw new ArgumentOutOfRangeException(@"Forma desconocida");
            }
        }
        
        public decimal CalcularPerimetro()
        {
            switch (Tipo)
            {
                case (int)enuFormas.Cuadrado: return _lado * 4;
                case (int)enuFormas.Circulo: return (decimal)Math.PI * _lado;
                case (int)enuFormas.TrianguloEquilatero: return _lado * 3;
                case (int)enuFormas.Trapecio: return (_alto + _alto + _lado + _lado);
                case (int)enuFormas.Rectangulo: return (_lado + _alto) * 2;
                default:
                    throw new ArgumentOutOfRangeException(@"Forma desconocida");
            }
        }
    }
}
