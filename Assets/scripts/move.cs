using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float velocidade = 10.0f;
    public float velocidade2 = 15.0f;

    public float rotationSpeed = 300.0f;
    public float jumpForce = 5.0f;
    private bool podePular = true;
    private bool aguardandoPulo = false;
    private float delay = 0.5f;
    private float timer = 0.0f;
    private Rigidbody rb;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * velocidade);
            anim.SetBool("avancar", true);
            if (Input.GetKey(KeyCode.Space) && podePular && !aguardandoPulo)
            {
                anim.SetBool("pularAndando", true);
                aguardandoPulo = true;
                velocidade = 5.0f;
                timer = 0.0f;
            }
        }
        else
        {
            anim.SetBool("avancar", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * velocidade);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * velocidade2);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * velocidade2);
        }

        if (Input.GetKeyDown(KeyCode.Space) && podePular && !aguardandoPulo)
        {
            anim.SetBool("pular", true);
            aguardandoPulo = true;
            velocidade = 5.0f;
            timer = 0.0f;
        }

        if (aguardandoPulo)
        {
            timer += Time.deltaTime;

            if (timer >= delay)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                podePular = false;
                aguardandoPulo = false;
                Invoke(nameof(PermitirPularNovamente), 1f);
                velocidade = 10.0f;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool("pularAndando", false);
            anim.SetBool("pular", false);
        }
        if (Input.GetMouseButton(1))
        {
            anim.SetBool("mirar", true);

            if (Input.GetMouseButton(0))
            {
                anim.SetBool("atirar", true);
            }
             if (Input.GetMouseButtonUp(0))
            {
                anim.SetBool("atirar", false);
            }
        }
        if (Input.GetMouseButtonUp(1))
        {
            anim.SetBool("mirar", false);
        }
    }

    private void PermitirPularNovamente()
    {
        podePular = true;
    }
}
