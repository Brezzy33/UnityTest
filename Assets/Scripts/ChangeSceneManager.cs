using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSceneManager : MonoBehaviour
{
    private List<string> previousScenes = new List<string>();
    public void ChangeScene(string sceneName)
    {
        previousScenes.Add(Application.loadedLevelName);
        LevelManager.Instance.LoadScene(sceneName);
    }

    public void ChangeSceneWithImage(string sceneName)
    {
        ShareImage.RawImage = GetComponent<RawImage>();
        ChangeScene(sceneName);
    }

    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                LoadPreviousScene();

                return;
            }
        }
    }

    public void LoadPreviousScene()
    {
        if (previousScenes.Count >= 1)
        {
            string previousScene = previousScenes[previousScenes.Count - 1];
            previousScenes.RemoveAt(previousScenes.Count - 1); 
            LevelManager.Instance.LoadScene(previousScene);
        }
    }
}
