namespace readabilityTest.Algorithms
{
    public interface IAlgorithm
    {
        double ReadabilityScore { get; }
        int ReadabilityAge { get; }
    }
}