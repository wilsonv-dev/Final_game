using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public int numeroDeEsteNivel; // pon 1, 2, 3 o 4 según el nivel en el Inspector

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Guarda el progreso antes de cambiar de escena
            int nivelesDesbloqueados = PlayerPrefs.GetInt("NivelesDesbloqueados", 1);

            if (numeroDeEsteNivel + 1 > nivelesDesbloqueados)
            {
                PlayerPrefs.SetInt("NivelesDesbloqueados", numeroDeEsteNivel + 1);
                PlayerPrefs.Save();
            }

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}