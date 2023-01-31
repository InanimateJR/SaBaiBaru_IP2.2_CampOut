using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SimplePlayerStats
{
    public string username;
    public int totalScore;
    public int leaderboardLastUpdated;
    public int sticksCollected;
    public int foodCooked;
    public int fishCollected;
    public int mushroomsCollected;
    public SimplePlayerStats()
    {
    }

    public SimplePlayerStats(string username, int totalScore, int leaderboardLastUpdated, int foodCooked, int fishCollected, int mushroomsCollected, int sticksCollected)
    {
        this.username = username;
        this.totalScore = totalScore;
        this.leaderboardLastUpdated = leaderboardLastUpdated;
        this.foodCooked = foodCooked;
        this.fishCollected = fishCollected; 
        this.mushroomsCollected = mushroomsCollected;
        this.sticksCollected = sticksCollected;
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