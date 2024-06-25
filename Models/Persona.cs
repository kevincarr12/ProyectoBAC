namespace ProyectoBAC.Models
{
    public class Persona
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string HomePhone { get; set; }
        public string CellPhone { get; set; }
        public string BirthYear { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
