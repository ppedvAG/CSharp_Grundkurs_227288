namespace M007
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region GC
			for (int i = 0; i < 5; i++)
			{
				Fenster f = new Fenster();
			}

			GC.Collect();
			GC.WaitForPendingFinalizers(); //Warte auf alle Destruktoren
			#endregion

			#region Static
			Fenster f1 = new Fenster(1, 2);
			Fenster f2 = new Fenster(3, 4);
			Fenster f3 = new Fenster(5, 6);
            //Test(); //Statische Methoden können nicht auf nicht-statische Methoden zugreifen, es sei denn es existiert ein Objekt

			//Statische Member angreifen über den Klassennamen
            Console.WriteLine(Fenster.Zaehler);
			#endregion

			#region Werte-/Referenztypen
			//Wertetyp
			//struct
			//==, != werden die Inhalte verglichen
			//Zuweisungen sind Kopien statt Referenzen
			int original = 5;
			int x = original; //Inhalt von original wird in x kopiert
			original = 10; //original und x sind unabhängig voneinander

			//Referenztyp
			//class
			//==, != werden die Speicheradressen verglichen
			//Zuweisungen sind Referenzen anstatt Kopien
			Fenster f5 = new Fenster();
			Fenster f6 = f5; //Inhalt von f5 wird in f6 referenziert
			f6.SetLaenge(9); //f5 und f6 werden verändert
			#endregion

			#region Null
			//Null: leerer Wert, keine Referenz auf ein Objekt
			Fenster f4; //Standardmäßig null (es hängt kein Wert daran)
			f4 = new Fenster(); //Objekt erstellen und Referenz herstellen
			f4 = null; //Zeiger trennen (Objekt wird eventuell vom GC eingesammelt, wenn keine weiteren Referenzen angehängt sind)

			//f4.FensterOeffnen(); //Nicht vorhandenes Objekt kann nicht geöffnet werden

			if (f4 != null) //Wenn f4 nicht leer ist
			{
				f4.FensterOeffnen(); //Mach auf
			}
			else
			{
                Console.WriteLine("Fenster existiert nicht");
            }
			#endregion
		}

		public void Test()
		{

		}
	}
}