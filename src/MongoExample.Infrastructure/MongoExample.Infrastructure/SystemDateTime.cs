using MongoExample.Core.Boundaries;

namespace MongoExample.Infrastructure;

public class SystemDateTime : IDateTime
{
    public DateTime Now => DateTime.UtcNow;
}
