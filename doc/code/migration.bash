# From Infraestructure directory
dotnet ef migrations add "<your-migration-name>" -s ../Api # Create the migration
dotnet database update -s ../Api # Apply the migration to the database