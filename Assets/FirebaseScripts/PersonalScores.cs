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

public class PersonalScores : MonoBehaviour
{
    DatabaseReference dbPlayerStatsReference;
    DatabaseReference dbUserStatsReference;
    Firebase.Auth.FirebaseAuth auth;
    int mushroomsCollected = 0;
    int fishCollected = 0;
    int foodCooked = 0;
    int sticksCollected = 0;
    int leaderboardLastUpdated;
    int totalScore = 0;
    string username;
    string userID;

    public TMP_Text playerName;
    public TMP_Text fishScore;
    public TMP_Text foodScore;
    public TMP_Text sticksScore;
    public TMP_Text mushroomsScore;
    public TMP_Text lastLogin;
    public TMP_Text accountCreated;

    public void Awake()
    {
        InitializeFirebase();
    }
    public void Start()
    {
        Firebase.Auth.FirebaseUser currentUser = auth.CurrentUser;
        Debug.Log("User Recorded");
        if (currentUser != null)
        {
            userID = currentUser.UserId;
            username = currentUser.DisplayName;
        }
    }
    public void InitializeFirebase()
    {
        dbPlayerStatsReference = FirebaseDatabase.DefaultInstance.GetReference("playerStats");
        auth = FirebaseAuth.DefaultInstance;
    }

    public void GetPlayerScores()
    {
        dbPlayerStatsReference.Child(userID).GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                string json = task.Result.GetRawJsonValue();
                SimplePlayerStats playerStats = JsonUtility.FromJson<SimplePlayerStats>(json);
                User user = JsonUtility.FromJson<User>(json);
                Debug.Log(playerStats.username + " + " + playerStats.fishCollected + " + " + playerStats.mushroomsCollected);
                playerName.text = ("Player: " + playerStats.username);
                fishScore.text = ("Fish Score: " + playerStats.fishCollected);
                foodScore.text = ("Cooked Food Score: " + playerStats.foodCooked);
                mushroomsScore.text = ("Mushrooms Score: " + playerStats.mushroomsCollected);
                sticksScore.text = ("Sticks Score: " + playerStats.sticksCollected);
            }
        });
    }
}
