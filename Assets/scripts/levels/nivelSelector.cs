using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class NivelData
{
    public int numeroNivel;
    public Vector2 posicionBoton;
}

public class nivelSelector : MonoBehaviour
{
    public GameObject nivelButtonPrefab;
    public Transform buttonContainer;
    public NivelData[] niveles;

    void Start()
    {
        generateLevelButtons();
    }

    public void generateLevelButtons()
    {
        int nivelesDesbloqueados = PlayerPrefs.GetInt("NivelesDesbloqueados", 1);

        foreach (NivelData nivel in niveles)
        {
            GameObject buttonObj = Instantiate(nivelButtonPrefab, buttonContainer);

            RectTransform rt = buttonObj.GetComponent<RectTransform>();
            rt.anchoredPosition = nivel.posicionBoton;

            buttonObj.GetComponentInChildren<TextMeshProUGUI>().text = "Nivel " + nivel.numeroNivel;

            bool desbloqueado = nivel.numeroNivel <= nivelesDesbloqueados;
            int levelIndex = nivel.numeroNivel;

            Button boton = buttonObj.GetComponent<Button>();

            if (desbloqueado)
            {
                boton.interactable = true;
                boton.onClick.AddListener(() =>
                {
                    SceneManager.LoadScene("nivel_" + levelIndex);
                });
            }
            else
            {
                boton.interactable = false;
            }
        }
    }
}