using UnityEngine;

public class ErrorPanel : TempPanel
{
    [SerializeField] private float _delay;

    public static ErrorPanel Instance {get; private set;}

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }

        Destroy(this.gameObject);
    }

    public void EnablePanel()
    {
        SwitchEnable(1, true, true);
        Invoke("DisablePanel", _delay);
    }

    private void DisablePanel()
    {
        SwitchEnable(0, false, false);
    }
}
