namespace TwitterClone.Domain.Entities;

public sealed class CommentNotification : Notification
{
    public Guid CommentByUserId { get; set; }

    public CommentNotification(Guid commentByUserId) : base("Comment")
    {
        CommentByUserId = commentByUserId;
    }

    public void AddMessage(string message)
    {
        Message = message;
    }

    public override string DescribeRecord()
    {
        return $"{base.DescribeRecord()}, CommentByUserId: {CommentByUserId}";
    }

    public override string GetMessage()
    {
        return $"user with Id {CommentByUserId} commented on your post";
    }
}