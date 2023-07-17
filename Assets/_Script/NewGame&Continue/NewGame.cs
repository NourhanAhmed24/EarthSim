using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    // Name of the scene to reset
    public string sceneName;

    // Method called when the button is clicked
    public void ResetScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
