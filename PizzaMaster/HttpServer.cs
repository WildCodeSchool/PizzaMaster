using System;
using System.Net;

namespace PizzaMaster
{
    public abstract class HttpServer
    {
        protected HttpListener listener;
        protected bool running = true;

        protected HttpServer(string[] serverPrefixes)
        {
            listener = new HttpListener();
            foreach (string prefix in serverPrefixes)
            {
                listener.Prefixes.Add(prefix);
            }
        }

        public void run()
        {
            listener.Start();
            while (running)
            {
                HandleRequest();
            }
            listener.Stop();
        }

        public abstract void HandleRequest();
    }
}
