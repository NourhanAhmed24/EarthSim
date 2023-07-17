/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class MenuCameraMovement : MonoBehaviour
{
   
    private Vector3 _newPosition, _newRotation;

    [SerializeField]
    private Vector2 min;

    [SerializeField]
    private Vector2 max;

    [SerializeField]
    private Vector2 yRotationRange;

    [SerializeField]
    [Range(0.01f, 0.1f)]
    private float lerpSpeed = 0.05f;


    private void Awake()
    {
        _newPosition = transform.position;
        _newRotation = transform.rotation.eulerAngles;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _newPosition, Time.deltaTime * lerpSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(_newRotation), Time.deltaTime * lerpSpeed);

        if (Vector3.Distance(transform.position, _newPosition) < 1f)
        {
            GetNewPosition();
        }
    }

    void GetNewPosition()
    {
        var randomXPosition = UnityEngine.Random.Range(min.x, max.x);
        var randomZPosition = UnityEngine.Random.Range(min.y, max.y);
        _newRotation = new Vector3(0, UnityEngine.Random.Range(yRotationRange.x, yRotationRange.y), 0);
        _newPosition = new Vector3(randomXPosition, 0, randomZPosition);
    }

}*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCameraMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 1f;

    [SerializeField]
    private float xMovementRange = 10f;

    [SerializeField]
    private float yMovementRange = 5f;

    [SerializeField]
    private float zMovementRange = 10f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float xMovement = Mathf.Sin(Time.time) * xMovementRange;
        float yMovement = Mathf.Cos(Time.time) * yMovementRange;
        float zMovement = Mathf.Sin(Time.time * 0.5f) * zMovementRange;

        Vector3 targetPosition = startPosition + new Vector3(xMovement, yMovement, zMovement);

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * movementSpeed);
    }
}

