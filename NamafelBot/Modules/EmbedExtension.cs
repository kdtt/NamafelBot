using Discord;
using Discord.Commands;

namespace NamafelBot.Modules
{
    public static class EmbedExtension
    {
        private static readonly EmbedBuilder _embed = new()
        {
            Color = new Color(0xff4448),
        };

        public static EmbedBuilder Embed => _embed;

        public static async Task<IUserMessage> ReplyEmbedAsync(this IUserMessage msg, string title = null, string message = null, EmbedFooterBuilder embedFooter = null, bool isTTS = false, RequestOptions options = null, MessageReference messageReference = null, MessageComponent components = null, ISticker[] stickers = null, Embed[] embeds = null)
        {
            _embed.WithTitle(title);
            _embed.WithDescription(message);
            if (embedFooter is not null)
                _embed.WithFooter(embedFooter);

            Embed builtEmbed = _embed.Build();
            
            return await msg.Channel.SendMessageAsync(null, isTTS, builtEmbed, options, AllowedMentions.None, new MessageReference(msg.Id), components, stickers, embeds).ConfigureAwait(continueOnCapturedContext: false);
        }


    }
}
