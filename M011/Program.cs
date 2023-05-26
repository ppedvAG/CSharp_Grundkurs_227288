namespace M011;

internal class Program
{
	static void Main(string[] args)
	{
		//Generisches Typargument: Gibt die Möglichkeit, einen Typen für die gesamte Klasse vorzugeben
		//Passt bei allen Vorkommnissen von T den Typen an auf den von uns definierten Typen
		//<int>: T -> int, Add(T) -> Add(int), Remove(T) -> Remove(int)

		//List: Funktioniert wie Array, hat aber keine fixe Größe und keine Ordnung
		List<int> list = new List<int>();
		list.Add(1); //T wird durch int ersetzt

		list.Remove(1);

		List<string> strList = new List<string>();
		strList.Add("1");
		
        Console.WriteLine(list.Count); //Count = Length beim Array
		list[2] = 4; //Angreifen wie bei Array
		Console.WriteLine(list[2]); //Auslesen wie bei Array

		foreach (int i in list)
		{
            Console.WriteLine(i);
        }

		//Dictionary: Liste von Key-Value Paaren
		//Wird verwendet um Zuordnungen zu speichern
		Dictionary<string, int> einwohnerzahlen = new Dictionary<string, int>();
		einwohnerzahlen.Add("Wien", 2_000_000); //Zwei Parameter: Key = string, Value = int
		einwohnerzahlen.Add("Berlin", 3_650_000);
		einwohnerzahlen.Add("Paris", 2_160_000);
		//einwohnerzahlen.Add("Paris", 2_160_000); //Keys können nicht zweimal vorkommen

		if (!einwohnerzahlen.ContainsKey("Paris")) //Schauen ob ein Key schon enthalten ist
		{

		}

		Console.WriteLine(einwohnerzahlen["Wien"]); //Elemente angreifen über den Key (wie bei Array) -> Ergebnis: die Zahl

		foreach (var kv in einwohnerzahlen) //Einträge durchgehen
		{
			Console.WriteLine(kv.Key + " " + kv.Value); //Einträge aufschlüsseln
		}
    }
}