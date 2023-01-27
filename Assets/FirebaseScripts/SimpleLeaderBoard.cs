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

public class SimpleLeaderBoard
{
    public string username;
    public int totalScore;
    public int leaderboardLastUpdated;
    public SimpleLeaderBoard()
    {
    }

    public SimpleLeaderBoard(string username, int totalScore, int leaderboardLastUpdated)
    {
        this.username = username;
        this.totalScore = totalScore;
        this.leaderboardLastUpdated = leaderboardLastUpdated;
    }

    public string SimpleLeaderboardToJson()
    {
        return JsonUtility.ToJson(this);
    }
}
