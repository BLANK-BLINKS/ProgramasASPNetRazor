using Microsoft.AspNetCore.Mvc;
using ProgramasASPNetRazor.Models;
using System;
using System.Linq;


namespace ProgramasASPNetRazor.Controllers
{
    public class ArreglosController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var arreglosModel = GenerarDatos();
            var listaDeUnElemento = new List<ArreglosModel> { arreglosModel };
            return View(listaDeUnElemento);
        }

        private ArreglosModel GenerarDatos()
        {
            var arreglosModel = new ArreglosModel();
            Random random = new Random();

            //Generamos 20 numero aleatorios entre 0 y 100
            for (int i = 0; i < 20; i++)
            {
                arreglosModel.NumerosOriginales.Add(random.Next(0, 101));
            }

            //Suma y promeddio con LINQ
            arreglosModel.Suma = arreglosModel.NumerosOriginales.Sum();
            arreglosModel.Promedio = arreglosModel.NumerosOriginales.Average();

            //Arreglos ordenados
            arreglosModel.NumerosOrdenados = arreglosModel.NumerosOriginales.OrderBy(n => n).ToList();

            //Mediana en las posiciones de en medio 9 y 10
            int valorCentro1 = arreglosModel.NumerosOrdenados[9];
            int valorCentro2 = arreglosModel.NumerosOrdenados[10];

            arreglosModel.Mediana = (valorCentro1 + valorCentro2) / 2.0;
            arreglosModel.PasosMediana = $"Valores centrales: {valorCentro1} y {valorCentro2} / 2, Mediana: {arreglosModel.Mediana}";

            //Moda con LINQ
            var numerosAgrupados = arreglosModel.NumerosOriginales.GroupBy(n => n);
            int maxFrecuencia = numerosAgrupados.Max(g => g.Count()); //Obtenemos los numeros que tienen la frecuencia maxima

            if (maxFrecuencia > 1)
            {
                //Obtenemos los numeros que tienen la frecuencia maxima
                arreglosModel.Moda = numerosAgrupados.Where(g => g.Count() == maxFrecuencia).Select(g => g.Key).ToList();
            }
            return arreglosModel;
        }
    }
}
