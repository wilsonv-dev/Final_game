using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform objetivo;
    public float VelocidadCamara = 0.025f;
    public Vector3 desplazamiento;

    private void LateUpdate()
    {
        Vector3 posicionDeseada = objetivo.position + desplazamiento;
        Vector3 posicionSuavizada = Vector3.Lerp(transform.position, posicionDeseada, VelocidadCamara);
        transform.position = posicionSuavizada;
    }
}
