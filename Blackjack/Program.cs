using System.Collections.Concurrent;

namespace Blackjack
{
	internal class Program
	{
		static void Main(string[] args)
		{
            Console.WriteLine("1. Highlow \n 2.Piros v Fekete \n Szamtipp \n Jackpot");
			int egyenleg = 1000;
            Console.WriteLine("Kérem adja meg mit szeretne játszani");
            int szam = Convert.ToInt32(Console.ReadLine());
			switch (szam) {
				case 1: Console.Clear();
					
					break;
				case 2:
					Console.Clear();

					break;
				case 3:
					Console.Clear();

					break;
				case 4:
					Console.Clear();

					break;
				default: Console.Clear();
                    Console.WriteLine("Helytelen opcio");
					break;
            }

        }
	}
}
