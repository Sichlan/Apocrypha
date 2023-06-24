# Apocrypha Character Creator

TODO: Description

## Update Database

> For mor information on the dotnet ef tool, [refer to this](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)

To add a migration to the entity model, use

```shell
dotnet ef migrations add [MIGRATION NAME] --project Apocrypha.EntityFramework --startup-project Apocrypha.ModernUi -- --environment Production
```

|     Argument      |              Values               |                                                            Explanation                                                            |
|:-----------------:|:---------------------------------:|:---------------------------------------------------------------------------------------------------------------------------------:|
| [MIGRATION NAME]  |               *any*               |                                           The name of the migration. Must not be null.                                            |
|     --project     |     Apocrypha.EntityFramework     |                                        The project in which the migration should be added.                                        |
| --startup-project | Apocrypha.WPF, Apocrypha.ModernUi |                          The project that calls the database model and provides connection strings etc.                           |
| -- --environment  | Production, Staging, Development  | The environment in which the migration should be executed. This should be executed based on which environment you are working on. |

After that, upload the migration to the database:

```shell
dotnet ef database update --project Apocrypha.EntityFramework --startup-project Apocrypha.ModernUi -- --environment Production
```

|     Argument      |              Values               |                                                            Explanation                                                            |
|:-----------------:|:---------------------------------:|:---------------------------------------------------------------------------------------------------------------------------------:|
|     --project     |     Apocrypha.EntityFramework     |                                        The project in which the migration should be added.                                        |
| --startup-project | Apocrypha.WPF, Apocrypha.ModernUi |                          The project that calls the database model and provides connection strings etc.                           |
| -- --environment  | Production, Staging, Development  | The environment in which the migration should be executed. This should be executed based on which environment you are working on. |