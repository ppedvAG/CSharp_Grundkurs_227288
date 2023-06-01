namespace M013;

internal class Program
{
	static void Main(string[] args)
	{
		//Unerwartete Fehler abfangen mittels try-catch
		//Normalerweise stürzt das Programm ab wenn ein Fehler auftritt und nicht behandelt wird
		//Try-Catch:
		//Im try Block den Code inkludieren, der getestet werden soll (der Code der Fehler werfen könnte)
		//In den Catch Blöcken die Fehler behandeln. Jeder Catch Block sollte eine bestimmte Exception behandeln

		//Event: Events sind statische Punkte an denen Funktionen angehängt werden können
		//Die angehängten Funktionen werden ausgeführt, wenn das Event gefeuert wird
		AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
		//throw new Exception("Log Test");

		try //Codeblock markieren + Rechtsklick + Snippet -> Surround With -> try(f)
		{
			string eingabe = Console.ReadLine(); //Maus über Methode -> Exceptions sind die Fehler die auftreten können
			int x = int.Parse(eingabe); //3 mögliche Exceptions: ArgumentNullException, FormatException, OverflowException

			if (x == 0)
			{
				throw new TestException("Die Zahl darf nicht 0 sein.", x); //Mittels throw können beliebige Exceptions geworfen werden
			}

			Console.WriteLine($"Die eingegebene Zahl ist {x}");
		}
		catch (FormatException) //Keine Zahl (Buchstaben)
		{
            Console.WriteLine("Die Eingabe ist keine Zahl");
        }
		catch (OverflowException e) //Zu große/kleine Zahl
		{
            Console.WriteLine("Die Zahl ist zu klein/groß");
            Console.WriteLine(e.Message); //Die interne Nachricht zum Fehler (Value was either too large or too small for an Int32.)
			Console.WriteLine(e.StackTrace); //Informationen zu genauen Punkten im Code wo der Fehler aufgetreten ist (von unten nach oben lesen um den genauen Ort in unserem Code zu finden)
        }
		catch (TestException e)
		{
            Console.WriteLine($"TestException wurde gefangen, eingegebene Zahl: {e.Zahl}");
            Console.WriteLine(e.Message);
            Console.WriteLine(e.StackTrace);
        }
		catch (Exception e) //Fängt alle anderen Exceptions
		{
			//FormatException und OverflowException werden oben bereits behandelt -> hier gibt es keine Fehlerbehandlung
			Console.WriteLine("Anderer Fehler");
            Console.WriteLine(e.Message);
            Console.WriteLine(e.StackTrace);

			//throw ohne Exception kann nur in catch Blöcken verwendet werden
			//Lässt das Programm trotz Behandlung des Fehlers abstürzen
			//Bei Fatalen Fehlern
			throw;
        }
		finally //Wird immer ausgeführt auch wenn kein Fehler auftritt
		{
            Console.WriteLine("Parsen abgeschlossen");
        }
    }

	private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
	{
		//Logging-Code
		Exception ex = e.ExceptionObject as Exception;
		File.WriteAllText("Log.txt", ex.Message + "\n" + ex.StackTrace);
	}
}

public class TestException : Exception
{
	public int Zahl { get; set; }

	public TestException(string? message) : base(message)
	{

	}

	public TestException(string? message, int zahl) : base(message)
	{
		Zahl = zahl;
	}
}