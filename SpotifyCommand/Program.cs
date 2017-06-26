using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyAPI.Local;

namespace SpotifyCommand
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!args.Any())
            {
                Console.WriteLine("No commands inputted..");
                return;
            }

            var command = args.First();

            SpotifyService service = new SpotifyService();
            service.Execute(command);

            Console.WriteLine("Bye..");
        }
    }

    internal class SpotifyService
    {
        private readonly SpotifyLocalAPI _spotify = new SpotifyLocalAPI();

        public SpotifyService()
        {
            var success = _spotify.Connect();
            if (!success)
                throw new InvalidOperationException("Unable to connect to spotify...");
        }

        public async void Execute(string command)
        {
            switch (command)
            {
                case "pause":
                    await _spotify.Pause();
                    break;
                case "resume":
                    await _spotify.Play();
                    break;
                default:
                    throw new InvalidOperationException("Unknown command: " + command);
            }
        }
    }
}
