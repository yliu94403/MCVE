using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using Firebase.Firestore;
using System.Threading.Tasks;

public class FirebaseController : MonoBehaviour
{
    public string Email;

    public string Password;

    public string ProjectID;

    public string CustomerID;

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

    public async void Login()
    {
        FirebaseAuth auth = FirebaseAuth.GetAuth(myApp2); ;
        Task<FirebaseUser> authTask = auth.SignInWithEmailAndPasswordAsync(Email,Password);

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
