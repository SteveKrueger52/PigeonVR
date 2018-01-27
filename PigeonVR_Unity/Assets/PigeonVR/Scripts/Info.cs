using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Info : MonoBehaviour{
    // Location Enumeration
    public enum Location { TOWN, FOREST, DESERT, SNOW, VOLCANO, WASTELAND, CITY, MOON}

    [System.Serializable]
    public struct LocationDataWrapper {
        public LocationData[] locations;

        public override string ToString() {
            string res = "locations: [";
            foreach(var l in locations) {
                res += "{" + l.ToString() + "}";
            }
            res += "]";
            return res;
        }
    }

    [System.Serializable]
    public struct LocationData {
        public string id;
        public LetterData[] letters;

        public override string ToString() {
            string res = "id: " + id + ", letters: [";
            foreach(var letter in letters) {
                res += "{" + letter.ToString() + "}";
            }
            res += "]";
            return res;
        }
    }

    [System.Serializable]
    public struct LetterData {
        public string text;
        public int weight;

        public override string ToString() {
            return "text: " + text + ", weight: " + weight;
        }
    }

    // Singleton Code
    public static Info instance = null;
    private static string gameDataFileName = "data.json";
    private Dictionary <Location, string[]> _senders = new Dictionary<Location, string[]> ();

    private void Awake() {
        // setup of Singleton
        if (instance != null && instance != this) 
        {
            Destroy(this.gameObject);
        }
        instance = this;
        Init ();
        DontDestroyOnLoad( this.gameObject );
    }

    private void Init() {
        // Load data from JSON file - not implemented yet
        string filepath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);
        if (File.Exists(filepath)) {
            // Read the json from the file into a string
            string dataAsJson = File.ReadAllText(filepath); 
            // Pass the json to JsonUtility, and tell it to create a GameData object from it
            LocationDataWrapper locationData = JsonUtility.FromJson<LocationDataWrapper>(dataAsJson);
            Debug.Log(locationData);
        }
        else
        {
            File.WriteAllText(filepath, "{\"message\":\"HERE I AM\"}");
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
    public static string[] getAllSenders (Location loc) {
        string[] output;
        if (instance._senders.TryGetValue(loc, out output))
            return output;
        return new string[]{};
    }

    // Gets a random sender
    public static string getRandomSender (Location loc) {
        string[] output;
        if (instance._senders.TryGetValue(loc, out output)) {
            return output [(int) Random.Range (0, output.GetLength (0) - 1)];
        }
        return "Nobody In Particular";
    }
}
