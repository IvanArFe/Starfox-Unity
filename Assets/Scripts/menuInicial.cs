using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Para trabajar con botones

public class menuInicial : MonoBehaviour
{
    public Button jugarButton; // Referencia al botón Jugar
    public Button sortirButton; // Referencia al botón Sortir
    public LevelLoader levelLoader;

    void Update()
    {
        // Si se presiona la tecla Espacio, activa el botón Jugar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.LogError("Tecla Espacio presionada");
            Jugar();
        }

        // Si se presiona la tecla Escape, activa el botón Sortir
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.LogError("Tecla Escape presionada");
            Sortir();
        }
    }

    public void Jugar()
    {
        Debug.LogError("Botón Jugar activado");
        levelLoader.LoadNextLevel();
    }

    public void Sortir()
    {
        Debug.Log("Botón Sortir activado");
        Application.Quit();
    }
}