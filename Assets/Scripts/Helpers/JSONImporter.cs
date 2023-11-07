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
            UnityEngine.Debug.Log("File Contents: " + json);
            fishList = JsonConvert.DeserializeObject<List<Fish>>(json);
            UnityEngine.Debug.Log("fish 0: " + fishList[0].name);
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