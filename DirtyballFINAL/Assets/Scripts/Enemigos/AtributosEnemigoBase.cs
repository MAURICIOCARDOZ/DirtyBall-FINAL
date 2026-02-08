using System;
using UnityEngine;

public class AtributosEnemigoBase : MonoBehaviour
{
    public int VidaActual = 100;
    public int VidaMaxima = 100; // Es útil tener un máximo
    public int Salto = 5;
    public int daño = 1;
    public float cooldown = 1f;

    public Animator animator;
    public GameObject[] armas;
    
    //public Vector3 PosicionLocalArma = new Vector3(0.5f, 1.0f, 0.2f);

    [Tooltip("El Empty/Socket en la mano donde se adjuntarán las armas.")]
    public Transform HandSocket;
    public Vector3 RotacionLocalArma = new Vector3(0f, 0f, 0f);
    public Vector3 EscalaLocalArma = new Vector3(0.01f, 0.01f, 0.01f);


    //Tomar la clase de Barra de vida
    void Start()
    {
        VidaActual = VidaMaxima;


        //Setear el indice del arma
        if (armas == null || armas.Length == 0)
        {
            Debug.LogWarning(gameObject.name + ": La lista de armas está vacía.");
            return;
        }
        else
        {
            int indiceAleatorio = UnityEngine.Random.Range(0, armas.Length);
            setearArma(indiceAleatorio);
        }

    }
    public void RecibirDanoEnemigo(int dano)
    {
        VidaActual -= dano;
        // Limita la vida para que no baje de 0
        VidaActual = Mathf.Max(VidaActual, 0);

        Debug.Log(gameObject.name + " recibió " + dano + ". Vida restante: " + VidaActual);

        if (VidaActual <= 0)
        {
            Morir_enemigo();
        }
    }

    public void Morir_enemigo()
    {
        Debug.Log(gameObject.name + " ha muerto.");
        // Destruye el objeto al que está adjunto este script
        Destroy(gameObject);

    }

    public void setearArma(int indiceArma)
    {
        GameObject armaPrefab = armas[indiceArma];


        armaPrefab.SetActive(true);
    }

    public void Atacar(GameObject player)
    {
       player.GetComponent<AtributosPersonaje>().RecibirDano(daño);

    }
}