# StudentManagement

## Overview
Our branches indicate which type of EF migrations we have used. All branches are listed under feat/. If a branch ends with "-state" we implemented the state-based approach to migrations.
If the branch ends with "-ef" we implemented the change-based approach to migrations.
We use SQL Lite for the changed based approach, and MSSQL for the state based approach, as SQL Lite does not support the state based approach. 

## Initial setup
We created the 3 models and used the modelbuilder in AppDbContext to create the constraints and properties of each column.
Once we did that we used the following command in the terminal:
```bash
dotnet ef migrations add V[VersionNumber]__[NameOfMigration]
```
This command was used throughout the exercise each time we needed to create a new migrations.

### State
We used the following statement to create the sql script based on the state-based approach:
```bash
dotnet ef migrations script --idempotent -c AppDbContext -o V[VersionNumber]__[NameOfMigration].sql
```

### Change
We used the following statement to create the initial sql script based on the change-based approach:
```bash
dotnet ef migrations script -c AppDbContext -o V[VersionNumber]__[NameOfMigration].sql
```
For the remainding scripts we had to make sure to insert the previous migration and the current migration as parameters:
```bash
dotnet ef migrations script V[PreviousVersionNumber]__[NameOfPreviousMigration] V[CurrentVersionNumber]__[NameOfCurrentMigration] -o V[CurrentVersionNumber]__[NameOfCurrentMigration].sql
```


## Comments
### 5.
We use a non-destructive approach to change the column name. There could be some desctructive changes if there were any stored procedures or functions that were dependent on this column, but EF would handle those as well.

### 6.
We choose to create a navigation property as the DepartmentHead, but it also has a DepartmentHeadId, to facilitate a foreign key constraint.

### 7.
This is technically a destructive approach, as changing a type could lead to significant data loss. However we changed it from int -> double, which wouldn't change much. 
The other way around, however, would have resulted in a loss of precision.
As we are using SQL lite for the change based approach, EF automatically makes a transfer of all data to a new table, with the new datatype of credits, before dropping the old table, so this could be considered a soft delete.
