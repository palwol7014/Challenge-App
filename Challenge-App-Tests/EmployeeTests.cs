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
			var minNote = 2.47f;
			var averageNote = 6.85f;
			var maxNote = 54.68f;

			employee.AddScore(minNote);
			employee.AddScore(averageNote);
			employee.AddScore(maxNote);
			var average = (minNote + averageNote + maxNote) / 3;

			var statistics = employee.GetStatistics();

			Assert.Multiple(() =>
			{
				Assert.That(statistics.Min, Is.EqualTo(minNote));
				Assert.That(statistics.Max, Is.EqualTo(maxNote));
				Assert.That(statistics.Average, Is.EqualTo(average));
			});
		}
	}
}
