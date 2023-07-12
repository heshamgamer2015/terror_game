using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]

public class inimigo : MonoBehaviour
{
    private Animator anim;
    public float velocidadeInimigo = 8f;
    private NavMeshAgent navMesh;
    public GameObject[] jogadores;
    public int indexPlayerProximo = 0;
    public float distanciaPlayer = 2.0f;
    public float dano = 100f;
    public GunAmmo gunAmmo;
    private GameObject player;

    void Start()
    {
        anim = GetComponent<Animator>();
        navMesh = GetComponent<NavMeshAgent>();
        gunAmmo = GameObject.FindObjectOfType<GunAmmo>();
        player = GameObject.FindWithTag("Player"); // Atribuição do objeto Player ao campo player
        navMesh.speed = velocidadeInimigo;
    }

    void Update()
    {
        navMesh.destination = player.transform.position;

        if (Vector3.Distance(transform.position, player.transform.position) < 3)
        {
            navMesh.speed = 0;
            anim.SetBool("atack", true);
            StartCoroutine("ataque");
        }else
        {
            anim.SetBool("atack", false);
        }
    }
    IEnumerator ataque()
        {
            yield return new WaitForSeconds(0.2f);
            anim.SetBool("atack", false);
            yield return new WaitForSeconds(2.8f);
            navMesh.speed = velocidadeInimigo;
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

    public void Damage(float amount)
    {
        dano -= amount; // Diminui o valor do dano pelo valor recebido como parâmetro

        if (dano <= 0)
        {
            gunAmmo.kill++;
            Destroy(gameObject);
        }
    }
}
