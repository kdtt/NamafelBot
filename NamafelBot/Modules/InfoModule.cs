using Discord;
using Discord.Commands;
using Discord.WebSocket;
using NamafelBot.Services;

namespace NamafelBot.Modules
{
    [RequireOwner]
    public class InfoModule : ModuleBase<SocketCommandContext>
    {
        private readonly DiscordSocketClient _client;
        private readonly StatsService _stats;

        public InfoModule(DiscordSocketClient client, StatsService stats)
        {
            _client = client;
            _stats = stats;
        }

        // ~say hello world -> hello world
        [Command("say")]
        [Summary("Echoes a message.")]
        public Task SayAsync([Remainder][Summary("The text to echo")] string echo)
          => Context.Message.ReplyAsync(echo);

        [Command("ping")]
        [Summary("Check bot latency")]
        public Task PingAsync()
        {
            return Context.Message.ReplyEmbedAsync("Ping", _client.Latency.ToString() + " ms");
        }

        [Command("uptime")]
        [Summary("Check bot uptime")]
        public Task UptimeAsync()
        {
            EmbedFooterBuilder embedFooter = new()
            {
                Text = $"Start date: {_stats.StartDate}"
            };

            return Context.Message.ReplyEmbedAsync("Uptime", _stats.Uptime.ToString(), embedFooter);
        }
    }
}
