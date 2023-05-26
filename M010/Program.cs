using System.Text;

namespace M010;

internal class Program
{
	static void Main(string[] args)
	{
		Console.OutputEncoding = Encoding.UTF8;

		Mensch m = new Mensch();
		m.Job = "Softwareentwickler";
		m.Gehalt = 5000;
		//m.Lohnauszahlung();
        Console.WriteLine(m.Jahresgehalt());
        Console.WriteLine(m.LohnProStunde(m.Gehalt));

		//IArbeit Variable die alle Objekte vom Typ IArbeit halten kann
		IArbeit arbeit = m;
		arbeit.Lohnauszahlung(); //Hier passt nur ein Objekt an diese Variable, das selbst auch das Interface hat -> alle Methoden vom Interface hat

		ITeilzeitArbeit teilzeitArbeit = m;
		teilzeitArbeit.Lohnauszahlung();

		//IList: Basis von allen Listen, gibt Methoden vor zum Bearbeiten von Listen
		//IEnumerable: Basis von IList, gibt den Basismechanismus von allen Listen vor
		IEnumerable<int> e1 = new int[10];
		IEnumerable<int> e2 = new List<int>();
		IEnumerable<KeyValuePair<string, int>> e3 = new Dictionary<string, int>();

		Test(e1);
		Test(e2);
		Test(e3);

		void Test<T>(IEnumerable<T> e) { }
    }
}

public class Lebewesen { }

public class Mensch : Lebewesen, IArbeit, ITeilzeitArbeit
{
	/// <summary>
	/// Job bezieht sich auf beide Interfaces
	/// </summary>
	public string Job { get; set; } //Auto-Property

	//Full Property
	private int gehalt;

	/// <summary>
	/// Gehalt bezieht sich auf beide Interfaces
	/// </summary>
	public int Gehalt
	{
		get => gehalt;
		set => gehalt = value;
	}

	/// <summary>
	/// Diese Methode bezieht sich nur auf IArbeit (40 Stunden)
	/// </summary>
	void IArbeit.Lohnauszahlung()
	{
        Console.WriteLine($"Dieser Mitarbeiter hat ein Gehalt von {Gehalt}€ für den Job {Job} erhalten. " +
			$"Er arbeitet {IArbeit.Wochenstunden} Stunden pro Woche.");
    }

	/// <summary>
	/// Diese Methode bezieht sich nur auf ITeilzeitArbeit (20 Stunden)
	/// </summary>
	void ITeilzeitArbeit.Lohnauszahlung()
	{
		Console.WriteLine($"Dieser Mitarbeiter hat ein Gehalt von {Gehalt / 2.0}€ für den Job {Job} erhalten. " +
			$"Er arbeitet {ITeilzeitArbeit.Wochenstunden} Stunden pro Woche.");
	}

	public int Jahresgehalt()
	{
		return gehalt * 12;
	}

	public double LohnProStunde(int lohn)
	{
		return lohn / (IArbeit.Wochenstunden * 4.0);
	}
}

/// <summary>
/// Interface: Eigener Typ, der eine Struktur vorgibt (Properties, Methoden)<br/>
/// Die Klassen das Interface implementieren sollen, müssen alle Properties und Methoden vom Interface implementieren (mit einer Implementation)<br/>
/// Wie bei Abstrakter Klasse nur eine Struktur (kein Code)
/// </summary>
public interface IArbeit
{
	public static readonly int Wochenstunden = 40; //Statisches Feld im Interface über IArbeit.Wochenstunden, globales Feld für alle Klassen die dieses Interface haben

	public string Job { get; set; }

	public int Gehalt { get; set; }

	void Lohnauszahlung();

	int Jahresgehalt();

	double LohnProStunde(int lohn);

	public void Test()
	{
		//Bad Practice
	}
}

public interface ITeilzeitArbeit
{
	public static readonly int Wochenstunden = 20;

	public string Job { get; set; }

	public int Gehalt { get; set; }

	void Lohnauszahlung();
}