using System;
using System.Numerics;

namespace Blackjack
{
	internal class Program
	{
		static void Main(string[] args)
		{
			bool fut = true;
			while (fut == true)
			{
				Console.Clear();
				Console.WriteLine("1. Blackjack");
				Console.WriteLine("2. Piros v Fekete");
				Console.WriteLine("3. Számtipp");
				Console.WriteLine("4. Jackpot");
                Console.WriteLine("5. Kilépés");
                int egyenleg = 1000;
				Console.WriteLine("Kérem adja meg mit szeretne játszani");
				int szam = Convert.ToInt32(Console.ReadLine());

				switch (szam)
				{
					case 1:
						Console.Clear();
						egyenleg = BlackJack(ref egyenleg);
						Console.ReadKey();
						break;
					case 2:
						Console.Clear();
						Pirosfekete(ref egyenleg);
						Console.ReadKey();

						break;
					case 3:
						Console.Clear();
						Intervallum(ref egyenleg);
						Console.ReadKey();
						break;
					case 4:
						Console.Clear();
						Jackpot(ref egyenleg);
						Console.ReadKey();
						break;
					case 5: 
						Console.Clear();
                        Console.WriteLine("Kilépés");
						fut = false;
						Console.ReadKey();
						break;
                    default:
						Console.Clear();
						Console.WriteLine("Helytelen opció");
						Console.ReadKey();
						break;
				}
			}

			static int BlackJack(ref int osszeg)
			{
				Console.WriteLine("Blackjack \n Adja meg a tétet");
				int tet = Convert.ToInt32(Console.ReadLine());
				osszeg -= tet;

				int playerScore = 0;
				int dealerScore = 0;

				// Játékos lapjainak húzása
				playerScore += Huzlapot(ref playerScore); // Első lap
				playerScore += Huzlapot(ref playerScore); // Második lap

				// Dealer lapjainak húzása
				dealerScore += Huzlapot(ref dealerScore); // Első lap
				dealerScore += Huzlapot(ref dealerScore); // Második lap

				Console.WriteLine($"Játékos kártyái összesen: {playerScore}");
				Console.WriteLine($"Dealer első lapja: {dealerScore}");


				while (playerScore < 21)
				{
					Console.WriteLine("Kér még lapot? (Igen/Nem)");
					string valasz = Console.ReadLine().ToLower();
					if (valasz == "igen")
					{
						playerScore += Huzlapot(ref playerScore);
						Console.WriteLine($"Játékos kártyái összesen: {playerScore}");
					}
					else
					{
						break;
					}
				}


				while (dealerScore < 17)
				{
					dealerScore += Huzlapot(ref dealerScore);
				}

				Console.WriteLine($"Dealer kártyái összesen: {dealerScore}");


				if (playerScore > 21)
				{
					Console.WriteLine("Túllépte a 21-et, veszített!");
					return osszeg;
				}
				if (dealerScore > 21)
				{
					Console.WriteLine("Dealer túllépte a 21-et, Ön nyert!");
					return osszeg + tet * 2;
				}

				if (playerScore > dealerScore)
				{
					Console.WriteLine("Ön nyert!");
					return osszeg + tet * 2;
				}
				else if (playerScore < dealerScore)
				{
					Console.WriteLine("Dealer nyert!");
					return osszeg;
				}
				else
				{
					Console.WriteLine("Döntetlen!");
					return osszeg + tet;
				}
			}

			static int Huzlapot(ref int score)
			{
				Random rnd = new Random();
				int randomnmbr = rnd.Next(2, 15);


				if (randomnmbr >= 11 && randomnmbr <= 13)
				{
					randomnmbr = 10;
				}

				if (randomnmbr == 14)
				{
					Console.WriteLine("Ász jött, válasszon: 1 vagy 11?");
					int valasz = Convert.ToInt32(Console.ReadLine());
					return valasz;
				}

				return randomnmbr;
			}
			static int Pirosfekete(ref int osszeg)
			{
				Console.WriteLine("Kérem a tétet!");
				int tet = Convert.ToInt32(Console.ReadLine());
				osszeg -= tet;
				Console.WriteLine("Piri (1) vagy fekete (2)");
				int pirivagyfeke = Convert.ToInt32(Console.ReadLine());
				Random PvF = new Random();
				int randomnmbr = PvF.Next(1, 3);
				if (randomnmbr == pirivagyfeke)
				{
					osszeg += 2 * tet;

				}
				else
				{
					Console.WriteLine("Vesztett");

				}

				return osszeg;
			}

			static int Jackpot(ref int osszeg)

			{
				Console.WriteLine("Tét: ");
				int tet = Convert.ToInt32(Console.ReadLine());
				osszeg -= tet;
				Console.WriteLine("Tippeljen egy számot 1-10 között");
				int tipp = Convert.ToInt32(Console.ReadLine());
				Random szam = new Random();
				int szamok = szam.Next(1, 11);
				if (szamok == tipp)
				{
					osszeg += tet * 11;
				}
				else
				{
					Console.WriteLine("Vesztett");
				}

				return osszeg;
			}

			static int Intervallum(ref int osszeg)
			{
				Console.WriteLine("Tét: ");
				int tet = Convert.ToInt32(Console.ReadLine());
				osszeg -= tet;
				Console.WriteLine("Tippeljen egy számot 1-100 között");
				int tipp = Convert.ToInt32(Console.ReadLine());
				Random szam = new Random();
				int szamok = szam.Next(1, 100);
				Random szam2 = new Random();
				int szamok2 = szam.Next(1, 100);

				if (szamok > szamok2)
				{
					if (tipp > szamok2 && tipp < szamok)
					{
						osszeg += tipp * 2;
					}
					else
					{ Console.WriteLine("Vesztett"); }

				}
				else
				{
					if (tipp < szamok2 && tipp > szamok)
					{
						osszeg += tipp * 2;
					}
					else
					{ Console.WriteLine("Vesztett"); }
				}

				


				return osszeg;
			}
		}

	}
}