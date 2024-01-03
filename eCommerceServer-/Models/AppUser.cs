namespace eCommerceServer_.Models;

public sealed class AppUser
{
    public int Id { get; set; }
    public string Firstname { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
	public string Password { get; set; } = string.Empty;
}
