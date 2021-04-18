namespace vigalileo.Data.Entities
{
    public interface IBaseEntity<TPKey>
    {
        TPKey Id { get; set; }
    }
}