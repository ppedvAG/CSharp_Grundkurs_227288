using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace M015;

internal class Program
{
	static void Main(string[] args)
	{
		//Dateimanagement Klassen:
		//File
		//- Files schreiben, bewegen, löschen, ...
		//Directory
		//- Ordner erstellen, bewegen, löschen, auflisten, ...
		//Path
		//- Pfade bauen

		//GetFolderPath: Pfad von einem speziellen Ordner unter Windows holen (funktioniert auch auf anderen Systemen)
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

		//Path.Combine: Baut Pfade zusammen, setzt die Trennzeichen abhängig vom Betriebssystem ein
		string folderPath = Path.Combine(desktop, "Test"); //Pfad zum Ordner

		string filePath = Path.Combine(folderPath, "Test.txt"); //Pfad zur Datei

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		//NuGet-Packages: Externe Pakete die zum Projekt hinzugefügt werden können
		//Geben neue Funktionen für das bestehende Projekt (häufig für Kompatiblität nach außen)

		//Streams();

		//NewtonsoftJson();

		//SystemJson();

		//Xml();
	}

	public static void Streams()
	{
		//Dateimanagement Klassen:
		//File
		//- Files schreiben, bewegen, löschen, ...
		//Directory
		//- Ordner erstellen, bewegen, löschen, auflisten, ...
		//Path
		//- Pfade bauen

		//GetFolderPath: Pfad von einem speziellen Ordner unter Windows holen (funktioniert auch auf anderen Systemen)
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

		//Path.Combine: Baut Pfade zusammen, setzt die Trennzeichen abhängig vom Betriebssystem ein
		string folderPath = Path.Combine(desktop, "Test"); //Pfad zum Ordner

		string filePath = Path.Combine(folderPath, "Test.txt"); //Pfad zur Datei

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		//StreamWriter: öffnet einen Stream zu der entsprechenden Datei
		//Blockiert die Datei solange der Stream offen ist
		//Der Inhalt wird zuerst in den Stream geschrieben, und muss dann in die Datei weitergeleitet werden
		StreamWriter sw = new StreamWriter(filePath);
		sw.WriteLine("Test1");
		sw.WriteLine("Test2");
		sw.WriteLine("Test3");
		sw.Flush(); //Schreibe den Inhalt des Streams in die Datei
		sw.Close(); //Schließe den Stream und schreibe davor den Inhalt in die Datei

		//using-Block: Schließt den Stream am Ende des Blocks automatisch
		//Alle Klassen die das IDisposable Interface haben, können in einem using Block deklariert werden
		using (StreamWriter sw2 = new StreamWriter(filePath))
		{
			sw2.WriteLine("Test1");
			sw2.WriteLine("Test2");
			sw2.WriteLine("Test3");
		} //Hier am Ende wird automatisch Dispose() ausgeführt

		//using-Statement: Schließt den Stream am Ende der Methode automatisch
		using StreamReader sr = new StreamReader(filePath);
		sr.ReadToEnd(); //Ließt den gesamten Text ein

		sr.BaseStream.Position = 0; //Cursor an den Anfang des Files zurück setzen

		List<string> lines = new List<string>();
		while (!sr.EndOfStream)
			lines.Add(sr.ReadLine()); //Ließt die nächste Zeile im Stream ein

		//Schnelle Methoden
		File.WriteAllText(filePath, "Test1\nTest2\nTest3\n"); //string schreiben
		File.WriteAllLines(filePath, lines); //Collection schreiben
		File.AppendAllText(filePath, "Test4"); //Text anhängen (statt überschreiben)

		string str = File.ReadAllText(filePath); //Lies das gesamte File in einen String
		string[] readLines = File.ReadAllLines(filePath); //Lies das gesamte File in ein Array (Zeile für Zeile)
	}

	public static void NewtonsoftJson()
	{
		////Dateimanagement Klassen:
		////File
		////- Files schreiben, bewegen, löschen, ...
		////Directory
		////- Ordner erstellen, bewegen, löschen, auflisten, ...
		////Path
		////- Pfade bauen

		////GetFolderPath: Pfad von einem speziellen Ordner unter Windows holen (funktioniert auch auf anderen Systemen)
		//string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

		////Path.Combine: Baut Pfade zusammen, setzt die Trennzeichen abhängig vom Betriebssystem ein
		//string folderPath = Path.Combine(desktop, "Test"); //Pfad zum Ordner

		//string filePath = Path.Combine(folderPath, "Test.txt"); //Pfad zur Datei

		//if (!Directory.Exists(folderPath))
		//	Directory.CreateDirectory(folderPath);

		////Streams();

		////NuGet-Packages: Externe Pakete die zum Projekt hinzugefügt werden können
		////Geben neue Funktionen für das bestehende Projekt (häufig für Kompatiblität nach außen)

		//List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		//{
		//	new Fahrzeug(251, FahrzeugMarke.BMW),
		//	new Fahrzeug(274, FahrzeugMarke.BMW),
		//	new Fahrzeug(146, FahrzeugMarke.BMW),
		//	new Fahrzeug(208, FahrzeugMarke.Audi),
		//	new Fahrzeug(189, FahrzeugMarke.Audi),
		//	new Fahrzeug(133, FahrzeugMarke.VW),
		//	new Fahrzeug(253, FahrzeugMarke.VW),
		//	new Fahrzeug(304, FahrzeugMarke.BMW),
		//	new Fahrzeug(151, FahrzeugMarke.VW),
		//	new PKW(250, FahrzeugMarke.VW),
		//	new Fahrzeug(217, FahrzeugMarke.Audi),
		//	new Fahrzeug(125, FahrzeugMarke.Audi)
		//};

		////Settings: Einstellungen beim Serialisieren/Deserialisieren von Objekten vornehmen (z.B.: Schön schreiben, Datumsformatierung, ...)
		////WICHTIG: Einstellungen müssen bei SerializeObject/DeserializeObject mitgegeben werden
		//JsonSerializerSettings settings = new JsonSerializerSettings();
		//settings.Formatting = Formatting.Indented;
		//settings.TypeNameHandling = TypeNameHandling.Objects; //Vererbung ermöglichen, speichert bei jedem Objekt den Typen dazu

		////JsonConvert: Ermöglicht das Serialisieren/Deserialisieren von Objekten
		//string json = JsonConvert.SerializeObject(fahrzeuge, settings);
		//File.WriteAllText(filePath, json);

		//string readJson = File.ReadAllText(filePath);
		//List<Fahrzeug> readFzg = JsonConvert.DeserializeObject<List<Fahrzeug>>(readJson, settings);
	}

	public static void SystemJson()
	{
		//Dateimanagement Klassen:
		//File
		//- Files schreiben, bewegen, löschen, ...
		//Directory
		//- Ordner erstellen, bewegen, löschen, auflisten, ...
		//Path
		//- Pfade bauen

		//GetFolderPath: Pfad von einem speziellen Ordner unter Windows holen (funktioniert auch auf anderen Systemen)
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

		//Path.Combine: Baut Pfade zusammen, setzt die Trennzeichen abhängig vom Betriebssystem ein
		string folderPath = Path.Combine(desktop, "Test"); //Pfad zum Ordner

		string filePath = Path.Combine(folderPath, "Test.txt"); //Pfad zur Datei

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		//NuGet-Packages: Externe Pakete die zum Projekt hinzugefügt werden können
		//Geben neue Funktionen für das bestehende Projekt (häufig für Kompatiblität nach außen)

		//Streams();

		//NewtonsoftJson();

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
			new PKW(250, FahrzeugMarke.VW),
			new Fahrzeug(217, FahrzeugMarke.Audi),
			new Fahrzeug(125, FahrzeugMarke.Audi)
		};

		//Options: Einstellungen beim Serialisieren/Deserialisieren von Objekten vornehmen (z.B.: Schön schreiben, Datumsformatierung, ...)
		//WICHTIG: Einstellungen müssen bei Serialize/Deserialize mitgegeben werden
		JsonSerializerOptions settings = new JsonSerializerOptions();
		settings.WriteIndented = true;
		//Vererbung wird hier nicht über eine Einstellung gemacht, sondern über Attribute

		//JsonSerializer: Ermöglicht das Serialisieren/Deserialisieren von Objekten
		string json = JsonSerializer.Serialize(fahrzeuge, settings);
		File.WriteAllText(filePath, json);

		string readJson = File.ReadAllText(filePath);
		List<Fahrzeug> readFzg = JsonSerializer.Deserialize<List<Fahrzeug>>(readJson, settings);
	}

	public static void Xml()
	{
		//Dateimanagement Klassen:
		//File
		//- Files schreiben, bewegen, löschen, ...
		//Directory
		//- Ordner erstellen, bewegen, löschen, auflisten, ...
		//Path
		//- Pfade bauen

		//GetFolderPath: Pfad von einem speziellen Ordner unter Windows holen (funktioniert auch auf anderen Systemen)
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

		//Path.Combine: Baut Pfade zusammen, setzt die Trennzeichen abhängig vom Betriebssystem ein
		string folderPath = Path.Combine(desktop, "Test"); //Pfad zum Ordner

		string filePath = Path.Combine(folderPath, "Test.txt"); //Pfad zur Datei

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		//NuGet-Packages: Externe Pakete die zum Projekt hinzugefügt werden können
		//Geben neue Funktionen für das bestehende Projekt (häufig für Kompatiblität nach außen)

		//Streams();

		//NewtonsoftJson();

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

		XmlSerializer xml = new XmlSerializer(fahrzeuge.GetType());
		using (StreamWriter sw = new StreamWriter(filePath))
			xml.Serialize(sw, fahrzeuge);

		using (StreamReader sr = new StreamReader(filePath))
		{
			List<Fahrzeug> readFzg = xml.Deserialize(sr) as List<Fahrzeug>; //as-Cast: Normaler Cast, stürzt nicht ab wenn der Cast nicht funktioniert
		}
	}
}

[JsonDerivedType(typeof(Fahrzeug), "F")]
[JsonDerivedType(typeof(PKW), "P")]
public class Fahrzeug
{
	public int MaxGeschwindigkeit { get; set; }

	public FahrzeugMarke Marke { get; set; }

	public Fahrzeug(int v, FahrzeugMarke fm)
	{
		MaxGeschwindigkeit = v;
		Marke = fm;
	}

    public Fahrzeug()
    {
        
    }
}

public class PKW : Fahrzeug
{
	public PKW(int v, FahrzeugMarke fm) : base(v, fm)
	{
	}

    public PKW()
    {
        
    }
}

public enum FahrzeugMarke { Audi, BMW, VW }