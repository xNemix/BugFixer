namespace BugFixer.Exceptions;

public class UnknownErrorException : ShopException
{
    public UnknownErrorException()
    {
        
    }
    
    public UnknownErrorException(Exception exception) : base("", exception)
    {
        
    }
}