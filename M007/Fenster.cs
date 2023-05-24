namespace M007
{
	/// <summary>
	/// Bauplan für Fenster Objekte, hier wird nur definiert wie ein Fenster aufgebaut ist
	/// </summary>
	public class Fenster
	{
		#region Variablen
		private double laenge; //Feld ist privat, damit der Benutzer keinen Unsinn in das Feld schreiben kann (z.B. -5)

		/// <summary>
		/// Gibt die Länge des Fensters zurück.</br>
		/// Get-Methoden geben das Feld dahinter zurück, und haben generell keine Parameter.
		/// </summary>
		/// <returns>Die Länge des Fensters in Meter.</returns>
		public double GetLaenge()
		{
			return laenge;
		}

		/// <summary>
		/// Setzt die Länge des Fensters auf einen neuen Wert.</br>
		/// Set-Methoden sind generell void und haben genau einen Parameter.</br>
		/// Über die Set-Methode kann ein neuer Wert in das Feld geschrieben werden, und davor kann eine Überprüfung gemacht werden.
		/// </summary>
		/// <param name="neueLaenge">Die neue Länge des Fensters in Meter.</param>
		public void SetLaenge(double neueLaenge)
		{
			if (neueLaenge > 0 && neueLaenge < 10)
			{
				laenge = neueLaenge;
			}
			else
			{
                Console.WriteLine("Neue Länge muss zwischen 0 und 10 Meter sein");
            }
		}
		#endregion

		#region Properties
		private double breite;

		public double Breite
		{
			get //Äquivalent zu GetLaenge()
			{
				return breite;
			}
			set //Äquivalent zu SetLaenge()
			{
				if (value > 0 && value < 10) //value: Äquivalent zu neueLaenge bei SetLaenge()
				{
					breite = value;
				}
				else
				{
					Console.WriteLine("Neue Breite muss zwischen 0 und 10 Meter sein");
				}
			}
		}

		//Get-Only Property
		public double Area
		{
			get
			{
				return laenge * breite;
			}
			//set weglassen, macht keinen Sinn für eine Fläche (wird berechnet)
		}

		public double Area2
		{
			get => laenge * breite;
		}

		private FensterStatus status = FensterStatus.Geschlossen; //Fenster bei allen Objekten standardmäßig schließen

		public FensterStatus Status
		{
			get => status;
			private set //private set: von außen nicht angreifbar
			{
				status = value;
			}
		}

		/// <summary>
		/// Benutzer die Möglichkeit geben das Fenster zu öffnen ohne auf das Property zuzugreifen
		/// </summary>
		public void FensterOeffnen()
		{
			if (status != FensterStatus.Offen)
			{
				status = FensterStatus.Offen;
			}
			else
			{
                Console.WriteLine("Fenster ist bereits geöffnet");
            }
		}

		//Auto Property: Macht genau das gleiche wie ohne { get; set; } wie eine normale Variable, hat aber viele Vorteile bei weiterführenden Themen
		public int AnzahlScheiben { get; set; }
		#endregion

		#region Konstruktor
		/// <summary>
		/// Standardkonstruktor wird gelöscht, wenn ein Konstruktor angelegt wird
		/// </summary>
		public Fenster() { }

		/// <summary>
		/// Konstruktor: Code der bei Erstellung des Objekts ausgeführt wird</br>
		/// Hier sollten Standardwerte gesetzt werden (über Parameter)</br>
		/// ctor + Tab + Tab, Cursor auf Klassenname -> Strg + . -> Generate Constructor -> Felder auswählen -> OK
		/// </summary>
		public Fenster(double laenge, double breite)
        {
            SetLaenge(laenge);
			Breite = breite;
			//this.laenge = laenge; //this: Nach oben greifen, bei gleichen Variablennamen muss ausgewählt werden, welches Feld angegriffen werden soll
			//this.breite = breite;
			Zaehler++;
        }

		/// <summary>
		/// Konstruktoren verketten: mit this(...) mehrere Konstruktoren aneinanderhängen, um Redundanz zu sparen</br>
		/// Kette kann beliebig viele Konstruktoren enthalten
		/// </summary>
		public Fenster(double laenge, double breite, FensterStatus status) : this(laenge, breite)
		{
			Status = status;
		}
		#endregion

		~Fenster()
		{
            Console.WriteLine($"Objekt wurde aufgeräumt {GetHashCode()}"); //GetHashCode(): Gibt die Speicheradresse des Objekts aus
        }

		/// <summary>
		/// static: Globale Variablen erstellen, diese Variablen sind auf dem Bauplan darauf, aber nicht auf den Objekten selbst
		/// -> statische Member sind geteilt zwischen den Objekten
		/// </summary>
		public static int Zaehler { get; set; }
	}

	public enum FensterStatus
	{
		Offen,
		Gekippt,
		Geschlossen
	}
}
