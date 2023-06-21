using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GalleryScreen : MonoBehaviour
{
    private const int PicturesCount = 66;

    // Start is called before the first frame update
    void Start()
    {
        Application.runInBackground = true;
        StartCoroutine(LoadImages(4));
        ScrollBar.onValueChanged.AddListener(ScrollbarCallBack);
    }

    private bool _crRunning;
    void ScrollbarCallBack(float value)
    {
        if (!_crRunning && value <= 0.2 && _imageIndex < PicturesCount)
        {
            int nextImagesCount = _imageIndex + 1;

            StartCoroutine(LoadImages(nextImagesCount));
        }
    }

    public Scrollbar ScrollBar;
    public RectTransform Prefab;
    public RectTransform Content;

    private readonly IList<Texture2D> _textures= new List<Texture2D>();

    void OnReceivedModels(int i)
    {
        GameObject instance = Instantiate(Prefab.gameObject);

        TestItemView view = new TestItemView(instance.transform)
        {
            Image = { texture = _textures[i-1], name = (i-1).ToString()}
        };

        instance.transform.SetParent(Content, false);
    }

    private int _imageIndex = 1;
    IEnumerator LoadImages(int count)
    {
        try
        {
            _crRunning = true;
            yield return new WaitForSeconds(1f);
            for (; _imageIndex <= count; _imageIndex++)
            {
                string url = $"http://data.ikppbb.com/test-task-unity-data/pics/{_imageIndex}.jpg";
                Debug.Log(url);
                yield return LoadTextureAsync(url, AddLoadedTextureToCollection);

                OnReceivedModels(_imageIndex);
            }
        }
        finally
        {
            _crRunning = false;
        }
    }

    private void AddLoadedTextureToCollection(Texture2D texture)
    {
        _textures.Add(texture);
    }

    public IEnumerator LoadTextureAsync(string url, Action<Texture2D> result)
    {
        using WWW www = new WWW(url);
        while (!www.isDone)
            yield return null;

        Texture2D loadedTexture = new Texture2D(1000, 1000);

        www.LoadImageIntoTexture(loadedTexture);

        result(loadedTexture);
    }

    public class TestItemView
    {
        public RawImage Image;

        public TestItemView(Transform rootView)
        {
            Image = rootView.GetComponent<RawImage>();
        }
    }
}