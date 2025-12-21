

using Challenge_App;

namespace Challenge_App_Tests
{
	internal class SupervisorTests
	{
		[Test]
		public void CheckCorrectCreateSupervisor()
		{
			var name = "Monika";
			var surmane = "Mika";
			var supervisor = new Supervisor(name, surmane);
			var statistics = supervisor.GetStatistics();

			Assert.Multiple(() =>
			{
				Assert.That(supervisor.Name, Is.EqualTo(name));
				Assert.That(supervisor.Surname, Is.EqualTo(surmane));
				Assert.That(statistics.Max, Is.EqualTo(0));
				Assert.That(statistics.Min, Is.EqualTo(0));
				Assert.That(statistics.Average, Is.EqualTo(0));
			});
		}

		[Test]
		public void CheckCorrectCalculateStatisticsSupervisor()
		{
			var supervisor = new Supervisor("Monika", "Mika");
			var minNote = 2.47f;
			var averageNote = 6.85f;
			var maxNote = 54.68f;
			var score = 101.43f;
			var average = (minNote + averageNote + maxNote) / 3;
			var error = $"Wartość poza zakresem. Zostało podane {score}";

			Assert.Multiple(() =>
			{
				Assert.DoesNotThrow(() => supervisor.AddScore(minNote));
				Assert.DoesNotThrow(() => supervisor.AddScore(averageNote));
				Assert.DoesNotThrow(() => supervisor.AddScore(maxNote));
				Assert.Throws(Is.TypeOf<Exception>().And.Message.EqualTo(error), () => supervisor.AddScore(score));
				var statistics = supervisor.GetStatistics();
				Assert.That(statistics.Min, Is.EqualTo(minNote));
				Assert.That(statistics.Max, Is.EqualTo(maxNote));
				Assert.That(statistics.Average, Is.EqualTo(average));
			});
		}

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

		[Test]
		public void CheckCorrectAddScoreFromListTypeOfFloat()
		{
			var supervisor = new Supervisor("Monika", "Mika");
			var minNote = 2.47f;
			var averageNote = 6.85f;
			var maxNote = 54.68f;
			var score = 251.45f;
			var average = (minNote + averageNote + maxNote) / 3;
			var error = $"Wartość poza zakresem. Zostało podane {score}";

			Assert.Multiple(() =>
			{
				Assert.Throws(Is.TypeOf<Exception>().And.Message.EqualTo(error), () => supervisor.AddScore([minNote, averageNote, maxNote, score]));
				var statistics = supervisor.GetStatistics();
				Assert.That(statistics.Min, Is.EqualTo(minNote));
				Assert.That(statistics.Max, Is.EqualTo(maxNote));
				Assert.That(statistics.Average, Is.EqualTo(average));
			});
		}

		[Test]
		public void CheckCorrectAddScoreFromListTYpeOfDouble()
		{
			var supervisor = new Supervisor("Monika", "Mika");
			var minNote = 2.47;
			var averageNote = 6.85;
			var maxNote = 54.68;
			var score = 251.45;
			var average = (minNote + averageNote + maxNote) / 3;
			var error = $"Wartość poza zakresem. Zostało podane {score}";

			Assert.Multiple(() =>
			{
				Assert.Throws(Is.TypeOf<Exception>().And.Message.EqualTo(error), () => supervisor.AddScore([minNote, averageNote, maxNote, score]));
				var statistics = supervisor.GetStatistics();
				Assert.That(statistics.Min, Is.EqualTo((float)minNote));
				Assert.That(statistics.Max, Is.EqualTo((float)maxNote));
				Assert.That(statistics.Average, Is.EqualTo((float)average));
			});
		}

		[Test]
		public void CheckCorrectAddScoreFromLetter()
		{
			var supervisor = new Supervisor("Monika", "Mika");
			var inCorrectLetter = 'x';
			var error = $"Nieprawidłowa litera, zostało podane {inCorrectLetter}";

			Assert.Multiple(() =>
			{
				Assert.DoesNotThrow(() => supervisor.AddScore('a'));
				Assert.DoesNotThrow(() => supervisor.AddScore('b'));
				Assert.Throws(Is.TypeOf<Exception>().And.Message.EqualTo(error), () => supervisor.AddScore(inCorrectLetter));
				var statistics = supervisor.GetStatistics();
				Assert.That(statistics.Min, Is.EqualTo(90));
				Assert.That(statistics.Max, Is.EqualTo(100));
				Assert.That(statistics.Average, Is.EqualTo((100f + 90f) / 2f));
			});
		}
	}
}
