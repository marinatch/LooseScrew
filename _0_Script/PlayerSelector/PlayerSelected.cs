using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelected : MonoBehaviour
{
    public int player;

    private GameObject[] characterList;
    private int index = 0;

    void Start()
    {
        if (player == 1) index = PlayerPrefs.GetInt("CharacterSelectedP1");
        else index = PlayerPrefs.GetInt("CharacterSelectedP2");

        characterList = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            characterList[i] = transform.GetChild(i).gameObject;
        }
        // Desactivar los GameObjects
        foreach (GameObject color in characterList)
        {
            color.SetActive(false);
        }

        // Mostrar el modelo seleccionado
        if (characterList[index])
        {
            characterList[index].SetActive(true);
        }
    }
}
