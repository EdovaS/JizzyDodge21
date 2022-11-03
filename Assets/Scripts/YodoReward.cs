using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Yodo1.MAS;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class YodoReward : MonoBehaviour
{

    [SerializeField] private GameManager _gameManager;
    [HideInInspector] public bool CanShowAd;
    
    public void Start()
    {
        this.InitializeRewardedAds();
        this.RequestRewardedAds();
    }

    private void InitializeRewardedAds()
    {
        // Instantiate
        Yodo1U3dRewardAd.GetInstance();

        // Ad Events
        Yodo1U3dRewardAd.GetInstance().OnAdLoadedEvent += OnRewardAdLoadedEvent;
        Yodo1U3dRewardAd.GetInstance().OnAdLoadFailedEvent += OnRewardAdLoadFailedEvent;
        Yodo1U3dRewardAd.GetInstance().OnAdOpenedEvent += OnRewardAdOpenedEvent;
        Yodo1U3dRewardAd.GetInstance().OnAdOpenFailedEvent += OnRewardAdOpenFailedEvent;
        Yodo1U3dRewardAd.GetInstance().OnAdClosedEvent += OnRewardAdClosedEvent;
        Yodo1U3dRewardAd.GetInstance().OnAdEarnedEvent += OnRewardAdEarnedEvent;
    }

    private void RequestRewardedAds()
    {
        Yodo1U3dRewardAd.GetInstance().LoadAd();
    }

    public void ShowRewardedAds()
    {
        bool isLoaded = Yodo1U3dRewardAd.GetInstance().IsLoaded();

        if(isLoaded) Yodo1U3dRewardAd.GetInstance().ShowAd();
    }

    private void OnRewardAdLoadedEvent(Yodo1U3dRewardAd ad)
    {
        Debug.Log("[Yodo1 Mas] OnRewardAdLoadedEvent event received");
    }

    private void OnRewardAdLoadFailedEvent(Yodo1U3dRewardAd ad, Yodo1U3dAdError adError)
    {
        Debug.Log("[Yodo1 Mas] OnRewardAdLoadFailedEvent event received with error: " + adError.ToString());
    }

    private void OnRewardAdOpenedEvent(Yodo1U3dRewardAd ad)
    {
        Debug.Log("[Yodo1 Mas] OnRewardAdOpenedEvent event received");
    }

    private void OnRewardAdOpenFailedEvent(Yodo1U3dRewardAd ad, Yodo1U3dAdError adError)
    {
        Debug.Log("[Yodo1 Mas] OnRewardAdOpenFailedEvent event received with error: " + adError.ToString());
        // Load the next ad
        this.RequestRewardedAds();
    }

    private void OnRewardAdClosedEvent(Yodo1U3dRewardAd ad)
    {
        Debug.Log("[Yodo1 Mas] OnRewardAdClosedEvent event received");
        // Load the next ad
        this.RequestRewardedAds();
    }

    

    private void OnRewardAdEarnedEvent(Yodo1U3dRewardAd ad)
    {
        Debug.Log("[Yodo1 Mas] OnRewardAdEarnedEvent event received");
        // Add your reward code here
        _gameManager.Revive();

        if(!CanShowAd) return; // return if player has watched already.
        
        // make so the player can only revive once
        CanShowAd = true;
        Button reviveButton = GetComponent<Button>();
        reviveButton.interactable = false;
        reviveButton.GetComponent<Image>().enabled = false;
        

    }
    
}
