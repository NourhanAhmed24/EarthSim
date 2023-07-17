using UnityEngine;
using UnityEditor.SceneManagement;

public class SaveSceneButton : MonoBehaviour
{
    // Name of the scene to save
    public string sceneName;

    // Method called when the button is clicked
    public void SaveScene()
    {
        EditorSceneManager.SaveScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene(), sceneName);
    }
}
