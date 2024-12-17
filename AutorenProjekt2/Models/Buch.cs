using Microsoft.EntityFrameworkCore;

namespace AutorenProjekt2.Models
{
    public class Buch
    {
        public int Id { get; set; }
        public string Buchtitel { get; set; }
        public string Klappentext { get; set; }
        [Precision(10,2 )]                      // Präzision für Preis: 5 Stellen insgesamt , 2 Nachkommastellen ( 3 vor Dezimalpunkt + 2 Nachkommastellen)
        public decimal Preis { get; set; }
        public DateOnly Erscheinungsdatum { get; set; }
        public string ISBN { get; set; }


        // Navigation :  Liste der Rezensionen

        public List<Rezension> Rezensionen { get; set; } = new List<Rezension>();




    }
}
