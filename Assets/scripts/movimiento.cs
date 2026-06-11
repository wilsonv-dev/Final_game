// movimiento.cs
using UnityEngine;
using System.Collections;

public class movimiento : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 8f;
    public float fuerzaRebote = 8f;
    public float longitudRayCast = 0.1f;
    public int vida;
    public bool muerto;
    private bool enSuelo;
    private bool recibiendoDanio;
    private bool atacando;
    private Rigidbody2D rb;
    public Animator animator;
    public LayerMask capaSuelo;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!muerto)
        {
            if (!atacando)
            {
                move();

                RaycastHit2D hit = Physics2D.Raycast(
                    transform.position,
                    Vector2.down,
                    longitudRayCast,
                    capaSuelo
                );
                enSuelo = hit.collider != null;

                if (enSuelo && Input.GetKeyDown(KeyCode.Space) && !recibiendoDanio)
                    rb.AddForce(new Vector2(0f, fuerzaSalto), ForceMode2D.Impulse);
            }
        }

        if (Input.GetKeyDown(KeyCode.Z) && !atacando && enSuelo)
            Atacando();

        animaciones();
    }

    public void animaciones()
    {
        animator.SetBool("enSuelo", enSuelo);
        animator.SetBool("recibeDano", recibiendoDanio);
        animator.SetBool("atacando", atacando);
        animator.SetBool("muerto", muerto);
    }

    public void move()
    {
        float velocidadX = Input.GetAxis("Horizontal") * Time.deltaTime * velocidad;

        if (!recibiendoDanio)
        {
            animator.SetFloat("movement", velocidad * velocidadX);

            if (velocidadX < 0)
                transform.localScale = new Vector3(-1, 1, 1);
            if (velocidadX > 0)
                transform.localScale = new Vector3(1, 1, 1);

            Vector3 posicion = transform.position;
            transform.position = new Vector3(velocidadX + posicion.x, posicion.y, posicion.z);
        }
        else
        {
            animator.SetFloat("movement", 0);
        }
    }

    public void RecibeDanio(Vector2 direccion, int catDanio)
    {
        if (!recibiendoDanio)
        {
            StartCoroutine(RutinaRecibeDanio(direccion));
            vida -= catDanio;
            if (vida <= 0)
                muerto = true;
        }
    }

    public bool EstaRecibiendoDanio()
    {
        return recibiendoDanio;
    }

    private IEnumerator RutinaRecibeDanio(Vector2 direccion)
    {
        recibiendoDanio = true;

        Vector2 rebote = new Vector2(-direccion.x * 1.5f, 1.5f).normalized;
        rb.AddForce(rebote * fuerzaRebote, ForceMode2D.Impulse);

        // Espera 3 frames para que el Animator cambie al estado de daño
        yield return null;
        yield return null;
        yield return null;

        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        yield return new WaitForSeconds(stateInfo.length);

        recibiendoDanio = false;
    }

    public void DesactivaDanio()
    {
        recibiendoDanio = false;
    }

    public void Atacando()
    {
        atacando = true;
    }

    public void DesactivaAtaque()
    {
        atacando = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * longitudRayCast);
    }
}