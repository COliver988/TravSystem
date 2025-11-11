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
        if (index < 0)
            index = 0;
        if (index >= hexcodes.Length)
            index = hexcodes.Length - 1;
        return hexcodes.Substring(index, 1);
    }

    public int HexToInt(char hex)
    {
        // Find the index of the character in the hexcodes string
        int index = hexcodes.IndexOf(hex);

        // If the character is not found, throw an exception or handle the error
        if (index == -1)
        {
            throw new ArgumentException($"Invalid hex character: {hex}");
        }

        return index;
    }

}
