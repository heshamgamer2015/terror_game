using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class inimigo : MonoBehaviour
{
    
    private Animator anim;
    private NavMeshAgent navMesh;
    public GameObject[] jogadores;
    public int indexPlayerProximo = 0;
    public float distanciaPlayer = 2.0f;

    void Start()
    {
        anim = GetComponent<Animator>();
        navMesh = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        jogadores = GameObject.FindGameObjectsWithTag("Player");
        ChecarJogadorMaisProximo();
        navMesh.destination = jogadores[indexPlayerProximo].transform.position;
        if (Vector3.Distance(transform.position, jogadores[indexPlayerProximo].transform.position) <= distanciaPlayer)
        {
            anim.SetBool("atack", true);
        }
    }

    void ChecarJogadorMaisProximo()
    {
        float distanciaMax = Mathf.Infinity;
        for (int x = 0; x < jogadores.Length; x++)
        {
            float distanciaVeiculoAtual = Vector3.Distance(transform.position, jogadores[x].transform.position);
            if (distanciaVeiculoAtual < distanciaMax)
            {
                distanciaMax = distanciaVeiculoAtual;
                indexPlayerProximo = x;
            }
        }
    }
}
