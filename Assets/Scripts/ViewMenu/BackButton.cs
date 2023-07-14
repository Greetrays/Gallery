using UnityEngine;
using IJunior.TypedScenes;

public class BackButton : SceneLoader
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            OnClick();
        }
    }

    protected override void LoadScene()
    {
        Gallery.Load();
    }
}
