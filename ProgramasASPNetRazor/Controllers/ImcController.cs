using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ProgramasASPNetRazor.Models;

namespace ProgramasASPNetRazor.Controllers
{
    public class ImcController : Controller
    {
        private static List<ImcModel> ListaImc = new List<ImcModel>
        {
            new ImcModel {
                Nombre = "Emmanuel Ortiz",
                Peso = 88,
                Altura = 1.90,
                Imc = 88 / (1.90 * 1.90),
                Clasificacion = "Peso Normal",
                Imagen = "/img/peso_normal.png",
                Recomendacion = "Sigue manteniendo un estilo de vida saludable, con una dieta equilibrada y ejercicio regular."
            },
            new ImcModel {
                Nombre = "Maria Lopez",
                Peso = 92,
                Altura = 1.70,
                Imc = 92 / (1.70 * 1.70),
                Clasificacion = "Obesidad Grado II",
                Imagen = "/img/obesidad_grado_dos.png",
                Recomendacion = "Es crucial que consultes con un profesional de la salud para evaluar tu situación y recibir recomendaciones personalizadas. Podría ser necesario realizar cambios significativos en tu dieta y aumentar tu actividad física, así como considerar otras opciones de tratamiento, como medicamentos o cirugía, para alcanzar un peso saludable."
            }
        };

        [HttpGet]
        public IActionResult Index()
        {
            return View(ListaImc);
        }

        [HttpGet]
        public IActionResult Create()
        { 
            return View();
        }

        [HttpPost]
        public IActionResult Calcular(ImcModel imcModel)
        {

            //Calculamos el IMC
            imcModel.Imc = imcModel.Peso / (imcModel.Altura * imcModel.Altura);

            //Evaluar los datos y regresar una clasificacion acompañada de una imagen de recomendacion
            if (imcModel.Imc < 18) 
            {
                imcModel.Clasificacion = "Peso Bajo";
                imcModel.Imagen = "/img/peso_bajo.png";
                imcModel.Recomendacion = "Es importante que consultes con un profesional de la salud para evaluar tu situación y recibir recomendaciones personalizadas. Podría ser necesario aumentar tu ingesta calórica y asegurarte de tener una dieta equilibrada.";
            }
            else if (imcModel.Imc >= 18 && imcModel.Imc <=25)
            {
                imcModel.Clasificacion = "Peso Normal";
                imcModel.Imagen = "/img/peso_normal.png";
                imcModel.Recomendacion = "Sigue manteniendo un estilo de vida saludable, con una dieta equilibrada y ejercicio regular.";
            }
            else if (imcModel.Imc >= 25 && imcModel.Imc <= 27)
            {
                imcModel.Clasificacion = "Sobre Peso";
                imcModel.Imagen = "/img/sobre_peso.png";
                imcModel.Recomendacion = "Es recomendable que consultes con un profesional de la salud para evaluar tu situación y recibir recomendaciones personalizadas. Podría ser necesario realizar cambios en tu dieta y aumentar tu actividad física para alcanzar un peso saludable.";
            }
            else if (imcModel.Imc >= 27 && imcModel.Imc <= 30)
            {
                imcModel.Clasificacion = "Obesidad Grado I";
                imcModel.Imagen = "/img/obesidad_grado_uno.png";
                imcModel.Recomendacion = "Es importante que consultes con un profesional de la salud para evaluar tu situación y recibir recomendaciones personalizadas. Podría ser necesario realizar cambios significativos en tu dieta y aumentar tu actividad física, así como considerar otras opciones de tratamiento para alcanzar un peso saludable.";
            }
            else if (imcModel.Imc >= 30 && imcModel.Imc <= 40)
            {
                imcModel.Clasificacion = "Obesidad Grado II";
                imcModel.Imagen = "/img/obesidad_grado_dos.png";
                imcModel.Recomendacion = "Es crucial que consultes con un profesional de la salud para evaluar tu situación y recibir recomendaciones personalizadas. Podría ser necesario realizar cambios significativos en tu dieta y aumentar tu actividad física, así como considerar otras opciones de tratamiento, como medicamentos o cirugía, para alcanzar un peso saludable.";
            }
            else if (imcModel.Imc >= 40)
            {
                imcModel.Clasificacion = "Obesidad Grado III";
                imcModel.Imagen = "/img/obesidad_grado_tres.png";
                imcModel.Recomendacion = "Es fundamental que consultes con un profesional de la salud para evaluar tu situación y recibir recomendaciones personalizadas. Podría ser necesario realizar cambios significativos en tu dieta y aumentar tu actividad física, así como considerar otras opciones de tratamiento, como medicamentos o cirugía, para alcanzar un peso saludable.";
            }
            else
            {
                imcModel.Clasificacion = "Datos Incorrectos";
                imcModel.Imagen = "/img/datos_incorrectos.png";
            }

            //Agregamos el nuevo registro a la lista
            ListaImc.Add(imcModel);

            return Redirect("Index");
        }
    }
}