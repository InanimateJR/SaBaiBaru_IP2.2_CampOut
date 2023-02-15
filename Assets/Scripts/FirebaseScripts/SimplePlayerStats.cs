using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SimplePlayerStats
{
    public string username;
    public int totalScore;
    public int leaderboardLastUpdated;
    public int sticksScore;
    public int foodCooked;
    public int fishScore;
    public int mushroomsScore;
    public SimplePlayerStats()
    {
    }

    public SimplePlayerStats(string username, int totalScore, int leaderboardLastUpdated, int foodCooked, int fishScore, int mushroomsScore, int sticksScore)
    {
        this.username = username;
        this.totalScore = totalScore;
        this.leaderboardLastUpdated = leaderboardLastUpdated;
        this.foodCooked = foodCooked;
        this.fishScore = fishScore; 
        this.mushroomsScore = mushroomsScore;
        this.sticksScore = sticksScore;
    }

    public long GetTimeUnix()
    {
        return new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
    }
    public string SimplePlayerStatsToJson()
    {
        return JsonUtility.ToJson(this);
    }
}