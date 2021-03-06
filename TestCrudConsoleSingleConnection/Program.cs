using System;
using System.Threading.Tasks;
using MongoDB.Bson;
using Newtonsoft.Json;
using MongoDB.Driver;
using System.Collections.Generic;
using MongoRepository;
using System.Diagnostics;
using System.Linq;
using log4net;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "App.config", Watch = true)]
namespace TestCrudConsoleSingleConnection
{
    class Program
    {
        public IMongoCollection<Item> _item;
        private List<int> time = new List<int>();
        private static readonly ILog log =
        LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static async Task Main(string[] args)
        {
            Console.WriteLine("Beginning operations...");
            Program p = new Program();
            await p.fireLoop();
        }

        public async Task fireLoop()
        {
            time.Clear();
            Console.WriteLine("Enter the amount of loop.");
            string loopselection = Console.ReadLine();
            int j = int.Parse(loopselection);
            List<Task> task = new List<Task>();
            MongoClient mongoClient = new MongoClient("mongodb+srv://chan:chh428493@testcluster.axotv.mongodb.net/newTest?retryWrites=true&w=majority");
            var db = mongoClient.GetDatabase("newTest");
            _item = db.GetCollection<Item>("Item");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            log.Info(DateTime.Now);
            for (int i = 0; i < j; i++)
            {
                task.Add(Demo());
            }
            await Task.WhenAll(task);
            stopwatch.Stop();
            log.Info("==============================END================================");
            log.Info("The number of attempts: " + time.Count());
            log.Info("The minimum time taken: " + time.Min());
            log.Info("The average time taken: " + time.Average());
            log.Info("The maximum time taken: " + time.Max());
            log.Info("Time taken for operation: " + stopwatch.ElapsedMilliseconds);
            Console.WriteLine("");
            Console.WriteLine("Continue to loop? '1' for yes, '0' to close");
            string loopcontinue = Console.ReadLine();
            if (loopcontinue == "1")
            {
                await this.fireLoop();
            }
            else if (loopcontinue == "0")
            {
                Environment.Exit(0);
            }
        }

        public async Task Demo()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            List<Item> item = await GetAll();
            item.ToJson();
            stopwatch.Stop();
            log.Info(stopwatch.ElapsedMilliseconds + "ms");
            int i = (int)stopwatch.ElapsedMilliseconds;
            time.Add(i);
        }

        public async Task<List<Item>> GetAll()
        {
            List<Item> item = (await _item.FindAsync(item => true)).ToList();
            return item;
        }
    }
}
