using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


//Escoge que nivel va aparecer en el menu de seleccion de nivel, se le asigna a cada boton un numero que corresponde a la posicion del nivel en la lista, y se activa el nivel correspondiente al numero del boton
public class ElegirNivel: MonoBehaviour
{
    public List<GameObject> listaNiveles;
    private int nivelActual = 0;
    
    public void pasarSiguienteNivel()
    {
        listaNiveles[nivelActual].SetActive(false);
        nivelActual++;
        
        if (nivelActual >= listaNiveles.Count)
        {
            nivelActual = 0; // Reiniciar al primer nivel si se supera el último
        }

        listaNiveles[nivelActual].SetActive(true);
    }

    public void retrocederNivel()
    {
        listaNiveles[nivelActual].SetActive(false);
        nivelActual--;
        if (nivelActual < 0)
        {
            nivelActual = listaNiveles.Count - 1; // Ir al último nivel si se retrocede desde el primero
        }
        listaNiveles[nivelActual].SetActive(true);
    }

    public void cargarEscenaSeleccionada(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }
}
