using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace KenjiBot
{
    class Program
    {
        static void Main(string[] args) => new Program().MainTask().GetAwaiter().GetResult();


        async Task MainTask()
        {
            DiscordSocketClient client = new DiscordSocketClient();

            client.Log += Log;
            client.MessageReceived += NewMessageReceived;

            await client.LoginAsync(TokenType.Bot, "MzE1ODU4MTA1Nzg1MjUzODg4.DAM1sg.kGDN5CpTyFpDynobB_wrNqsqRTA");
            await client.StartAsync();

            client.SetGameAsync("George's sexy bot").ConfigureAwait(false);

            await Task.Delay(-1);
        }

        Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        async Task NewMessageReceived(SocketMessage message)
        {
            

            if (message.Content.IndexOf("Play", StringComparison.OrdinalIgnoreCase) >= 0 && message.Content.IndexOf("FF", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                Console.WriteLine(message.Content);

                await message.Channel.SendMessageAsync("NEVEEERRRRRRR");
                return;
            }

            if (!(message.Content.IndexOf("kenji", StringComparison.OrdinalIgnoreCase) >= 0))
            {
                return;
            }

            if (message.Content.IndexOf("hi", StringComparison.OrdinalIgnoreCase) >= 0 || message.Content.IndexOf("hello", StringComparison.OrdinalIgnoreCase) >= 0 || message.Content.IndexOf("hey", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                Console.WriteLine(message.Content);

                await message.Channel.SendMessageAsync("Hi");

            }

            if (message.Content.IndexOf("?", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                Console.WriteLine(message.Content);

                if((DateTime.Now.Second % 2) == 0)
                    await message.Channel.SendMessageAsync("yes");
                else
                    await message.Channel.SendMessageAsync("no");
            }
        }

    }
}