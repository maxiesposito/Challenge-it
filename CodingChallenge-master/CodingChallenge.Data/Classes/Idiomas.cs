using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    class Idiomas 
    {
        public string Formas { get; set ; }
        public string Perimetro { get; set; }
        public string ListaVacia { get; set;  }
        public string HeaderReporte { get; set; }
        public string Circulo { get; set; }
        public string Cuadrado { get; set; }
        public string Triangulo { get; set; }
        public string Trapecio { get; set; }
        public string Rectangulo { get; set; }
        public Idiomas _idi;

        //Constructor por defecto
        public Idiomas() { }
       
        //Constructor parametrizable
        public Idiomas(int idioma, bool singular)
        {
            ;
            if (idioma == 1)
            {
                _idi = new Castellano(singular);
            }
            else if (idioma == 2)
            {
                _idi = new Ingles(singular);

            }
            else if (idioma == 3)
            { _idi = new Portugues(singular); }
            else { }
        }
       
        //Idiomas
        public class Castellano : Idiomas
        {
            public Castellano(bool singular) 
            {
                if (!singular)
                {
                    Circulo = "Círculo";
                    Cuadrado = "Cuadrado";
                    Triangulo = "Triángulo";
                    Trapecio = "Trapecio";
                    Rectangulo = "Rectangulo";
                }
                else {
                    Circulo = "Círculos";
                    Cuadrado = "Cuadrados";
                    Triangulo = "Triángulos";
                    Trapecio = "Trapecios";
                    Rectangulo = "Rectangulos";
                }
                Formas = "Formas";
                Perimetro = "Perimetro ";
                ListaVacia= "<h1>Lista vacía de formas!</h1>"; 
                HeaderReporte="<h1>Reporte de Formas</h1>";
                
            }

        }
        public class Ingles : Idiomas
    {
            public Ingles(bool singular) 
            {
                if (!singular)
                {
                    Cuadrado= "Square";
                    Circulo = "Circle";
                    Triangulo = "Triangle";
                    Trapecio = "trapezoid";
                    Rectangulo = "rectangle";
                }
                else {
                    Cuadrado = "Squares";
                    Circulo = "Circles";
                    Triangulo = "Triangles";
                    Trapecio = "trapezoids";
                    Rectangulo = "rectangles";
                }
                Formas = "Shapes";
                Perimetro = "Perimeter ";
                ListaVacia = "<h1>Empty list of shapes!</h1>";
                HeaderReporte = "<h1>Shapes report</h1>";
              
            }
        }
        public class Portugues : Idiomas
        {
            public Portugues(bool singular)
            {
                if (!singular)
                {
                    Cuadrado = "quadrado";
                    Circulo = "Círculo";
                    Triangulo = "Triángulo";
                    Trapecio = "Trapézio";
                    Rectangulo = "Rectangulo";
                }
                else {
                    Cuadrado = "quadrados";
                    Circulo = "Círculos";
                    Triangulo = "Triángulos";
                    Trapecio = "Trapézios";
                    Rectangulo = "Rectangulos";
                }
                Formas = "Formas";
                Perimetro = "Perimetro ";
                ListaVacia = "<h1>Lista vacía de formas!</h1>";
                HeaderReporte = "<h1>Relatório de formas</h1>";
              
            }

        }

    }

       
      
    
}

