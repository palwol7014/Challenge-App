﻿using Challenge_App;

var listEmployee = new List<Employee>
{
	new("Marek", "Pawłowski"),
	new("Ilona", "Kwiecień"),
	new("Arkadiusz", "Ryba")
};

listEmployee[0].AddScore(2);
listEmployee[0].AddScore(6);
listEmployee[0].AddScore(8);
listEmployee[0].AddScore(1);
listEmployee[0].AddScore(1);
listEmployee[0].AddScore(6);

listEmployee[1].AddScore(1);
listEmployee[1].AddScore(2);
listEmployee[1].AddScore(10);
listEmployee[1].AddScore(7);
listEmployee[1].AddScore(5);

listEmployee[2].AddScore(3);
listEmployee[2].AddScore(1);
listEmployee[2].AddScore(6);
listEmployee[2].AddScore(9);
listEmployee[2].AddScore(2);


foreach (var employee in listEmployee)
{
	Console.WriteLine(employee);
}
