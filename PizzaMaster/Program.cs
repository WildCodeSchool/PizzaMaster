using System;

namespace PizzaMaster
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string[] prefixes = { "http://localhost:12345/PizzaMaster/" };
            HttpServer server = new PizzaServer(prefixes);
            server.run();
        }
    }
}
