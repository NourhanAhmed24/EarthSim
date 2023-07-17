using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GetInputOnClick : MonoBehaviour
{
    public Button btnClick;
    public InputField doctorInput;
    public InputField firefighterInput;
    public InputField victimInput;
    public InputField obstacleInput;
    MapGenerator mapGenerator = new MapGenerator();


    int doctorsNum=0;
    int firefightersNum;
    int victimsNum;
    int obstaclesNum;

    private void  Start()
    {
        btnClick.onClick.AddListener(GetInputOnClickHandler);
    }

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
    }


   /* public void GoToScene()
    {
        mapGenerator.Generate(doctorsNum);
        //Debug.Log(doctorsNum);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }*/

}
