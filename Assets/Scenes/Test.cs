using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{


    public float value;

    public Transform cube;


     public void SetValue(float val)
    {
        value = val;
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cube.Rotate(Vector3.forward * value);
    }
}
