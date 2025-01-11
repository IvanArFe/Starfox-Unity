using UnityEngine;
using System.Collections;

public class Pain : MonoBehaviour
{
    
    [SerializeField]
    float painAmount = 25.0f;
    
    private void OnTriggerEnter(Collider other)
    {
        Vida lc = other.gameObject.GetComponent<Vida>();
        if (lc != null)
        {
            lc.DoDamage(painAmount);
        }
        
    }
}
