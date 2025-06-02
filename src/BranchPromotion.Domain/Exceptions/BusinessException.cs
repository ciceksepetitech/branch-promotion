namespace BranchPromotion.Domain.Exceptions;

public class BusinessException : Exception
{
    public BusinessException(string message) : base(message)
    {
        
    }
    
    public static void ThrowIf(bool condition, string message)
    {
        if (condition) 
            throw new BusinessException(message);
    }
}
