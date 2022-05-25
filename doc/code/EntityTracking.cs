public class DatabaseContext : DbContext
{
    // ...
    public DatabaseContext
    (
        DbContextOptions<DatabaseContext> options
    )
        : base(options)
    {
        ChangeTracker.StateChanged += OnEntityStateChanged;
        ChangeTracker.Tracked += OnEntityTracked;        
    }
    
    private void OnEntityTracked
    (
        object sender, 
        EntityTrackedEventArgs e
    )
    {
        if (!e.FromQuery && 
            e.Entry.State == EntityState.Added 
            && e.Entry.Entity is BaseEntity entity
        )
        {
            entity.CreatedOn = DateTime.UtcNow;
        }
    }

    private void OnEntityStateChanged
    (
        object sender, 
        EntityStateChangedEventArgs e
    )
    {
        if (e.NewState == EntityState.Modified && 
            e.Entry.Entity is BaseEntity entity
        )
        {
            entity.ModifiedOn = DateTime.UtcNow;
        }
    }

    // ...
}