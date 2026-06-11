using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    public Image rellenoBarraVida;
    private movimiento playerController;
    private float vidaMaxima;
    void Start()
    {
        playerController = GameObject.Find("player").GetComponent<movimiento>();
        vidaMaxima = playerController.vida;
    }

    // Update is called once per frame
    void Update()
    {
        rellenoBarraVida.fillAmount = playerController.vida / vidaMaxima;
    }
}
