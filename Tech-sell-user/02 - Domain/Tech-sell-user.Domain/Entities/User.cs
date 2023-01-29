using Tech_sell_user.Domain.Entities.Base;

namespace Tech_sell_user.Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; set; }
        
        public string Email { get; set; }
        
        public bool EmailConfirmed { get; set; }
        
        public string Password { get; set; }
        
        public string CPF { get; set; }
        
        public string? Address { get; set; }
        
        public string? City { get; set; }
        
        public string? State { get; set; }
        
        public string? Telephone { get; set; }
        
        public string Salt { get; set; }
    }
}