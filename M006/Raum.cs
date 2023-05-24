using M006.Bauteile; //using: Namespaces importieren um die Klassen darin verwenden zu können

namespace M006
{
	internal class Raum
	{
		public double Laenge, Breite, Hoehe;

		public Tuere Tuer { get; set; }

		public Fenster[] Fensters { get; set; }
	}
}
