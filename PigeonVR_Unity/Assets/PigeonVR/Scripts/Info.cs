using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Info : MonoBehaviour{
    // Location Enumeration
    public enum Location { TOWN, FOREST, DESERT, SNOW, VOLCANO, WASTELAND, CITY, MOON}

    // Singleton Code
    public static Info instance = null;
    private Dictionary <Location, string[]> _senders = new Dictionary<Location, string> ();

    private void Awake() {
        // setup of Singleton
        if (instance != null && instance != this) 
        {
            Destroy(this.gameObject);
        }
        instance = this;
        DontDestroyOnLoad( this.gameObject );
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
        if (instance._senders.TryGetValue(loc,output))
            return output;
        return new string[]{};
    }

    // Gets a random sender
    public static string getRandomSender (Location loc) {
        string[] output;
        if (instance._senders.TryGetValue(loc,output)) {
            return output [(int) Random.Range (0, output.GetLength (0) - 1)];
        }
        return "Nobody In Particular";
    }
}
