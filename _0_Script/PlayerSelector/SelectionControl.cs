using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionControl : MonoBehaviour
{
    public bool p1Confirmed, p2Confirmed;
    void Start()
    {
        p1Confirmed = p2Confirmed = false;
    }

    void Update()
    {
        if(p1Confirmed == true && p2Confirmed == true)
        {
            SceneManager.LoadScene(3);
        }
    }
}
