/**
//This class will pull JSON from a file and then turn it into CSharp Objects.
//We can use this for storing data such as fish, lures, characters, dialogue
//to use this helper:

string json = Resources.Load<TextAsset>("Data/FishData").text;
Fish[] fishArray = JsonHelper.FromJson<Fish>(json);

**/

using System;
using UnityEngine;

public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}