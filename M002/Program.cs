namespace M002
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region Variablen
			//Variable: Feld das einen Wert halten kann, besteht aus Typ und Name
			int zahl; //int: Ganze Zahl
			zahl = 5; //Wert in eine Variable schreiben

            Console.WriteLine(zahl); //cw + Tab

			int zahlMalZwei = zahl * 2; //Zahl von oben wiederverwenden
            Console.WriteLine(zahlMalZwei);

			string wort = "Hallo"; //string: Text, doppelte Hochkomma
			char buchstabe = 'A'; //char: einzelnes Zeichen, einzelne Hochkomma

			//Kommazahlen: float, double, decimal
			double kommazahl = 325.24568347;
			float floatZahl = 3428.23587f; //Kommazahlen sind standardmäßig doubles, mit F am Ende zu einem float konvertieren
			decimal decimalZahl = 4398.328475m; //Kommazahlen sind standardmäßig doubles, mit M am Ende zu einem Decimal konvertieren

			long longZahl = 35928792438;

			//bool: Wahr-/Falschwert (true oder false)
			bool b = true;
			b = false;
			#endregion

			#region Strings
			//Strings verbinden
			string kombi = "Das Wort ist: " + wort;
			Console.WriteLine(kombi);

			string kombination = "Das Wort ist: " + wort + ", die Zahl ist: " + zahl + ", der Boolean ist: " + b; //Anstrengend
            Console.WriteLine(kombination);

			//String Interpolation: Code in Strings einbinden, wird häufig verwendet um Strings zusammenzubauen
			string interpolation = $"Das Wort ist: {wort}, die Zahl ist: {zahl}, der Boolean ist: {b}";
            Console.WriteLine(interpolation);

			//Escape-Sequenzen: Gibt die Möglichkeit, besondere Zeichen in einen String einzubauen
			//\n: Zeilenumbruch, \t: Tab
			//https://docs.microsoft.com/en-us/cpp/c-language/escape-sequences?view=msvc-170
			Console.WriteLine("Umbruch \n \t Umbruch");
            Console.WriteLine("Ein doppeltes Hochkomma: \" ");
			char einzeln = '\'';
			char leer = '\0';

			//Verbatim-String: Ignoriert Escape-Sequenzen, nützlich bei Pfaden
			string pfad = @"C:\Users\lk3\source\repos\CSharp_Grundkurs_2023_05_22";
			string backslash = "\\"; //-> Wird zu einem einzelnen Backslash konvertiert
            Console.WriteLine(backslash);
			#endregion

			#region	Eingabe
			////Console.ReadLine(): Warte auf eine Eingabe vom Benutzer
			//string eingabe = Console.ReadLine(); //Eingabe wird in die Variable geschrieben
			//Console.WriteLine($"Deine Eingabe ist: {eingabe}");

			////Parse: Konvertiert einen String zum entsprechenden Typen
			//int eingabeZahl = int.Parse(eingabe); //Eingabe vom Benutzer zu einer Zahl konvertieren
			//Console.WriteLine($"Die eingegebene Zahl mal Zwei ist: {eingabeZahl * 2}");

			//double eingabeDouble = double.Parse(eingabe); //Eingabe vom Benutzer zu einer Kommazahl konvertieren
			//Console.WriteLine($"Die eingegebene Kommazahl ist: {eingabeDouble}");
			#endregion

			#region Konvertierungen
			//String -> anderer Typ: Parse
			//anderer Typ -> String: ToString()
			//anderer Typ -> anderer Typ: Typecast, Cast, Casting
			int zahlToString = 438;
            Console.WriteLine(zahlToString.ToString());

			long grosseZahl = 3845792534683579827;
			short kurzeZahl = (short) grosseZahl; //(short) -> Der Cast, die Umwandlung von long zu short

			double grosseKommazahl = 5347823298579823759.243578;
			float kleineKommazahl = (float) grosseKommazahl; //(float) -> Umwandlung erzwingen

			double kommaZ = 57.54387;
			int x = (int) kommaZ; //Kommazahl nicht direkt kompatibel mit ganzer Zahl -> Umwandlung erzwingen
			#endregion

			#region Arithmetik
			int z1 = 5;
			int z2 = 8;

            Console.WriteLine(z1 + z2); //Ergebnis wird berechnet, Variablen bleiben unverändert
			z1 += z2; //Ergebnis wird berechnet und in z1 geschrieben

            Console.WriteLine(z1 % z2); //Modulo: Rest einer Division, x % 2 -> ist eine Zahl gerade oder nicht?

			z1 += 1;
			z1++; //Erhöhe die Zahl um 1, selbiges wie oben
			z1--;

			double d = 3985725.23957239457;
			//Rundungsfunktionen: Floor, Ceiling, Round
			Math.Floor(d); //Floor: Immer abrunden, originale Zahl wird nicht verändert
			Math.Ceiling(d); //Ceiling: Immer aufrunden
			Math.Round(d); //Rundet auf oder ab, bei .5 wird zur nächsten geraden Zahl gerundet
			Math.Round(4.5); //4
			Math.Round(5.5); //6

			double zweiKomma = Math.Round(d, 2); //Auf X Kommastellen runden

            Console.WriteLine(8 / 5); //Int-Division: da zwei Ints als Argumente (Ergebnis 1 statt 1.6)
            Console.WriteLine(8d / 5); //Kommadivision erzwingen, wenn einer beiden Zahlen eine Kommazahl ist
			Console.WriteLine(8.0 / 5);
            Console.WriteLine(8f / 5);
			Console.WriteLine((double) z1 / z2); //z1 temporär zu einem double konvertieren
            #endregion
        }
	}
}