namespace Challenge_App
{
	internal abstract class Person(string name, string surname)
   {
		public string Name { get; protected set; } = name;
		public string Surname { get; protected set; } = surname;
	}
}
