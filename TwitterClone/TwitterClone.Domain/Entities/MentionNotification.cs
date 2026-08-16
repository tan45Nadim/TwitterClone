namespace TwitterClone.Domain.Entities;

public class MentionNotification : Notification
{
    public Guid MentionedByUserId { get; set; }

    public MentionNotification(Guid mentionedByUserId) : base("Mention")
    {
        MentionedByUserId = mentionedByUserId;
    }

    public override string DescribeRecord()
    {
        return $"{base.DescribeRecord()}, MentionedByUserId: {MentionedByUserId}";
    }

    public override string GetMessage()
    {
        return $"User with ID {MentionedByUserId} mentioned you in a post.";
    }

}