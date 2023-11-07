using System.Collections.Generic;

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Fish
    {
        public string name { get; set; }
        public int depthRange { get; set; }
        public int rarity { get; set; }
        public int moneyRange { get; set; }
        public int starLevel { get; set; }
        public int lengthRange { get; set; }
        public int lureChance { get; set; }
        public int lureLevel { get; set; }
    }
