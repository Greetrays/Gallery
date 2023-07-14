using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DownloadPanel : TempPanel
{
    [SerializeField] private float _delay;
    [SerializeField] private TMP_Text _progressText;
    [SerializeField] private Image _progressBar;

    private float _elapsedTime;

    public static DownloadPanel Instance {get; private set;}

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }

        Destroy(this.gameObject);
    }

    private void Start()
    {
        ResetValue();
    }

    public void OnClick(Action targetFunction)
    {
        SwitchEnable(1, true, true);
        StartCoroutine(ChangeBar(targetFunction));
    }

    private void ResetValue()
    {
        _progressBar.fillAmount = 0;
    }

    private IEnumerator ChangeBar(Action targetFunction)
    {
        int targetProgresValue = 100;
        int progress = 0;
        _elapsedTime = 0;

        while (_progressBar.fillAmount < 1)
        {
            _progressBar.fillAmount = Mathf.MoveTowards(0, 1, _elapsedTime / _delay);
            progress = (int)Mathf.MoveTowards(0, targetProgresValue, _elapsedTime / _delay * targetProgresValue);
            _progressText.text = $"{progress}%";
            _elapsedTime += Time.deltaTime;
            yield return null;
        }

        SwitchEnable(0, false, false);
        ResetValue();
        targetFunction();
    }
}
