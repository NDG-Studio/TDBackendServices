namespace IdentityApi.Entities
{
    public class UserToken
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Token { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
