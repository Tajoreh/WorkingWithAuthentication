namespace Shared;
public record LoginCommand(string UserName,string Password);

public static class Constants
{
    public static string TokenApi = "https://localhost:7267";
}