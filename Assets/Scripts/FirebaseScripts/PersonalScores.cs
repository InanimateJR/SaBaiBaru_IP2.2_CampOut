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
    //set firebase reference and auth
    DatabaseReference dbPlayerStatsReference;
    DatabaseReference mDatabaseRef;
    Firebase.Auth.FirebaseAuth auth;
    //set variables
    string username;
    string userID;
    int lastLogin;
    int accountCreation;
    //set TMP texts that have to be changed
    public TMP_Text playerName;
    public TMP_Text fishScores;
    public TMP_Text foodScores;
    public TMP_Text sticksScores;
    public TMP_Text mushroomsScores;
    public TMP_Text totalScore;
    public void Awake()
    {
        //start initializing firebase
        InitializeFirebase();
    }
    public void Start()
    {
        //record current user and get UID and Username
        Firebase.Auth.FirebaseUser currentUser = auth.CurrentUser;
        Debug.Log("User Recorded");
        if (currentUser != null)
        {
            userID = currentUser.UserId;
            Query userData = mDatabaseRef.Child("User").Child(userID);
            userData.GetValueAsync().ContinueWithOnMainThread(task =>
            {
                if (task.IsCompleted)
                {
                    DataSnapshot userInfo = task.Result;
                    if (userInfo.Exists)
                    {
                        User user = JsonUtility.FromJson<User>(userInfo.GetRawJsonValue());
                        username = user.username;
                    }
                }
            });
        }
    }
    public void InitializeFirebase()
    {
        dbPlayerStatsReference = FirebaseDatabase.DefaultInstance.GetReference("playerStats");
        mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;
        auth = FirebaseAuth.DefaultInstance;
    }

    public void GetPlayerScores()
    {
        //retrieve playername, fishScore, foodScore, mushroomScore, sticksScore and total score to display
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
