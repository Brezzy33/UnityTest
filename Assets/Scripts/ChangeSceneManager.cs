using UnityEngine;

public class ChangeSceneManager : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        LevelManager.Instance.LoadScene(sceneName);
    }

    public void ChangeSceneWithImage(string sceneName)
    {
        LevelManager.Instance.LoadSceneWithImage(sceneName);
    }
}
