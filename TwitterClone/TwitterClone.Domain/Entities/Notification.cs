namespace TwitterClone.Domain.Entities;

public abstract class Notification : BaseEntity

{
    private Guid _userId;
    private string _type;
    private string _message;
    private bool _isRead;

    public Notification(string notifivationType) : base(Guid.NewGuid())
    {
        _type = notifivationType;
    }

    public Guid UserId
    {
        get { return _userId; }
        set { _userId = value; }
    }

    public string Type
    {
        get { return _type; }
        set { _type = value; }
    }

    public string Message
    {
        get { return _message; }
        set { _message = value; }
    }

    public bool IsRead
    {
        get { return _isRead; }
        set { _isRead =  value; }
    }

    public override string DescribeRecord()
    {
        return $"{base.DescribeRecord()}, UserId: {UserId}, Type: {Type}, Message: {Message}, IsRead: {IsRead}";
    }

    public abstract string GetMessage();

}
