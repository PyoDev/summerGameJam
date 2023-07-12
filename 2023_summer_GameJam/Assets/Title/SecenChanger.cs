using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SecenChanger : MonoBehaviour
{
    public float delay = 2f;

    public void SceneChange()
    {
        StartCoroutine(DelayCoroutine(delay));
    }

    private IEnumerator DelayCoroutine(float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        SceneManager.LoadScene("Loding");
    }
}
