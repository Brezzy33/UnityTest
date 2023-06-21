using UnityEngine;
using UnityEngine.SceneManagement;

public class PortraitOrientationScript : MonoBehaviour
{
    private void Start()
    {
        Screen.orientation = ScreenOrientation.AutoRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Application.isMobilePlatform)
            return;

        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == "GalleryMainMenu" || sceneName == "GalleryMenu")
        {
            if (Input.deviceOrientation != DeviceOrientation.Portrait)
            {
                Screen.orientation = ScreenOrientation.Portrait;
            }
        }
    }
}
