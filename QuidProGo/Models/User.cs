namespace QuidProGo.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirebaseUserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string State { get; set; }
        public int UserTypeId { get; set; }

    }
}
