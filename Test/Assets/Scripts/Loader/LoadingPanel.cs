using System.Collections;
using UnityEngine;

public class LoadingPanel : MonoBehaviour
{
    [SerializeField] private CanvasGroup _curtain;

    private readonly float _startAlpha = 1.0f;
    private readonly float _secondsTime = 0.03f;
    private readonly float _alphaDelimetr = 0.03f; 

    public void Show()
    {
        gameObject.SetActive(true);
        _curtain.alpha = _startAlpha;
    }

    public void Hide() => StartCoroutine(DoFadeIn());

    private IEnumerator DoFadeIn()
    {
        while (_curtain.alpha > 0)
        {
            _curtain.alpha -= _alphaDelimetr;
            yield return new WaitForSeconds(_secondsTime);
        }

        gameObject.SetActive(false);
    }
}