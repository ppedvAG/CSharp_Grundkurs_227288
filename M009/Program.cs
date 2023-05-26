namespace M009;

internal class Program
{
	static void Main(string[] args)
	{
		Mensch m = new Mensch(0, ""); //Variablentyp Mensch, kann alle Objekte vom Typ Mensch oder einer Unterklasse vom Typ Mensch halten

		Lebewesen l = new Mensch(0, ""); //Variablentyp Lebewesen, kann alle Objekte vom Typ Lebewesen oder einer Unterklasse vom Typ Lebewesen halten
		//l = new Lebewesen(0);
		l = new Katze(0, "");

		object o = new Mensch(0, ""); //Variablentyp Object, kann alle Objekte halten
		o = 123; //int
		o = "123"; //string
		o = false; //bool

		m = (Mensch) l; //Kompatibel mit Mensch über einen Cast, wenn an l das korrekte Objekt angehängt ist
		l = m; //Immer möglich, da an m nur eine Unterklasse von l angehängt sein kann
		l = (Lebewesen) o; //Funktioniert nur, wenn an o ein Lebewesen angehängt ist

		//.GetType(): Gibt den Typen des Objekts der an der Variable hängt zurück
		//typeof(<Klassenname>): Gibt mir ein Typ Objekt über den Klassennamen
		Type mt = m.GetType(); //Type Objekt des Mensch Typs
		Type ct = typeof(Lebewesen); //Type Objekt des Lebewesen Typs

		#region Exakter Typvergleich
		if (m.GetType() == typeof(Mensch)) //Hängt an der m Variable ein Objekt vom Typ Mensch?
		{
			//true
		}

		if (l.GetType() == typeof(Mensch)) //Hängt an der l Variable ein Objekt vom Typ Mensch?
		{
			//false -> Katze Objekt hängt momentan daran
		}

		if (l.GetType() == typeof(Katze))
		{
			//true
		}
		#endregion

		#region Vererbungshiearchie Typvergleich
		if (m is Mensch) //Hängt an der m Variable ein Objekt vom Typ Mensch oder einer Unterklasse vom Typ Mensch?
		{
			//true
		}

		if (l is Katze) //Hängt an der l Variable ein Objekt vom Typ Katze oder einer Unterklasse vom Typ Katze?
		{
			//true
		}

		if (l is Lebewesen) //Hängt an der l Variable ein Objekt vom Typ Lebewesen oder einer Unterklasse vom Typ Lebewesen?
		{
			//true
		}
		#endregion

		//Praktisches Beispiel
		Lebewesen[] lebewesen = new Lebewesen[3];
		lebewesen[0] = new Mensch(0, "");
		lebewesen[1] = new Katze(0, "");
		lebewesen[2] = new Tiger(0, "");
		//Lebewesen kann alle Lebewesen halten (= Mensch, Katze oder Tiger)

		foreach (Lebewesen leb in lebewesen)
		{
			if (leb is Mensch) //Ist das derzeitige Lebewesen ein Mensch?
			{
				Mensch mensch = (Mensch) leb; //Umwandlung zu Mensch, nachdem wir jetzt wissen das das Objekt ein Mensch ist
                Console.WriteLine("Das derzeitige Lebewesen ist ein Mensch oder eine Unterklasse von Mensch");
				mensch.Sprechen(); //Mensch-spezifische Methode ausführen
            }

			if (leb.GetType() == typeof(Katze))
			{
				Katze k = (Katze) leb;
				Console.WriteLine("Das derzeitige Lebewesen ist eine Katze");
				k.Bewegen();
			}

			if (leb is Tiger t) //Schneller Cast, selbiges wie oben nur in der is Zeile
			{
				//Tiger t = (Tiger) leb; //Wird gespart durch schnellen Cast
				Console.WriteLine("Das derzeitige Lebewesen ist ein Tiger oder eine Unterklasse von Tiger");
				t.Bewegen();
			}
		}

		long x = 329578429357898234;
		Test3((int) x);

		short s = 234;
		Test3(s);
	}

	/// <summary>
	/// Diese Funktion nimmt ein Lebewesen (Mensch, Katze oder Tiger), diese Funktion muss wahrscheinlich schauen welchen Typen das Objekt hat
	/// </summary>
	public void Test(Lebewesen l) { }

	public Lebewesen Test2() { return null; }

	public static void Test3(int x) { }
}

/// <summary>
/// abstract: Gibt eine Strukturklasse vor. Die Klasse selbst kann nurnoch für Vererbung verwendet werden (kann nicht mehr erstellt werden) -> new Lebewesen() ist nicht möglich</br>
/// Durch abstrakte Methoden und Properties kann eine Struktur bereitgestellt werden</br>
/// Es gibt auf der Welt kein Lebewesen das nur als Lebewesen bezeichnet wird, jedes Lebewesen hat eine bestimmte Bezeichnung (Mensch, Hund, Katze, Ameise, Spinne, ...)
/// </summary>
public abstract class Lebewesen
{
	public int Alter { get; set; }

	public Lebewesen(int Alter)
	{
		this.Alter = Alter;
	}

	/// <summary>
	/// Abstrakte Methoden haben keinen Body (keine Basisimplementation)</br>
	/// Alle Unterklassen müssen eine Implementation dieser Methode durchführen
	/// </summary>
	public abstract void WasBinIch();
}

public class Mensch : Lebewesen
{
	public string Name { get; set; }

	public Mensch(int Alter, string Name) : base(Alter)
	{
		this.Name = Name;
	}

	public override void WasBinIch()
	{
		Console.WriteLine($"Ich bin ein Mensch und heiße {Name}");
	}

	public void Sprechen()
	{
        Console.WriteLine("Hallo");
    }
}

public class Katze : Lebewesen
{
	public string Fellfarbe { get; set; }

	public Katze(int Alter, string Fellfarbe) : base(Alter)
	{
		this.Fellfarbe = Fellfarbe;
	}

	public void Bewegen()
	{
        Console.WriteLine("Die Katze bewegt sich");
    }

	public override void WasBinIch()
	{
        Console.WriteLine($"Ich bin eine Katze");
    }
}

public class Tiger : Katze
{
	public Tiger(int Alter, string Fellfarbe) : base(Alter, Fellfarbe)
	{
	}
}