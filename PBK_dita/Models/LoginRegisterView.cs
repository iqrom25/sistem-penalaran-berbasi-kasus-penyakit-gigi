namespace PBK_dita.Models
{
    public record LoginRegisterView
    {
        public LoginModel LoginModel { get; set; }
        public User User { get; set; }
    }
}