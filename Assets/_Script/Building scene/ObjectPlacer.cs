using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{   [SerializeField]
    private List<GameObject> placedGameObject = new();
    private float rotateSpeed = 50f;
    private List<SpawnedObjectsData> spawnedObjectsDataList = new List<SpawnedObjectsData>();
    private IDataService DataService = new JsonDataService();
    private bool EncryptionEnabled;
    [SerializeField] public GameObject[] buildingPrefabs;
    private static bool newScene;

    public void NewScene()
    {
        newScene = true;
        Debug.Log("clicked");
        Debug.Log(newScene);
        
    }

    public void Save()
    {
        Debug.Log(newScene);

        if (newScene == true)
        {
            DataService.SaveBuildingSceneNewData("/building-scene.json", spawnedObjectsDataList, EncryptionEnabled);
            Debug.Log(spawnedObjectsDataList.Count);
            Debug.Log("newwwwww");
        }
        else
        {
            DataService.SaveBuildingSceneData("/building-scene.json", spawnedObjectsDataList, EncryptionEnabled);
            Debug.Log(spawnedObjectsDataList.Count);
        }
        
    }




    public void GenerateSavedScene(string[] objects)
    {
        string str = "";
        //string[] objects = savedSceneObjects.LoadList();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("hi");
        for (int s = 0; s < objects.Length; s++)
        {
            Debug.Log(objects[s]);
        }
        for (int i = 0; i < objects.Length; i++)
        {
            string json = objects[i];
            if (json != "")
            {
                SpawnedObjectsData storedObjectsData = JsonUtility.FromJson<SpawnedObjectsData>(json);

                bool prefabFound = false;
                for (int j = 0; j < buildingPrefabs.Length; j++)
                {
                    Debug.Log("hiiiiiiii");
                   
                        str = storedObjectsData.name.Replace("(Clone)", "");
                    
                    // Debug.Log(storedObjectsData.name);
                    // Debug.Log(buildingPrefabs[j].name);
                    if (str == buildingPrefabs[j].name)
                    {
                        GameObject obj = Instantiate(buildingPrefabs[j], storedObjectsData.occupiedPositions, storedObjectsData.rotation);
                        // float rotation = storedObjectsData.rotation.y;
                        //   obj.transform.Rotate(Vector3.up * rotation);
                        // destroySavedObjects.Add(obj);
                        Debug.Log("hiii");
                        prefabFound = true;
                        break;
                    }
                }

                if (!prefabFound)
                {
                    Debug.LogError("Failed to load prefab: " + storedObjectsData.name);
                }
            }
        }
        Debug.Log(spawnedObjectsDataList.Count);
    }


    public int PlaceObject(GameObject prefab, Vector3 position, float yRotation)
    {
        GameObject newObject = Instantiate(prefab);
        newObject.transform.position = position;
        newObject.transform.Rotate(Vector3.up * yRotation);
        placedGameObject.Add(newObject);
        SpawnedObjectsData data = new SpawnedObjectsData(newObject.transform.position, newObject.name, newObject.transform.rotation);
        spawnedObjectsDataList.Add(data);
        return placedGameObject.Count - 1;
    }


    internal void RemoveObjectsAt(int gameObjectIndex)
    {
        if(placedGameObject.Count <= gameObjectIndex || placedGameObject[gameObjectIndex] == null )
        {
            return;
        }
        Destroy(placedGameObject[gameObjectIndex]);
        placedGameObject[gameObjectIndex] = null;
        spawnedObjectsDataList[gameObjectIndex] = null;
    }



   /*internal void RotateObjectsAt(int gameObjectIndex)
    {
        if (placedGameObject.Count <= gameObjectIndex || placedGameObject[gameObjectIndex] == null)
        {
            return;
        }
        float degreesPerSecond = 20;
        placedGameObject[gameObjectIndex].transform.Rotate(); 
    }*/
}




