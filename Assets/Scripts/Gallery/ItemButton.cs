using UnityEngine;
using IJunior.TypedScenes;
using UnityEngine.UI;

public class ItemButton : SceneLoader
{
    [SerializeField] private Image _image; 

    protected override void LoadScene()
    {
        if (_image.sprite != null)
        {
            Viewing.Load(_image.sprite);
        }
        else
        {
            ErrorPanel.Instance.EnablePanel();
        }
    }
}
