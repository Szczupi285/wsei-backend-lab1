namespace WebApi.DTO
{
    public class LoginUserDto
    {
        public string LoginName { get; set; }

        public string Password { get; set; }

        public LoginUserDto(string loginName, string password)
        {
            LoginName = loginName;
            Password = password;
        }
    }
}
