using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public List<GameObject> FxAudios;

    public void GoToScene(int nextScene)
    {
        // Añadimos sonido
        GameObject newSound = Instantiate(FxAudios[0], transform.position, Quaternion.identity);
        Destroy(newSound, 2);

        SceneManager.LoadScene(nextScene);
        
    }

    public void ExitGame()
    {
        Application.Quit();
        
    }
}
