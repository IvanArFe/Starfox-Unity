using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Vida : MonoBehaviour
{
    [SerializeField]
    float maxHealth = 100.0f; // Salud máxima
    public float currentHealth;      // Salud actual

    [SerializeField]
    int totalLives = 3;       // Número total de vidas
    int currentLives;         // Vidas actuales

    public Image BarraVida;   // Referencia a la barra de vida (UI)
    public Image VidasImage;  // Referencia a la imagen de vidas en el HUD

    // Imágenes para cada estado de vidas
    public Sprite Vidas3Sprite;
    public Sprite Vidas2Sprite;
    public Sprite Vidas1Sprite;

    public Kills kills;

    void Start()
    {
        currentHealth = maxHealth;
        currentLives = totalLives;

        // Inicializar el HUD
        if (BarraVida != null)
            BarraVida.fillAmount = 1f; // Barra llena al inicio

        UpdateHUD();
    }

    public void DoDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        // Actualizar la barra de vida
        if (BarraVida != null)
            BarraVida.fillAmount = currentHealth / maxHealth;

        if (currentHealth == 0)
        {
            LoseLife();
        }
    }

    public void AddHealth(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        // Actualizar la barra de vida
        if (BarraVida != null)
            BarraVida.fillAmount = currentHealth / maxHealth;

        Debug.Log("Vida: " + currentHealth);
    }

    void LoseLife()
    {
        currentLives--;

        if (currentLives > 0)
        {
            // Resetear la salud si aún hay vidas
            currentHealth = maxHealth;
            if (BarraVida != null)
                BarraVida.fillAmount = 1f; // Restaurar barra de vida
        }
        else
        {
            // Si este objeto es el jugador, activamos el Game Over
            if (gameObject.CompareTag("Player"))
            {
                GameOver();
            }
            else
            {
                // Si es el enemigo, simplemente lo destruimos
                Destroy(gameObject);
            }
        }

        UpdateHUD();
    }

    void UpdateHUD()
    {
        // Cambiar la imagen según las vidas restantes
        if (VidasImage != null)
        {
            if (currentLives == 3)
                VidasImage.sprite = Vidas3Sprite;
            else if (currentLives == 2)
                VidasImage.sprite = Vidas2Sprite;
            else if (currentLives == 1)
                VidasImage.sprite = Vidas1Sprite;
            else
                VidasImage.enabled = false; // Ocultar la imagen si no hay vidas
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over!");
        SceneManager.LoadScene("gameOver");
    }
}
