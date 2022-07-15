using Discord.Commands;

namespace NamafelBot.Modules
{
    public class TimerModule : ModuleBase<SocketCommandContext>
    {
        [Command("voyage")]
        [Summary("Add timer for submersible or airship")]
        public Task VoyageAsync()
        {
            return ReplyAsync("Voyage");
        }
    }
}
