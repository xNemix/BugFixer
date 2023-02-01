namespace BugFixer.Exceptions;

public class AddBalanceException : ShopException
{
    public AddBalanceException()
    {
        
    }
    
    public AddBalanceException(Exception exception) : base("", exception)
    {
        
    }
}