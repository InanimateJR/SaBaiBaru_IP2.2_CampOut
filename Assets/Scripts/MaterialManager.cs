using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Auth;
using Firebase.Extensions;
public class MaterialManager : MonoBehaviour
{
    // Define Materials
    public Material[] foldedTentMats;   // Material Array for Folded Tent
    public Material[] tentMats;         // Material Array for Tent
    public Material[] bagMats;          // Material Array for Bag

    // Define MeshRenderers
    public MeshRenderer foldedTentRenderer;
    public MeshRenderer[] tentRenderer;
    public MeshRenderer bagRenderer;

    // Store Player selection
    public int foldedTentSelection;
    public int tentSelection;
    public int bagSelection;

    // Store Player ID
    public string uid;
    //call firebase
    Firebase.Auth.FirebaseAuth auth;
    DatabaseReference mDatabaseRef;
    DatabaseReference customizationDatabase;
    //sets up firebase and user ID, sets listener
    private void Awake()
    {
        auth = FirebaseAuth.DefaultInstance;
        mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;
        Firebase.Auth.FirebaseUser currentUser = auth.CurrentUser;
        customizationDatabase = FirebaseDatabase.DefaultInstance.GetReference("userCustomization");
        customizationDatabase.ValueChanged += HandlePlayerValueChanged;
        if (currentUser != null)
        {
            uid = currentUser.UserId;
        }
    }
        //retrieve material index from firebase, then changes the materials of the object
        public void SetMaterials()
        {
        Query playerQuery = customizationDatabase.Child(uid);
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
                    CustomizationIndex ci = JsonUtility.FromJson<CustomizationIndex>(playerStats.GetRawJsonValue());
                    foldedTentSelection = ci.foldedTentMaterial;
                    tentSelection = ci.tentMaterial;
                    bagSelection = ci.bagMaterial;
                    foldedTentRenderer.material = foldedTentMats[foldedTentSelection];
                    bagRenderer.material = bagMats[bagSelection];

                    for (int i = 0; i < tentRenderer.Length; i++)
                    {
                        tentRenderer[i].material = tentMats[tentSelection];
                    }
                }
            }
        });
    }

    //change folded tent to colour 1
    public void TentFolded0()
    {
        foldedTentSelection = 0;
        SaveFoldedTentToFirebase(foldedTentSelection);
    }
    //change folded tent to colour 2
    public void TentFolded1()
    {
        foldedTentSelection = 1;
        SaveFoldedTentToFirebase(foldedTentSelection);
    }
    //change folded tent to colour 3
    public void TentFolded2()
    {
        foldedTentSelection = 2;
        SaveFoldedTentToFirebase(foldedTentSelection);
    }
    //change tent to colour 1
    public void Tent1()
    {
        tentSelection = 0;
        SaveTentToFirebase(tentSelection);
    }
    //change tent to colour 2
    public void Tent2()
    {
        tentSelection = 1;
        SaveTentToFirebase(tentSelection);
    }
    //change tent to colour 3
    public void Tent3()
    {
        tentSelection = 2;
        SaveTentToFirebase(tentSelection);
    }
    //change bag to colour 1
    public void Bag1()
    {
        bagSelection = 0;
        SaveBagToFirebase(bagSelection);
    }
    //change bag to colour 2
    public void Bag2()
    {
        bagSelection = 1;
        SaveBagToFirebase(bagSelection);
    }
    //change bag to colour 3
    public void Bag3()
    {
        bagSelection = 2;
        SaveBagToFirebase(bagSelection);
    }
    //savedata for folded tent in firebase
    public void SaveFoldedTentToFirebase(int materialIndex)
    {
        string foldedTent = materialIndex.ToString();
        mDatabaseRef.Child("userCustomization").Child(uid).Child("foldedTentMaterial").SetRawJsonValueAsync(foldedTent);
    }
    //savedata for tent in firebase
    public void SaveTentToFirebase(int materialIndex)
    {
        string tent = materialIndex.ToString();
        mDatabaseRef.Child("userCustomization").Child(uid).Child("tentMaterial").SetRawJsonValueAsync(tent);
    }
    //savedata for bag in firebase
    public void SaveBagToFirebase(int materialIndex)
    {
        string bag = materialIndex.ToString();
        mDatabaseRef.Child("userCustomization").Child(uid).Child("bagMaterial").SetRawJsonValueAsync(bag);
    }
    //listens for firebase change, then executes material changes
    void HandlePlayerValueChanged(object send, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        else
        {
            SetMaterials();
        }
    }
}
