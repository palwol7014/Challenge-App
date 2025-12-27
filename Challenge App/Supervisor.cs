using System.Text;

namespace Challenge_App
{
	internal class Supervisor(string name, string surname) : Employee(name, surname, TypeEmployee.Supervisor)
	{
		public TypeEmployee Type
		{
			get
			{
				return type;
			}
		}
		public override void AddScore(string score)
		{

			if (int.TryParse(score, out int value))
			{
				if (value >= 1 && value <= 6)
				{
					AddScore((value - 1) * 20);
				}
				else
				{
					throw new Exception($"Wartość poza zakresem. Zostało podane {score}");
				}
			}
			else if (int.TryParse(score.AsSpan(0, 1), out value))
			{
				if (value >= 1 && value <= 4 && score[1] == '+')
				{
					AddScore((value - 1) * 20 + 5);
				}
				else if(value >= 2 && value <= 5 && score[1] == '-')
				{
					AddScore((value - 1) * 20 - 5);
				}
				else
				{
					throw new Exception($"Wartość poza zakresem. Zostało podane {score}");
				}
			}
			else if (int.TryParse(score.AsSpan(1, 0), out value))
			{
				if (value >= 1 && value <= 4 && score[0] == '+')
				{
					AddScore((value - 1) * 20 + 5);
				}
				else if (value >= 2 && value <= 5 && score[0] == '-')
				{
					AddScore((value - 1) * 20 - 5);
				}
				else
				{
					throw new Exception($"Wartość poza zakresem. Zostało podane {score}");
				}
			}
			else
			{
				throw new Exception($"Nieprawidłowe dane. Zostało podane {score}");
			}
		}

		public override string ToString()
		{
			var sb = new StringBuilder();
			sb.AppendLine("Menadżer");
			sb.AppendLine($"Pracownik {Name} {Surname}");

			if (scores.Count > 0)
			{
				var sbPoint = new StringBuilder();

				foreach (var score in scores)
				{
					sbPoint.Append($"{score}, ");
				}

				sb.AppendLine($"Punkty: {sbPoint.ToString(0, sbPoint.Length - 2)}");
			}
			else
			{
				sb.AppendLine("Brak punktów.");
			}

			var statistics = GetStatistics();

			sb.AppendLine($"Największa liczba punktów {statistics.Max}");
			sb.AppendLine($"Najmniejsza liczba punktów {statistics.Min}");
			sb.AppendLine($"Średnia liczba punktów {Math.Round(statistics.Average, 2, MidpointRounding.AwayFromZero)}");
			sb.AppendLine($"Kategoria punktowa {statistics.AverageLetter}");

			return sb.ToString();
		}
	}
}
