﻿/*
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

        public const int Cuadrado = 1;
        public const int TrianguloEquilatero = 2;
        public const int Circulo = 3;
        public const int Trapecio = 4;
        public const int Rectangulo = 5;

        #endregion

        #region Idiomas

        public const int Castellano = 1;
        public const int Ingles = 2;
        public const int Portuges = 3;

        #endregion

        private readonly decimal _lado;
        private readonly decimal _alto;


        public int Tipo { get; set; }

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

            if (!formas.Any())
            {
              
                if (idioma == Castellano)
                    sb.Append("<h1>Lista vacía de formas!</h1>");
                else if (idioma == Ingles)
                    sb.Append("<h1>Empty list of shapes!</h1>");
                else
                    sb.Append("<h1>Lista vazia de formas!</h1>");
                

            }
            else
            {
                // Hay por lo menos una forma
                // HEADER
                if (idioma == Castellano)
                    sb.Append("<h1>Reporte de Formas</h1>");
                else if (idioma == Ingles)
                    sb.Append("<h1>Shapes report</h1>");
                else
                    sb.Append("<h1>Relatório de formas</h1>");

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

                for (var i = 0; i < formas.Count; i++)
                {
                    if (formas[i].Tipo == Cuadrado)
                    {
                        numeroCuadrados++;
                        areaCuadrados += formas[i].CalcularArea();
                        perimetroCuadrados += formas[i].CalcularPerimetro();
                    }
                    if (formas[i].Tipo == Circulo)
                    {
                        numeroCirculos++;
                        areaCirculos += formas[i].CalcularArea();
                        perimetroCirculos += formas[i].CalcularPerimetro();
                    }
                    if (formas[i].Tipo == TrianguloEquilatero)
                    {
                        numeroTriangulos++;
                        areaTriangulos += formas[i].CalcularArea();
                        perimetroTriangulos += formas[i].CalcularPerimetro();
                    }
                    if (formas[i].Tipo == Trapecio)
                    {
                        numeroTrapecio++;
                        areaTrapecio += formas[i].CalcularArea();
                        perimetroTrapecio += formas[i].CalcularPerimetro();
                    }
                    if (formas[i].Tipo == Rectangulo)
                    {
                        numeroRectangulo++;
                        areaRectangulo += formas[i].CalcularArea();
                        perimetroRectangulo += formas[i].CalcularPerimetro();
                    }
                }
                
                sb.Append(ObtenerLinea(numeroCuadrados, areaCuadrados, perimetroCuadrados, Cuadrado, idioma));
                sb.Append(ObtenerLinea(numeroCirculos, areaCirculos, perimetroCirculos, Circulo, idioma));
                sb.Append(ObtenerLinea(numeroTriangulos, areaTriangulos, perimetroTriangulos, TrianguloEquilatero, idioma));
                sb.Append(ObtenerLinea(numeroTrapecio, areaTrapecio, perimetroTrapecio, Trapecio, idioma));
                sb.Append(ObtenerLinea(numeroRectangulo, areaRectangulo, perimetroRectangulo, Rectangulo, idioma));


                // FOOTER
                sb.Append("TOTAL:<br/>");
                //sb.Append(numeroCuadrados + numeroCirculos + numeroTriangulos + " " + (idioma == Castellano ? "formas" : "shapes") + " ");
                sb.Append(numeroCuadrados + numeroCirculos + numeroTriangulos +numeroTrapecio + numeroRectangulo + " " + Classes.idioma.traduccionFormas(idioma) + " ");
                sb.Append(Classes.idioma.traduccionPerimetro(idioma) + (perimetroCuadrados + perimetroTriangulos + perimetroCirculos + perimetroTrapecio + perimetroRectangulo).ToString("#.##") + " ");
                sb.Append("Area " + (areaCuadrados + areaCirculos + areaTriangulos +areaTrapecio + areaRectangulo).ToString("#.##"));
            }

            return sb.ToString();
        }

        private static string traduccionFormas(int idioma )
        {
            switch (idioma)
            {
                case Castellano: return "Formas";
                case Ingles: return "Shapes";
                case Portuges: return "Formas";
                default: return "idioma desconocido";
            }
        }
        
        private static string traduccionPerimetro(int idioma)
        {
            switch (idioma)
            {
                case Castellano: return "Perimetro ";
                case Ingles: return "Perimeter ";
                case Portuges: return "Perimetro";
                default: return "idioma desconocido";
            }
        }

        private static string ObtenerLinea(int cantidad, decimal area, decimal perimetro, int tipo, int idioma)
        {
            if (cantidad > 0)
            {
                if (idioma == Castellano)
                    return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Area {area:#.##} | Perimetro {perimetro:#.##} <br/>";
                else if (idioma==Ingles)
                return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Area {area:#.##} | Perimeter {perimetro:#.##} <br/>";
                else
                    return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Area {area:#.##} | Perimetro {perimetro:#.##} <br/>";
            }

            return string.Empty;
        }
        
        private static string TraducirForma(int tipo, int cantidad, int idioma)
        {
            switch (tipo)
            {
                case Cuadrado:
                {
                    switch (idioma)
                    {
                        case Castellano: return cantidad == 1 ? "Cuadrado" : "Cuadrados";
                        case Portuges: return cantidad == 1 ? "quadrado" : "quadrados";
                        case Ingles: return cantidad == 1 ? "Square" : "Squares";
                    }
                }
                break;
                case Circulo:
                {
                    switch (idioma)
                    {
                        case Castellano: return cantidad == 1 ? "Círculo" : "Círculos";
                        case Portuges: return cantidad == 1 ? "Círculo" : "Círculos";
                        case Ingles: return cantidad == 1 ? "Circle" : "Circles";
                    }
                } 
                    break;
                case TrianguloEquilatero:
                {
                    switch (idioma)
                    {
                        case Castellano: return cantidad == 1 ? "Triángulo" : "Triángulos";
                        case Portuges: return cantidad == 1 ? "Triángulo" : "Triángulos";
                        case Ingles: return cantidad == 1 ? "Triangle" : "Triangles";

                    }

                    break;
                }
                case Trapecio:
                {
                    switch (idioma)
                    {
                        case Castellano: return cantidad == 1 ? "Trapecio" : "Trapecios";
                        case Portuges: return cantidad == 1 ? "Trapézio" : "Trapézios";
                        case Ingles: return cantidad == 1 ? "trapezoid" : "trapezoids";

                    }

                    break;
                }
                case Rectangulo:
                {
                    switch (idioma)
                    {
                        case Castellano: return cantidad == 1 ? "Rectangulo" : "Rectangulos";
                        case Portuges: return cantidad == 1 ? "Rectangulo" : "Rectangulos";
                        case Ingles: return cantidad == 1 ? "rectangle" : "rectangles";

                    }

                    break;
                }
}
            

            return string.Empty;
        }
        
        public decimal CalcularArea()
        {
            switch (Tipo)
            {
                case Cuadrado: return _lado * _lado;
                case Circulo: return (decimal)Math.PI * (_lado / 2) * (_lado / 2);
                case TrianguloEquilatero: return ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
                case Trapecio: return (_alto * ((_lado + _lado) / 2));
                case Rectangulo: return _lado * _alto;
                default:
                    throw new ArgumentOutOfRangeException(@"Forma desconocida");
            }
        }
        
        public decimal CalcularPerimetro()
        {
            switch (Tipo)
            {
                case Cuadrado: return _lado * 4;
                case Circulo: return (decimal)Math.PI * _lado;
                case TrianguloEquilatero: return _lado * 3;
                case Trapecio: return (_alto + _alto + _lado + _lado);
                case Rectangulo: return (_lado + _alto) * 2;
                default:
                    throw new ArgumentOutOfRangeException(@"Forma desconocida");
            }
        }
    }
}
