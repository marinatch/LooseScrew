using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class WinScript : MonoBehaviour
{
    public GameObject youWinPanel;
    public AudioSource winAudio;
    public int sceneNumber;
    public Text winnerText;

    private void Start()
    {
        youWinPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" || other.tag == "Player2")
        {
            youWinPanel.SetActive(true);
            winAudio.Play();
            Time.timeScale = 0.0f;
            if(other.tag == "Player")
            {
                winnerText.text = "Player 1 wins!";
            }
            else
            {
                winnerText.text = "Player 2 wins!";
            }
        }
    }

    public void NextLevel()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(sceneNumber);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    
    public void QuitGame()
    {
        Debug.Log("Quit...");//la dejamos para confirmar que Quit esta funcionando. Porque con quit solo no pasa nada en la consola
        Application.Quit();
    }
}
