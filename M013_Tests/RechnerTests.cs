using M013;

namespace M013_Tests;

[TestClass]
public class RechnerTests
{
	//Unit Tests: Tests die regelmäßig ausgeführt werden um die Funktionalität des Codes zu gewährleisten
	//Bei Änderungen des Codes könnten Test fehlschlagen -> Bug im Code

	//Dependencies: Referenzen zu anderen Projekten herstellen, um Code aus diesen Projekten zu verwenden (Projektübergreifend)
	//Solution Explorerer -> Dependencies -> Rechtsklick -> Add Project Reference -> Projekt(e) Auswählen -> OK

	//Test Explorer: View -> Test Explorer
	//Gibt die Möglichkeit Tests auszuführen und zu observieren

	Rechner r;

	[TestInitialize]
	public void Init()
	{
		r = new Rechner();
	}

	[TestCleanup]
	public void Cleanup() 
	{
		r = null;
	}

	[TestMethod]
	[TestCategory("Addiere Test")]
	public void TesteAddiere()
	{
		double ergebnis = r.Addiere(3, 4);

		//Assert Klasse: Gibt die Möglichkeit einen Test zu beenden
		//Notwendig in Unit Testing
		Assert.AreEqual(7, ergebnis);
	}

	[TestMethod]
	[TestCategory("Subtrahiere Test")]
	public void TesteSubtrahiere()
	{
		double ergebnis = r.Subtrahiere(6, 2);
		Assert.AreEqual(4, ergebnis);
	}
}