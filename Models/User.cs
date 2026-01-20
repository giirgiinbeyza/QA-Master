namespace DermaLogic.Models
{
    public class User
    {
        public int Id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string Role { get; set; }
        public int Durum { get; set; }
    }
}