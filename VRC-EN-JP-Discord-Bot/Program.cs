using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

class Program
{
    private ServerConfig config;

    private DiscordSocketClient client;

    private static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();

    public async Task MainAsync()
    {
        config = Json.Deserialize<ServerConfig>("configurations.json");

        //Create client
        client = new DiscordSocketClient();

        //Add log method to callback
        client.Log += message =>
        {
            Console.WriteLine(message.ToString());
            return Task.CompletedTask;
        };

        //Connect to server
        await client.LoginAsync(TokenType.Bot, config.token);
        await client.StartAsync();

        await Task.Delay(-1);
    }
}
