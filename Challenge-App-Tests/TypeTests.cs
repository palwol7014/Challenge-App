using Challenge_App;

namespace Challenge_App_Tests
{
	internal class TypeTests
	{
		private Person person1;
		private Person person2;

		[SetUp]
		public void Setup()
		{
			person1 = new("Mateusz", "Nowak", "11111");
			person2 = new("Mateusz", "Nowak", "11111");
		}

		[Test]
		public void TestCompareTwoObjectAsTypeOfValue()
		{
			//Bum! Zasłona spadła.
			//String jest tak naprawdę typem referencyjnym, tylko implementacja operatorów "==", "!=", przeciążenie metod GetHashCode i Equals powoduje, że typ jest interpretowany rownież jako wartościowy. 
			Assert.That(person1, Is.EqualTo(person2));
		}

		[Test]
		public void TestCompareString()
		{
			string s1 = "aaa";
			string s2 = "aaa";

			Assert.That(s1, Is.EqualTo(s2));
		}

		[Test]
		public void TestCompareInt()
		{
			int x = 3;
			int y = 3;

			Assert.That(x, Is.EqualTo(y));
		}
	}
}
