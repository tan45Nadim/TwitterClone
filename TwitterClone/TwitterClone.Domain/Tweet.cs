namespace TwitterClone.Domain;

internal class Tweet
{
    private Guid _id;
    private Guid _authorId;
    private string _content;

    public Guid Id
    {
        get { return _id; }
    }

    public Guid AuthorId
    {
        get { return _authorId; }
    }

    public string Content
    {
        get {  return Content; }
        set { Content = value; }
    }
}