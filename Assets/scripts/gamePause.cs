using UnityEngine;

public class gamePause : MonoBehaviour
{

    public GameObject menuPausa;
    public bool juegoPausado = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
        if (juegoPausado)
        {
            reanudar();
        }
        else
        {
            pausar();
        }
        }
    }

    public void reanudar()
    {
        menuPausa.SetActive(false);
        Time.timeScale=1;
        juegoPausado = false;
    }
    
    public void pausar()
    {
       menuPausa.SetActive(true);
        Time.timeScale= 0;
        juegoPausado = true; 
    }

}
