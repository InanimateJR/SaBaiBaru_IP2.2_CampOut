using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Auth;
using TMPro;

public class LoginRecorder : MonoBehaviour
{
    Firebase.Auth.FirebaseAuth auth;
    DatabaseReference mDatabaseRef;
    // Start is called before the first frame update
    private void Awake()
    {
        //sets up firebase
        auth = FirebaseAuth.DefaultInstance;
        mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;
        Firebase.Auth.FirebaseUser currentUser = auth.CurrentUser;
        if (currentUser != null)
        {
            var epochStart = new System.DateTime(1970, 1, 1, 8, 0, 0, System.DateTimeKind.Utc);
            var timestamp = (System.DateTime.UtcNow - epochStart).TotalSeconds;
            int lastLogin = (int)timestamp;
            UpdatePlayerLogin(currentUser.UserId, lastLogin);
        }
    }

    private void UpdatePlayerLogin(string userId, int lastLogin)
    {
        string myString = lastLogin.ToString();
        mDatabaseRef.Child("User").Child(userId).Child("lastLogin").SetRawJsonValueAsync(myString);
    }
}
