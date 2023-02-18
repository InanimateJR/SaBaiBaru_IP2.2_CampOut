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
            //get user data
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
        dbLeaderboardsReference = FirebaseDatabase.DefaultInstance.GetReference("leaderBoard");
        dbPlayerStatsReference = FirebaseDatabase.DefaultInstance.GetReference("playerStats");
        mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;
        auth = FirebaseAuth.DefaultInstance;
    }

    public void WriteNewScore(string userId, string username, int totalScore, int leaderboardLastUpdated, int foodCooked, int fishScore, int mushroomsScore, int sticksScore)
    {
        SimplePlayerStats sp = new SimplePlayerStats(username, totalScore, leaderboardLastUpdated, foodCooked, fishScore, mushroomsScore, sticksScore);
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
        //updates mushroom scores
        Firebase.Auth.FirebaseUser currentUser = auth.CurrentUser;
        if (currentUser != null)
        {
            Query playerQuery = dbPlayerStatsReference.Child(userID);
            Debug.Log("MushroomUpdate");
            playerQuery.GetValueAsync().ContinueWithOnMainThread(task =>
            {
                if (task.IsCanceled || task.IsFaulted)
                {

                }
                else if (task.IsCompleted)
                {
                    DataSnapshot playerStats = task.Result;
                    if (playerStats.Exists)
                    {
                        SimplePlayerStats sp = JsonUtility.FromJson<SimplePlayerStats>(playerStats.GetRawJsonValue());
                        sp.mushroomsScore += mushroomScore;
                        var epochStart = new System.DateTime(1970, 1, 1, 8, 0, 0, System.DateTimeKind.Utc);
                        var timestamp = (System.DateTime.UtcNow - epochStart).TotalSeconds;
                        sp.leaderboardLastUpdated = (int)timestamp;
                        sp.totalScore = sp.foodCooked + sp.fishScore + sp.mushroomsScore + sp.sticksScore;
                        dbPlayerStatsReference.Child(userID).SetRawJsonValueAsync(sp.SimplePlayerStatsToJson());
                        WriteNewLeaderBoard(userID, sp.username, sp.totalScore, sp.leaderboardLastUpdated);

                    }
                }
            });
        }
    }
    public void UpdateFish(int fishScore)
    {
        //updates fish scores
        Firebase.Auth.FirebaseUser currentUser = auth.CurrentUser;
        if (currentUser != null)
        {
            Query playerQuery = dbPlayerStatsReference.Child(userID);
            Debug.Log("FishUpdate");
            playerQuery.GetValueAsync().ContinueWithOnMainThread(task =>
            {
                if (task.IsCanceled || task.IsFaulted)
                {

                }
                else if (task.IsCompleted)
                {
                    DataSnapshot playerStats = task.Result;
                    if (playerStats.Exists)
                    {
                        SimplePlayerStats sp = JsonUtility.FromJson<SimplePlayerStats>(playerStats.GetRawJsonValue());
                        sp.fishScore += fishScore;
                        var epochStart = new System.DateTime(1970, 1, 1, 8, 0, 0, System.DateTimeKind.Utc);
                        var timestamp = (System.DateTime.UtcNow - epochStart).TotalSeconds;
                        sp.leaderboardLastUpdated = (int)timestamp;
                        sp.totalScore = sp.foodCooked + sp.fishScore + sp.mushroomsScore + sp.sticksScore;
                        dbPlayerStatsReference.Child(userID).SetRawJsonValueAsync(sp.SimplePlayerStatsToJson());
                        WriteNewLeaderBoard(userID, sp.username, sp.totalScore, sp.leaderboardLastUpdated);
                    }
                }
            });
        }
    }
    public void UpdateFood(int foodScore)
    {
        //updates cooked food score
        Firebase.Auth.FirebaseUser currentUser = auth.CurrentUser;
        if (currentUser != null)
        {
            Query playerQuery = dbPlayerStatsReference.Child(userID);
            Debug.Log("FoodUpdate");
            playerQuery.GetValueAsync().ContinueWithOnMainThread(task =>
            {
                if (task.IsCanceled || task.IsFaulted)
                {

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
                        sp.totalScore = sp.foodCooked + sp.fishScore + sp.mushroomsScore + sp.sticksScore;
                        dbPlayerStatsReference.Child(userID).SetRawJsonValueAsync(sp.SimplePlayerStatsToJson());
                        WriteNewLeaderBoard(userID, sp.username, sp.totalScore, sp.leaderboardLastUpdated);
                    }
                }
            });
        }
    }
    public void UpdateSticks(int sticksScore)
    {
        //updates sticks score
        Firebase.Auth.FirebaseUser currentUser = auth.CurrentUser;
        if (currentUser != null)
        {
            Query playerQuery = dbPlayerStatsReference.Child(userID);
            Debug.Log("SticksUpdate");
            playerQuery.GetValueAsync().ContinueWithOnMainThread(task =>
            {
                if (task.IsCanceled || task.IsFaulted)
                {

                }
                else if (task.IsCompleted)
                {
                    DataSnapshot playerStats = task.Result;
                    if (playerStats.Exists)
                    {
                        SimplePlayerStats sp = JsonUtility.FromJson<SimplePlayerStats>(playerStats.GetRawJsonValue());
                        sp.sticksScore += sticksScore;
                        var epochStart = new System.DateTime(1970, 1, 1, 8, 0, 0, System.DateTimeKind.Utc);
                        var timestamp = (System.DateTime.UtcNow - epochStart).TotalSeconds;
                        sp.leaderboardLastUpdated = (int)timestamp;
                        sp.totalScore = sp.foodCooked + sp.fishScore + sp.mushroomsScore + sp.sticksScore;
                        dbPlayerStatsReference.Child(userID).SetRawJsonValueAsync(sp.SimplePlayerStatsToJson());
                        WriteNewLeaderBoard(userID, sp.username, sp.totalScore, sp.leaderboardLastUpdated);
                    }
                }
            });
        }

    }


    public async Task<List<SimpleLeaderBoard>> GetLeaderboard()
    {
        //gets a List object for leaderboard to display later
        Query q = dbLeaderboardsReference.OrderByChild("totalScore").LimitToLast(5);

        List<SimpleLeaderBoard> leaderBoardList = new List<SimpleLeaderBoard>();
        q.KeepSynced(true);

        await q.GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled || task.IsFaulted)
            {

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
                        //Debug.LogFormat("Leaderboard: Rank {0} Playername {1} High Score {2}", rankCounter, lb.username, lb.totalScore);
                        rankCounter++;
                    }
                }
            }
        });

        return leaderBoardList;
    }
}
