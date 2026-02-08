using UnityEngine;

public class MenuPausa : MonoBehaviour
{
    [Header("Configuración de Interfaz")]
    public GameObject objetoMenuPausa; // Arrastra aquí tu Canvas de Pausa
    private bool juegoPausado = false;

    void Update()
    {
        // Detecta la tecla Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                Reanudar();
            }
            else
            {
                Pausar();
            }
        }
    }

    public void Reanudar()
    {
        objetoMenuPausa.SetActive(false); // Esconde el menú
        Time.timeScale = 1f;              // El tiempo vuelve a la normalidad
        juegoPausado = false;
        
        // Bloquea el cursor de nuevo para el juego
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Pausar()
    {
        objetoMenuPausa.SetActive(true);  // Muestra el menú
        Time.timeScale = 0f;               // CONGELA el tiempo
        juegoPausado = true;

        // Libera el cursor para poder hacer clic en los botones
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Método para el botón de "Salir" del menú
    public void SalirAlMenuPrincipal()
    {
        Time.timeScale = 1f; // ¡IMPORTANTE! Siempre restaura el tiempo antes de cambiar de escena
        UnityEngine.SceneManagement.SceneManager.LoadScene("NombreDeTuMenuPrincipal");
    }
}