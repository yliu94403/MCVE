using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using Firebase.Firestore;
using System.Threading.Tasks;

public class FirebaseController : MonoBehaviour
{
    public string Email1;

    public string Password1;

    public string Email2;

    public string Password2;

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
        Task<FirebaseUser> authTask = auth.SignInWithEmailAndPasswordAsync(Email1, Password1);

        await authTask;

        if (authTask.IsCompleted)
        {
            Debug.Log(authTask.Result.UserId);

            getUserSnapshot(authTask.Result.UserId);
        }
    }

    public async void LoginApp2()
    {
        FirebaseAuth auth = FirebaseAuth.GetAuth(myApp2); ;
        Task<FirebaseUser> authTask = auth.SignInWithEmailAndPasswordAsync(Email2,Password2);

        await authTask;

        if (authTask.IsCompleted)
        {
            Debug.Log(authTask.Result.UserId);

            getUserSnapshot(authTask.Result.UserId);
        }
    }

    public async void getUserSnapshot(string UserID)
    {
        FirebaseFirestore db = FirebaseFirestore.GetInstance(myApp2);

        DocumentReference UserRef = db.Collection("users").Document(UserID);

        Task<DocumentSnapshot> UserSnapshotTask = UserRef.GetSnapshotAsync();

        await UserSnapshotTask;

        if (UserSnapshotTask.IsCompleted)
        {
            Debug.Log(UserSnapshotTask.IsCompleted);
        }
    }
}
