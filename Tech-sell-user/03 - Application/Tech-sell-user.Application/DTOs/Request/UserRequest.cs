namespace Tech_sell_user.Application.DTOs.Request
{
    public class UserRequest
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string? CPF { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? Telephone { get; set; }
    }
}