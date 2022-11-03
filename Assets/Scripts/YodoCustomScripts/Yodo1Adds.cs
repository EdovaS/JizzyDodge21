using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yodo1.MAS;

public class Yodo1Adds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Yodo1AdBuildConfig config =
            new Yodo1AdBuildConfig().enableUserPrivacyDialog(true);
        Yodo1U3dMas.SetAdBuildConfig(config);
        
        Yodo1U3dMas.InitializeMasSdk();

        Yodo1U3dMasCallback.OnSdkInitializedEvent += (success, error) =>
        {
            Debug.Log("[Yodo1 Mas] OnSdkInitializedEvent, success:" + success + ", error: " + error.ToString());
            if (success)
            {
                Debug.Log("[Yodo1 Mas] The initialization has succeeded");
            }
            else
            {
                Debug.Log("[Yodo1 Mas] The initialization has failed");
            }
        };
    }
    
}
