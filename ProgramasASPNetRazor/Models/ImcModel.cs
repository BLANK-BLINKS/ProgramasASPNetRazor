namespace ProgramasASPNetRazor.Models
{
    public class ImcModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Peso { get; set; }
        public double Altura { get; set; }
        public double Imc { get; set; }
        public string Clasificacion { get; set; }
        public string Imagen { get; set; }
        public string Recomendacion { get; set; }
    }
}