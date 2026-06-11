using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class nivelSelector : MonoBehaviour
{

    public GameObject nivelButtonPrefab;
    public Transform buttonContainer;
    public int totalLevels = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        generateLevelButtons();
    }
    public void generateLevelButtons()
    {
        for(int i = 1; i<= totalLevels; i++)
        {
            GameObject buttonObj = Instantiate(nivelButtonPrefab, buttonContainer);
            buttonObj.GetComponentInChildren<TextMeshProUGUI>().text = "Nivel " + 1;

            int levelIndex = i;
            buttonObj.GetComponent<Button>().onClick.AddListener(() => 
            { 
                SceneManager.LoadScene("Nivel_" + levelIndex);
            });
        }
    }
  
}
