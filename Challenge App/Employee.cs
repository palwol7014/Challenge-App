using System.Text;

namespace Challenge_App
{
	public class Employee(string name, string surname)
	{
		public string Name { get; private set; } = name;
		public string Surname { get; private set; } = surname;
		private readonly List<float> scores = [];
		public float[] Scores
		{
			get
			{
				return [.. scores];
			}
		}

		public string[] ListErrors
		{
			get
			{
				var tabListError = listErrors.ToArray();
				listErrors.Clear();
				return tabListError;
			}
		}
		private readonly List<string> listErrors = [];

		public void AddScore(float score)
		{
			if (score >= 0 && score <= 100)
			{
				scores.Add(Math.Abs(score));
			}
			else
			{
				listErrors.Add($"Wartość poza zakresem. Zostało podane {score}");
			}
		}

		public void AddScore(List<float> scores)
		{
			foreach (var score in scores)
			{
				AddScore(score);
			}
		}

		public void AddScore(string score)
		{
			if(float.TryParse(score, out float value))
			{
				AddScore(value);
			}
			else
			{
				listErrors.Add($"Nie została podana liczba. Zostało podane {score}");
			}
		}

		public void AddScore(double score)
		{
			AddScore((float)score);
		}

		public void AddScore(List<double> scores)
		{
			foreach (var score in scores)
			{
				AddScore(score);
			}
		}

		public Statistics GetStatistics()
		{
			Statistics statistics;

			if (scores.Count > 0)
			{

				statistics = new()
				{
					Min = float.MaxValue,
					Max = float.MinValue
				};

				foreach (var score in scores)
				{
					statistics.Min = Math.Min(score, statistics.Min);
					statistics.Max = Math.Max(score, statistics.Max);
					statistics.Average += score;
				}

				statistics.Average /= scores.Count;
			}
			else
			{
				statistics = new();
			}

			return statistics;
		}

		public override string ToString()
		{
			var sb = new StringBuilder();
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

			return sb.ToString();
		}
	}
}