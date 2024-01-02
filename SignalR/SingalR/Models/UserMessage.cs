namespace SignalR.Models;

public class UserMessage
{
    public string Username { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public bool CurrentUser { get; set; }
    public DateTime DateSent { get; set; }
}