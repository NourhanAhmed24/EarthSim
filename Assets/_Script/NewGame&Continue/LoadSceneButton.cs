using UnityEngine;
using UnityEditor.SceneManagement;

public class LoadSceneButton : MonoBehaviour
{
    // Name of the saved scene to retrieve
    public string savedSceneName;

    // Method called to retrieve the saved scene
    public void RetrieveScene()
    {
        // Load the saved scene as a temporary scene
        var tempScene = EditorSceneManager.OpenScene("Assets/Scenes/" + savedSceneName + ".unity", OpenSceneMode.Additive);

        // Set the temporary scene as the active scene
        EditorSceneManager.SetActiveScene(tempScene);
    }
}
