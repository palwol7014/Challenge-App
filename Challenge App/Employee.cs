using System.Text;

namespace Challenge_App
{
	public class Employee(string name, string surname) : IComparable<Employee>
	{
		private readonly List<uint> scores = [];
		private readonly List<uint> penatlyScores = [];
		private uint sumScores;
		private uint sumPenatlyScores;
		private bool isChangeScores = false;
		private bool isChangePenatlyScores = false;
		public string Name { get; private set; } = name;
		public string Surname { get; private set; } = surname;

		public uint[] Scores
		{
			get
			{
				return [.. scores];
			}
		}

		public uint[] PenatlyScores
		{
			get
			{
				return [.. penatlyScores];
			}
		}

		public uint SumScores
		{
			get
			{
				if (isChangeScores)
				{
					sumScores = 0;

					foreach (var score in scores)
					{
						sumScores += score;
					}

					isChangeScores = false;
				}

				return sumScores;
			}
		}

		public uint SumPenatlyScores
		{
			get
			{
				if (isChangePenatlyScores)
				{
					sumPenatlyScores = 0;

					foreach (var scores in penatlyScores)
					{
						sumPenatlyScores += scores;
					}

					isChangePenatlyScores = false;
				}

				return sumPenatlyScores;
			}
		}

		public int BalancePoints
		{
			get
			{
				return (int)SumScores - (int)SumPenatlyScores;
			}
		}

		public void AddScore(uint score)
		{
			scores.Add(score);
			isChangeScores = true;
		}

		public void AddPenatlyScore(uint score)
		{
			penatlyScores.Add(score);
			isChangePenatlyScores = true;
		}

		public override string ToString()
		{
			var sb = new StringBuilder();
			var sbPoints = new StringBuilder();
			sb.AppendLine($"Imię: {Name}").AppendLine($"Nazwisko: {Surname}");

			foreach (var point in scores)
			{
				sbPoints.Append($"{point}, ");
			}

			if (scores.Count > 0)
			{
				sbPoints.Remove(sbPoints.Length - 2, 2);
			}
			else
			{
				sbPoints.Append("Brak");
			}

			sb.AppendLine($"Punkty: {sbPoints}").AppendLine($"Suma punktów: {SumScores}");
			sbPoints.Clear();

			foreach (var point in penatlyScores)
			{
				sbPoints.Append($"{point}, ");
			}
			
			if(penatlyScores.Count > 0)
			{
				sbPoints.Remove(sbPoints.Length - 2, 2);
			}
			else
			{
				sbPoints.Append("Brak");
			}

			sb.AppendLine($"Punkty karne: {sbPoints}").AppendLine($"Suma punktów karnych: {SumPenatlyScores}").AppendLine($"Bilans punków: {BalancePoints}");

			return sb.ToString();
		}

		public int CompareTo(Employee? other)
		{
			return BalancePoints.CompareTo(other?.BalancePoints);
		}
	}
}