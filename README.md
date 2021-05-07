* Pakiety
```
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Design

Microsoft.EntityFrameworkCore.Tools (VS)
```

* Instalacja dotnet-ef (CLI)
```
dotnet tool install --global dotnet-ef
```

* ConnectionString dla MSSQL
```
Server=(localdb)\\mssqllocaldb;Database=<name>
Server=(local);Database=<name>;Integrated Security=True
Server=(local)\\SQLExpress;Database=<name>;Integrated Security=True
Server=192.168.200.125;Database=<name>;User Id=<username>;Password=<password>
```

* Migracje
  * CLI
  ```
  dotnet ef migrations add <name>
  dotnet ef migrations remove [-f]
  dotnet ef database update
  ```
  * Package Manager Console (VS)
  ```
  Add-Migration <name>
  Remove-Migration [-f]
  Update-Database
  ```
* Database First
  * CLI
  ```
  dotnet ef dbcontext scaffold [connection string] [provider]
  (dotnet ef dbcontext scaffold "Server=(local);Database=EFC;Integrated Security=true" Microsoft.EntityFrameworkCore.SqlServer)
  ```
  * Package Manager Console (VS)
  ```
  Scaffold-DbContext [connection string] [provider]
  Scaffold-DbContext "Server=(local);Database=EFC;Integrated Security=true" Microsoft.EntityFrameworkCore.SqlServer
  ```
