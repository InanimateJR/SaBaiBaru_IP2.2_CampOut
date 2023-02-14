using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Auth;
using Firebase.Extensions;
using System;
using TMPro;
public class GetUserLogins : MonoBehaviour
{
    DatabaseReference dbUserStatsReference;
    Firebase.Auth.FirebaseAuth auth;
    long lastLogin;
    long accountCreation;
    string username;
    string userID;

    public TMP_Text loginDisplay;
    public TMP_Text accountCreationDisplay;
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
            Debug.Log(userID);
        }
    }
    public void InitializeFirebase()
    {
        dbUserStatsReference = FirebaseDatabase.DefaultInstance.GetReference("User");
        auth = FirebaseAuth.DefaultInstance;
    }

    public void GetUserLogin()
    {
        dbUserStatsReference.Child(userID).GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                string json = task.Result.GetRawJsonValue();
                User user = JsonUtility.FromJson<User>(json);
                lastLogin = user.lastLogin;
                accountCreation = user.creationDate;
                Debug.Log(lastLogin + " + " + accountCreation);
                DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                dateTime = dateTime.AddSeconds(lastLogin).ToLocalTime();
                string loginString = dateTime.ToString("dd/MM/yyyy HH:mm:ss");
                DateTime dateTime2 = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                dateTime2 = dateTime2.AddSeconds(accountCreation).ToLocalTime();
                string accountCreationString = dateTime2.ToString("dd/MM/yyyy HH:mm:ss");
                loginDisplay.text = ("Last Login: " + loginString);
                accountCreationDisplay.text = ("Accoutn Created: " + accountCreationString);

            }
            if (task.IsFaulted)
            {
                Debug.LogError("UserRetrieval encountered an error: " + task.Exception);
                return;
            }
        });
    }
}
