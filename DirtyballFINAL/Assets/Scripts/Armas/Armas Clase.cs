using UnityEngine;

public class ArmasClase : MonoBehaviour
{
    public int rango = 1;
    public int daño = 1;
    public float cooldown = 1f;

    private Collider colliderArma;


    private void Start()
    {
        colliderArma = GetComponent<Collider>();
        if (colliderArma == null)
        {
            Debug.LogWarning(gameObject.name + ": No se encontró un Collider en el arma.");
        }
        else
        {
            colliderArma.isTrigger = true; // Asegura que el collider sea un trigger
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("COLISION CON BOTELLA");
    }
}

