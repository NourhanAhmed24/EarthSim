using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using TMPro;
using System.IO;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] public GameObject[] buildingPrefabs;
    [SerializeField] private Transform[] spawnLocations;
    //GetInputOnClick fields = new GetInputOnClick();

    private List<SpawnedObjectsData> spawnedObjectsDataList = new List<SpawnedObjectsData>();
    private IDataService DataService = new JsonDataService();
    private bool EncryptionEnabled;
   private long SaveTime;
    [SerializeField]
    private TextMeshProUGUI SourceDataText;
    [SerializeField]
    private TMP_InputField InputField;
    [SerializeField] private TextMeshProUGUI SaveTimeText;
    [SerializeField] private TextMeshProUGUI LoadTimeText;

    private List<GameObject> spawnedObjects = new List<GameObject>();
    private List<GameObject> destroySavedObjects = new List<GameObject>();


    //fields

    public InputField doctorInput;
    public InputField firefighterInput;
    public InputField victimInput;
    public InputField obstacleInput;
    public InputField housesInput;

    int doctorsNum = 0;
    int firefightersNum;
    int victimsNum;
    int obstaclesNum;
    int housesNum;


   public LoadSavedScene savedSceneObjects = new LoadSavedScene();
  

    public void GetInputOnClickHandler()
    {

        doctorsNum = int.Parse(doctorInput.text);
        //  Debug.Log("input value:" + doctorsNum);



        firefightersNum = int.Parse(firefighterInput.text);
        // Debug.Log("input value:" + firefightersNum);

        obstaclesNum = int.Parse(obstacleInput.text);
        // Debug.Log("input value:" + obstaclesNum);

        victimsNum = int.Parse(victimInput.text);
        // Debug.Log("input value:" + victimsNum);

        housesNum = int.Parse(housesInput.text);


        /*int ranNum = UnityEngine.Random.Range(0, 3);

        GenerateDoctor(doctorsNum);
        GenerateFirefighter(firefightersNum);
        GenerateVictim(victimsNum);
        GenerateObstacles(obstaclesNum);
        GenerateHouses(housesNum);*/



        /*  if (ranNum == 0)
          {
              Generate(doctorsNum);
              GenerateFirefighter(firefightersNum);
              GenerateVictim(victimsNum);
              GenerateObstacles(obstaclesNum);
          }


          if (ranNum == 1)
          {

              GenerateFirefighter(firefightersNum);
              Generate(doctorsNum);   
              GenerateObstacles(obstaclesNum);
              GenerateVictim(victimsNum);
          }


          if (ranNum == 2)
          {
              GenerateVictim(victimsNum);
              Generate(doctorsNum);
              GenerateObstacles(obstaclesNum);
              GenerateFirefighter(firefightersNum);
          }



          if (ranNum == 2)
          {
              GenerateObstacles(obstaclesNum);
              GenerateVictim(victimsNum);
              GenerateFirefighter(firefightersNum);
              Generate(doctorsNum);
          }*/



    }

    public void Randomize()
    {
        // Destroy previously spawned objects
        foreach (GameObject obj in spawnedObjects)
        {
            Destroy(obj);
        }

        foreach(GameObject obj in destroySavedObjects)
        {
            Destroy(obj);
        }
        spawnedObjects.Clear();
        spawnedObjectsDataList.Clear();
        destroySavedObjects.Clear();

        

        GenerateDoctor(doctorsNum);
        GenerateFirefighter(firefightersNum);
        GenerateVictim(victimsNum);
        GenerateObstacles(obstaclesNum);
        GenerateHouses(housesNum);
       // DataService.SaveData("/random-scene.json", spawnedObjectsDataList, EncryptionEnabled);

    }

    public void Save()
    {
        DataService.SaveData("/random-scene.json", spawnedObjectsDataList, EncryptionEnabled);
       
    }

  /*  public void Load()
    {
        // DataService.LoadData("/random-scene.json", EncryptionEnabled);
        DataService.LoadData();
    }*/

    public void ToggleEncryption(bool EncryptionEnabled)
    {
        this.EncryptionEnabled = EncryptionEnabled;
    }


    public void GenerateDoctor(int doctorsNum)
    {
        Debug.Log(doctorsNum);
        //int spawnLocationsLength = spawnLocations.Length;
        Debug.Log(spawnLocations.Length);

        while (doctorsNum != 0)
        {
            int ranNum = UnityEngine.Random.Range(0, spawnLocations.Length);
            for (int j = 0; j < buildingPrefabs.Length; j++)
            {
                if (buildingPrefabs[j].name == "DoctorRotateParent")
                {
                    GameObject gameObject = Instantiate(buildingPrefabs[j], spawnLocations[ranNum].position, buildingPrefabs[j].transform.rotation);
                    gameObject.transform.SetParent(spawnLocations[ranNum]);
                    spawnedObjects.Add(gameObject);
                    SpawnedObjectsData data = new SpawnedObjectsData(gameObject.transform.position, gameObject.name, gameObject.transform.rotation);
                    // Debug.Log(data.occupiedPositions);
                    //Debug.Log(data.occupiedPositions);
                    spawnedObjectsDataList.Add(data);

                }
            }
            doctorsNum = doctorsNum - 1;
        }

    }


    public void GenerateFirefighter(int firefighterNum)
    {
        while (firefighterNum != 0)
        {
            int ranNum = UnityEngine.Random.Range(0, spawnLocations.Length);

            for (int j = 0; j < buildingPrefabs.Length; j++)
            {
                if (buildingPrefabs[j].name == "FirefighterRotateParent")
                {
                    while (spawnLocations[ranNum].childCount > 0)
                    {
                        ranNum = UnityEngine.Random.Range(0, spawnLocations.Length);
                    }
                    GameObject gameObject = Instantiate(buildingPrefabs[j], spawnLocations[ranNum].position, buildingPrefabs[j].transform.rotation);
                    gameObject.transform.SetParent(spawnLocations[ranNum]);
                    spawnedObjects.Add(gameObject);
                    SpawnedObjectsData data = new SpawnedObjectsData(gameObject.transform.position, gameObject.name, gameObject.transform.rotation);
                    // Debug.Log(data.occupiedPositions);
                    //Debug.Log(data.occupiedPositions);
                    spawnedObjectsDataList.Add(data);
                }
            }
            firefighterNum = firefighterNum - 1;
        }

    }


    public void GenerateVictim(int victimsNum)
    {
        while (victimsNum != 0)
        {
            int ranNum = UnityEngine.Random.Range(0, spawnLocations.Length);

            for (int j = 0; j < buildingPrefabs.Length; j++)
            {
                if (buildingPrefabs[j].name == "VictimRotateParent")
                {
                    while (spawnLocations[ranNum].childCount > 0)
                    {
                        ranNum = UnityEngine.Random.Range(0, spawnLocations.Length);
                    }
                    GameObject gameObject = Instantiate(buildingPrefabs[j], spawnLocations[ranNum].position, buildingPrefabs[j].transform.rotation);
                    gameObject.transform.SetParent(spawnLocations[ranNum]);
                    spawnedObjects.Add(gameObject);
                    SpawnedObjectsData data = new SpawnedObjectsData(gameObject.transform.position, gameObject.name, gameObject.transform.rotation);
                    // Debug.Log(data.occupiedPositions);
                    //Debug.Log(data.occupiedPositions);
                    spawnedObjectsDataList.Add(data);
                }
            }
            victimsNum = victimsNum - 1;
        }

    }




    public void GenerateObstacles(int obstaclesNum)
    {
        while (obstaclesNum != 0)
        {
            int ranNum = UnityEngine.Random.Range(0, spawnLocations.Length);

            for (int j = 0; j < buildingPrefabs.Length; j++)
            {
                if (buildingPrefabs[j].name == "DebrisRotateParent")
                {
                    while (spawnLocations[ranNum].childCount > 0)
                    {
                        ranNum = UnityEngine.Random.Range(0, spawnLocations.Length);
                    }
                    GameObject gameObject = Instantiate(buildingPrefabs[j], spawnLocations[ranNum].position, buildingPrefabs[j].transform.rotation);
                    gameObject.transform.SetParent(spawnLocations[ranNum]);
                    spawnedObjects.Add(gameObject);
                    SpawnedObjectsData data = new SpawnedObjectsData(gameObject.transform.position, gameObject.name, gameObject.transform.rotation);
                    // Debug.Log(data.occupiedPositions);
                    //Debug.Log(data.occupiedPositions);
                    spawnedObjectsDataList.Add(data);
                }
            }
            obstaclesNum = obstaclesNum - 1;
        }

    }


    public void GenerateHouses(int housesNum)
    {
        while (housesNum != 0)
        {
            int ranNum = UnityEngine.Random.Range(0, spawnLocations.Length);

            for (int j = 0; j < buildingPrefabs.Length; j++)
            {
                if (buildingPrefabs[j].name == "HouseRotateParent")
                {
                    while (spawnLocations[ranNum].childCount > 0)
                    {
                        ranNum = UnityEngine.Random.Range(0, spawnLocations.Length);
                    }
                    GameObject gameObject = Instantiate(buildingPrefabs[j], spawnLocations[ranNum].position, buildingPrefabs[j].transform.rotation);
                    gameObject.transform.SetParent(spawnLocations[ranNum]);
                    spawnedObjects.Add(gameObject);
                    SpawnedObjectsData data = new SpawnedObjectsData(gameObject.transform.position, gameObject.name, gameObject.transform.rotation);
                    // Debug.Log(data.occupiedPositions);
                    //Debug.Log(data.occupiedPositions);
                    spawnedObjectsDataList.Add(data);
                   
                }
            }
            housesNum = housesNum - 1;
        }

    }


    /* public void GenerateSavedScene(string [] objects)
     {

        // objects = DataService.LoadData();
         for (int i=0;i<objects.Length;i++)
         {


                     string json = objects[i];
                     SpawnedObjectsData storedObjectsData = JsonUtility.FromJson<SpawnedObjectsData>(json);
                     Debug.Log(storedObjectsData.name);
                     GameObject prefab = Resources.Load<GameObject>(storedObjectsData.name);
                     GameObject obj = Instantiate(prefab, storedObjectsData.occupiedPositions, Quaternion.identity);


         }
     }*/

    public void GenerateSavedScene(string [] objects)
    {
        //string[] objects = savedSceneObjects.LoadList();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("hi");
        for (int s=0;s<objects.Length;s++)
        {
            Debug.Log(objects[s]);
        }
        for (int i = 0; i < objects.Length; i++)
        {
            string json = objects[i];
            
            SpawnedObjectsData storedObjectsData = JsonUtility.FromJson<SpawnedObjectsData>(json);

            bool prefabFound = false;
            for (int j = 0; j < buildingPrefabs.Length; j++)
            {
                Debug.Log("hiiiiiiii");
               string  str = storedObjectsData.name.Replace("(Clone)", "");

                // Debug.Log(storedObjectsData.name);
                // Debug.Log(buildingPrefabs[j].name);
                if (str == buildingPrefabs[j].name)
                {
                    GameObject obj = Instantiate(buildingPrefabs[j], storedObjectsData.occupiedPositions, Quaternion.identity);
                    destroySavedObjects.Add(obj);
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



    /* private void Start()
     {
         Generate();
     }

     private void Update()
     {
         if (Input.GetKeyDown(KeyCode.Space))
         {
             Generate();
         }
     }

     public void Generate()
     {
         // Destroy previously spawned objects
         foreach (GameObject obj in spawnedObjects)
         {
             Destroy(obj);
         }
         spawnedObjects.Clear();

         // Generate new objects
         for (int i = 0; i < spawnLocations.Length; i++)
         {
             int ranNum = UnityEngine.Random.Range(0, buildingPrefabs.Length);
             GameObject gameObject = Instantiate(buildingPrefabs[ranNum], spawnLocations[i].position, buildingPrefabs[ranNum].transform.rotation);
             gameObject.transform.SetParent(spawnLocations[i]);
             spawnedObjects.Add(gameObject);
             SpawnedObjectsData data = new SpawnedObjectsData(gameObject.transform.position, gameObject.name);
            // Debug.Log(data.occupiedPositions);
             //Debug.Log(data.occupiedPositions);
             spawnedObjectsDataList.Add(data);

         }
         Debug.Log(spawnLocations.Length);
         DataService.SaveData("/random-scene.json", spawnedObjectsDataList, EncryptionEnabled);

     }

     public void SerializeData()
     {
         long startTime = DateTime.Now.Ticks;
          if (DataService.SaveData("/random-scene.json", spawnedObjectsDataList, EncryptionEnabled))
          {
              SaveTime = DateTime.Now.Ticks - startTime;
             // SaveTimeText.SetText($"Save Time: { (SaveTime / 10000f):N4}ms");
          }
          else
          {
              Debug.LogError("Could not save file");
             // InputField.text = "<color+#ff0000>Error saving data!</color>";
          }

         DataService.SaveData("/random-scene.json", spawnedObjectsDataList, EncryptionEnabled);
     }*/




}


[Serializable]
public class SpawnedObjectsData
{
    public Vector3 occupiedPositions;
    public string name;
    public Quaternion rotation;

    public SpawnedObjectsData(Vector3 occupiedPositions, string name, Quaternion rotation)
    {
        this.occupiedPositions = occupiedPositions;
        this.name = name;
        this.rotation = rotation;
    }
}
