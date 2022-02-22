namespace MongoExample.Core.Entities;

public interface IBrand
{
    string Name { get; set; }

    IEnumerable<string> AvailableModels { get; set; }
}
