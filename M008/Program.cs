namespace M008;

internal class Program
{
	static void Main(string[] args)
	{
		Mensch m = new Mensch(23, "Max");
        Console.WriteLine(m.Alter); //Mensch hat von Lebewesen das Alter geerbt
		m.WasBinIch(); //WasBinIch wird auch von oben weitergegeben

		Katze k = new Katze(5, "Weiß");
		k.WasBinIch();
    }
}

/// <summary>
/// Basisklasse für verschiedene Lebewesen
/// Diese Klasse gibt ihre Member (Variablen, Properties, Funktionen, ...) an die Unterklassen weiter
/// </summary>
public class Lebewesen
{
	public int Alter { get; set; }

    public Lebewesen(int Alter)
    {
		this.Alter = Alter;
    }

	/// <summary>
	/// In Lebewesen wurde jetzt eine Basisimplementation angelegt, diese kann in Unterklassen überschrieben werden
	/// </summary>
	public virtual void WasBinIch()
	{
        Console.Write("Ich bin ein Lebewesen");
    }
}

/// <summary>
/// Mit : Lebewesen eine Vererbung zu Lebewesen herstellen
/// -> Mensch ist ein Lebewesen
/// </summary>
public class Mensch : Lebewesen
{
	public string Name { get; set; }

	/// <summary>
	/// Konstruktoren in Unterklassen müssen mit Konstruktoren in Oberklassen verkettet sein</br>
	/// Mit Strg + . den Konstruktor generieren</br>
	/// Hier in den generierten Konstruktor die neuen Felder einfach hinzufügen
	/// </summary>
	public Mensch(int Alter, string Name) : base(Alter) //base: Äquivalent zu this, aber in Vererbungshierarchien statt nur innerhalb der Klasse (greift eine Klasse nach oben)
	{
		this.Name = Name;
	}

	/// <summary>
	/// Hier in Mensch mittels override die Methode von oben überschreiben und eine eigene Implementation definieren
	/// override schreiben und dann VS arbeiten lassen
	/// </summary>
	public override void WasBinIch()
	{
		base.WasBinIch(); //base.WasBinIch() führt den Code der Oberklasse aus
        Console.WriteLine($" und heiße {Name}");
    }
}

public class Katze : Lebewesen
{
	public string Fellfarbe { get; set; }

	public Katze(int Alter, string Fellfarbe) : base(Alter)
	{
		this.Fellfarbe = Fellfarbe;
	}

	public override void WasBinIch()
	{
        Console.WriteLine("Ich bin eine Katze");
    }
}

/// <summary>
/// Tiger ist eine Unterklasse von Katze, Katze ist einer Unterklasse von Lebewesen -> Tiger ist ein Lebewesen
/// </summary>
public class Tiger : Katze
{
	public Tiger(int Alter, string Fellfarbe) : base(Alter, Fellfarbe)
	{
	}
}