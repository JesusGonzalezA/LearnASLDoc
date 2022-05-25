
public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }
    protected virtual object Actual => this;

    public override bool Equals(object obj)
    {
        // implementation
    }

    public static bool operator ==(BaseEntity a, BaseEntity b)
    {
        // implementation
    }

    public static bool operator !=(BaseEntity a, BaseEntity b)
    {
        // implementation
    }

    public override int GetHashCode()
    {
        // implementation
    }
}
