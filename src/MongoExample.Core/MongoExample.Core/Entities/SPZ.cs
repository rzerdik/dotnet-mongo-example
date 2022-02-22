using MongoExample.Core.Exceptions;

namespace MongoExample.Core.Entities;

public class SPZ
{
    public SPZ(string value)
    {
        //validation here

        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidSpzException("SPZ cannot be empty");

        Value = value;
    }

    public string Value { get; }
}
