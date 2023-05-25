namespace M008;

class AccessModifier //Member ohne Modifier sind internal
{
	public string Name { get; set; } //Kann überall gesehen werden (auch außerhalb vom Projekt)

	private int Alter { get; set; } //Kann nur innerhalb der Klasse gesehen werden

	internal string Wohnort { get; set; } //Kann überall gesehen werden (aber nicht außerhalb vom Projekt)
}