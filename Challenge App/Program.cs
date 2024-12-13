var number = 455541101387996544;
var numberOfString = number.ToString();
var countOfDigits = new int[10];

foreach (var character in numberOfString)
{
	//Bez względu na kodowanie znaków zawsze znaki cyfr 0 - 9 występują kolejno po sobie.
	//'0' jest traktowany jako kod znaku.
	countOfDigits[character - '0']++;
}

for (var i = 0; i < countOfDigits.Length; i++)
{
	Console.WriteLine($"{i} => {countOfDigits[i]}");
}