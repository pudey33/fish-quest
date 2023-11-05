using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JSONImporter
{
    public static List<Fish> ImportFishData(string filePath)
    {
        List<Fish> fishList = new List<Fish>();

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            JSONObject jsonObject = new JSONObject(json);

            foreach (JSONObject fishObject in jsonObject.list)
            {
                int depthRange = (int)fishObject.GetField("depthRange").n;
                int rarity = (int)fishObject.GetField("rarity").n;
                int moneyRange = (int)fishObject.GetField("moneyRange").n;
                int starLevel = (int)fishObject.GetField("starLevel").n;
                int lengthRange = (int)fishObject.GetField("lengthRange").n;
                int lureChance = (int)fishObject.GetField("lureChance").n;
                int lureLevel = (int)fishObject.GetField("lureLevel").n;

                Fish fish = new Fish(depthRange, rarity, moneyRange, starLevel, lengthRange, lureChance, lureLevel);
                fishList.Add(fish);
            }
        }
        else
        {
            Debug.LogError("File not found at path: " + filePath);
        }

        return fishList;
    }
}

