using M006.Bauteile;

namespace M006
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Fenster f;
			f = new Fenster(); //new: Objekt aus Bauplan erstellen ohne Standardwerte
			f.SetLaenge(5); //Methode im Objekt aufrufen, der Code in SetLaenge() wird hier für dieses spezifische Objekt ausgeführt
			f.Breite = 3; //Setzen einer neuen Breite in diesem spezifischen Fenster Objekt

            Console.WriteLine(f.Area);
            //f.Area = 10;

            Console.WriteLine(f.Status);
			//f.Status = FensterStatus.Offen;

			f.FensterOeffnen(); //Das Objekt hat vom Bauplan diese Funktion bekommen

			Fenster f2 = new Fenster(); //Zweites Fensterobjekt erstellen, f und f2 haben keinen Zusammenhang (außer das sie vom selben Bauplan kommen)
			f2.SetLaenge(8);
			f2.Breite = 2;

			Fenster f3 = new Fenster(4, 4); //Hier Standardwerte setzen
			Fenster f4 = new Fenster(5, 5, FensterStatus.Gekippt); //Hier werden beide Konstruktoren ausgeführt

			//Namespace: Unterteilung von Klassen in "Pakete"
			//Console, int, double -> System
			//File, Directory, Path -> System.IO (Unternamespace von System)
			//HttpClient -> System.Net.Http

			//Referenzierung von Objekten
			Raum r = new Raum();
			r.Tuer = new Tuere();
			r.Fensters = new Fenster[5];
			r.Fensters[0] = f;
			r.Fensters[1] = f2;
			r.Fensters[2] = f3;
			r.Fensters[3] = f4;
        }
	}
}