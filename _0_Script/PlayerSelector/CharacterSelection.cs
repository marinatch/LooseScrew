using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public int player;
    public GameObject selectionControl;
    public GameObject left, right, confirm, cancel;
    public List<GameObject> FxAudios;

    private GameObject[] characterList;
    private int index = 0;
    void Start()
    {
        if(player == 1) PlayerPrefs.SetInt("CharacterSelectedP1", index);
        else PlayerPrefs.SetInt("CharacterSelectedP2", index);

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
        if(characterList[index])
        { 
            characterList[index].SetActive(true);
        }
    }

    public void ToggleLeft()
    {
        // Añadimos sonido
        GameObject newSound = Instantiate(FxAudios[0], transform.position, Quaternion.identity);
        Destroy(newSound, 2);
        //desactivar los models
        characterList[index].SetActive(false);

        index--;
        if(index < 0)
        {
            index = characterList.Length - 1;
        }

        //activar el nuevo model
        characterList[index].SetActive(true);
    }
    public void ToggleRight()
    {
        // Añadimos sonido
        GameObject newSound = Instantiate(FxAudios[0], transform.position, Quaternion.identity);
        Destroy(newSound, 2);
        //desactivar los models
        characterList[index].SetActive(false);

        index++;
        if (index == characterList.Length)
        {
            index = 0;
        }

        //activar el nuevo model
        characterList[index].SetActive(true);
    }
    
    public void ConfirmButton()
    {
        // Añadimos sonido
        GameObject newSound = Instantiate(FxAudios[0], transform.position, Quaternion.identity);
        Destroy(newSound, 2);

        if (player == 1)
        {
            if (PlayerPrefs.GetInt("CharacterSelectedP2") != index)
            { 
                PlayerPrefs.SetInt("CharacterSelectedP1", index);
                selectionControl.GetComponent<SelectionControl>().p1Confirmed = true;
                left.SetActive(false);
                right.SetActive(false);
                confirm.SetActive(false);
                cancel.SetActive(true);
            }
        }
        else
        {
            if (PlayerPrefs.GetInt("CharacterSelectedP1") != index)
            {
                PlayerPrefs.SetInt("CharacterSelectedP2", index);
                selectionControl.GetComponent<SelectionControl>().p2Confirmed = true;
                left.SetActive(false);
                right.SetActive(false);
                confirm.SetActive(false);
                cancel.SetActive(true);
            }
        }
    }

    public void CancelButton()
    {
        // Añadimos sonido
        GameObject newSound = Instantiate(FxAudios[0], transform.position, Quaternion.identity);
        Destroy(newSound, 2);

        if (player == 1)
        {
            PlayerPrefs.SetInt("CharacterSelectedP1", 0);
            selectionControl.GetComponent<SelectionControl>().p1Confirmed = false;
        }
        else
        {
            PlayerPrefs.SetInt("CharacterSelectedP2", 0);
            selectionControl.GetComponent<SelectionControl>().p2Confirmed = false;
        }

        cancel.SetActive(false);
        left.SetActive(true);
        right.SetActive(true);
        confirm.SetActive(true);
    }
}