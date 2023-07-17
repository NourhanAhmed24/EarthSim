using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CameraMovement : MonoBehaviour
{
    [SerializeField] Camera camera;

    public float zoomAMT ;
    public Scrollbar scrollBar;
   

    public float moveSpeed = 5f; // Adjust this to change the speed of the camera movement
    public float moveAmount = 1f; // Adjust this to change how much the camera moves

    public void Start()
    {
        scrollBar.value = 0.2f;
        camera.fieldOfView = scrollBar.value*zoomAMT;
    }

    public void changeZoom()
    {
        camera.fieldOfView = scrollBar.value * zoomAMT;
    }

    public void MoveUp()
    {
        // Move the camera up when the "Up" arrow key is pressed
        if (camera.transform.position.y < 80)
            camera.transform.Translate(Vector3.up * moveAmount * moveSpeed * Time.deltaTime);
           // camera.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z+1);
    }

    public void MoveDown()
    {
        camera.transform.Translate(Vector3.down * moveAmount * moveSpeed * Time.deltaTime);
    }

    public void MoveRight()
    {
        if(camera.transform.position.x<85)
        camera.transform.Translate(Vector3.right * moveAmount * moveSpeed * Time.deltaTime);

    }

    public void MoveLeft()
    {
        if(camera.transform.position.x > -70)
        camera.transform.Translate(Vector3.left * moveAmount * moveSpeed * Time.deltaTime);
    }

}
