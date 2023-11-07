using System.Collections.Generic;

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Fish
    {
        public string name { get; set; }
        public int depthMax { get; set; }
        public int depthMin { get; set; }
        public int rarity { get; set; }
        public int baseMoney { get; set; }        public int starsMax { get; set; }
        public int starLevel { get; set; }
        public int lengthMax { get; set; }
        public int lengthMin { get; set; }
        public int lureChance { get; set; }
        public int lureLevel { get; set; }
    }
