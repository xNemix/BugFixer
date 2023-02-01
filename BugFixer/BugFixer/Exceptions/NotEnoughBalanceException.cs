namespace BugFixer.Exceptions;

public class NotEnoughBalanceException : ShopException
{
    public NotEnoughBalanceException()
    {
        
    }
    
    public NotEnoughBalanceException(Exception exception) : base("", exception)
    {
        
    }
}