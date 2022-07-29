using System;
using System.Runtime.Serialization;

[Serializable]
internal class error : Exception
{
    public error()
    {
    }

    public error(string message) : base(message)
    {
    }

    public error(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected error(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}