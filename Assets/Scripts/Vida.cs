using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour
{
	[SerializeField]
	float maxHealth = 100.0f;
	float currentHealth;
	public Image BarraVida; // Referencia a la barra de vida (UI)
	
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
		if (BarraVida != null)
            BarraVida.fillAmount = 1f; // Barra llena al inicio
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void DoDamage(float amount){ 
	
		currentHealth -= amount;
		currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

		// Actualizar la barra de vida
        if (BarraVida != null)
            BarraVida.fillAmount = currentHealth / maxHealth;

		if(currentHealth == 0){
			Destroy(gameObject);
		}
	}
}
