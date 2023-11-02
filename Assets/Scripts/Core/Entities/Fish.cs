public class Fish
{
    public int DepthRange { get; set; }
    public int Rarity { get; set; }
    public int MoneyRange { get; set; }
    public int StarLevel { get; set; }
    public int LengthRange { get; set; }
    public int LureChance { get; set; }
    public int LureLevel { get; set; }

    public Fish(int depthRange, int rarity, int moneyRange, int starLevel, int lengthRange, int lureChance, int lureLevel)
    {
        DepthRange = depthRange;
        Rarity = rarity;
        MoneyRange = moneyRange;
        StarLevel = starLevel;
        LengthRange = lengthRange;
        LureChance = lureChance;
        LureLevel = lureLevel;
    }
}