using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectScene : MonoBehaviour
{
    public GameObject[] characters;
    
    public int bodyCount;

    private int currentCharacter;
    private CharacterSelectorCont[] characterControls;
    private int  currentBody;


    void Start()
    {
        characterControls = new CharacterSelectorCont[characters.Length];


        SetCharacter(0);
    }
    public void SetCharacter(int newCharacter)
    {
        currentCharacter = newCharacter;

        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].SetActive(i == currentCharacter);

            if (i == currentCharacter)
            {
                characterControls[i].SetMaterial(currentBody);
            }
        }
    }

    public void NextBodyMaterial()
    {
        currentBody++;
        if (currentBody >= bodyCount) currentBody = 0;

        characterControls[currentCharacter].SetMaterial(currentBody);
    }
}
