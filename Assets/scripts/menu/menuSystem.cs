using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menuSystem : MonoBehaviour
{
    public void jugar()
    {
         SceneManager.LoadScene("niveles");
    }

    public void salir()
    {
        Debug.Log("Saliendo del juego....");
        Application.Quit();
    }
}
