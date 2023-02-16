using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Auth;
using TMPro;
using Firebase.Extensions;
using UnityEngine.SceneManagement;

public class AuthManager : MonoBehaviour
{
    Firebase.Auth.FirebaseAuth auth;
    DatabaseReference mDatabaseRef;
    public GameObject loginScreen;
    public GameObject signedInScreen;
    public GameObject tableTutorialScreen;
    public GameObject fishingTutorialScreen;
    public GameObject campfireTutorialScreen;
    public TMP_InputField emailRegister;
    public TMP_InputField passwordRegister;
    public TMP_InputField emailLogin;
    public TMP_InputField passwordLogin;
    public TextMeshProUGUI registerFail;
    public TextMeshProUGUI loginFail;
    public TMP_Text usernameDisplay;
    public string uid;
    public TMP_InputField usernameRegister;
    public TextMeshProUGUI helloText;
    public string username;
    public int creationTime;
    public int lastLogin;
    public string emailAddress;
    private void Awake()
    {
        loginScreen.SetActive(true);
        signedInScreen.SetActive(false);
        //sets up firebase
        auth = FirebaseAuth.DefaultInstance;
        mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void RegisterButton()
    {
        Register(emailRegister.text, passwordRegister.text);
    }
    public void SignInButton()
    {
        SignInUser(emailLogin.text, passwordLogin.text);
    }

    private void Register(string email, string password)
    {
        //registers the user, then creates user data in firebase with their email, username and creation time
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted || task.IsCanceled)
            {
                Debug.LogError("Sorry, there was an error creating your new account, ERROR: " + task.Exception);
                registerFail.gameObject.SetActive(true);
                loginFail.gameObject.SetActive(false);
                return;
            }
            else if (task.IsCompleted)
            {
                Firebase.Auth.FirebaseUser newPlayer = task.Result;
                //SceneManager.LoadScene(1);
                Debug.LogFormat("User signed in successfully: ({0})", newPlayer.UserId);
                string uid = newPlayer.UserId;
                var epochStart = new System.DateTime(1970, 1, 1, 8, 0, 0, System.DateTimeKind.Utc);
                var timestamp = (System.DateTime.UtcNow - epochStart).TotalSeconds;
                int creationTime = (int)timestamp;
                int lastLogin = (int)timestamp;
                WriteNewUser(uid, emailRegister.text, usernameRegister.text, creationTime, lastLogin);
                WriteNewScore(uid, usernameRegister.text, 0, lastLogin, 0, 0, 0, 0);
                loginScreen.SetActive(false);
                signedInScreen.SetActive(true);
                campfireTutorialScreen.SetActive(true);
                tableTutorialScreen.SetActive(true);
                fishingTutorialScreen.SetActive(true);
                LoadUsername();
            }
        });
        Firebase.Auth.FirebaseUser currentUser = auth.CurrentUser;
        if (currentUser != null)
        {
            Firebase.Auth.UserProfile profile = new Firebase.Auth.UserProfile
            {
                DisplayName = usernameRegister.text,
            };
            currentUser.UpdateUserProfileAsync(profile).ContinueWith(task => {
                if (task.IsCanceled)
                {
                    Debug.LogError("UpdateUserProfileAsync was canceled.");
                    return;
                }
                if (task.IsFaulted)
                {
                    Debug.LogError("UpdateUserProfileAsync encountered an error: " + task.Exception);
                    return;
                }

                Debug.Log("User profile updated successfully.");
            });
            username = currentUser.DisplayName;
        }
    }

    public void SignInUser(string email, string password)
    {
        //logs in according to the credentials
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(authTask =>
        {
            if (authTask.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPassword Sync was cancelled");
                return;
            }
            if (authTask.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPassword Async encountered an error: " + authTask.Exception);
                registerFail.gameObject.SetActive(false);
                loginFail.gameObject.SetActive(true);
                return;
            }
            FirebaseUser currentPlayer = authTask.Result;
            if (currentPlayer != null)
            {
                string uid = currentPlayer.UserId;
                username = currentPlayer.DisplayName;
                var epochStart = new System.DateTime(1970, 1, 1, 8, 0, 0, System.DateTimeKind.Utc);
                var timestamp = (System.DateTime.UtcNow - epochStart).TotalSeconds;
                int lastLogin = (int)timestamp;
                UpdatePlayerLogin(uid, lastLogin);
                loginScreen.SetActive(false);
                signedInScreen.SetActive(true);
                campfireTutorialScreen.SetActive(true);
                tableTutorialScreen.SetActive(true);
                fishingTutorialScreen.SetActive(true);
                LoadUsername();
            }
        });
    }

    public void SignOut()
    {
        //signs current user out
        if (auth.CurrentUser != null)
        {
            auth.SignOut();
            loginScreen.SetActive(true);
            signedInScreen.SetActive(false);
        }

    }

    private void UpdatePlayerLogin(string userId, int lastLogin)
    {
        string myString = lastLogin.ToString();
        mDatabaseRef.Child("User").Child(userId).Child("lastLogin").SetRawJsonValueAsync(myString);
    }

    private void WriteNewUser(string userId, string email, string username, int creationDate, int lastLogin)
    {
        //writes the new user's id, email, username and creation date into firebase
        User user = new User(email, username, creationDate, lastLogin);
        string json = JsonUtility.ToJson(user);

        mDatabaseRef.Child("User").Child(userId).SetRawJsonValueAsync(json);
    }
    private void WriteNewScore(string userId, string username, int totalScore, int leaderboardLastUpdated, int foodCooked, int fishScore
        , int mushroomsScore, int sticksScore)
    {
        SimplePlayerStats sp = new SimplePlayerStats(username, totalScore, leaderboardLastUpdated, foodCooked, fishScore, mushroomsScore, sticksScore);
        string json = JsonUtility.ToJson(sp);

        mDatabaseRef.Child("playerStats").Child(userId).SetRawJsonValueAsync(json);
    }
    public void ResetPassword()
    {
        Firebase.Auth.FirebaseUser currentUser = auth.CurrentUser;
        if (currentUser != null)
        {
            emailAddress = currentUser.Email;
        }
        if (currentUser != null)
        {
            auth.SendPasswordResetEmailAsync(emailAddress).ContinueWithOnMainThread(task => {
                if (task.IsCanceled)
                {
                    Debug.LogError("SendPasswordResetEmailAsync was canceled.");
                    return;
                }
                if (task.IsFaulted)
                {
                    Debug.LogError("SendPasswordResetEmailAsync encountered an error: " + task.Exception);
                    return;
                }

                Debug.Log("Password reset email sent successfully.");
            });
        }
    }
    public void RestartScene()
    {
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }
    public void ChangeScene(int sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void LoadUsername()
    {
        Firebase.Auth.FirebaseUser currentUser = auth.CurrentUser;
        if (currentUser != null)
        {
            string uid = currentUser.UserId;
            Query userData = mDatabaseRef.Child("User").Child(uid);
            userData.GetValueAsync().ContinueWithOnMainThread(task =>
            {
                if (task.IsCompleted)
                {
                    DataSnapshot userInfo = task.Result;
                    if (userInfo.Exists)
                    {
                        User user = JsonUtility.FromJson<User>(userInfo.GetRawJsonValue());
                        username = user.username;
                        usernameDisplay.text = ("Current Player: " + username);
                    }
                }
            });
        }
    }
}
