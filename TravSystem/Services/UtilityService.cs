namespace TravSystem.Services;

public class UtilityService : IUtilitlityService
{
    private Random _random;

    public UtilityService()
    {
        _random = new Random();
    }

    public int DieRoll(int side, int number)
    {
        int results = 0;
        for (int i = 0; i < number; i++)
        {
            results += _random.Next(1, side + 1);
        }
        return results;
    }
}
