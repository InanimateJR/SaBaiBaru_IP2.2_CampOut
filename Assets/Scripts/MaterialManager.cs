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
        SetMaterials();
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
                }
            }
        });

        foldedTentRenderer.material = foldedTentMats[foldedTentSelection];
        bagRenderer.material = bagMats[bagSelection];


        for (int i = 0; i < tentRenderer.Length; i++)
        {
            tentRenderer[i].material = tentMats[tentSelection];
        }
    }

    //change folded tent to colour 1
    public void TentFolded1()
    {
        foldedTentSelection = 0;
        SaveMaterialsToFirebase(foldedTentSelection, tentSelection, bagSelection);
    }
    //change folded tent to colour 2
    public void TentFolded2()
    {
        foldedTentSelection = 1;
        SaveMaterialsToFirebase(foldedTentSelection, tentSelection, bagSelection);
    }
    //change folded tent to colour 3
    public void TentFolded3()
    {
        foldedTentSelection = 2;
        SaveMaterialsToFirebase(foldedTentSelection, tentSelection, bagSelection);
    }
    //change tent to colour 1
    public void Tent1()
    {
        tentSelection = 0;
        SaveMaterialsToFirebase(foldedTentSelection, tentSelection, bagSelection);
    }
    //change tent to colour 2
    public void Tent2()
    {
        tentSelection = 1;
        SaveMaterialsToFirebase(foldedTentSelection, tentSelection, bagSelection);
    }
    //change tent to colour 3
    public void Tent3()
    {
        tentSelection = 2;
        SaveMaterialsToFirebase(foldedTentSelection, tentSelection, bagSelection);
    }
    //change bag to colour 1
    public void Bag1()
    {
        bagSelection = 0;
        SaveMaterialsToFirebase(foldedTentSelection, tentSelection, bagSelection);
    }
    //change bag to colour 2
    public void Bag2()
    {
        bagSelection = 1;
        SaveMaterialsToFirebase(foldedTentSelection, tentSelection, bagSelection);
    }
    //change bag to colour 3
    public void Bag3()
    {
        bagSelection = 2;
        SaveMaterialsToFirebase(foldedTentSelection, tentSelection, bagSelection);
    }
    //savedata for folded tent in firebase
    public void SaveMaterialsToFirebase(int foldedTentMaterial, int tentMaterial, int bagMaterial)
    {
        CustomizationIndex ci = new CustomizationIndex(foldedTentMaterial, tentMaterial, bagMaterial);
        string json = JsonUtility.ToJson(ci);
        mDatabaseRef.Child("userCustomization").Child(uid).SetRawJsonValueAsync(json);
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
            //Debug.Log("Value Changed");

            SetMaterials();
        }
    }
}
