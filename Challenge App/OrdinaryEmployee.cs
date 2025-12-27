using System.Text;

namespace Challenge_App
{
	internal class OrdinaryEmployee(string name, string surname) : Employee(name, surname, TypeEmployee.Ordinary)
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
			if (score.Length == 1)
			{
				AddScore(score[0]);
			}
			else
			{
				throw new Exception($"Nie została podana liczba. Zostało podane {score}");
			}
		}

		public override string ToString()
		{
			var sb = new StringBuilder();
			sb.AppendLine("Zwykły pracownik");
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