using Challenge_App;
using System.Diagnostics.Metrics;

namespace Challenge_App_Tests
{
	public class EmployeeTests
	{

		[Test]
		public void CheckCorrectCreateEmployee()
		{
			var name = "Monika";
			var surmane = "Mika";
			var employee = new Employee(name, surmane);
			var statistics = employee.GetStatistics();

			Assert.Multiple(() =>
			{
				Assert.That(employee.Name, Is.EqualTo(name));
				Assert.That(employee.Surname, Is.EqualTo(surmane));
				Assert.That(statistics.Max, Is.EqualTo(0));
				Assert.That(statistics.Min, Is.EqualTo(0));
				Assert.That(statistics.Average, Is.EqualTo(0));
			});
		}

		[Test]
		public void CheckCorrectCalculateStatisticsEmployee()
		{
			var employee = new Employee("Monika", "Mika");
			var minNote = 2.47f;
			var averageNote = 6.85f;
			var maxNote = 54.68f;
			var score = 101.43f;

			employee.AddScore(minNote);
			employee.AddScore(averageNote);
			employee.AddScore(maxNote);
			employee.AddScore(score);
			var average = (minNote + averageNote + maxNote) / 3;
			var error = $"Wartość poza zakresem. Zostało podane {score}";
			var listErrors = employee.ListErrors;

			var statistics = employee.GetStatistics();

			Assert.Multiple(() =>
			{
				Assert.That(statistics.Min, Is.EqualTo(minNote));
				Assert.That(statistics.Max, Is.EqualTo(maxNote));
				Assert.That(statistics.Average, Is.EqualTo(average));
				Assert.That(listErrors, Has.Length.EqualTo(1));
				Assert.That(listErrors[0], Is.EqualTo(error));
			});
		}

		[Test]
		public void CheckCorrectAddScoreFromString()
		{
			var employee = new Employee("Monika", "Mika");
			var score = "jeden";
			employee.AddScore("84");
			employee.AddScore(score);
			var listErrors = employee.ListErrors;
			var error = $"Nie została podana liczba. Zostało podane {score}";
			
			Assert.Multiple(() =>
			{
				Assert.That(employee.Scores[0], Is.EqualTo(84));
				Assert.That(employee.Scores, Has.Length.EqualTo(1));
				Assert.That(listErrors, Has.Length.EqualTo(1));
				Assert.That(listErrors[0], Is.EqualTo(error));
			});
		}

		[Test]
		public void CheckCorrectAddScoreFromListTypeOfFloat()
		{
			var employee = new Employee("Monika", "Mika");
			var minNote = 2.47f;
			var averageNote = 6.85f;
			var maxNote = 54.68f;
			var score = 251.45f;
			var average = (minNote + averageNote + maxNote) / 3;

			employee.AddScore([minNote, averageNote, maxNote, score]);
			var listErrors = employee.ListErrors;
			var statistics = employee.GetStatistics();
			var error = $"Wartość poza zakresem. Zostało podane {score}";

			Assert.Multiple(() =>
			{
				Assert.That(statistics.Min, Is.EqualTo(minNote));
				Assert.That(statistics.Max, Is.EqualTo(maxNote));
				Assert.That(statistics.Average, Is.EqualTo(average));
				Assert.That(listErrors, Has.Length.EqualTo(1));
				Assert.That(listErrors[0], Is.EqualTo(error));
			});
		}

		[Test]
		public void CheckCorrectAddScoreFromListTYpeOfDouble()
		{
			var employee = new Employee("Monika", "Mika");
			var minNote = 2.47;
			var averageNote = 6.85;
			var maxNote = 54.68;
			var score = 251.45;
			var average = (minNote + averageNote + maxNote) / 3;

			employee.AddScore([minNote, averageNote, maxNote, score]);
			var listErrors = employee.ListErrors;
			var statistics = employee.GetStatistics();
			var error = $"Wartość poza zakresem. Zostało podane {score}";

			Assert.Multiple(() =>
			{
				Assert.That(statistics.Min, Is.EqualTo((float)minNote));
				Assert.That(statistics.Max, Is.EqualTo((float)maxNote));
				Assert.That(statistics.Average, Is.EqualTo((float)average));
				Assert.That(listErrors, Has.Length.EqualTo(1));
				Assert.That(listErrors[0], Is.EqualTo(error));
			});
		}

		[Test]
		public void CheckCorrectAddScoreFromLetter()
		{
			var employee = new Employee("Monika", "Mika");
			var inCorrectLetter = "x";
			var error = $"Nieprawidłowa litera, zostało podane {inCorrectLetter}";

			employee.AddScore("a");
			employee.AddScore("b");
			employee.AddScore(inCorrectLetter);
			var statistics = employee.GetStatistics();
			var listErrors = employee.ListErrors;

			Assert.Multiple(() =>
			{
				Assert.That(statistics.Min, Is.EqualTo(90));
				Assert.That(statistics.Max, Is.EqualTo(100));
				Assert.That(statistics.Average, Is.EqualTo((100f + 90f) / 2f));
				Assert.That(listErrors, Has.Length.EqualTo(1));
				Assert.That(listErrors[0], Is.EqualTo(error));
			});
		}
	}
}
