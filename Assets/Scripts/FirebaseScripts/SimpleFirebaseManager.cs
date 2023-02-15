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

public class SimpleFirebaseManager : MonoBehaviour
{
    DatabaseReference dbPlayerStatsReference;
    Firebase.Auth.FirebaseAuth auth;
    DatabaseReference dbLeaderboardsReference;
    DatabaseReference mDatabaseRef;
    int mushroomsCollected = 0;
    int fishCollected = 0;
    int foodCooked = 0;
    int sticksCollected = 0;
    int leaderboardLastUpdated;
    int totalScore = 0;
    string username;
    string userID;

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
            Debug.Log(username + " + " + userID);
            //totalScore = tentPoints + foodCooked + fishCollected + mushroomsCollected + sticksCollected + 1;
            //var epochStart = new System.DateTime(1970, 1, 1, 8, 0, 0, System.DateTimeKind.Utc);
            //var timestamp = (System.DateTime.UtcNow - epochStart).TotalSeconds;
            //leaderboardLastUpdated = (int)timestamp;
            //WriteNewScore(userID, username, totalScore, leaderboardLastUpdated, foodCooked, fishCollected, mushroomsCollected, sticksCollected);
        }
    }


    public void InitializeFirebase()
    {
        dbLeaderboardsReference = FirebaseDatabase.DefaultInstance.GetReference("leaderBoard");
        dbPlayerStatsReference = FirebaseDatabase.DefaultInstance.GetReference("playerStats");
        mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;
        auth = FirebaseAuth.DefaultInstance;
    }

    public void WriteNewScore(string userId, string username, int totalScore, int leaderboardLastUpdated, int foodCooked, int fishCollected, int mushroomsCollected, int sticksCollected)
    {
        SimplePlayerStats sp = new SimplePlayerStats(username, totalScore, leaderboardLastUpdated, foodCooked, fishCollected, mushroomsCollected, sticksCollected);
        string json = JsonUtility.ToJson(sp);

        mDatabaseRef.Child("playerStats").Child(userId).SetRawJsonValueAsync(json);
    }

    public void WriteNewLeaderBoard(string userId, string username, int totalScore, int leaderboardLastUpdated)
    {
        SimpleLeaderBoard leaderboard = new SimpleLeaderBoard(username, totalScore, leaderboardLastUpdated);
        string json = JsonUtility.ToJson(leaderboard);

        mDatabaseRef.Child("leaderBoard").Child(userId).SetRawJsonValueAsync(json);
    }

    public void UpdateMushrooms(int mushroomScore)
    {
        Query playerQuery = dbPlayerStatsReference.Child(userID);
        Debug.Log("MushroomUpdate");
        playerQuery.GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled || task.IsFaulted)
            {
                Debug.LogError("Sorry, there was an error creating your entries, ERROR: " + task.Exception);
            }
            else if (task.IsCompleted)
            {
                DataSnapshot playerStats = task.Result;
                if (playerStats.Exists)
                {
                    SimplePlayerStats sp = JsonUtility.FromJson<SimplePlayerStats>(playerStats.GetRawJsonValue());
                    sp.mushroomsCollected += mushroomScore;
                    var epochStart = new System.DateTime(1970, 1, 1, 8, 0, 0, System.DateTimeKind.Utc);
                    var timestamp = (System.DateTime.UtcNow - epochStart).TotalSeconds;
                    sp.leaderboardLastUpdated = (int)timestamp;
                    sp.totalScore = sp.foodCooked + sp.fishCollected + sp.mushroomsCollected + sp.sticksCollected;
                    dbPlayerStatsReference.Child(userID).SetRawJsonValueAsync(sp.SimplePlayerStatsToJson());
                    WriteNewLeaderBoard(userID, username, sp.totalScore, sp.leaderboardLastUpdated);

                }
            }
        });

    }
    public void UpdateFish(int fishScore)
    {
        Query playerQuery = dbPlayerStatsReference.Child(userID);
        Debug.Log("FishUpdate");
        playerQuery.GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled || task.IsFaulted)
            {
                Debug.LogError("Sorry, there was an error creating your entries, ERROR: " + task.Exception);
            }
            else if (task.IsCompleted)
            {
                DataSnapshot playerStats = task.Result;
                if (playerStats.Exists)
                {
                    SimplePlayerStats sp = JsonUtility.FromJson<SimplePlayerStats>(playerStats.GetRawJsonValue());
                    sp.fishCollected += fishScore;
                    var epochStart = new System.DateTime(1970, 1, 1, 8, 0, 0, System.DateTimeKind.Utc);
                    var timestamp = (System.DateTime.UtcNow - epochStart).TotalSeconds;
                    sp.leaderboardLastUpdated = (int)timestamp;
                    sp.totalScore = sp.foodCooked + sp.fishCollected + sp.mushroomsCollected + sp.sticksCollected;
                    dbPlayerStatsReference.Child(userID).SetRawJsonValueAsync(sp.SimplePlayerStatsToJson());
                    WriteNewLeaderBoard(userID, username, sp.totalScore, sp.leaderboardLastUpdated);
                }
            }
        });

    }
    public void UpdateFood(int foodScore)
    {
        Query playerQuery = dbPlayerStatsReference.Child(userID);
        Debug.Log("FoodUpdate");
        playerQuery.GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled || task.IsFaulted)
            {
                Debug.LogError("Sorry, there was an error creating your entries, ERROR: " + task.Exception);
            }
            else if (task.IsCompleted)
            {
                DataSnapshot playerStats = task.Result;
                if (playerStats.Exists)
                {
                    SimplePlayerStats sp = JsonUtility.FromJson<SimplePlayerStats>(playerStats.GetRawJsonValue());
                    sp.foodCooked += foodScore;
                    var epochStart = new System.DateTime(1970, 1, 1, 8, 0, 0, System.DateTimeKind.Utc);
                    var timestamp = (System.DateTime.UtcNow - epochStart).TotalSeconds;
                    sp.leaderboardLastUpdated = (int)timestamp;
                    sp.totalScore = sp.foodCooked + sp.fishCollected + sp.mushroomsCollected + sp.sticksCollected;
                    dbPlayerStatsReference.Child(userID).SetRawJsonValueAsync(sp.SimplePlayerStatsToJson());
                    WriteNewLeaderBoard(userID, username, sp.totalScore, sp.leaderboardLastUpdated);
                }
            }
        });

    }
    public void UpdateSticks(int sticksScore)
    {
        Query playerQuery = dbPlayerStatsReference.Child(userID);
        Debug.Log("SticksUpdate");
        playerQuery.GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled || task.IsFaulted)
            {
                Debug.LogError("Sorry, there was an error creating your entries, ERROR: " + task.Exception);
            }
            else if (task.IsCompleted)
            {
                DataSnapshot playerStats = task.Result;
                if (playerStats.Exists)
                {
                    SimplePlayerStats sp = JsonUtility.FromJson<SimplePlayerStats>(playerStats.GetRawJsonValue());
                    sp.sticksCollected += sticksScore;
                    var epochStart = new System.DateTime(1970, 1, 1, 8, 0, 0, System.DateTimeKind.Utc);
                    var timestamp = (System.DateTime.UtcNow - epochStart).TotalSeconds;
                    sp.leaderboardLastUpdated = (int)timestamp;
                    sp.totalScore = sp.foodCooked + sp.fishCollected + sp.mushroomsCollected + sp.sticksCollected;
                    dbPlayerStatsReference.Child(userID).SetRawJsonValueAsync(sp.SimplePlayerStatsToJson());
                    WriteNewLeaderBoard(userID, username, sp.totalScore, sp.leaderboardLastUpdated);
                }
            }
        });

    }


    public async Task<List<SimpleLeaderBoard>> GetLeaderboard(int limit = 5)
    {
        Query q = dbLeaderboardsReference.OrderByChild("totalScore").LimitToLast(limit);

        List<SimpleLeaderBoard> leaderBoardList = new List<SimpleLeaderBoard>();
        q.KeepSynced(true);

        await q.GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled || task.IsFaulted)
            {
                Debug.LogError("Error: ");
            }
            else if (task.IsCompleted)
            {
                DataSnapshot ds = task.Result;
                Debug.Log("Success!");

                if (ds.Exists)
                {
                    int rankCounter = 1;
                    foreach (var record in task.Result.Children)
                    {
                        SimpleLeaderBoard lb = JsonUtility.FromJson<SimpleLeaderBoard>(record.GetRawJsonValue());

                        leaderBoardList.Add(lb);
                        //Debug.LogFormat("Leaderboard: Rank {0} Playername {1} High Score {2}", rankCounter, lb.username, lb.totalScore);
                    }
                    leaderBoardList.Reverse();

                    foreach (SimpleLeaderBoard lb in leaderBoardList)
                    {
                        Debug.LogFormat("Leaderboard: Rank {0} Playername {1} High Score {2}", rankCounter, lb.username, lb.totalScore);
                        rankCounter++;
                    }
                }
            }
        });

        return leaderBoardList;
    }
}
