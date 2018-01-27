using System.Collections;
using System.Collections.Generic;
using System.IO;
using Enum = System.Enum;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Info : MonoBehaviour{
    // Location Enumeration
    public enum Location { TOWN, FOREST, DESERT, SNOW, VOLCANO, WASTELAND, CITY, MOON}

    [System.Serializable]
    public struct LocationDataWrapper {
        public LocationData[] locations;
    }

    [System.Serializable]
    public struct LocationData {
        public string id;
        public LetterData[] letters;
    }

    [System.Serializable]
    public struct LetterData {
        public string text;
        public int weight;
    }

    // Singleton Code
    public static Info instance = null;
    private static string gameDataFileName = "data.json";
    private Dictionary <Location, LetterData[]> _senders = new Dictionary<Location, LetterData[]> ();

    void Awake() {
        // setup of Singleton
        if (instance != null && instance != this) 
        {
            Destroy(this.gameObject);
        }
        instance = this;
        Init();
        DontDestroyOnLoad(this.gameObject);
    }

    void Init() {
        // Load data from JSON file - not implemented yet
        string filepath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);
        if (File.Exists(filepath)) {
            // Read the json from the file into a string
            string dataAsJson = File.ReadAllText(filepath); 
            // Pass the json to JsonUtility, and tell it to create a GameData object from it
            LocationDataWrapper locationData = JsonUtility.FromJson<LocationDataWrapper>(dataAsJson);
            foreach (var loc in locationData.locations) {
                _senders.Add((Location) Enum.Parse(typeof(Location), loc.id), loc.letters);
            }
        }
        else
        {
            Debug.LogError("Cannot load game data!");
        }
    }

    // Public Functions
    public static Info Instance {
        get {
            return instance ?? (instance = new GameObject("Database").AddComponent<Info>());
        }
    }

    // Gets a list of all senders
    public static LetterData[] getAllSenders (Location loc) {
        LetterData[] output;
        if (instance._senders.TryGetValue(loc, out output))
            return output;
        return new LetterData[]{};
    }

    // Gets a random sender
    public static LetterData getRandomSender (Location loc) {
        LetterData[] output;
        if (instance._senders.TryGetValue(loc, out output)) {
            return output [(int) Random.Range (0, output.GetLength (0) - 1)];
        }
        return new LetterData();
    }
}
