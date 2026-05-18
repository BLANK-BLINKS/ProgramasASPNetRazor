using Microsoft.AspNetCore.Mvc;
using ProgramasASPNetRazor.Models;
using System.Collections.Generic;

namespace ProgramasASPNetRazor.Controllers
{
    public class CesarController : Controller
    {
        // Declaramos el alfabeto
        private static readonly string _alfabeto = "ABCDEFGHIJKLMNOPQRSTUVXYZ";

        // Volvemos el método de cálculo estático para poder usarlo al inicializar la lista
        private static string AplicarCifradoCesar(string mensaje, int n, bool esCodificacion)
        {
            string resultado = "";
            string mensajeMayusculas = mensaje.ToUpper();

            foreach (char letra in mensajeMayusculas)
            {
                int posicionOriginal = _alfabeto.IndexOf(letra);

                if (posicionOriginal != -1)
                {
                    int nuevaPosicion;
                    if (esCodificacion)
                    {
                        nuevaPosicion = (posicionOriginal + n) % _alfabeto.Length;
                    }
                    else
                    {
                        nuevaPosicion = (posicionOriginal - (n % _alfabeto.Length) + _alfabeto.Length) % _alfabeto.Length;
                    }
                    resultado += _alfabeto[nuevaPosicion];
                }
                else
                {
                    resultado += letra;
                }
            }
            return resultado;
        }

        // Inicializamos la lista
        private static List<CesarModel> ListaCesar = new List<CesarModel>
        {
            new CesarModel
            {
                Mensaje = "ALEA IACTA EST",
                Desplazamiento = 3,
                Accion = "Codificar",
                Resultado = AplicarCifradoCesar("ALEA IACTA EST", 3, true)
            },
            new CesarModel
            {
                Mensaje = "DOHD LDFXD HVX",
                Desplazamiento = 3,
                Accion = "Decodificar",
                Resultado = AplicarCifradoCesar("DOHD LDFXD HVX", 3, false)
            }
        };

        [HttpGet]
        public IActionResult Index()
        {
            //Pasamos la lista a la vista
            return View(ListaCesar);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CesarModel { Accion = "Codificar" });
        }

        [HttpPost]
        public IActionResult Procesar(CesarModel cesarModel)
        {
            // Calculamos el resultado
            cesarModel.Resultado = AplicarCifradoCesar(cesarModel.Mensaje, cesarModel.Desplazamiento, cesarModel.Accion == "Codificar");

            // Agregamos el nuevo registro a la lista
            ListaCesar.Add(cesarModel);

            // Redirigimos a la tabla (Index)
            return RedirectToAction("Index");
        }
    }
}