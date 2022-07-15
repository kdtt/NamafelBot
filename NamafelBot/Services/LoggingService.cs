using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace NamafelBot.Services
{
    internal class LoggingService
    {
        public LoggingService(DiscordSocketClient client, CommandService command)
        {
            client.Log += LogAsync;
            command.Log += LogAsync;
        }
        public Task LogAsync(LogMessage message)
        {
            switch (message.Severity)
            {
                case LogSeverity.Critical:
                case LogSeverity.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogSeverity.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case LogSeverity.Info:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case LogSeverity.Verbose:
                case LogSeverity.Debug:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
            }

            if (message.Exception is CommandException cmdException)
            {
                Console.WriteLine($"[Command | {message.Severity}] {cmdException.Command.Aliases[0]}"
                  + $" failed to execute in {cmdException.Context.Channel}.");
                Console.WriteLine(cmdException);
            }
            else
                Console.WriteLine($"[General | {message.Severity}] {message}");

            return Task.CompletedTask;
        }
    }
}
