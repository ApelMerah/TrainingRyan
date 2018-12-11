$connectionString = "Data Source=ACCELISTG3;Initial Catalog=Calvin;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
$provider = "Microsoft.EntityFrameworkCore.SqlServer";
$dbContextName = "CalvinDbContext";

Remove-Item *.cs 
dotnet ef dbcontext scaffold $ConnectionString $provider -c $dbContextName -d --use-database-names -v
# -c: set DB Context name to...
# -d: use Data Annotation / attributes where possible.
# --use-database-names: do not PascalCase-ify table and column names.
# -v: show verbose output.
