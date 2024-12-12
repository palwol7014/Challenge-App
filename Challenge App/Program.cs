var age = 30;
var name = "Marta";
var sex = 'K';
string message;

if((sex == 'K' || sex == 'k') && age < 30)
{
	message = "Kobieta poniżej 30 lat";
}
else if(name == "Ewa" && age == 30)
{
	message = $"{name}, lat {age}";
}
else if ((sex == 'm' || sex == 'M') && age < 18)
{
	message = "Niepełnoletni mężczyzna";
}
else
{
	message = "Brak klasyfikacji";
}

Console.WriteLine(message);