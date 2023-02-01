namespace BugFixer.Exceptions;

public class ShopCheckoutException : ShopException
{
    public ShopCheckoutException()
    {
        
    }
    
    public ShopCheckoutException(Exception exception) : base("", exception)
    {
        
    }
}