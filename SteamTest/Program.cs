using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SteamTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string txt;
            HttpClient client = new HttpClient();

            Task<string> callTask = Task.Run(() => CallHttp());
            callTask.Wait();
            txt = callTask.Result;

            Console.Write(txt);
            Console.ReadLine();
        }

        static public async Task<string> CallHttp()
        {
            // Just a demo.  Normally my HttpClient is global (see docs)
            HttpClient aClient = new HttpClient();
            // async function call we want to wait on, so wait
            string astr = await aClient.GetStringAsync("http://api.steampowered.com/IPlayerService/IsPlayingSharedGame/v0001/?key=E608303CABB6E393DE24393B35212D68&steamid=76561198025333369&appid_playing=240&format=json");
            // return the value
            return astr;
        }
    }
}
