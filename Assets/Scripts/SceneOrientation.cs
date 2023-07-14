using UnityEngine;

public class SceneOrientation : MonoBehaviour
{
    [SerializeField] private ScreenOrientation _orientation;

    private void Start()
    {
        Screen.orientation = _orientation;
    }
}
