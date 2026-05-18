using Microsoft.AspNetCore.Mvc;
using ProgramasASPNetRazor.Models;

namespace ProgramasASPNetRazor.Controllers
{
    public class ExpresionController : Controller
    {
        //Lista para almacenar los resultados de las expresiones
        private static List<ExpresionModel> ListaResultados = new List<ExpresionModel>();

        [HttpGet]
        public IActionResult Index()
        {
            return View(ListaResultados);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new ExpresionModel());
        }

        //Método para procesar la expresión ingresada por el usuario
        [HttpPost]
        public IActionResult Procesar(ExpresionModel expresionModel)
        {
            if (expresionModel.n < 0)
            {
                ModelState.AddModelError("n", "El valor de n debe ser un número entero no negativo.");
                return View("Create", expresionModel);
            }

            double sumatoria = 0;

            //Comenzamos a evaluar la sumatoria desde k=0 hasta n
            for (int k = 0; k <= expresionModel.n; k++)
            {
                //Calculamos la combinacion (n en k)
                double combinacion = CalcularCombinacion(expresionModel.n, k);

                //Calculamos (ax)^(n-k)
                double termino1 = Math.Pow(expresionModel.a * expresionModel.x, expresionModel.n - k);

                //Calculamos (by)^(k)
                double termino2 = Math.Pow(expresionModel.b * expresionModel.y, k);

                //Multiplicamos todo y lo sumamos al totaL
                sumatoria += combinacion * termino1 * termino2;
            }

            expresionModel.Resultado = sumatoria;

            double igualdad = (expresionModel.a * expresionModel.x)+(expresionModel.b * expresionModel.y);
            double resultadoIgualdad = igualdad * igualdad;

            expresionModel.ExpresionArmada = $"[ ({expresionModel.a})({expresionModel.x}) + ({expresionModel.b})({expresionModel.y}) ]^{expresionModel.n} = {resultadoIgualdad}";
            ListaResultados.Add(expresionModel);

            return RedirectToAction("Index");
        }

        //Hacemos la formula de la factorial
        public double Factorial(int numero)
        {
            if (numero == 0 || numero == 1) return 1;

            double resultado = 1;
            for (int i = 2; i <= numero; i++)
            {
                resultado *= i;
            }
            return resultado;
        }
        //Combinamos la factorial con la formula de la combinatoria (n | k)
        private double CalcularCombinacion(int n, int k)
        {
            return Factorial(n) / (Factorial(k) * Factorial(n - k));
        }

    }
}
