using System.Runtime.Serialization;

namespace MongoExample.Core.Exceptions;

[Serializable]
public class InvalidSpzException : Exception
{
    public InvalidSpzException()
    {
    }

    public InvalidSpzException(string message) : base(message)
    {
    }

    public InvalidSpzException(string message, Exception inner) : base(message, inner)
    {
    }

    protected InvalidSpzException(
        SerializationInfo info,
        StreamingContext context) : base(info, context)
    {
    }
}
