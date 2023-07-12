using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{
    public Image fadePanel; //ÆäÀÌµå ÆÇ³Ú
    public float fadeDuration = 1.0f; //ÆäÀÌµå ÁøÇà ½Ã°£
    public float delay = 2.5f; //ÄÚ·çÆ¾ µô·¹ÀÌ
    public string scene; //¹Ù²Ü ¾À

    private void Start()
    {
        fadePanel.color = new Color(fadePanel.color.r, fadePanel.color.g, fadePanel.color.b, 0f);
        fadePanel.gameObject.SetActive(true);
    }

    public void Fade()
    {
        LeanTween.alpha(fadePanel.rectTransform, 1f, fadeDuration)
            .setEase(LeanTweenType.linear)
            .setOnComplete(() => fadePanel.gameObject.SetActive(true));
        StartCoroutine(DelayCoroutine(delay));
    }

    public IEnumerator DelayCoroutine(float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        SceneManager.LoadScene(scene);
    }
}
