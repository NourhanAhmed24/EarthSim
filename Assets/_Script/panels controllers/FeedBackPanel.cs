using UnityEngine.UI;
using UnityEngine;
using System.Collections;


public class FeedBackPanel : MonoBehaviour
{
    public GameObject panel; // assign the panel game object in the inspector
    public float delaySeconds = 2.0f; // set the delay time in seconds

    private void Start()
    {
        // make sure the panel is initially disabled
        panel.SetActive(false);
    }

    public void OpenAndClosePanel()
    {
        // enable the panel
        panel.SetActive(true);

        // use a coroutine to delay for the specified number of seconds
        StartCoroutine(ClosePanelAfterDelay(delaySeconds));
    }

    private IEnumerator ClosePanelAfterDelay(float seconds)
    {
        // wait for the specified number of seconds
        yield return new WaitForSeconds(seconds);

        // disable the panel
        panel.SetActive(false);
    }
}
