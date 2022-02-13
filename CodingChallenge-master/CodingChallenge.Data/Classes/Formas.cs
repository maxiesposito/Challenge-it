using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    class Formas
    {
        public int Tipo { get; set; }
        //Constructor por defecto
        public Formas() { }

        //Constructor parametrizable
        public class Cuadrado : Formas
        {
            public int Numeros { get; set; }
            private decimal _perimetrosCuadrados { get; set; }
            private decimal _areasCuadrados { get; set; }
            public decimal perimetro
            {
                get
                {
                    return _perimetrosCuadrados;
                }
                set
                {
                    _perimetrosCuadrados += value * 4;
                }
            }
            public decimal Area {
                get
                {
                    return _areasCuadrados;
                }
                set
                {
                    _areasCuadrados += value * value;
                }
            }
            

            //Constructor
            public Cuadrado()
            { }

          
        }
        public class TrianguloEquilatero : Formas
        {
            public int Numeros { get; set; }
            private decimal _areaTriangulos { get; set; }
            private decimal _perimetroTriangulos { get; set; }
            public decimal Perimetro
        {
                get
                {
                    return _perimetroTriangulos;
                }
                set
                {
                    _perimetroTriangulos += value * 3;
                }
            }
            public decimal Area
            {
                get
                {
                    return _areaTriangulos;
                }
                set
                {
                    _areaTriangulos += ((decimal)Math.Sqrt(3) / 4) * value * value; 
                }
            }


            public TrianguloEquilatero() { }

        }
        public class Circulo : Formas
        {
            private decimal _perimetroCirculos { get; set; }
            private decimal _areaCirculos { get; set; }
            public int Numeros { get; set; }

            public decimal Perimetro
            {
                get
                {
                    return _perimetroCirculos;
                }
                set
                {
                    _perimetroCirculos += (decimal)Math.PI * value;
                }
            }
            public decimal Area
            {
                get
                {
                    return _areaCirculos;
                }
                set
                {
                    _areaCirculos += (decimal)Math.PI * (value / 2) * (value / 2);
                }
            }




            public Circulo() { }

        }
        public class Trapecio: Formas
        {
            public decimal Alto { get; set; }
            public int Numeros { get; set; }
            public decimal _areaTrapecio { get; set; }
            public decimal _perimetroTrapecio { get; set; } 
            public decimal Perimetro
            {
                get
                {
                    return _perimetroTrapecio;
                }
                set
                {
                    _perimetroTrapecio += (Alto + Alto + value + value);
                }
            }
            public decimal Area
            {
                get
                {
                    return _areaTrapecio;
                }
                set
                {
                    _areaTrapecio += (Alto * ((value + value) / 2));
                }
            }
            public Trapecio() { }

        }
        public class Rectangulo: Formas
        {
            public decimal Alto { get; set; }
            public int Numeros{ get; set; }
            private decimal _areaRectangulo { get; set; }
            private decimal _perimetroRectangulo { get; set; }

            public decimal Perimetro
            {
                get
                {
                    return _perimetroRectangulo;
                }
                set
                {
                    _perimetroRectangulo += (Alto + value) *2;
                }
            }
            public decimal Area
            {
                get
                {
                    return _areaRectangulo;
                }
                set
                {
                    _areaRectangulo += Alto * value;
                }
            }

            public Rectangulo() { }

        }

    }
}
