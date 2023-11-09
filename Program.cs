using System.Text;
using Test_StreamReader;
namespace Test_ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char delimiter;
            Console.WriteLine("Введите разделитель");
            delimiter = (char)Console.Read();
            Console.WriteLine($"Разделитель - \"{delimiter}\"");
            var message = MessageReader.ReadMessages(delimiter);


            foreach (var line in message)
            {
                Console.WriteLine(Encoding.Default.GetString(line));
            }
        }
    }
}