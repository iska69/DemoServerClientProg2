using System.Text;
using System.Text.Json;


namespace DemoKlient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();

            string server = "http://10.71.39.98:5144/messages";

            Console.Write("Användarnamn: ");
            string user = Console.ReadLine();

            while (true)
            {
                Console.WriteLine("\n1. Skicka meddelande");
                Console.WriteLine("2. Läs chatt");
                Console.WriteLine("3. Avsluta");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    string text = Console.ReadLine();

                    var msg = new Message
                    {
                        user = user,
                        text = text
                    };

                    string json = JsonSerializer.Serialize(msg);

                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    await client.PostAsync(server, content);
                }

                else if (choice == "2")
                {
                    string json = await client.GetStringAsync(server);

                    List<Message> messages = JsonSerializer.Deserialize<List<Message>>(json);


                    Console.WriteLine("\n--- Skickade meddelanden ---");

                    foreach (var m in messages)
                    {
                        Console.WriteLine(m);
                        Console.WriteLine($"{m.user}: {m.text}");
                    }
                }

                else if (choice == "3")
                {
                    break;
                }
            }
        }
    }

    public class Message
    {
        public string user { get; set; }
        public string text { get; set; }
    }

}
