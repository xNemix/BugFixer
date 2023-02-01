namespace BugFixer.Exceptions;

public class NoItemsInCartException: ShopException
{
    public NoItemsInCartException()
    {
        
    }
    
    public NoItemsInCartException(Exception exception) : base("", exception)
    {
        
    }
}