using System.ComponentModel;

namespace M005
{
	internal class Program
	{
		static void Main(string[] args)
		{
			PrintAddiere(4, 5);
			PrintAddiere(3, 8);
			PrintAddiere(1, 3);

			int summe = Addiere(4, 6); //Ergebnis der Addiere Funtkion in eine Variable schreiben
            Console.WriteLine(summe);

            Console.WriteLine(); //18 Overloads, 18 Funktionen mit dem selben Namen aber unterschiedlichen Parametern

			double summe2 = Addiere(1.4, 2); //Über die Parameter wird gesteuert, welche Funktion ausgewählt wird

			int summe3 = Addiere(3, 4);

			int summe4 = Addiere(1, 2, 3);

			Summiere(); //keine Parameter sind auch beliebig viele Parameter
			Summiere(1, 2, 3);
			Summiere(1, 2, 3, 4, 5);
			Summiere(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);

			Subtrahiere(1, 2);
			Subtrahiere(4, 2, 1); //z wird hier überschrieben

			SubtrahiereOderAddiere(2, 5);
			SubtrahiereOderAddiere(6, 3);
			SubtrahiereOderAddiere(1, 4);
			SubtrahiereOderAddiere(3, 9);
			SubtrahiereOderAddiere(3, 9, true);

			Test(z: 5, w: 10);
			Test(x: 3, w: 8);

			Person(vorname: "Lukas", nachname: "Kern"); //Ich kann jetzt nur die Parameter eingeben die ich auch wirklich brauche

			int differenz;
			int summe5 = AddiereUndSubtrahiere(4, 5, out differenz); //Mit out den Parameter mit der Variable verbinden

			int result;
			bool b = int.TryParse("123", out result);
			if (b)
			{
				Console.WriteLine($"Parsen hat funktioniert: {result}");
			}
			else
			{
                Console.WriteLine("Parsen hat nicht funktioniert");
            }

			//int res;
            Console.WriteLine(int.TryParse("123", out int res) ? $"Parsen hat funktioniert: {res}" : "Parsen hat nicht funktioniert"); //Feld wird hier bei out direkt erstellt

			(int, int) ergebnisse = AddiereUndSubtrahiere(3, 4);
            Console.WriteLine($"Summe: {ergebnisse.Item1}, Differenz: {ergebnisse.Item2}");
        }

		/// <summary>
		/// Berechnet die Summe von z1 und z2 und schreibt diese in die Konsole.<br/>
		/// Funktion mit void (kein Rückgabewert), Zwei Parameter: z1 und z2
		/// </summary>
		/// <param name="z1">Die erste Zahl</param>
		/// <param name="z2">Die zweite Zahl</param>
		static void PrintAddiere(int z1, int z2)
		{
            Console.WriteLine($"{z1} + {z2} = {z1 + z2}");
        }

		/// <summary>
		/// Funktion mit Rückgabetyp (int), muss ein Ergebnis zurück geben
		/// </summary>
		/// <returns>Die Summe von z1 und z2</returns>
		static int Addiere(int z1, int z2)
		{
			return z1 + z2; //return: Ergebnis der Funktion zurück geben, Funktion wird beendet
        }

		/// <summary>
		/// Überladung: Methode mit dem selben Namen wie eine andere Methode, aber mit anderen Parametern
		/// </summary>
		static double Addiere(double z1, double z2)
		{
			return z1 + z2;
		}

		static int Addiere(int x, int y, int z)
		{
			return x + y + z;
		}

		/// <summary>
		/// params: Gibt die Möglichkeit beliebig viele Parameter zu übergeben
		/// </summary>
		static int Summiere(params int[] zahlen)
		{
			return zahlen.Sum();
		}

		/// <summary>
		/// Optionaler Parameter (hier z): Gibt Parametern Standardwerte, müssen bei Aufruf der Funktion nicht übergeben werden
		/// </summary>
		static double Subtrahiere(double x, double y, double z = 0)
		{
			return x - y - z;
		}

		/// <summary>
		/// Über den Boolean wird gesteuert wie die Funktion arbeitet (Sonderfall)
		/// </summary>
		static double SubtrahiereOderAddiere(double x, double y, bool addiere = false)
		{
			//if (addiere)
			//{
			//	return x + y;
			//}
			//else
			//{
			//	return x - y;
			//}
			return addiere ? x + y : x - y;
		}

		/// <summary>
		/// Über optionale Parameter kann eine Funktion konfiguriert werden
		/// </summary>
		static void Test(int x = 0, int y = 0, int z = 0, int w = 0) { }

		/// <summary>
		/// Diese Funktion erzeugt eine Person
		/// </summary>
		static void Person(string vorname = default, string nachname = default, DateTime gebDat = default, string adresse = default, string job = default) { }

		/// <summary>
		/// out: Gibt die Möglichkeit, mehrere Werte zurück zu geben
		/// </summary>
		static int AddiereUndSubtrahiere(int x, int y, out int diff)
		{
			diff = x - y;
			return x + y;
		}

		/// <summary>
		/// Tupel: Typ der mehrere Werte halten kann, ähnlich wie ein Array, aber einfacher zum Bearbeiten ist
		/// </summary>
		static (int, int) AddiereUndSubtrahiere(int x, int y)
		{
			return (x + y, x - y);
		}

		static void PrintZahl(int z)
		{
            Console.WriteLine(z);
			return; //Aus Funktion herausspringen / Funktion beenden (häufig in Kombination mit einer if)
            Console.WriteLine(z);
        }

		/// <summary>
		/// Enum als Parameter um eine Sicherheit zu bieten bei den Parametern
		/// </summary>
		static string PrintWochentag(DayOfWeek tag)
		{
			switch (tag)
			{
				case DayOfWeek.Monday: return "Montag"; //Bei einem Switch mit return muss kein break verwendet werden
				case DayOfWeek.Tuesday: return "Dienstag";
				case DayOfWeek.Wednesday: return "Mittwoch";
				case DayOfWeek.Thursday: return "Donnerstag";
				case DayOfWeek.Friday: return "Freitag";
				case DayOfWeek.Saturday: return "Samstag";
				case DayOfWeek.Sunday: return "Sonntag";
				default: return "Fehler"; //Alle Code Pfade müssen einen Wert zurückgeben, daher default notwendig
			}
		}
	}
}