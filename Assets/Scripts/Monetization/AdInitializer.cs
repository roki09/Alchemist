using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdInitializer : MonoBehaviour, IUnityAdsInitializationListener
{

    [SerializeField] private string androidGameID = "5592517";
    [SerializeField] private string iOsGameID = "5592516";
    [SerializeField] bool testMode = true;

    private string gameID;

    private void Awake()
    {
        InitializeAds();
    }

    public void InitializeAds()
    {
        gameID = (Application.platform == RuntimePlatform.IPhonePlayer) ? iOsGameID : androidGameID;
        Advertisement.Initialize(gameID, testMode, this);
    }


    public void OnInitializationComplete()
    {
        Debug.Log("complite");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log("Dont Complite");
    }


}
