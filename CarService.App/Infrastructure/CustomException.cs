namespace CarService.App.Infrastructure;

public class CustomException : Exception
{
    public CustomException() : base("Server error") { }

    public CustomException(string message) : base(message) { }

}