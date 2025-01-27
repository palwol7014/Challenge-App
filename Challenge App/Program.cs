using Challenge_App;

var listEmployee = new List<Employee>
{
	new("Marek", "Pawłowski"),
	new("Ilona", "Kwiecień"),
	new("Arkadiusz", "Ryba")
};

var isShowErrors = false;

listEmployee[0].AddScore([51.65, 41.32f, 98.3f, 56.3f, 12.32f]);
foreach (var error in listEmployee[0].ListErrors)
{
	if(!isShowErrors)
	{
		Console.WriteLine($"Podczas dodawania ocen pracownika {listEmployee[0].Name} {listEmployee[0].Surname} pojawiły się następujące błędy:");
		isShowErrors = true;
	}

	Console.WriteLine(error);
}

isShowErrors = false;

listEmployee[1].AddScore([6.5, 52.1, 61.3, 2, 1, 65]);
foreach (var error in listEmployee[1].ListErrors)
{
	if (!isShowErrors)
	{
		Console.WriteLine($"Podczas dodawania ocen pracownika {listEmployee[1].Name} {listEmployee[1].Surname} pojawiły się następujące błędy:");
		isShowErrors = true;
	}

	Console.WriteLine(error);
}

isShowErrors = false;

listEmployee[2].AddScore([12.5, 85, 63.14, 43.5, 91.2, 7, 5]);
foreach (var error in listEmployee[2].ListErrors)
{
	if (!isShowErrors)
	{
		Console.WriteLine($"Podczas dodawania ocen pracownika {listEmployee[2].Name} {listEmployee[2].Surname} pojawiły się następujące błędy:");
		isShowErrors = true;
	}

	Console.WriteLine(error);
}

foreach (var employee in listEmployee)
{
	Console.WriteLine(employee);
}
