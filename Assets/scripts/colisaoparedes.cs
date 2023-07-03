using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colisaoparedes : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public int distacia = 1300;
    public float m_Thrust = 20f;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("paredes"))
        {
            /*rb.AddForce(Vector3.back * distacia);
            rb.AddForce(Vector3.left * distacia);
            rb.AddForce(Vector3.forward * distacia);*/
            m_Rigidbody.AddForce(Vector3.back * m_Thrust);

        }
    }
}
