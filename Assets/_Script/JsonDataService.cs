using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
//using Newtonsoft.Json.JsonSerializerSettings;
using System;
using System.IO;



public class JsonDataService : IDataService
{

    public NewBehaviourScript newBehaviourScript = new NewBehaviourScript();

    public bool SaveData(string RelativePath, List<SpawnedObjectsData> Data, bool Encrypted)
     {
         //string path = Application.persistentDataPath + RelativePath;

        //string data = JsonConvert.SerializeObject(Data, Formatting.Indented, ReferencedLoopHandling = ReferencedLoopHandling.Serialize);
        //Debug.Log(data);

        /*  try
          {
              if(File.Exists(path))
              {
                  Debug.Log("Data Exists. Deleting the old file and creating a new one");

                  File.Delete(path);
              }
              using FileStream stream = File.Create(path);
          Debug.Log(path);

              File.WriteAllText(path, JsonConvert.SerializeObject(Data, Formatting.Indented));
          stream.Close();
          return true;
          }
          catch(Exception e)
          {
             // Debug.LogError($"Unable to save data due to: {"e.Message"} {e.StackTrace}");
              return false;
          }*/

        /* using (StreamWriter file = File.CreateText(@"D:\path.txt"))
         {
           


            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, Data);
          }

        return true;

        */
       // Debug.Log(path);

        for (int i = 0; i < Data.Count; i++)
        {
            String fileName = "random-scene2";
            if (File.Exists(fileName) && i==0)
            {
                
                String json = JsonUtility.ToJson(Data[i]);
              //  Debug.Log(json);
                File.WriteAllText(fileName,json);
                File.AppendAllText(fileName, "\n");
            }
            else
            {
                String json = JsonUtility.ToJson(Data[i]);
               // Debug.Log(json);
                File.AppendAllText(fileName, json);
                File.AppendAllText(fileName, "\n");

            }
              
        }

        Debug.Log("saved");
        
        return true;

    }

    




    public bool SaveRoadData(string RelativePath, List<SpawnedObjectsData> Data, bool Encrypted)
    {
        for (int i = 0; i < Data.Count; i++)
        {
            String fileName = "random-sceneRoads2";
            String json = JsonUtility.ToJson(Data[i]);
            if (i==0)
            {
                File.WriteAllText(fileName, json);
                File.AppendAllText(fileName, "\n");
            }
                
                // Debug.Log(json);
                File.AppendAllText(fileName, json);
                File.AppendAllText(fileName, "\n");

            Debug.Log("hereee");

        }

        Debug.Log("Roads Saved");

        return true;

    }

   


    public bool SaveBuildingSceneData(string RelativePath, List<SpawnedObjectsData> Data, bool Encrypted)
    {
        //bool flag = newBehaviourScript.NewScene();
        for (int i = 0; i < Data.Count; i++)
        {
            String fileName = "building-scene";
            String json = JsonUtility.ToJson(Data[i]);
           /* if ( flag == true)
            {
                File.WriteAllText(fileName, json);
                File.AppendAllText(fileName, "\n");
            }*/

            // Debug.Log(json);
            File.AppendAllText(fileName, json);
            File.AppendAllText(fileName, "\n");



        }


        return true;

    }


    public bool SaveBuildingSceneNewData(string RelativePath, List<SpawnedObjectsData> Data, bool Encrypted)
    {
        
        for (int i = 0; i < Data.Count; i++)
        {
            String fileName = "building-scene";
            String json = JsonUtility.ToJson(Data[i]);
             if ( i == 0)
             {
                 File.WriteAllText(fileName, json);
                 File.AppendAllText(fileName, "\n");
             }

            else
            {
                File.AppendAllText(fileName, json);
                File.AppendAllText(fileName, "\n");
            }
           



        }
        Debug.Log("new data");

        return true;

    }



    /*public string  LoadData(string RelativePath, bool Encrypted)
    {
        string path = Application.persistentDataPath + RelativePath;
       // Debug.Log(path);
       /* if (!File.Exists(path))
        {
            Debug.LogError($"can not load file at {path}");
            throw new FileNotFoundException($"{path} does not exist");
            Debug.Log(path);
            return ("null");

        }*/
    //else if(File.Exists(path))

    // String fileContent = File.ReadAllText(path);
    // Console.WriteLine(fileContent);
    // return fileContent;
    // Debug.Log(fileContent);
    //Debug.Log(path);


    // Read a text file line by line.
    //string  lines = File.ReadAllText(path);


    //Debug.Log(lines);
    /*   for (int i=0; i<lines.Length;i++)
       {
           Console.WriteLine(lines[i]);
           Debug.Log("hiiii");
       }




    //return lines;

}*/

    //reads objects file
    public string[] LoadData()
    {
        string fileName = "random-scene2";
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
        string[] fileContent;

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"Cannot load file at {filePath}. File does not exist.");
        }

       // string[] fileContent = new;
        try
        {
             fileContent = File.ReadAllLines(filePath);
            /*for(int i=0; i<fileContent.Length;i++)
            {
                Debug.Log(fileContent[i]);
            }*/
           // Debug.Log(fileContent.Length);
           // Debug.Log("done");
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while loading the file at {filePath}. Error message: {ex.Message}");
        }

        return fileContent;
    }

    //reads roads file
    public string[] LoadRoadsData()
    {
        string fileName = "random-sceneRoads2";
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
        string[] fileContent;

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"Cannot load file at {filePath}. File does not exist.");
        }

        // string[] fileContent = new;
        try
        {
            fileContent = File.ReadAllLines(filePath);
            /*for(int i=0; i<fileContent.Length;i++)
            {
                Debug.Log(fileContent[i]);
            }*/
            // Debug.Log(fileContent.Length);
            // Debug.Log("done");
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while loading the file at {filePath}. Error message: {ex.Message}");
        }

        return fileContent;
    }


  //reads building scene file
    public string[] LoadBuildingSceneData()
    {
        string fileName = "building-scene";
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
        string[] fileContent;

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"Cannot load file at {filePath}. File does not exist.");
        }

        // string[] fileContent = new;
        try
        {
            fileContent = File.ReadAllLines(filePath);
            /*for(int i=0; i<fileContent.Length;i++)
            {
                Debug.Log(fileContent[i]);
            }*/
            // Debug.Log(fileContent.Length);
            // Debug.Log("done");
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while loading the file at {filePath}. Error message: {ex.Message}");
        }

        return fileContent;
    }



}
