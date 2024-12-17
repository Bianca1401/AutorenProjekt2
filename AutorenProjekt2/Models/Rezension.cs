namespace AutorenProjekt2.Models
{
    public class Rezension
    {
        public int Id { get; set; }
        public int BuchId { get; set; }
        public string Name { get; set; }
        public string Kommentar { get; set; }
        public int Bewertung { get; set; }

        // Navigation: Verweis auf Bücher
        
        public Buch? Bücher {  get; set; }
    }
}
