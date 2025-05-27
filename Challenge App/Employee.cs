using System.Text;

namespace Challenge_App
{
	public class Employee(string name, string surname) : Person(name, surname)
	{
		private readonly List<float> scores = [];
		public float[] Scores
		{
			get
			{
				return [.. scores];
			}
		}

		public void AddScore(float score)
		{
			if (score >= 0 && score <= 100)
			{
				scores.Add(Math.Abs(score));
			}
			else
			{
				throw new Exception($"Wartość poza zakresem. Zostało podane {score}");
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
			else if(score.Length == 1)
			{
				AddScore(score[0]);
			}
			else
			{
				throw new Exception($"Nie została podana liczba. Zostało podane {score}");
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

		public void AddScore(char letter)
		{
			switch(letter)
			{
				case 'a':
				case 'A':
					AddScore(100);
					break;
				case 'b':
				case 'B':
					AddScore(90);
					break;
				case 'c':
				case 'C':
					AddScore(80);
					break;
				case 'd':
				case 'D':
					AddScore(70);
					break;
				case 'e':
				case 'E':
					AddScore(60);
					break;
				case 'f':
				case 'F':
					AddScore(50);
					break;
				case 'g':
				case 'G':
					AddScore(40);
					break;
				case 'h':
				case 'H':
					AddScore(30);
					break;
				case 'i':
				case 'I':
					AddScore(20);
					break;
				case 'j':
				case 'J':
					AddScore(10);
					break;
				case 'k':
				case 'K':
					AddScore(0);
					break;
				default: throw new Exception($"Nieprawidłowa litera, zostało podane {letter}");
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

				statistics.AverageLetter = statistics.Average switch
				{
					>= 90 => 'A',
					>= 80 => 'B',
					>= 70 => 'C',
					>= 60 => 'E',
					>= 50 => 'F',
					>= 40 => 'G',
					>= 30 => 'H',
					>= 20 => 'I',
					>= 10 => 'J',
					_ => 'K'
				};
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
			sb.AppendLine($"Kategoria punktowa {statistics.AverageLetter}");

			return sb.ToString();
		}
	}
}