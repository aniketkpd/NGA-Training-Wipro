namespace SecureRoleMvc.Models;

public class AdminUserViewModel
{
    public required string UserName { get; init; }

    public required string Email { get; init; }

    public required string Roles { get; init; }

    public required string ProtectedUserId { get; init; }
}
