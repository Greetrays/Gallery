using UnityEngine;
using System;

public abstract class SceneLoader : MonoBehaviour
{
    public void OnClick()
    {
        Action myDelegate = LoadScene;
        DownloadPanel.Instance.OnClick(myDelegate);
    }

    protected abstract void LoadScene();
}
