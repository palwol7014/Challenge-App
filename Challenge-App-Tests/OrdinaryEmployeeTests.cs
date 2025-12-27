using Challenge_App;

namespace Challenge_App_Tests
{
	internal class OrdinaryEmployeeTests
	{
		[Test]
		public void CheckCorrectAddScoreFromString()
		{
			var employee = new OrdinaryEmployee("Monika", "Mika");
			var score = "jeden";
			var error = $"Nie została podana liczba. Zostało podane {score}";

			Assert.Multiple(() =>
			{
				Assert.DoesNotThrow(() => employee.AddScore("a"));
				Assert.Throws(Is.TypeOf<Exception>().And.Message.EqualTo(error), () => employee.AddScore(score));
				Assert.That(employee.Scores[0], Is.EqualTo(100));
				Assert.That(employee.Scores, Has.Length.EqualTo(1));
			});
		}
	}
}
