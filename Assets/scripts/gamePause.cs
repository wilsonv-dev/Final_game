using UnityEngine;
using UnityEngine.SceneManagement;

public class gamePause : MonoBehaviour
{
    public GameObject menuPausa;
    public bool juegoPausado = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
                reanudar();
            else
                pausar();
        }
    }

    public void reanudar()
    {
        menuPausa.SetActive(false);
        Time.timeScale = 1;
        juegoPausado = false;
    }

    public void pausar()
    {
        menuPausa.SetActive(true);
        Time.timeScale = 0;
        juegoPausado = true;
    }

    public void reiniciarNivel()
    {
        Time.timeScale = 1; // importante, si no el nivel queda congelado
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void irAlMenu()
    {
        Time.timeScale = 1; // importante, mismo motivo
        SceneManager.LoadScene("menu");
    }
}