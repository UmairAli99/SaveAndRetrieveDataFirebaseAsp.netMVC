using Google.Cloud.Firestore;
using Firebase.Database;
using Google.Cloud.Firestore.V1;
using Google.Rpc;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;

public class FirebaseContext
{
    private FirebaseClient _client;

    public FirebaseClient Client
    {
        get
        {
            if (_client == null)
            {
                string apiKey = "AIzaSyAci0GnNYJrSWppjhA5ivupDFhcc4rAp6E";
                string databaseUrl = "https://testpro-8e054-default-rtdb.firebaseio.com/";

                _client = new FirebaseClient(databaseUrl, new FirebaseOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(apiKey)
                });
            }
            return _client;
        }
    }
}

