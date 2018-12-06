using SQLite;

namespace Szkola.Data.Entities
{
    public class BaseEntity
    {
        [AutoIncrement, PrimaryKey]
        public int ID { get; set; }
    }
}