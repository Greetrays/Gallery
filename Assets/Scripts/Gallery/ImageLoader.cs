using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ImageLoader : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private Item _itemTemplate;

    private List<string> _url = new List<string>();
    private List<Texture2D> _imageList = new List<Texture2D>();
    private List<Item> _items = new List<Item>();
    private int _renderedImageCount;
    private int _visibleImageCount;   
    private const int _imageCount = 66;
    private Coroutine _coroutine;

    void Start()
    {
        for (int i = 1; i <= _imageCount; i++)
        {
            _url.Add($"http://data.ikppbb.com/test-task-unity-data/pics/{i}.jpg");
        }

        for (int i = 0; i < _imageCount; i++)
        {
            Item item = Instantiate(_itemTemplate, _container);
            _items.Add(item);
        }

        Invoke("OnScroll", 0.1f);    
    }

    public void OnScroll()
    {
        foreach (var item in _items)
        {
            if (item.IsAboveScreenBottom && item.IsVisible == false)
            {
                _visibleImageCount++;
                item.SetVisible();
            }
        }

        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(LoadImagesFromServer(_url));
        } 
    }

    private void RenderImages(Texture2D texture, int index)
    {
        Rect rect = new Rect(0, 0, texture.width, texture.height);
        _items[index].Init(Sprite.Create(texture, rect, Vector2.zero));
    }

    private IEnumerator LoadImagesFromServer(List<string> imageURLs)
    {
        for (; _renderedImageCount < _visibleImageCount; _renderedImageCount++)
        {
            UnityWebRequest www = UnityWebRequestTexture.GetTexture(imageURLs[_renderedImageCount]);
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Texture2D texture = DownloadHandlerTexture.GetContent(www);
                _imageList.Add(texture);
                RenderImages(texture, _renderedImageCount);
            }
            else
            {
                Debug.LogError("Failed to load image from " + imageURLs[_renderedImageCount] + ": " + www.error);
            }
        }

        _coroutine = null;
    }
}
