using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIGunUpdater : MonoBehaviour
{
    public Image uiImage;

    [Header("Animation")]
    public float duration = .1f;
    public Ease ease = Ease.OutBack;

    private Tween _currTween;

    private void OnValidate()
    {
        if (uiImage == null)
            uiImage = GetComponent<Image>();
    }
    public void UpdateValue(float max, float current)
    {
        if (_currTween != null)
            _currTween.Kill();

        float value = 1 - (current / max);

        _currTween = uiImage
            .DOFillAmount(value, duration)
            .SetEase(ease);
    }
    public void UpdateRecharge(float normalized)
    {
        uiImage.fillAmount = normalized;
    }
}
