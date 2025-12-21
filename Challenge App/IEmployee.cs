namespace Challenge_App
{
    internal interface IEmployee
    {
		public void AddScore(float score);
		public void AddScore(List<float> scores);
		public void AddScore(string score);
		public void AddScore(double score);
		public void AddScore(List<double> scores);
		public void AddScore(char letter);

	 }
}
