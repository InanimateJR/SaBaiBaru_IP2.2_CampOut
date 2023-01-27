using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Auth;
using Firebase.Extensions;

public class FirebaseTesting : MonoBehaviour
{
    int mushroomsCollected = 0;
    int fishCollected = 0;
    int foodCooked = 0;
    int tentPoints = 0;
    int sticksCollected = 0;
    int leaderboardLastUpdated;
    int totalScore = 0;
    string username;
    string userID;
    Firebase.Auth.FirebaseAuth auth;
    DatabaseReference mDatabaseRef;
    DatabaseReference dbPlayerStatsReference;
    // Start is called before the first frame update
    private void Awake()
    {
        auth = FirebaseAuth.DefaultInstance;
        mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;
        dbPlayerStatsReference = FirebaseDatabase.DefaultInstance.GetReference("PlayerScores");
    }
    void Start()
    {
        Firebase.Auth.FirebaseUser currentUser = auth.CurrentUser;
        Debug.Log("User Recorded");
        if (currentUser != null)
        {
            userID = currentUser.UserId;
            username = currentUser.DisplayName;
            Debug.Log(username + userID);

        }
        totalScore = tentPoints + foodCooked + fishCollected + mushroomsCollected + sticksCollected;
        var epochStart = new System.DateTime(1970, 1, 1, 8, 0, 0, System.DateTimeKind.Utc);
        var timestamp = (System.DateTime.UtcNow - epochStart).TotalSeconds;
        leaderboardLastUpdated = (int)timestamp;
        WriteNewScore(userID, username, totalScore, leaderboardLastUpdated, foodCooked, fishCollected, mushroomsCollected, sticksCollected);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void WriteNewScore(string userId, string username, int totalScore, int leaderboardLastUpdated,  int foodCooked, int fishCollected, int mushroomsCollected, int sticksCollected)
    {
        Scores score = new Scores(username, totalScore, leaderboardLastUpdated, foodCooked, fishCollected, mushroomsCollected, sticksCollected);
        string json = JsonUtility.ToJson(score);

        mDatabaseRef.Child("PlayerScores").Child(userId).SetRawJsonValueAsync(json);
    }
}
