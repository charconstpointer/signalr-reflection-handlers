namespace Pub
{
    public interface IMessage
    {
    }

    public record Message (string Body) : IMessage;
}