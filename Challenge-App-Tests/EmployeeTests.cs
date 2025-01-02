using Challenge_App;

namespace Challenge_App_Tests
{
	public class EmployeeTests
	{
		private readonly string name = "Mariusz";
		private readonly string surname = "Kowalski";
		private Employee employee;

		[SetUp]
		public void Setup()
		{
			employee = new(name, surname);
		}

		[Test]
		public void CheckCorrectCreateEmployee()
		{
			var name = "Monika";
			var surmane = "Mika";
			var employee = new Employee(name, surmane);

			Assert.Multiple(() =>
			{
				Assert.That(employee.Name, Is.EqualTo(name));
				Assert.That(employee.Surname, Is.EqualTo(surmane));
				Assert.That(employee.SumScores, Is.EqualTo(0));
			});
		}

		[Test]
		public void CheckCorrectAddPoints()
		{
			employee.AddScore(3);
			employee.AddScore(4);

			Assert.Multiple(() =>
			{
				Assert.That(employee.Scores, Has.Length.EqualTo(2));
				Assert.That(employee.Scores[0], Is.EqualTo(3));
				Assert.That(employee.Scores[1], Is.EqualTo(4));
				Assert.That(employee.SumScores, Is.EqualTo(3 + 4));
			});
		}

		[Test]
		public void CheckCorrectAddPenatlyPoints()
		{
			employee.AddScore(3);
			employee.AddScore(4);
			employee.AddPenatlyScore(5);

			Assert.Multiple(() =>
			{
				Assert.That(employee.Scores, Has.Length.EqualTo(2));
				Assert.That(employee.Scores[0], Is.EqualTo(3));
				Assert.That(employee.Scores[1], Is.EqualTo(4));
				Assert.That(employee.SumScores, Is.EqualTo(3 + 4));
				Assert.That(employee.SumPenatlyScores, Is.EqualTo(5));
				Assert.That(employee.PenatlyScores, Has.Length.EqualTo(1));
				Assert.That(employee.PenatlyScores[0], Is.EqualTo(5));
			});
		}
	}
}
