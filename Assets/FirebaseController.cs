using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using Firebase.Firestore;
using System.Threading.Tasks;
using Firebase.Extensions;

public class FirebaseController : MonoBehaviour
{
    public string Email1;

    public string Password1;

    public string Email2;

    public string Password2;

    private string userID;

    Firebase.FirebaseApp myApp1;

    Firebase.FirebaseApp myApp2;

    public void OnEnable()
    {
        Firebase.AppOptions appOptions1 = new Firebase.AppOptions
        {
            ApiKey = "AIzaSyBSCaPGmN3WR510Gtxb9781MQxA5gCksh0",
            AppId = "1:31386850366:ios:386d3c60af275cca07ad6f",
            ProjectId = "campfire-35eff"
        };

        Firebase.AppOptions appOptions2 = new Firebase.AppOptions
        {
            ApiKey = "AIzaSyBSCaPGmN3WR510Gtxb9781MQxA5gCksh0",
            AppId = "1:31386850366:ios:e3ea3e612859197c07ad6f",
            ProjectId = "campfire-35eff"
        };

        myApp1 = Firebase.FirebaseApp.Create(appOptions1);

        myApp2 = Firebase.FirebaseApp.Create(appOptions2);
    }

    public async void LoginApp1()
    {
        FirebaseAuth auth = FirebaseAuth.GetAuth(myApp1); ;
        //Task<FirebaseUser> authTask = auth.SignInWithEmailAndPasswordAsync(Email1, Password1);

        try
        {
            await auth.SignInWithEmailAndPasswordAsync(Email1, Password1).ContinueWithOnMainThread(authTask =>
            {
                if (authTask.IsCompleted)
                {
                    try
                    {
                        if (authTask.IsCompleted)
                        {
                            Debug.Log(authTask.Result.UserId);

                            userID = authTask.Result.UserId;
                        }
                    }
                    catch (System.Exception e)
                    {

                        Debug.LogError(e.Message);
                    }
                }
            });
        }
        catch (System.Exception e)
        {

            Debug.LogError(e);
        }
    }

    public async void LoginApp2()
    {
        FirebaseAuth auth = FirebaseAuth.GetAuth(myApp2); ;
        //Task<FirebaseUser> authTask = auth.SignInWithEmailAndPasswordAsync(Email2,Password2);

        try
        {
            await auth.SignInWithEmailAndPasswordAsync(Email2, Password2).ContinueWithOnMainThread(authTask =>
            {
                if (authTask.IsCompleted)
                {
                    try
                    {
                        if (authTask.IsCompleted)
                        {
                            Debug.Log(authTask.Result.UserId);

                            userID = authTask.Result.UserId;
                        }
                    }
                    catch (System.Exception e)
                    {

                        Debug.LogError(e.Message);
                    }
                }
            });
        }
        catch (System.Exception e)
        {

            Debug.LogError(e);
        }
    }

    public async void getUserSnapshot1()
    {
        FirebaseFirestore db = FirebaseFirestore.GetInstance(myApp1);

        DocumentReference UserRef = db.Collection("users").Document(userID);

        Debug.Log("Query for user info");

        try
        {
            await UserRef.GetSnapshotAsync().ContinueWithOnMainThread(UserSnapshotTask =>
            {
                if (UserSnapshotTask.IsCompleted)
                {
                    Debug.Log(UserSnapshotTask.IsCompleted);
                }
            });
        }
        catch (System.Exception e)
        {

            Debug.LogError(e);
        }
    }

    public async void getUserSnapshot2()
    {
        FirebaseFirestore db = FirebaseFirestore.GetInstance(myApp2);

        DocumentReference UserRef = db.Collection("users").Document(userID);

        Debug.Log("Query for user info");

        try
        {
            await UserRef.GetSnapshotAsync().ContinueWithOnMainThread(UserSnapshotTask =>
            {
                if (UserSnapshotTask.IsCompleted)
                {
                    Debug.Log(UserSnapshotTask.IsCompleted);
                }
            });
        }
        catch (System.Exception e)
        {

            Debug.LogError(e);
        }
    }
}
