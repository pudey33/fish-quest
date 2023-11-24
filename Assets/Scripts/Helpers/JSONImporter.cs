using System.Runtime.Serialization;
using System;
using System.Security.AccessControl;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class JSONImporter
{
    public static List<Fish> ImportFishData(string filePath)
    {
        List<Fish> fishList = null;

        try
        {
            string json = File.ReadAllText(filePath);
            fishList = JsonConvert.DeserializeObject<List<Fish>>(json);
        }
        catch (FileNotFoundException e)
        {
            Debug.LogError("File not found at path: " + filePath + "error: " + e.Message);
        }
        catch (Exception e)
        {
            Debug.LogError("Error importing fish data: " + e.Message);
        }

        return fishList;
    }
}