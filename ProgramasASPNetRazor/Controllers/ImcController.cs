using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ProgramasASPNetRazor.Models;

namespace ProgramasASPNetRazor.Controllers
{
    public class ImcController : Controller
    {
        private static List<ImcModel> ListaImc = new List<ImcModel>
        {
            // 1. PESO BAJO (IMC < 18) -> IMC aproximado: 16.95
            new ImcModel {
                Nombre = "Ana Silva",
                Peso = 49,
                Altura = 1.70,
                Imc = 49 / (1.70 * 1.70),
                Clasificacion = "Peso Bajo",
                Imagen = "/img/peso_bajo.png",
                Recomendacion = "Es importante que consultes con un profesional de la salud para evaluar tu situación y recibir recomendaciones personalizadas. Podría ser necesario aumentar tu ingesta calórica y asegurarte de tener una dieta equilibrada."
            },

            // 2. PESO NORMAL (IMC entre 18 y 25) -> IMC aproximado: 22.20
            new ImcModel {
                Nombre = "Emmanuel Ortiz",
                Peso = 68,
                Altura = 1.75,
                Imc = 68 / (1.75 * 1.75),
                Clasificacion = "Peso Normal",
                Imagen = "/img/peso_normal.png",
                Recomendacion = "Sigue manteniendo un estilo de vida saludable, con una dieta equilibrada y ejercicio regular."
            },

            // 3. SOBRE PESO (IMC entre 25 y 27) -> IMC aproximado: 26.17
            new ImcModel {
                Nombre = "Carlos Mendoza",
                Peso = 67,
                Altura = 1.60,
                Imc = 67 / (1.60 * 1.60),
                Clasificacion = "Sobre Peso",
                Imagen = "/img/sobre_peso.png",
                Recomendacion = "Es recomendable que consultes con un profesional de la salud para evaluar tu situación y recibir recomendaciones personalizadas. Podría ser necesario realizar cambios en tu dieta y aumentar tu actividad física para alcanzar un peso saludable."
            },

            // 4. OBESIDAD GRADO I (IMC entre 27 y 30) -> IMC aproximado: 28.70
            new ImcModel {
                Nombre = "Luis Fernandez",
                Peso = 93,
                Altura = 1.80,
                Imc = 93 / (1.80 * 1.80),
                Clasificacion = "Obesidad Grado I",
                Imagen = "/img/obesidad_grado_uno.png",
                Recomendacion = "Es importante que consultes con un profesional de la salud para evaluar tu situación y recibir recomendaciones personalizadas. Podría ser necesario realizar cambios significativos en tu dieta y aumentar tu actividad física, así como considerar otras opciones de tratamiento para alcanzar un peso saludable."
            },

            // 5. OBESIDAD GRADO II (IMC entre 30 y 40) -> IMC aproximado: 35.29
            new ImcModel {
                Nombre = "Maria Lopez",
                Peso = 102,
                Altura = 1.70,
                Imc = 102 / (1.70 * 1.70),
                Clasificacion = "Obesidad Grado II",
                Imagen = "/img/obesidad_grado_dos.png",
                Recomendacion = "Es crucial que consultes con un profesional de la salud para evaluar tu situación y recibir recomendaciones personalizadas. Podría ser necesario realizar cambios significativos en tu dieta y aumentar tu actividad física, así como considerar otras opciones de tratamiento, como medicamentos o cirugía, para alcanzar un peso saludable."
            },

            // 6. OBESIDAD GRADO III (IMC mayor a 40) -> IMC aproximado: 45.91
            new ImcModel {
                Nombre = "Roberto Gomez",
                Peso = 125,
                Altura = 1.65,
                Imc = 125 / (1.65 * 1.65),
                Clasificacion = "Obesidad Grado III",
                Imagen = "/img/obesidad_grado_tres.png",
                Recomendacion = "Es fundamental que consultes con un profesional de la salud para evaluar tu situación y recibir recomendaciones personalizadas. Podría ser necesario realizar cambios significativos en tu dieta y aumentar tu actividad física, así como considerar otras opciones de tratamiento, como medicamentos o cirugía, para alcanzar un peso saludable."
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