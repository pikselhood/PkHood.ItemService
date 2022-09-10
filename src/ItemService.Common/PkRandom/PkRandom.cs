
namespace ItemService.Common.PkRandom;

public static class PkRandom
{
    private static Random _random = new Random();
    private const double Difficulty = 1000;
    private const double MinQuality = 1;
    private const double MaxQuality = Difficulty * 5;

    
    public static void SetSeed(int seed)
    {
        _random = new Random(seed);
    }

    public static double GetWithActivation(int dropRate)
    {
        var randomNumber = Get(1, (int) Difficulty);
        var result = ActivationFunction(dropRate, randomNumber) / Difficulty;
        return Math.Round(result, 2);
    }
    
    public static int SelectWithActivation(int dropRate, int number)
    {
        var randomNumber = Get(1, (int) Difficulty);
        var activationRandom = ActivationFunction(dropRate, randomNumber) - 1;
        return (int) (activationRandom / (Difficulty / number));
    }
    
    public static int Get(int max)
    {
        return _random.Next(max);
    }

    public static int Get(int min, int max)
    {
        return _random.Next(min, max);
    }

    private static int ActivationFunction(int dropRate, int x)
    {
        var alpha = Difficulty / dropRate;
        var y = Math.Pow(Difficulty, 1 - alpha) * Math.Pow(x, alpha);
        return (int) y;
    }
}