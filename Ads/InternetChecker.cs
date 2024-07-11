using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InternetChecker : MonoBehaviour
{
    public static InternetChecker instance;
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        IsInternetAvailable();
    }
    public bool IsInternetAvailable()
    {
        // Check if there is an internet connection available
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            // No internet connection
          
            return false;
        }
        else
        {
            // Internet connection is available
           
            return true;
        }
    }
}
