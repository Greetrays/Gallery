using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]

public abstract class TempPanel : MonoBehaviour
{
    private CanvasGroup _canvasGroup;

    private void OnEnable()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        SwitchEnable(0, false, false);
    }

    protected void SwitchEnable(float alpha, bool interactable, bool blockRaycast)
    {
        _canvasGroup.alpha = alpha;
        _canvasGroup.interactable = interactable;
        _canvasGroup.blocksRaycasts = blockRaycast;
    }
}
