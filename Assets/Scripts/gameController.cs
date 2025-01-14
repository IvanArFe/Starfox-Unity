using UnityEngine;

public class GameController : MonoBehaviour
{
    public randomStars starSpawner; // Referencia al script de generación de estrellas
    private bool isGameRunning = true;

    private void Update()
    {
        // Ejemplo: termina la partida si el jugador presiona "Esc"
        if (isGameRunning && Input.GetKeyDown(KeyCode.Escape))
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        isGameRunning = false;

        // Detener la generación de estrellas
        starSpawner.StopSpawning();

        // Destruir todas las estrellas restantes
        moveStars[] stars = Object.FindObjectsByType<moveStars>(FindObjectsSortMode.None);
        foreach (moveStars star in stars)
        {
            star.DestroyStar();
        }

        Debug.Log("La partida ha terminado.");
    }
}