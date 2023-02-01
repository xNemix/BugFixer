using Microsoft.VisualBasic;

namespace BugFixer.Exceptions;

public class ShopException : ApplicationException
{

    public ShopException()
    {
        
    }
    
    public ShopException(string msg, Exception innerException) : base(msg, innerException)
    {
        
    }
    
}