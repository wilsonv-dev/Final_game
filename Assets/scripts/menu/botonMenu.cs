// BotonMenu.cs
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class BotonMenu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public TMP_Text texto;

    private Color colorNormal = new Color(0.91f, 0.85f, 0.69f, 1f);
    private Color colorHover  = new Color(1f, 1f, 1f, 1f);

    private Vector3 escalaOriginal;
    private string textoOriginal;

    void Start()
    {
        escalaOriginal = transform.localScale;
        textoOriginal = texto.text;
        if (texto != null) texto.color = colorNormal;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (texto != null)
        {
            texto.color = colorHover;
            texto.text = "<color=#C0892A>|</color>  " + textoOriginal;
        }
        transform.localScale = escalaOriginal * 1.05f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (texto != null)
        {
            texto.color = colorNormal;
            texto.text = textoOriginal;
        }
        transform.localScale = escalaOriginal;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (texto != null)
            texto.color = colorHover;
    }
}