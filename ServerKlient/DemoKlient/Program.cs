using System.Text;
using System.Text.Json;


namespace DemoKlient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();

            string server = "http://[SERVER IP]:5144/messages"; //Lägg till server ip här dum dum.

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

                    var response = await client.PostAsync(server, content);

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Meddelande skickat!");
                    }
                    else
                    {
                        Console.WriteLine($"Fel: {response.StatusCode}");
                    }

                }

                else if (choice == "2")
                {
                    string json = await client.GetStringAsync(server);

                    List<Message> messages = JsonSerializer.Deserialize<List<Message>>(json);


                    Console.WriteLine("\n--- Skickade meddelanden ---");

                    foreach (var m in messages)
                    {
                        
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

// Iska was here!