using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InternetChecker : MonoBehaviour
{
    public Text message;
    private void Start()
    {
        IsInternetAvailable();
    }
    public bool IsInternetAvailable()
    {
        // Check if there is an internet connection available
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            // No internet connection
            message.text=("Off");
            return false;
        }
        else
        {
            // Internet connection is available
            message.text = ("On");
            return true;
        }
    }
}
