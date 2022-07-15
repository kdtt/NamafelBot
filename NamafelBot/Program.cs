using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NamafelBot.Services;

namespace NamafelBot
{
    internal class Program
    {
        private readonly DiscordSocketClient _client;
        private readonly IConfiguration _config;
        private readonly IServiceProvider _services;
        private readonly CommandHandlerService _command;

        private Program()
        {
            _services = new ServiceRegistry().ConfigureServices();

            _client = _services.GetRequiredService<DiscordSocketClient>();
            _command = _services.GetRequiredService<CommandHandlerService>();
            _config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();

            _services.GetRequiredService<LoggingService>();
        }

        public static Task Main(string[] args)
        {
            return new Program().MainAsync();
        }

        public async Task MainAsync()
        {
            await _command.InstallCommandsAsync();
            await _client.LoginAsync(TokenType.Bot, _config["Bot:Token"]);
            await _client.StartAsync();

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }
    }
}
