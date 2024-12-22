using System.Text;

namespace Challenge_App
{
	internal class Employee(string name, string surname) : IComparable<Employee>
	{
		private readonly List<int> scores = [];
		private int sumScores = 0;
		private bool isChange = false;
		public string Name { get; private set; } = name;
		public string Surname { get; private set; } = surname;

		public int[] Scores 
		{
			get
			{
				return [.. scores];
			}	
		}
		public int SumScores
		{
			get
			{
				if (isChange)
				{
					sumScores = scores.Sum();
					isChange = false;
				}

				return sumScores;
			}
		}

		public void AddScore(int score)
		{
			scores.Add(score);
			isChange = true;
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

			sbPoints.Remove(sbPoints.Length - 2, 2);
			sb.AppendLine(sbPoints.ToString()).AppendLine($"Suma punktów: {sumScores}");

			return sb.ToString();
		}

		public int CompareTo(Employee? other)
		{
			return SumScores.CompareTo(other?.SumScores);
		}
	}
}
