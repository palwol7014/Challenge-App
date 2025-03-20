using Challenge_App;

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
			var average = (minNote + averageNote + maxNote) / 3;
			var error = $"Wartość poza zakresem. Zostało podane {score}";

			Assert.Multiple(() =>
			{
				Assert.DoesNotThrow(() => employee.AddScore(minNote));
				Assert.DoesNotThrow(() => employee.AddScore(averageNote));
				Assert.DoesNotThrow(() => employee.AddScore(maxNote));
				Assert.Throws(Is.TypeOf<Exception>().And.Message.EqualTo(error), () => employee.AddScore(score));
				var statistics = employee.GetStatistics();
				Assert.That(statistics.Min, Is.EqualTo(minNote));
				Assert.That(statistics.Max, Is.EqualTo(maxNote));
				Assert.That(statistics.Average, Is.EqualTo(average));
			});
		}

		[Test]
		public void CheckCorrectAddScoreFromString()
		{
			var employee = new Employee("Monika", "Mika");
			var score = "jeden";
			var error = $"Nie została podana liczba. Zostało podane {score}";

			Assert.Multiple(() =>
			{
				Assert.DoesNotThrow(() => employee.AddScore("84"));
				Assert.Throws(Is.TypeOf<Exception>().And.Message.EqualTo(error), () => employee.AddScore(score));
				Assert.That(employee.Scores[0], Is.EqualTo(84));
				Assert.That(employee.Scores, Has.Length.EqualTo(1));
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
			var error = $"Wartość poza zakresem. Zostało podane {score}";

			Assert.Multiple(() =>
			{
				Assert.Throws(Is.TypeOf<Exception>().And.Message.EqualTo(error), () => employee.AddScore([minNote, averageNote, maxNote, score]));
				var statistics = employee.GetStatistics();
				Assert.That(statistics.Min, Is.EqualTo(minNote));
				Assert.That(statistics.Max, Is.EqualTo(maxNote));
				Assert.That(statistics.Average, Is.EqualTo(average));
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
			var error = $"Wartość poza zakresem. Zostało podane {score}";

			Assert.Multiple(() =>
			{
				Assert.Throws(Is.TypeOf<Exception>().And.Message.EqualTo(error), () => employee.AddScore([minNote, averageNote, maxNote, score]));
				var statistics = employee.GetStatistics();
				Assert.That(statistics.Min, Is.EqualTo((float)minNote));
				Assert.That(statistics.Max, Is.EqualTo((float)maxNote));
				Assert.That(statistics.Average, Is.EqualTo((float)average));
			});
		}

		[Test]
		public void CheckCorrectAddScoreFromLetter()
		{
			var employee = new Employee("Monika", "Mika");
			var inCorrectLetter = "x";
			var error = $"Nieprawidłowa litera, zostało podane {inCorrectLetter}";

			Assert.Multiple(() =>
			{
				Assert.DoesNotThrow(() => employee.AddScore("a"));
				Assert.DoesNotThrow(() => employee.AddScore("b"));
				Assert.Throws(Is.TypeOf<Exception>().And.Message.EqualTo(error), () => employee.AddScore(inCorrectLetter));
				var statistics = employee.GetStatistics();
				Assert.That(statistics.Min, Is.EqualTo(90));
				Assert.That(statistics.Max, Is.EqualTo(100));
				Assert.That(statistics.Average, Is.EqualTo((100f + 90f) / 2f));
			});
		}
	}
}
