using UnityEngine;

public class MenuPrincipal : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject menuPrincipal;
    public GameObject seleccionNivel;


    public void cambiarAseleccionNivel()
    {
        menuPrincipal.SetActive(false);
        seleccionNivel.SetActive(true);
    }

    public void volverAlMenuPrincipal()
    {
        seleccionNivel.SetActive(false);
        menuPrincipal.SetActive(true);
    }
    public void salirDelJuego()
    {
        Application.Quit();
    }
}
