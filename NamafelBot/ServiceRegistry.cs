using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using NamafelBot.Services;

namespace NamafelBot
{
    internal class ServiceRegistry
    {
        public IServiceProvider ConfigureServices() => new ServiceCollection()
            .AddSingleton<DiscordSocketClient>()
            .AddSingleton<CommandService>()
            .AddSingleton<LoggingService>()
            .AddSingleton<StatsService>()
            .AddSingleton<CommandHandlerService>()
            .BuildServiceProvider();
    }
}
