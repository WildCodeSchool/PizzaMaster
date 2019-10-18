using System;
using System.Net;
namespace PizzaMaster
{
    public class PizzaServer : HttpServer
    {
        private PizzaCart cart;

        public PizzaServer(string[] prefixes) : base(prefixes)
        {
            cart = new PizzaCart(20); 
        }

        public override void HandleRequest()
        {
            HttpListenerContext context = listener.GetContext();
            context.Response.StatusCode = 200;
            if (context.Request.HttpMethod == "POST")
            {
                HandleOrderPizza(context);
            }
            else
            {
                context.Response.StatusCode = 405;
                SendResponseToContext("405 Bad Method", ref context);
            }
            context.Response.OutputStream.Close();
        }

        private void HandleOrderPizza(HttpListenerContext context)
        {
            string response = "";
            try
            {
                PostDataReader data = new PostDataReader(context.Request.InputStream);
                cart.PizzaCount += Convert.ToInt32(data["nbPizzas"]);   
                response = "You have " + cart.PizzaCount + " pizzas ordered";
            }
            catch (FormatException exception)
            {
                context.Response.StatusCode = 400;
                response = exception.Message;
            } catch (ArgumentException exception)
            {
                context.Response.StatusCode = 400;
                response = exception.Message;
            }
            finally
            {
                SendResponseToContext(response, ref context);
            }
        }

        private void SendResponseToContext(string response, ref HttpListenerContext context)
        {
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(response);
            context.Response.ContentType = "text/plain";
            context.Response.ContentLength64 = buffer.Length;
            context.Response.OutputStream.Write(buffer, 0, buffer.Length);
        }
    }
}
