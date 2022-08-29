namespace Aplicacion_web.Models.DataModels
{
    public class UserTokens
    {
        public Guid Id { get; set; }
        public string Token { get; set; }
        public string UserName { get; set; }
        public TimeSpan Validity { get; set; }
        public string RefreshToken { get; set; }
        public string EmailID { get; set; }
        public Guid GuiID { get; set; }
        public DateTime ExpiredTime { get; set; }

        
    }

}
