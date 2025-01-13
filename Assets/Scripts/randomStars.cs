using UnityEngine;
using System.Collections;

//Codigo de https://www.youtube.com/watch?v=aPMBoqcRSyY

public class randomStars : MonoBehaviour
{
    public GameObject stars;
    private Vector3 randomVector;

    public void Update(){
        randomVector = new Vector3(Random.Range(-100,100),Random.Range(-15,-3), 35);
        Instantiate(stars, randomVector, transform.rotation);

    }


}
