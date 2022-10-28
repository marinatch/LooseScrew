using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectorCont : MonoBehaviour
{
    public GameObject body;
    public Material[] theMaterials;
    public void SetMaterial(int theMat)
    {
        body.GetComponent<Renderer>().material = theMaterials[theMat];
    }
}
