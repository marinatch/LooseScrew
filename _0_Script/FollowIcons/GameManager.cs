using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<SplineAnimatorClosestPoint> allPoints;
    public List<float> allParams;

    public Text[] textPos;

    void Start()
    {
        
    }


    void Update()
    {
        for (int i = 0; i < allPoints.Count; i++)
        {
            print(allPoints[i].lastParam);
            allParams.Add(allPoints[i].lastParam);
        }
        allParams.Sort();
        PrintPodio();
        allParams.Clear();
        //if(Input.GetKeyDown(KeyCode.H))
        //{


        //}
    }

    void PrintPodio()
    {
        for (int i = 0; i < allPoints.Count; i++)
        {
            int initPodio = 1;
            for (int j = allParams.Count-1; j >=0; j--)
            {
                if(allPoints[i].lastParam==allParams[j])
                {

                    textPos[i].text = initPodio.ToString();
                    //print("El jugador:" + (i + 1) + "Ha quedado en posición:" + initPodio);
                    break;
                }
                initPodio++;
            }
            
        }
    }
}
