namespace Johansson.OpenAI;

public class OpenAIException : Exception
{
    public OpenAIException()
    {
        // Intentionally left blank
    }

    public OpenAIException(string message)
        : base(message)
    {
        // Intentionally left blank
    }

    public OpenAIException(string message, Exception inner)
        : base(message, inner)
    {
        // Intentionally left blank
    }
}