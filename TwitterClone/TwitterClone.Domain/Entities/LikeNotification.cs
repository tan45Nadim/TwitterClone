namespace TwitterClone.Domain.Entities;

public sealed class LikeNotification : Notification
{
    public Guid LikeByUserId { get; set; }

    public LikeNotification(Guid likeByUserId) : base("Like")
    { 
        LikeByUserId = likeByUserId;
    }

    public void AddMessage(string message)
    {
        Message = message;
    }

    public override string DescribeRecord()
    {
        return $"{base.DescribeRecord()}, LikeByUserId: { LikeByUserId}";
    }

    public override string GetMessage()
    {
        return $"User with Id {LikeByUserId} liked your post";
    }

}
