using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public Image fadePanel;
    public float fadeDuration = 1.0f;

    private void Start()
    {
        Debug.Log("DD");
        fadePanel.gameObject.SetActive(true);
        fadePanel.color = new Color(fadePanel.color.r, fadePanel.color.g, fadePanel.color.b, 1f);
        Fade();
    }

    private void Fade()
    {
        Debug.Log("DDs");
        LeanTween.alpha(fadePanel.rectTransform, 0f, fadeDuration)
            .setEase(LeanTweenType.linear)
            .setOnComplete(() => fadePanel.gameObject.SetActive(false));
    }
}
