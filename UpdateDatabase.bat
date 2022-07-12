@echo off
:MAIN
    set /p answer=Please input name for migration:
    dotnet ef migrations add %answer% --project Apocrypha.EntityFramework --startup-project Apocrypha.WPF -- --environment Production
    dotnet ef database update --project Apocrypha.EntityFramework --startup-project Apocrypha.WPF -- --environment Development
    dotnet ef database update --project Apocrypha.EntityFramework --startup-project Apocrypha.WPF -- --environment Staging
    dotnet ef database update --project Apocrypha.EntityFramework --startup-project Apocrypha.WPF -- --environment Production
    pause