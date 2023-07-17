using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoadMap1 : MonoBehaviour
{
    [SerializeField] public GameObject[] buildingPrefabs;
    [SerializeField] private Transform[] straightRoadsSpawnLocationsMap1;
    [SerializeField] private Transform[] cornerRoadsSpawnLocationsMap1;
    [SerializeField] private GameObject straightRoad;
    [SerializeField] private GameObject cornerRoad;
    [SerializeField] private GameObject threeWayRoad;

    [SerializeField] private Transform[] straightRoadsSpawnLocationsMap2;
    [SerializeField] private Transform[] cornerRoadsSpawnLocationsMap2;
    private List<GameObject>  straightRoadsSpawnedObjects1 = new List<GameObject>();
    private List<GameObject> cornerRoadsSpawnedObjects1 = new List<GameObject>();
    private List<GameObject> straightRoadsSpawnedObjects2 = new List<GameObject>();
    private List<GameObject> cornerRoadsSpawnedObjects2 = new List<GameObject>();


    [SerializeField] private Transform[] straightRoadsSpawnLocationsMap3;
    private List<GameObject> straightRoadsSpawnedObjects3 = new List<GameObject>();

    
    private List<SpawnedObjectsData> spawnedObjectsDataList = new List<SpawnedObjectsData>();
    private IDataService DataService = new JsonDataService();
    private bool EncryptionEnabled;
    private List<GameObject> destroySavedObjects = new List<GameObject>();


    void Start()
    {
        //GenerateMap1();
    }

    
    public void RandomMap()
    {

        int min = 1;
        int max = 2;
        int randomNum = Random.Range(min, max + 1);
        foreach (GameObject obj in destroySavedObjects)
        {
            Debug.Log("destroyyyy");
            Destroy(obj);
        }
        destroySavedObjects.Clear();

        if (randomNum == 1)
        {
            foreach (GameObject obj in straightRoadsSpawnedObjects2)
            {
                Destroy(obj);
            }
           
            straightRoadsSpawnedObjects2.Clear();
            spawnedObjectsDataList.Clear();
           

            foreach (GameObject obj in cornerRoadsSpawnedObjects2)
            {
                Destroy(obj);
            }
            cornerRoadsSpawnedObjects2.Clear();


            GenerateMap1();
        }
        else if (randomNum==2)
        {
            foreach (GameObject obj in straightRoadsSpawnedObjects1)
            {
                Destroy(obj);
            }

           

            straightRoadsSpawnedObjects1.Clear();
            spawnedObjectsDataList.Clear();
            

            foreach (GameObject obj in cornerRoadsSpawnedObjects1)
            {
                Destroy(obj);
            }
            cornerRoadsSpawnedObjects1.Clear();

            GenerateMap2();
        }

    }

    public void GenerateMap1()
    {
        for (int i = 0; i < straightRoadsSpawnLocationsMap1.Length; i++)
        {
            if (i>140 && i<188  || i<73 && i>26)  //|| i>54 && i<74
            {
                GameObject gameObject = Instantiate(straightRoad, straightRoadsSpawnLocationsMap1[i].position, straightRoad.transform.rotation);
                gameObject.transform.SetParent(straightRoadsSpawnLocationsMap1[i]);
                gameObject.transform.Rotate(Vector3.up * 90);
               
                straightRoadsSpawnedObjects1.Add(gameObject);
                SpawnedObjectsData data = new SpawnedObjectsData(gameObject.transform.position, gameObject.name, gameObject.transform.rotation);
                spawnedObjectsDataList.Add(data);
                
            }
            else
            {
                GameObject gameObject;

                if (i == 188)
                {
                    gameObject = Instantiate(threeWayRoad, straightRoadsSpawnLocationsMap1[i].position, threeWayRoad.transform.rotation);
                    gameObject.transform.SetParent(straightRoadsSpawnLocationsMap1[i]);
                    gameObject.transform.Rotate(Vector3.up * 270);
                   
                    straightRoadsSpawnedObjects1.Add(gameObject);
                    SpawnedObjectsData data = new SpawnedObjectsData(gameObject.transform.position, gameObject.name, gameObject.transform.rotation);
                    spawnedObjectsDataList.Add(data);
                   
                }
                else
                {
                    gameObject = Instantiate(straightRoad, straightRoadsSpawnLocationsMap1[i].position, straightRoad.transform.rotation);
                    gameObject.transform.SetParent(straightRoadsSpawnLocationsMap1[i]);
                    straightRoadsSpawnedObjects1.Add(gameObject);
                   
                    SpawnedObjectsData data = new SpawnedObjectsData(gameObject.transform.position, gameObject.name, gameObject.transform.rotation);
                    spawnedObjectsDataList.Add(data);
                   

                }
                // GameObject gameObject = Instantiate(straightRoad, straightRoadsSpawnLocations[i].position, straightRoad.transform.rotation);
                //gameObject.transform.SetParent(straightRoadsSpawnLocations[i]);
            }
        }

        for (int j = 0; j < cornerRoadsSpawnLocationsMap1.Length; j++)
        {

            GameObject gameObject = Instantiate(cornerRoad, cornerRoadsSpawnLocationsMap1[j].position, cornerRoad.transform.rotation);
            gameObject.transform.SetParent(cornerRoadsSpawnLocationsMap1[j]);
           

            if (j == 1)
            {
                gameObject.transform.Rotate(Vector3.up * 270);

            }

            if (j == 2)
            {
                gameObject.transform.Rotate(Vector3.up * 180);

            }
            
            cornerRoadsSpawnedObjects1.Add(gameObject);
            SpawnedObjectsData data = new SpawnedObjectsData(gameObject.transform.position, gameObject.name, gameObject.transform.rotation);
            spawnedObjectsDataList.Add(data);
            
        }
    }


    public void GenerateMap2()
    {
        for(int i= 0; i<straightRoadsSpawnLocationsMap2.Length;i++)
        {
            if(i>12 && i<28 || i>41 && i<54 || i>80 && i<99)
            {
                GameObject gameObject = Instantiate(straightRoad, straightRoadsSpawnLocationsMap2[i].position, straightRoad.transform.rotation);
                gameObject.transform.SetParent(straightRoadsSpawnLocationsMap2[i]);
                gameObject.transform.Rotate(Vector3.up * 90);
               
                straightRoadsSpawnedObjects2.Add(gameObject);
                SpawnedObjectsData data = new SpawnedObjectsData(gameObject.transform.position, gameObject.name,gameObject.transform.rotation);
                spawnedObjectsDataList.Add(data);
               

            }
            else
            {
                GameObject gameObject = Instantiate(straightRoad, straightRoadsSpawnLocationsMap2[i].position, straightRoad.transform.rotation);
                gameObject.transform.SetParent(straightRoadsSpawnLocationsMap2[i]);
               
                straightRoadsSpawnedObjects2.Add(gameObject);
                SpawnedObjectsData data = new SpawnedObjectsData(gameObject.transform.position, gameObject.name, gameObject.transform.rotation);
                spawnedObjectsDataList.Add(data);
               

            }
        }

        for(int j=0; j<cornerRoadsSpawnLocationsMap2.Length;j++)
        {
            GameObject gameObject = Instantiate(cornerRoad, cornerRoadsSpawnLocationsMap2[j].position, cornerRoad.transform.rotation);
            gameObject.transform.SetParent(cornerRoadsSpawnLocationsMap2[j]);
            cornerRoadsSpawnedObjects2.Add(gameObject);
           


            if (j == 0 || j==2 )
            {
                gameObject.transform.Rotate(Vector3.up * 270);

            }

            if(j==4)
            {
                gameObject.transform.Rotate(Vector3.up * 180);
            }

            if (j == 1)
            {
                gameObject.transform.Rotate(Vector3.up * 90);

            }
            SpawnedObjectsData data = new SpawnedObjectsData(gameObject.transform.position, gameObject.name, gameObject.transform.rotation);
            spawnedObjectsDataList.Add(data);
           
        }
    }

    public void Save()
    {
        Debug.Log(spawnedObjectsDataList.Count);
        DataService.SaveRoadData("/random-sceneRoads2.json", spawnedObjectsDataList, EncryptionEnabled);
    }

    public void GenerateSavedScene(string[] objects)
    {
        //string[] objects = savedSceneObjects.LoadList();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       // Debug.Log("hi");
        for (int i = 0; i < objects.Length; i++)
        {
            Debug.Log(objects[i]);
            string json = objects[i];
            SpawnedObjectsData storedObjectsData = JsonUtility.FromJson<SpawnedObjectsData>(json);

            bool prefabFound = false;
            for (int j = 0; j < buildingPrefabs.Length; j++)
            {

                string str = storedObjectsData.name.Replace("(Clone)", "");

                // Debug.Log(storedObjectsData.name);
                // Debug.Log(buildingPrefabs[j].name);
                if (str == buildingPrefabs[j].name)
                {
                    GameObject obj = Instantiate(buildingPrefabs[j], storedObjectsData.occupiedPositions, Quaternion.identity);
                    obj.transform.rotation = storedObjectsData.rotation;
                    destroySavedObjects.Add(obj);
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


}
