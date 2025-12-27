using Challenge_App;
using System.Text;

Console.WriteLine("Witamy w aplikacji oceniania pracowników.");
Console.WriteLine("=========================================\n");

string name = "", surname = "";
string? input;
bool isNotCorrect;

do
{
	Console.Write("Podaj imię pracownika: ");
	input = Console.ReadLine();

	isNotCorrect = input?.Length == 0 || input is null;
	if (isNotCorrect)
	{
		Console.WriteLine("Nie podałeś imienia.");
	}
	else if (input is not null)
	{
		name = input;
	}
} while (isNotCorrect);

do
{
	Console.Write("Podaj nazwisko pracownika: ");
	input = Console.ReadLine();

	isNotCorrect = input?.Length == 0 || input is null;
	if (isNotCorrect)
	{
		Console.WriteLine("Nie podałeś nazwiska.");
	}
	else if (input is not null)
	{
		surname = input;
	}
} while (isNotCorrect);

var employee = new OrdinaryEmployee(name, surname);

Console.WriteLine("Wpisz oceny pracownika w formie liczb od 0 do 100 lub formie liter");
Console.WriteLine("Wpisanie \"q\" kończy wpisywanie punktów");

var sb = new StringBuilder();
char c = 'A';
for (int i = 0; i <= 10; i++)
{
	sb.AppendLine($"{(char)(c + i)} - {(10 - i) * 10}");
}
Console.WriteLine(sb);

do
{
	input = Console.ReadLine();
	if (input is not null && input != "q")
	{
		if (float.TryParse(input, out float value))
		{
			try
			{
				employee.AddScore(value);
			}
			catch (Exception exp)
			{
				Console.WriteLine(exp.Message);
			}
		}
		else
		{
			try
			{
				employee.AddScore(input);
			}
			catch (Exception exp)
			{
				Console.WriteLine(exp.Message);
			}
		}
	}
} while (input != "q");

Console.WriteLine(employee);
