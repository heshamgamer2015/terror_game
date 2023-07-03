using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float velocidade = 20.0f;
    public float rotationSpeed = 300.0f;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * velocidade);
            anim.SetBool("avancar", true);
        }
         if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetBool("avancar", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * velocidade);
            //anim.SetBool("voltar", true);
        }
         if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
        }
         if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * -rotationSpeed);
        }

        
    }
}
