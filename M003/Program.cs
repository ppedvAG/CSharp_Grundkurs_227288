namespace M003
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region Arrays
			//Array: Eine Variable, die mehrere Werte halten kann (statt einem)
			int[] zahlen; //Arrayvariable mit [] nach Typ (<Typ>[])
			zahlen = new int[10]; //Array mit Länge 10 erstellen (Indizes von 0 bis 9)
			zahlen[2] = 5; //An die Stelle 2 den Wert 5 schreiben
			//zahlen[10] = 10; //Nicht möglich, da Indizes im Array von 0 bis Länge - 1 gehen
			Console.WriteLine(zahlen[2]);

            Console.WriteLine(zahlen.Length); //Die Länge des Arrays (Anzahl Plätze -> 10)
            Console.WriteLine(zahlen.Contains(5)); //Überprüft, ob der gegebene Wert im Array enthalten ist -> true
            Console.WriteLine(zahlen.Contains(20)); //false

			int[] zahlenDirekt = new int[] { 1, 2, 3, 4, 5 }; //Direkte Initialisierung (schreibt die Werte von Anfang an in das Array), Länge 5, Indizes 0-4
			int[] zahlenDirektKuerzer = new[] { 1, 2, 3, 4, 5 }; //Kurzschreibweise (wie oben, nur kurz)
			int[] zahlenDirektNochKuerzer = { 1, 2, 3, 4, 5 }; //Kürzeste Schreibweise

			//Mehrdimensionale Arrays: Arrays mit mehreren Koordinaten (X, Y, Z, ...)
			int[,] zweiDArray = new int[3, 3]; //Matrix (3x3), Deklaration mit Komma in der Klammer (Kommas in der Klammer bestimmen die Dimensionen)
			zweiDArray[1, 1] = 4;
			Console.WriteLine(zweiDArray[1, 1]);

			zweiDArray = new int[,] //Direkte Initialisierung
			{
				{ 1, 2, 3 },
				{ 4, 5, 6 },
				{ 7, 8, 9 }
			};

            Console.WriteLine(zweiDArray.Length); //Summe der Elemente (3 * 3 = 9)
            Console.WriteLine(zweiDArray.Rank); //Anzahl Dimensionen (hier 2)
            Console.WriteLine(zweiDArray.GetLength(0)); //Länge der X-Koordinate (3)
            Console.WriteLine(zweiDArray.GetLength(1)); //Länge der Y-Koordinate (3)
			#endregion

			#region Bedingungen
			//Vergleichsoperatoren: ==, !=, <, >, <=, >=
			//a == b oder a >= b oder ...

			//Logische Operatoren (Bedingungen Verbinden): &&, ||, !, ^
			//Verbindungen: a == b && a == c

			int z1 = 5;
			int z2 = 8;

			if (z1 == 5)
			{
				//Wenn z1 5 ist, komme ich hier herein
			}
			else
			{
				//Wenn z1 nicht 5 ist, komme ich stattdessen hier herein
			}

			if (z1 < z2)
			{
				//Wenn z1 kleiner als z2
			}
			else if (z1 > z2)
			{
				//Wenn z1 größer als z2
			}
			else
			{
				//Wenn z1 nicht kleiner oder größer als z2 (hier wenn die Zahlen gleich sind)
			}

			if (z1 == 5 && z2 == 8)
			{
				//Wenn z1 5 und z2 8 (beide Bedingungen müssen gegeben sein)
			}

			if (z1 == 5 || z2 == 8)
			{
				//Wenn z1 gleich 5 oder z2 gleich 8 (eine von beiden Bedingungen muss gegeben sein, oder beide)
			}

			if (z1 == 5 ^ z2 == 8)
			{
				//Wenn z1 gleich 5 oder z2 gleich 8 (eine von beiden Bedingungen muss gegeben sein, aber nicht beide)
			}

			if (zahlen.Contains(5)) //Ist die Zahl 5 enthalten Ja/Nein
			{
				//Wenn zahlen 5 enthält
			}
			else
			{
				//Wenn zahlen nicht 5 enthält
			}

			if (!zahlen.Contains(5)) //Ist die Zahl 5 nicht enthalten Ja/Nein
			{
				//Wenn zahlen nicht 5 enthält
			}
			else
			{
				//Wenn zahlen 5 enthält
			}

			//Fragezeichen Operator (Ternary Operator): if's vereinfachen
			if (zahlen.Contains(5))
			{
                Console.WriteLine("Zahlen enthält 5");
            }
			else
			{
				Console.WriteLine("Zahlen enthält nicht 5");
			}

			//Bei einzeiliges if's und elses können die Klammern weggelassen werden
			if (zahlen.Contains(5))
				Console.WriteLine("Zahlen enthält 5");
			else
				Console.WriteLine("Zahlen enthält nicht 5");

			//? ist die if, : ist die else
            Console.WriteLine(zahlen.Contains(5) ? "Zahlen enthält 5" : "Zahlen enthält nicht 5");

            Console.WriteLine(z1 == z2 ? "z1 ist gleich z2" : "z1 ist nicht gleich z2");

			string enthaelt5 = zahlen.Contains(5) ? "Zahlen enthält 5" : "Zahlen enthält nicht 5";
            Console.WriteLine(enthaelt5);
            #endregion
        }
	}
}