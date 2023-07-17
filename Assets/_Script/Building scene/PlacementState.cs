using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementState : IBuildingState
{
    private int selectedObjectIndex = -1;
    int ID;
    Grid grid;
    PreviewSystem previewSystem;
    ObjectsDatabaseSO database;
    GridData floorData;
    GridData furnitureData;
    ObjectPlacer objectPlacer;
    SoundFeedback soundfeedback;


    public PlacementState(int iD, Grid grid,
        PreviewSystem previewSystem,
        ObjectsDatabaseSO database,
        GridData floorData,
        GridData furnitureData,
        ObjectPlacer objectPlacer,
        SoundFeedback soundfeedback)
    {
        ID = iD;
        this.grid = grid;
        this.previewSystem = previewSystem;
        this.database = database;
        this.floorData = floorData;
        this.furnitureData = furnitureData;
        this.objectPlacer = objectPlacer;
        this.soundfeedback = soundfeedback;
        

        selectedObjectIndex = database.objectsData.FindIndex(database => database.ID == ID);
        if(selectedObjectIndex>-1)
        {
            previewSystem.StartShowingPlacementPreview(
           database.objectsData[selectedObjectIndex].Prefab,
           database.objectsData[selectedObjectIndex].Size);
        }
        else
        {
            throw new System.Exception($"No object with ID {iD}");
        }
        
    }

    public void EndState()
    {
        previewSystem.StopShowingPreview();

    }

    private bool CheckPlacementValidity(Vector3Int gridPosition, int selectedObjectIndex)
    {
        GridData selectedData = database.objectsData[selectedObjectIndex].ID == 0 ? floorData : furnitureData;
        return selectedData.CanPlaceObjectAt(gridPosition, database.objectsData[selectedObjectIndex].Size);

    }

    public void OnAction(Vector3Int gridPosition, float yRotation)
    {
        bool PlacementValidity = CheckPlacementValidity(gridPosition, selectedObjectIndex);
        if (PlacementValidity == false)
        {
            soundfeedback.PlaySound(SoundType.wrongPlacement);
            return;
           
        }
        //source.Play();
        soundfeedback.PlaySound(SoundType.Place);
        int index = objectPlacer.PlaceObject(database.objectsData[selectedObjectIndex].Prefab, grid.CellToWorld(gridPosition), yRotation);

        //int index = objectPlacer.PlaceObject(database.objectsData[selectedObjectIndex].Prefab, grid.CellToWorld(gridPosition));

        GridData selectedData = database.objectsData[selectedObjectIndex].ID == 0 ? floorData : furnitureData;
        selectedData.AddObjectAt(gridPosition,
            database.objectsData[selectedObjectIndex].Size,
            database.objectsData[selectedObjectIndex].ID,
            index);
        // previewSystem.UpdatePosition(grid.CellToWorld(gridPosition), false, yRotation);
        previewSystem.UpdatePosition(grid.CellToWorld(gridPosition), false, yRotation);


    }


    public void UpdateState(Vector3Int gridPosition, float yRotation)
    {
        bool PlacementValidity = CheckPlacementValidity(gridPosition, selectedObjectIndex);
        previewSystem.UpdatePosition(grid.CellToWorld(gridPosition), PlacementValidity, yRotation);
        //previewSystem.UpdatePosition(grid.CellToWorld(gridPosition), PlacementValidity);

    }

}
