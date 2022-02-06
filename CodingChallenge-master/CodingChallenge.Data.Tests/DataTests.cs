using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using CodingChallenge.Data.Classes;
using NUnit.Framework;

namespace CodingChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), 1));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), 2));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<FormaGeometrica> {new FormaGeometrica((int)FormaGeometrica.enuFormas.Cuadrado, 5)};

            var resumen = FormaGeometrica.Imprimir(cuadrados, (int)Classes.enuIdioma.Castellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 Formas Perimetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<FormaGeometrica>
            {
                new FormaGeometrica((int)FormaGeometrica.enuFormas.Cuadrado, 5),
                new FormaGeometrica((int)FormaGeometrica.enuFormas.Cuadrado, 1),
                new FormaGeometrica((int)FormaGeometrica.enuFormas.Cuadrado, 3)
            };

            var resumen = FormaGeometrica.Imprimir(cuadrados, (int)Classes.enuIdioma.Ingles);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 Shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica((int)FormaGeometrica.enuFormas.Cuadrado, 5),
                new FormaGeometrica((int)FormaGeometrica.enuFormas.Circulo, 3),
                new FormaGeometrica((int)FormaGeometrica.enuFormas.TrianguloEquilatero, 4),
                new FormaGeometrica((int)FormaGeometrica.enuFormas.Cuadrado, 2),
                new FormaGeometrica((int)FormaGeometrica.enuFormas.TrianguloEquilatero, 9),
                new FormaGeometrica((int)FormaGeometrica.enuFormas.Circulo, 2.75m),
                new FormaGeometrica((int)FormaGeometrica.enuFormas.TrianguloEquilatero, 4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, (int)Classes.enuIdioma.Ingles);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 Shapes Perimeter 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica((int)FormaGeometrica.enuFormas.Cuadrado, 5),
                new FormaGeometrica((int)FormaGeometrica.enuFormas.Circulo, 3),
                new FormaGeometrica((int)FormaGeometrica.enuFormas.TrianguloEquilatero, 4),
                new FormaGeometrica((int)FormaGeometrica.enuFormas.Cuadrado, 2),
                new FormaGeometrica((int)FormaGeometrica.enuFormas.TrianguloEquilatero, 9),
                new FormaGeometrica((int)FormaGeometrica.enuFormas.Circulo, 2.75m),
                new FormaGeometrica((int)FormaGeometrica.enuFormas.TrianguloEquilatero, 4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, (int)Classes.enuIdioma.Castellano);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 Formas Perimetro 97,66 Area 91,65",
                resumen);
        }
        [TestCase]
        public void TestResumenListaConVariosTipos() //SE AGREGARON EL TRAPECIO , EL RECTANGULO Y EL IDIOMA NUEVO.
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica((int)FormaGeometrica.enuFormas.Cuadrado, 5),
                new FormaGeometrica((int)FormaGeometrica.enuFormas.Circulo, 3),
                new FormaGeometrica((int)FormaGeometrica.enuFormas.TrianguloEquilatero, 4),
                new FormaGeometrica((int)FormaGeometrica.enuFormas.Cuadrado, 2),
                new FormaGeometrica((int)FormaGeometrica.enuFormas.TrianguloEquilatero, 9),
                new FormaGeometrica((int)FormaGeometrica.enuFormas.Circulo, 2.75m),
                new FormaGeometrica((int)FormaGeometrica.enuFormas.TrianguloEquilatero, 4.2m),
                new FormaGeometrica((int)FormaGeometrica.enuFormas.Trapecio, 4 , 4.2m ),
                new FormaGeometrica((int)FormaGeometrica.enuFormas.Rectangulo, 2 , 4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, (int)Classes.enuIdioma.Portuges);

            Assert.AreEqual(
                "<h1>Relatório de formas</h1>2 quadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>1 Trapézio | Area 16,8 | Perimetro 16,4 <br/>1 Rectangulo | Area 8,4 | Perimetro 12,4 <br/>TOTAL:<br/>9 Formas Perimetro126,46 Area 116,85",
                resumen);
        }
    }
}
