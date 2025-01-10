using UnityEngine;

public class Vida : MonoBehaviour
{
	[SerializeField]
	float maxHealth = 100.0f;
	float currentHealth;
	
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void DoDamage(float amount){ 
	
		currentHealth -= amount;
		currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

		if(currentHealth == 0){
			Destroy(gameObject);
		}
	}
}
