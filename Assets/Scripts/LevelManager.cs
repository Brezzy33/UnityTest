using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField] private GameObject _loaderCanvas;
    [SerializeField] private Slider _progressBar;

    private TextMeshProUGUI _textBoxProgress;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            _textBoxProgress = _progressBar.transform.Find("ProgressText").gameObject.GetComponent<TextMeshProUGUI>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public async void LoadScene(string sceneName)
    {
        _progressBar.value = 0;

        var asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        asyncOperation.allowSceneActivation = false;

        _loaderCanvas.SetActive(true);

        float progress = 0;
        while (!asyncOperation.isDone) 
        {
            await Task.Delay(10);
            progress = Mathf.MoveTowards(progress, asyncOperation.progress, Time.deltaTime);
            _progressBar.value = progress;
            
            if (progress >= 0.9f)
            {
                _progressBar.value = 1;
                asyncOperation.allowSceneActivation = true;
            }
            SetProgress();
        } 

        //await Task.Delay(1000); //Just for test

        asyncOperation.allowSceneActivation = true;
        _loaderCanvas.SetActive(false);
    }

    private void SetProgress()
    {
        _textBoxProgress.SetText((_progressBar.value * 100).ToString("F0"));
    }
}
