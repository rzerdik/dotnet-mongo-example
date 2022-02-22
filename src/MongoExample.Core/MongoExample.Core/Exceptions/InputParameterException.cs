using System.Runtime.Serialization;

namespace MongoExample.Core.Exceptions;

[Serializable]
public class InputParameterException : Exception
{
    public InputParameterException()
    {
    }

    public InputParameterException(string message) : base(message)
    {
    }

    public InputParameterException(string message, Exception inner) : base(message, inner)
    {
    }

    protected InputParameterException(
        SerializationInfo info,
        StreamingContext context) : base(info, context)
    {
    }
}
