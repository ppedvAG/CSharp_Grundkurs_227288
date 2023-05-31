using System.Diagnostics;

namespace M012;

internal class Program
{
	static void Main(string[] args)
	{
		#region Einfaches Linq
		//Linq: Ermöglicht eine einfache Filterung von Listen (Array, List, Dictionary, ...)
		//-> Alle Klassen die von IEnumerable erben
		//Alle Linq Funktionen gehen über die Liste mit einer Schleife darüber und führen dann ihren Code aus

		//Enumerable.Range: Erzeugt eine Liste von <Start> mit <Anzahl> Elementen
		List<int> ints = Enumerable.Range(1, 20).ToList(); //Liste von 1-20

		Console.WriteLine(ints.Average());
		Console.WriteLine(ints.Sum());
		Console.WriteLine(ints.Min());
		Console.WriteLine(ints.Max());

		Console.WriteLine(ints.First()); //Gibt das erste Element der Liste zurück, Fehler wenn die Liste leer ist
		Console.WriteLine(ints.Last()); //Gibt das letzte Element der Liste zurück, Fehler wenn die Liste leer ist

		Console.WriteLine(ints.FirstOrDefault()); //Gibt das erste Element der Liste zurück, null wenn die Liste leer ist
		Console.WriteLine(ints.LastOrDefault()); //Gibt das letzte Element der Liste zurück, null wenn die Liste leer ist

		//Bei First/Last können auch Bedingungen mitgegeben werden
		//-> Gib das erste/letzte Element anhand einer Bedingung zurück

		//Console.WriteLine(ints.First(e => e % 50 == 0)); //Fehler
		Console.WriteLine(ints.FirstOrDefault(e => e % 50 == 0)); //0

		//Lambda-Expression (e => ...): Gibt die Bedingung an die die Funktion verwenden soll
		//e => ... wird in Linq Funktion generell immer benötigt
		//e ist nur der Variablenname, kann beliebig gewählt werden
		#endregion

		List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		{
			new Fahrzeug(251, FahrzeugMarke.BMW),
			new Fahrzeug(274, FahrzeugMarke.BMW),
			new Fahrzeug(146, FahrzeugMarke.BMW),
			new Fahrzeug(208, FahrzeugMarke.Audi),
			new Fahrzeug(189, FahrzeugMarke.Audi),
			new Fahrzeug(133, FahrzeugMarke.VW),
			new Fahrzeug(253, FahrzeugMarke.VW),
			new Fahrzeug(304, FahrzeugMarke.BMW),
			new Fahrzeug(151, FahrzeugMarke.VW),
			new Fahrzeug(250, FahrzeugMarke.VW),
			new Fahrzeug(217, FahrzeugMarke.Audi),
			new Fahrzeug(125, FahrzeugMarke.Audi)
		};

		#region Vergleich Linq-Schreibweisen
		//Alle BMWs finden
		List<Fahrzeug> bmwsForEach = new();
		foreach (Fahrzeug f in fahrzeuge)
			if (f.Marke == FahrzeugMarke.BMW)
				bmwsForEach.Add(f);

		//Standard-Linq: SQL-ähnliche Schreibweise (alt)
		List<Fahrzeug> bmwsAlt = (from f in fahrzeuge
								  where f.Marke == FahrzeugMarke.BMW
								  select f).ToList();

		//Methodenkette
		List<Fahrzeug> bmwsNeu = fahrzeuge.Where(e => e.Marke == FahrzeugMarke.BMW).ToList();
		#endregion

		#region Linq mit Objektliste
		//Alle Fahrzeuge finden, die mindestens 200km/h fahren können
		fahrzeuge.Where(e => e.MaxV >= 200);

		//Alle VWs finden
		fahrzeuge.Where(e => e.Marke == FahrzeugMarke.VW);

		//Alle VWs finden die mindestens 200km/h fahren können
		fahrzeuge.Where(e => e.Marke == FahrzeugMarke.VW).Where(e => e.MaxV >= 200);
		fahrzeuge.Where(e => e.Marke == FahrzeugMarke.VW && e.MaxV >= 200); //Performanter

		//Autos nach Marke sortieren
		fahrzeuge.OrderBy(e => e.Marke); //Originale Liste wird nicht verändert -> gibt eine neue sortierte Liste

		//Autos nach Marke und danach nach Geschwindigkeit sortieren
		fahrzeuge.OrderBy(e => e.Marke).ThenBy(e => e.MaxV); //Mit ThenBy ein weiteres Sortierkriterium angeben

		//Andere Sortierrichtung
		fahrzeuge.OrderByDescending(e => e.Marke).ThenByDescending(e => e.MaxV);

		//Liste von Geschwindigkeiten erzeugen
		fahrzeuge.Select(e => e.MaxV); //Neue Liste extrahieren anhand eines Felds -> int Liste

		//Die Durchschnittsgeschwindigkeit aller Fahrzeuge
		fahrzeuge.Select(e => e.MaxV).Average();

		//Fahren alle unsere Fahrzeuge mindestens 200km/h?
		fahrzeuge.All(e => e.MaxV >= 200); //bool als Ergebnis -> false
		if (fahrzeuge.All(e => e.MaxV >= 200))
		{
            Console.WriteLine("Alle Fahrzeuge fahren mindestens 200km/h");
        }

		//Fährt mindestens eins unserer Fahrzeuge mindestens 200km/h?
		fahrzeuge.Any(e => e.MaxV >= 200); //bool als Ergebnis -> true

		//Enthält die Liste Elemente?
		fahrzeuge.Any(); //fahrzeuge.Count > 0

		//Wieviele Audis haben wir?
		fahrzeuge.Count(e => e.Marke == FahrzeugMarke.Audi); //4

		//Was ist das Fahrzeug mit der kleinsten Geschwindigkeit?
		fahrzeuge.MinBy(e => e.MaxV); //Das Fahrzeug mit der kleinsten Geschwindigkeit -> Fahrzeug
		fahrzeuge.Min(e => e.MaxV); //Die kleinste Geschwindigkeit -> int

		//Die Durchschnittsgeschwindigkeit aller Fahrzeuge
		fahrzeuge.Select(e => e.MaxV).Average();
		fahrzeuge.Average(e => e.MaxV); //Auch bei Average kann in der Klammer ein Selektor angegeben werden

		//Was ist die Summe aller Geschwindigkeiten?
		fahrzeuge.Sum(e => e.MaxV);

		//Was ist die Durchschnittsgeschwindigkeit aller VWs?
		fahrzeuge
			.Where(e => e.Marke == FahrzeugMarke.VW)
			.Average(e => e.MaxV);

		//IEnumerable ist ein ziemlich umständlicher Typ zum mit Arbeiten -> ToList() für die Umwandlung zur List
		IEnumerable<Fahrzeug> fzg = fahrzeuge.Where(e => e.Marke == FahrzeugMarke.VW);
		//fzg[0]
		//fzg.Count
		#endregion

		#region Erweiterungsmethoden
		//Erweiterungsmethode: Funktion, die auf einen beliebigen Typen angehängt werden kann -> Code an beliebige Objekte anhängen
		//z.B.: Source Code von int indirekt anpassen
		int x = 53729;
		x.Quersumme();
        Console.WriteLine(3257.Quersumme());
        #endregion
    }
}

[DebuggerDisplay("Marke: {Marke}, MaxV: {MaxV}")]
public class Fahrzeug
{
	public int MaxV { get; set; }

	public FahrzeugMarke Marke { get; set; }

	public Fahrzeug(int maxV, FahrzeugMarke marke)
	{
		MaxV = maxV;
		Marke = marke;
	}
}

public enum FahrzeugMarke
{
	Audi, BMW, VW
}