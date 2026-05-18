namespace ProgramasASPNetRazor.Models
{
    public class ArreglosModel
    {
        public int Id { get; set; }
        public List<int> NumerosOriginales { get; set; } = new List<int>();
        public List<int> NumerosOrdenados { get;set; } = new List<int>();
        public int Suma { get; set; }
        public double Promedio { get; set; }
        public List<int> Moda { get; set; } = new List<int>();
        public double Mediana { get; set; }
        public string PasosMediana { get; set; }
    }
}
