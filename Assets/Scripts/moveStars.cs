using UnityEngine;
using System.Collections;
//video de https://www.youtube.com/watch?v=aPMBoqcRSyY
public class moveStars : MonoBehaviour
{
    private float zMovement;
    private float timeDestroy = 0.0f;

    public void Start(){
        zMovement = Random.Range(-5,-20) * Time.deltaTime;
    }

    public void Update(){
       gameObject.transform.Translate(0,0,zMovement);
        timeDestroy += Time.deltaTime;
        if(timeDestroy > 5) {
            Destroy(this.gameObject);
        }
    }

}
