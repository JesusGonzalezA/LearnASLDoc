public static UnitOfWork GetMockUnitOfWork()
{
    DbContextOptionsBuilder<DatabaseContext> dbOptions =
        new DbContextOptionsBuilder<DatabaseContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString());
    DatabaseContext context = new DatabaseContext(dbOptions.Options);

    return new UnitOfWork(context);
}