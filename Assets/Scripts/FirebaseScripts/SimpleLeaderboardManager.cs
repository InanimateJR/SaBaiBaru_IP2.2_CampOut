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

public class SimpleLeaderboardManager : MonoBehaviour
{
    public SimpleFirebaseManager fbManager;
    public GameObject rowPrefab;
    public Transform tableContent;
    void Awake()
    {
        FirebaseDatabase.DefaultInstance.GetReference("leaderBoard").OrderByChild("totalScore").ValueChanged += HandlePlayerValueChanged;
        StartLeaderboard();
    }
    void HandlePlayerValueChanged(object send, ValueChangedEventArgs args)
    {
        //if leaderboard tab changes, update ingame leaderboard
        if (args.DatabaseError != null)
        {
            return;
        }
        else
        {
            StartLeaderboard();
        }
    }
    public void StartLeaderboard()
    {
        UpdateLeaderBoardUI();
    }
    public async void UpdateLeaderBoardUI()
    {
        var leaderBoardList = await fbManager.GetLeaderboard();
        int rankCounter = 1;

        foreach (Transform item in tableContent)
        {
            Destroy(item.gameObject);

        }
        foreach (SimpleLeaderBoard lb in leaderBoardList)
        {
            //uses list from simplefirebasemanager and then instantiates them into a prefab textmeshpro and arranges them
            Debug.LogFormat("Leaderboard Mgr: Rank {0} Playername {1} High Score {2}", rankCounter, lb.username, lb.totalScore);
            GameObject entry = Instantiate(rowPrefab, tableContent);
            TextMeshProUGUI[] leaderBoardDetails = entry.GetComponentsInChildren<TextMeshProUGUI>(); 
            leaderBoardDetails[0].text = rankCounter.ToString();
            leaderBoardDetails[1].text = lb.username.ToString();
            leaderBoardDetails[2].text = lb.totalScore.ToString();

            rankCounter++;
        }
    }
}
