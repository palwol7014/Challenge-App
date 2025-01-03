namespace Challenge_App
{
	//Klasa utworzona tylko na potrzeby wykonania testu jednotkowych - zadanie domowe z dnia 8.
	public class Person(string name, string surname, string PESEL)
	{
		public string Name { get; private set; } = name;
		public string Surname { get; private set; } = surname;
		public string PESEL { get; private set; } = PESEL;
		public static bool operator==(Person p1, Person p2)
		{
			return p1.PESEL == p2.PESEL && p1.Name == p2.Name && p1.Surname == p2.Surname;
		}
		public static bool operator!=(Person p1, Person p2)
		{
			return p1.PESEL != p2.PESEL && p1.Name != p2.Name && p1.Surname != p2.Surname;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public override bool Equals(object? obj)
		{
			if(obj is null || (obj is not Person))
			{
				return false;
			}
			else
			{
				var o = obj as Person;
				return Name == o?.Name && Surname == o?.Surname && PESEL == o?.PESEL;
			}
		}
	}
}
