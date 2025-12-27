

using Challenge_App;

namespace Challenge_App_Tests
{
	internal class SupervisorTests
	{
		[Test]
		public void CheckCorrectAddScoreFromString()
		{
			var supervisor = new Supervisor("Monika", "Mika");
			var score1 = "jeden";
			var score2 = "7";
			var error1 = $"Nieprawidłowe dane. Zostało podane {score1}";
			var error2 = $"Wartość poza zakresem. Zostało podane {score2}";

			Assert.Multiple(() =>
			{
				Assert.DoesNotThrow(() => supervisor.AddScore("4+"));
				Assert.Throws(Is.TypeOf<Exception>().And.Message.EqualTo(error1), () => supervisor.AddScore(score1));
				Assert.Throws(Is.TypeOf<Exception>().And.Message.EqualTo(error2), () => supervisor.AddScore(score2));
				Assert.That(supervisor.Scores[0], Is.EqualTo(65));
				Assert.That(supervisor.Scores, Has.Length.EqualTo(1));
			});
		}
	}
}
