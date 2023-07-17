/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSavedScene : MonoBehaviour
{
    private MapGenerator mapGenerator;
    private IDataService DataService = new JsonDataService();
   // public string[] objects;

    public void LoadList()
    {
        // DataService.LoadData("/random-scene.json", EncryptionEnabled);
       string [] objects = DataService.LoadData();
        for (int i = 0; i < objects.Length; i++)
        {
            Debug.Log(objects[i]);
        }
       // return objects;

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        // Instantiate the MapGenerator object
        //mapGenerator = new MapGenerator();

        //mapGenerator.GenerateSavedScene(objects);
    }
}*/


/*using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSavedScene : MonoBehaviour
{
    private MapGenerator mapGenerator;
    private IDataService DataService = new JsonDataService();
    public string[] objects;

    public void LoadList()
    {
        // DataService.LoadData("/random-scene.json", EncryptionEnabled);
        objects = DataService.LoadData();
        for (int i = 0; i < objects.Length; i++)
        {
            Debug.Log(objects[i]);
        }

        // Load the target scene
        SceneManager.LoadScene("RandomGeneration", LoadSceneMode.Single);

        // Load the MapGenerator object from the target scene
        Scene targetScene = SceneManager.GetSceneByName("RandomGeneration");
        GameObject[] rootObjects = targetScene.GetRootGameObjects();
        foreach (GameObject obj in rootObjects)
        {
            mapGenerator = obj.GetComponent<MapGenerator>();
            if (mapGenerator != null)
            {
                break;
            }
        }

        // Call the GenerateSavedScene method on the MapGenerator object
        if (mapGenerator != null)
        {
            mapGenerator.GenerateSavedScene(objects);
        }
        else
        {
            Debug.LogError("MapGenerator not found in target scene.");
        }
    }
}*/

/*using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSavedScene : MonoBehaviour
{
    public MapGenerator mapGenerator;
    private IDataService DataService = new JsonDataService();
    public string[] objects;

    public void LoadList()
    {
        // DataService.LoadData("/random-scene.json", EncryptionEnabled);
        objects = DataService.LoadData();
        for (int i = 0; i < objects.Length; i++)
        {
            Debug.Log(objects[i]);
        }

        // Call the GenerateSavedScene method on the MapGenerator object
        if (mapGenerator != null)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            mapGenerator.GenerateSavedScene(objects);
        }
        else
        {
            Debug.LogError("MapGenerator is not assigned.");
        }
    }
}*/

using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadSavedScene : MonoBehaviour
{
    public string[] objects;
    public string[] roadObjects;
    public string[] buildingSceneObjects;
    public MapGenerator mapGenerator;
    public RoadMap1 roadMap;
    public ObjectPlacer objectPlacer;
    private IDataService DataService = new JsonDataService();


    public void LoadList()
    {
        // DataService.LoadData("/random-scene.json", EncryptionEnabled);
        objects = DataService.LoadData();
        roadObjects = DataService.LoadRoadsData();
        buildingSceneObjects = DataService.LoadBuildingSceneData();
        /* for (int i = 0; i < objects.Length; i++)
         {
             Debug.Log(objects[i]);
         }*/

        // Load the target scene asynchronously
        AsyncOperation operation = SceneManager.LoadSceneAsync("RandomGeneration", LoadSceneMode.Single);
        operation.completed += FindMapGenerator;
        operation.completed += FindRoadMapGenerator;
        // SceneManager.LoadSceneAsync("RandomGeneration", LoadSceneMode.Single).completed += FindRoadMapGenerator;

        
    }

    private void FindMapGenerator(AsyncOperation asyncOperation)
    {
        // Find the MapGenerator object in the target scene
        Scene targetScene = SceneManager.GetSceneByName("RandomGeneration");
        GameObject[] rootObjects = targetScene.GetRootGameObjects();
        foreach (GameObject obj in rootObjects)
        {
            mapGenerator = obj.GetComponent<MapGenerator>();
            if (mapGenerator != null)
            {
                // Call the GenerateSavedScene method on the MapGenerator object
                mapGenerator.GenerateSavedScene(objects);
                return;
            }
            // Debug.Log(obj);
            //Debug.Log(rootObjects.Length);
        }

        Debug.LogError("MapGenerator not found in target scene.");
    }


    private void FindRoadMapGenerator(AsyncOperation asyncOperation)
    {
        // Find the MapGenerator object in the target scene
        Scene targetScene = SceneManager.GetSceneByName("RandomGeneration");
        GameObject[] rootObjects = targetScene.GetRootGameObjects();
        foreach (GameObject obj in rootObjects)
        {
            roadMap = obj.GetComponent<RoadMap1>();
            if (roadMap != null)
            {
                // Call the GenerateSavedScene method on the MapGenerator object
                roadMap.GenerateSavedScene(roadObjects);
                return;
            }
            // Debug.Log(obj);
            //Debug.Log(rootObjects.Length);
        }

        Debug.LogError("RoadMap1 not found in target scene.");
    }



    public void LoadBuildingSceneList()
    {
        // DataService.LoadData("/random-scene.json", EncryptionEnabled);
       
        buildingSceneObjects = DataService.LoadBuildingSceneData();
        /* for (int i = 0; i < objects.Length; i++)
         {
             Debug.Log(objects[i]);
         }*/

       
       
        // SceneManager.LoadSceneAsync("RandomGeneration", LoadSceneMode.Single).completed += FindRoadMapGenerator;

        AsyncOperation buildingSceneOperation = SceneManager.LoadSceneAsync("GridPlacementSystem", LoadSceneMode.Single);
        buildingSceneOperation.completed += FindObjectPlacer;
    }

    private void FindObjectPlacer(AsyncOperation asyncOperation)
    {
        // Find the MapGenerator object in the target scene
        Scene targetScene = SceneManager.GetSceneByName("GridPlacementSystem");
        GameObject[] rootObjects = targetScene.GetRootGameObjects();
        foreach (GameObject obj in rootObjects)
        { 
            if(obj.name == "BuildingSystem")
            {
                objectPlacer = obj.GetComponentInChildren<ObjectPlacer>();
            }
           
            if (objectPlacer != null)
            {
                // Call the GenerateSavedScene method on the MapGenerator object
                objectPlacer.GenerateSavedScene(buildingSceneObjects);
               
                return;
            }
            // Debug.Log(obj);
            //Debug.Log(rootObjects.Length);
        }

        Debug.LogError("ObjectPlacer not found in target scene.");
    }
}




