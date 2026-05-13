# EF Core Notes

## Important

1. Must update System.Security.Cryptography.Xml in nugget package manager

2. Installing these will create version mismatch issue

```powershell
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools
```

To install them make their version same:

Fix:

```powershell
Uninstall-Package Microsoft.EntityFrameworkCore.SqlServer
Uninstall-Package Microsoft.EntityFrameworkCore.Tools
```

Then:

```powershell
Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 10.0.0
Install-Package Microsoft.EntityFrameworkCore.Tools -Version 10.0.0
```
