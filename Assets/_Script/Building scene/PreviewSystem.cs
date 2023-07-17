using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewSystem : MonoBehaviour
{
    [SerializeField]
    private float previewYOffset = 0.06f;

    [SerializeField]
    private GameObject cellIndicator;
    private GameObject previewObject;

    [SerializeField]
    private Material previewMaterialPrefab;
    private Material previewMaterialInstance;
    private float Rotation=0;

    private Renderer cellIndicatorRenderer;
    PlacementSystem placementSystem;

    private void Start()
    {
        previewMaterialInstance = new Material(previewMaterialPrefab);
        cellIndicator.SetActive(false);
        cellIndicatorRenderer = cellIndicator.GetComponentInChildren<Renderer>();
    }


   /* public void SetRotation90()
    {
        Rotation = 90;
    }

    public void SetRotation180()
    {
        Rotation = 180;
    }

    public void SetRotation270()
    {
        Rotation = 270;
    }

    public void SetRotation0()
    {
        Rotation = 0;
    }
   */
    public void StartShowingPlacementPreview(GameObject prefab, Vector2Int size)
    {
        previewObject = Instantiate(prefab);
        //previewObject.transform.Rotate(Vector3.up * Rotation);
        PreparePreview(previewObject);
        PrepareCursor(size);
        cellIndicator.SetActive(true);
    }

    private void PrepareCursor(Vector2Int size)
    {
        if(size.x >0 || size.y >0)
        {
            cellIndicator.transform.localScale = new Vector3(size.x, 1, size.y);
           // cellIndicator.transform.Rotate(Vector3.up * yRotation);
            cellIndicatorRenderer.material.mainTextureScale = size;
        }
    }

    private void PreparePreview(GameObject previewObject)
    {
        Renderer[] renderers = previewObject.GetComponentsInChildren<Renderer>();
        foreach(Renderer renderer in renderers)
        {
            Material[] materials = renderer.materials;
            for(int i=0;i <materials.Length;i++)
            {
                materials[i] = previewMaterialInstance;
            }

            renderer.materials = materials;
        }

       // previewObject.transform.Rotate(Vector3.up * Rotation);

    }
    

    public void StopShowingPreview()
    {
        cellIndicator.SetActive(false);
        if(previewObject!=null)
        {
            Destroy(previewObject);
        }
       
    }

    public void UpdatePosition(Vector3 position, bool validity, float Rotation)
    { 
        if(previewObject!=null)
        {
            //MovePreview(position, yRotation);
            MovePreview(position, Rotation);

            ApplyFeedbackToPreview(validity);
        }

        //MoveCursor(position,yRotation);
        MoveCursor(position);
        ApplyFeedbackToCursor(validity);
    }

    private void ApplyFeedbackToPreview(bool validity)
    {
        Color c = validity ? Color.white : Color.red;
        c.a = 0.5f;
        

        previewMaterialInstance.color = c;
    }

    private void ApplyFeedbackToCursor(bool validity)
    {
        Color c = validity ? Color.white : Color.red;
        c.a = 0.5f;
        cellIndicatorRenderer.material.color = c;

       
    }

    private void MoveCursor(Vector3 position)
    {
        cellIndicator.transform.position = position;
       // cellIndicator.transform.Rotate(Vector3.up * yRotation);
    }

    private void MovePreview(Vector3 position, float Rotation)
    {
        previewObject.transform.position = new Vector3(
            position.x, position.y + previewYOffset, position.z);

        previewObject.transform.Rotate(Vector3.up * Rotation);

    }

    internal void StartShowingRemovePreview()
    {
        cellIndicator.SetActive(true);
        PrepareCursor(Vector2Int.one);
        ApplyFeedbackToCursor(false);
    }
}
