using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemovingState : IBuildingState
{
    private int gameObjectIndex = -1;
    Grid grid;
    PreviewSystem previewSystem;
    GridData floorData;
    GridData furnitureData;
    ObjectPlacer objectPlacer;
    SoundFeedback soundfeedback;




    public RemovingState(Grid grid,
        PreviewSystem previewSystem,
        GridData floorData,
        GridData furnitureData,
        ObjectPlacer objectPlacer,
        SoundFeedback soundfeedback)
    {

        this.grid = grid;
        this.previewSystem = previewSystem;
        this.floorData = floorData;
        this.furnitureData = furnitureData;
        this.objectPlacer = objectPlacer;
        this.soundfeedback = soundfeedback;

        previewSystem.StartShowingRemovePreview();
    }


    public void EndState()
    {
        previewSystem.StopShowingPreview();
    }

    public void OnAction(Vector3Int gridPosition, float yRotation)
    {
        GridData selectedData = null;
        if(furnitureData.CanPlaceObjectAt(gridPosition, Vector2Int.one)==false)
        {
            selectedData = furnitureData;

        }
        else if (floorData.CanPlaceObjectAt(gridPosition, Vector2Int.one) == false)
        {
            selectedData = floorData;
        }

        if(selectedData == null)
        {
            //sound
        }
        else
        {
            gameObjectIndex = selectedData.GetRepresentationIndex(gridPosition);
            if (gameObjectIndex == -1)
                return;
            soundfeedback.PlaySound(SoundType.Remove);
            selectedData.RemoveObjectAt(gridPosition);
            objectPlacer.RemoveObjectsAt(gameObjectIndex);
        }
        Vector3 cellPosition = grid.CellToWorld(gridPosition);
        // previewSystem.UpdatePosition(cellPosition, CheckIfSelectionIsValid(gridPosition),yRotation);
        previewSystem.UpdatePosition(cellPosition, CheckIfSelectionIsValid(gridPosition),yRotation);

    }

    private bool CheckIfSelectionIsValid(Vector3Int gridPosition)
    {
        return !(furnitureData.CanPlaceObjectAt(gridPosition, Vector2Int.one) &&
            floorData.CanPlaceObjectAt(gridPosition, Vector2Int.one));
    }

    public void UpdateState(Vector3Int gridPosition, float yRotation)
    {
        bool validity = CheckIfSelectionIsValid(gridPosition);
          previewSystem.UpdatePosition(grid.CellToWorld(gridPosition), validity,yRotation);
        //previewSystem.UpdatePosition(grid.CellToWorld(gridPosition), validity);

    }

}