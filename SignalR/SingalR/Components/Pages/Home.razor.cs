using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using SignalR.Models;

namespace SignalR.Components.Pages;

partial class Home : IAsyncDisposable
{
    [Inject] 
    private NavigationManager? NavigationManager { get; set; }

    private HubConnection? _hubConnection;
    private List<UserMessage> _userMessages = new();
    private string _usernameInput = string.Empty;
    private string _messageInput = string.Empty;
    private bool _isUserReadonly = false;

    private bool IsConnected => _hubConnection!.State == HubConnectionState.Connected;

    protected override async Task OnInitializedAsync()
    {
        _hubConnection = new HubConnectionBuilder()
            .WithUrl(NavigationManager!.ToAbsoluteUri("/chathub"))
            .Build();

        _hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
        {
            _userMessages.Add(new UserMessage {Username = user, Message = message, CurrentUser = user == _usernameInput, DateSent = DateTime.Now});
            
            StateHasChanged();
        });
        await _hubConnection.StartAsync();
        Console.WriteLine("WOrks");
    }
    
    private async Task SendMsg()
    {
        if (!string.IsNullOrEmpty(_usernameInput) && !string.IsNullOrEmpty(_messageInput))
        {
            await _hubConnection!.SendAsync("SendMessage", _usernameInput, _messageInput);
            
            StateHasChanged();
            _isUserReadonly = true;
            _messageInput = string.Empty;
        }
    }


    public async ValueTask DisposeAsync()
    {
        if (_hubConnection is not null)
        {
            await _hubConnection.DisposeAsync();
        }
    }
}