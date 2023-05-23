namespace M004
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region Schleifen
			int a = 0;
			int b = 10;
			while (a < b) //Schleife läuft solange wie die Bedingung true ist
			{
				Console.WriteLine($"while: {a}");
				if (a == 5)
					break; //break: Beendet die Schleife, mit if kombinieren um das Ende der Schleife zu steuern
				a++;
			} //Nach jedem Ende der Schleife wird die Bedingung nochmal geprüft

			int c = 0;
			int d = 10;
			do //Wird mindestens einmal ausgeführt, auch wenn die Bedingung von Anfang an false ist
			{
				c++;
				if (c == 5)
					continue; //continue: Überspringe den Rest der Schleife und gehe in den Kopf zurück
				Console.WriteLine($"do-while: {c}");
			}
			while (c < d);

			//while (true) { } //Endlosschleife

			c = 0;

			while (true) //do-while mit while(true) darstellen
			{
				c++;
				if (c == 5)
					continue;
				Console.WriteLine($"while-true: {c}");

				if (c >= d)
					break;
			}

			//for + Tab + Tab
			//Drei Teile: Variablendeklaration (int i = 0), Bedingung (i < 10), Inkrement (i++)
			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine($"for: {i}");
			}

			//forr + Tab + Tab
			for (int i = 9; i >= 0; i--)
			{
				Console.WriteLine($"forr: {i}");
			}

			//Array durchgehen
			int[] zahlen = { 1, 2, 3, 4, 5, 6, 7, 8 };
			for (int i = 0; i < zahlen.Length; i++) //Array durchgehen und ausgeben
			{
				Console.WriteLine(zahlen[i]); //for Schleife ist fehleranfällig bei Arrays
			}

			//foreach + Tab + Tab
			foreach (int item in zahlen) //Array durchgehen aber kann nicht daneben greifen, weil kein Index
			{
				Console.WriteLine(item);
			}

			foreach (int item in zahlen) //Einzeilige Schleifen können auch ohne Klammern geschrieben werden
				Console.WriteLine(item);
			#endregion

			#region Enums
			//Enum: Fixe Zustände in einem eigenen Typen speichern
			Wochentag tag = Wochentag.Di; //Variable die nur bestimmte Werte haben kann

			if (tag == Wochentag.Do)
			{

			}

			//Jeder Enum Wert hat einen Int dahinter (Mo = 0, Di = 1, ...)
			int x = 2;
			Wochentag castTag = (Wochentag) x; //Direkte Umwandlung von int zu Enumwerten
			int y = (int) tag; //Tag von oben zu int umwandeln (Di -> 1)

			//String zu Enum Wert konvertieren, Typ muss in spitzer Klammer angegeben werden
			Wochentag parseTag = Enum.Parse<Wochentag>("Mo");
			Wochentag parseTagInt = Enum.Parse<Wochentag>("1"); //Enum.Parse kann auch Zahlen konvertieren

			Wochentag[] tage = Enum.GetValues<Wochentag>(); //Alle Enumwerte in ein Array packen
			foreach (Wochentag t in tage)
                Console.WriteLine(t);
			#endregion

			#region Switch
			//If-ElseIf Baum (unschön)
			if (tag == Wochentag.Mo)
                Console.WriteLine("Wochenanfang");
			else if (tag == Wochentag.Di || tag == Wochentag.Mi || tag == Wochentag.Do || tag == Wochentag.Fr)
                Console.WriteLine("Wochentag");
			else if (tag == Wochentag.Sa || tag == Wochentag.So)
                Console.WriteLine("Wochenende");
			else
                Console.WriteLine("Fehler");

			//Strg + .: Schnelloptionen für den Code unter dem Cursor aufrufen
			switch (tag) //Hier angeben welche Variable überprüft werden soll
			{
				case Wochentag.Mo: //Eine if
					Console.WriteLine("Wochenanfang");
					break; //Am Ende jedes Cases ein break machen
				case Wochentag.Di:
				case Wochentag.Mi:
				case Wochentag.Do:
				case Wochentag.Fr: //Eine Else-If mit ||, Cases werden hier kombiniert
					Console.WriteLine("Wochentag");
					break;
				case Wochentag.Sa:
				case Wochentag.So:
					Console.WriteLine("Wochenende");
					break;
				default: //Das Else
					Console.WriteLine("Fehler");
					break;
			}

			int z = 0;
			switch (z)
			{
				case 1:
                    Console.WriteLine("Eins");
					break;
				case 2:
                    Console.WriteLine("Zwei");
					break;
				case 3:
                    Console.WriteLine("Drei");
					break;
				default:
                    Console.WriteLine("Andere Zahl");
					break;
            }

			//switch mit boolescher Logik
			switch (tag)
			{
				//and und or statt && und ||
				case >= Wochentag.Mo and <= Wochentag.Fr:
                    Console.WriteLine("Wochentag");
					break;
				case Wochentag.Sa or Wochentag.So:
                    Console.WriteLine("Wochenende");
					break;
            }

			//Strg + Leertaste: Vorschläge öffnen
			#endregion
		}
	}

	enum Wochentag
	{
		Mo, Di, Mi, Do, Fr, Sa, So
	}
}