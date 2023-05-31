namespace M012;

public static class ExtensionMethods
{
	/// <summary>
	/// Berechnet die Quersumme von einer gegebenen Zahl
	/// mit this sich auf einen Typen beziehen
	/// </summary>
	public static int Quersumme(this int zahl)
	{
		return zahl.ToString().Sum(e => (int) char.GetNumericValue(e));
	}
}
