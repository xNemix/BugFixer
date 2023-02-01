namespace BugFixer.Exceptions;

public class InvalidInputException : ShopException
{
    public InvalidInputException()
    {
        
    }
    
    public InvalidInputException(Exception exception) : base("", exception)
    {
        
    }
}