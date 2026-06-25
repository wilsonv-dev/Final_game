using UnityEngine;

public class LevelCompleter : MonoBehaviour
{
    public int numeroDeEsteNivel; // pon 1, 2, 3, etc. según el nivel en el Inspector

    public void CompletarNivel()
    {
        int nivelesDesbloqueados = PlayerPrefs.GetInt("NivelesDesbloqueados", 1);

        // Si completaste el nivel 2, desbloqueas hasta el 3
        if (numeroDeEsteNivel + 1 > nivelesDesbloqueados)
        {
            PlayerPrefs.SetInt("NivelesDesbloqueados", numeroDeEsteNivel + 1);
            PlayerPrefs.Save();
        }
    }
}