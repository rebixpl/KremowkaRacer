using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    public static AdsManager instance;
    const string gameID = "4563854";

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(gameID);
        Advertisement.AddListener(this);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowAd()
    {
        if (Advertisement.IsReady("Interstitial_Android"))
        {
            Advertisement.Show("Interstitial_Android");
        }
    }

    public void ShowRewardedAd() {
        if (Advertisement.IsReady("Rewarded_Android"))
        {
            Advertisement.Show("Rewarded_Android");
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished) {
            // User watched entire ad, reward the user with 25 kremowka
            print("ADD 25 KREMOWKA FROM AD");
            ScoreManager.instance.KremowkaCollected(25);
        }
    }
}
