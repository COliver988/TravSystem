namespace TravSystem.Services;

public class UtilityService : IUtilitlityService
{
    private Random _random;
    private static string hexcodes = "0123456789ABCDEFGHJKLMNPQRSTUVWXYZ";

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

    public string IntToHex(int index)
    {
        return hexcodes.Substring(index, 1);
    }
}
