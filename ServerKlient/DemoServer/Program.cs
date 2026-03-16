
namespace DemoServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            List<Message> messages = new List<Message>();

            app.MapGet("/messages", () =>
            {
                return messages;
            });

            app.MapPost("/messages", (Message msg) =>
            {
                messages.Add(msg);
                return Results.Ok();
            });

            app.Run();
        }
    }
    public class Message
    {
        public string user { get; set; }
        public string text { get; set; }
    }
}
