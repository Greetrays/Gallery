using UnityEngine;
using IJunior.TypedScenes;
using UnityEngine.UI;

public class ViewMenu : MonoBehaviour, ISceneLoadHandler<Sprite>
{
    [SerializeField] private Image _image;

    public void OnSceneLoaded(Sprite sprite)
    {
        _image.sprite = sprite;
    }
}
