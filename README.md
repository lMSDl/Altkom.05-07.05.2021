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
