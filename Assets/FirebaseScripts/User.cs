public class User
{
    public string email;
    public string username;
    public int creationDate;
    public int lastLogin;

    public User()
    {
    }

    public User(string email, string username, int creationDate, int lastLogin)
    {
        this.email = email;
        this.username = username;
        this.creationDate = creationDate;
        this.lastLogin = lastLogin;
    }
}