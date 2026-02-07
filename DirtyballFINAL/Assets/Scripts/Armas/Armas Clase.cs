using UnityEngine;
using UnityEngine.Rendering;

public class ArmasClase : MonoBehaviour
{

    private Collider colliderArma;
    public AtributosEnemigoBase scriptEnemigo;


    private void Start()
    {
        colliderArma = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("COLISION CON BOTELLA");
        if (other.CompareTag("Player")) {
           scriptEnemigo.Atacar(other.gameObject);
        }
    }
}

