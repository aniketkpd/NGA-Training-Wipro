namespace OnlineBankingFiltersApp.Services;

public class RoleService : IRoleService
{
    public bool IsAdmin()
    {
        return true;
    }
}