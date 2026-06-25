using UnityEngine;

public class ZonaMuerte : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            movimiento playerScript = collision.GetComponent<movimiento>();
            if (playerScript != null)
            {
                playerScript.MorirInstantaneo();
            }
        }
    }
}