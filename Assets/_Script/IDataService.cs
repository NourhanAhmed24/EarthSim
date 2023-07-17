using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataService 
{
    bool SaveData(string RelativePath, List<SpawnedObjectsData> Data, bool Encrypted);
    bool SaveRoadData(string RelativePath, List<SpawnedObjectsData> Data, bool Encrypted);
    bool SaveBuildingSceneData(string RelativePath, List<SpawnedObjectsData> Data, bool Encrypted);
    bool SaveBuildingSceneNewData(string RelativePath, List<SpawnedObjectsData> Data, bool Encrypted);

    // string  LoadData(string RelativePath, bool Encrypted);
    string [] LoadData();
    string[] LoadRoadsData();
    string[] LoadBuildingSceneData();
}
