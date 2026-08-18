namespace TwitterClone.Domain.Entities;

public class User : BaseEntity, IFollowable, INotifiable
{
    private string _firstName;
    private string _lastName;
    private string _email;
    private List<Guid> _followers = new List<Guid>();
    private List<Guid> _inComingNotification = new List<Guid>();


    public User() : base(Guid.NewGuid())
    {
    }

    public string FirstName
    {
        get { return _firstName; }
        set { _firstName = value; }
    }

    public string LastName
    {
        get { return _lastName; }
        set { _lastName = value; }
    }

    public string Email
    {
        get { return _email; }
        set { _email = value; }
    }


    public override string DescribeRecord()
    {
        return $"{base.DescribeRecord()}, FirstName: {FirstName}, LastName: {LastName}, Email: {Email}";
    }

    public void Follow(Guid userId)
    {
        if (!_followers.Contains(userId))
        {
            _followers.Add(userId);
        }
    }

    public void UnFollow(Guid userId)
    {
        if (_followers.Contains(userId))
        {
            _followers.Remove(userId);
        }
    }
  
    public void AddNotification(Guid notificationId)
    {
        if (!_inComingNotification.Contains(notificationId))
        {
            _inComingNotification.Add(notificationId);
        }
    }
}