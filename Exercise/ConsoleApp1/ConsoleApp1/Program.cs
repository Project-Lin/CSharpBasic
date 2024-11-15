using System.Net.Http.Headers;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Npc npc = new Npc();

            Console.WriteLine(npc.hp);
            npc.setHp(1000);
            Console.WriteLine(npc.hp);


        }
        
    }
}