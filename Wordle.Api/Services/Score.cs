namespace Wordle.Api.Services
{
    public class Score
{
    public string Name { get; set; }
    public double Average { get; set; }
    public int GameCount { get; set; }

    public Score(string name, double average, int gameCount)
    {
        Name = name;
        Average = average;
        GameCount = gameCount;
    }
}
}
