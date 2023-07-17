using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenRotatePanel : MonoBehaviour
{
    public GameObject gameObject;
    bool active = false;

    public void Start()
    {
        gameObject.transform.gameObject.SetActive(false);
    }


    public void OpenAndClose()
    {

        if (active == false)
        {
            gameObject.transform.gameObject.SetActive(true);
            active = true;
        }
        else
        {
            gameObject.transform.gameObject.SetActive(false);
            active = false;
        }
    }
}
