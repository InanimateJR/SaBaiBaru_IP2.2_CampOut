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

    void Start()
    {
        fbManager.GetLeaderboard(5);
    }
}
