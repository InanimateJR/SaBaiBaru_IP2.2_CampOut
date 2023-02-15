using System;
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
    Firebase.Auth.FirebaseAuth auth;
    string username;
    string userID;
    int lastLogin;
    int accountCreation;
    public TMP_Text playerName;
    public TMP_Text fishScores;
    public TMP_Text foodScores;
    public TMP_Text sticksScores;
    public TMP_Text mushroomsScores;
    public TMP_Text totalScore;
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
                Debug.Log(playerStats.username + " + " + playerStats.fishScore + " + " + playerStats.mushroomsScore);
                playerName.text = ("Player: " + playerStats.username);
                fishScores.text = ("Fish Score: " + playerStats.fishScore);
                foodScores.text = ("Cooked Food Score: " + playerStats.foodCooked);
                mushroomsScores.text = ("Mushrooms Score: " + playerStats.mushroomsScore);
                sticksScores.text = ("Sticks Score: " + playerStats.sticksScore);
                totalScore.text = ("Total Score: " + playerStats.totalScore);
                //Debug.Log("I hate unity");
            }
        });
    }
}
