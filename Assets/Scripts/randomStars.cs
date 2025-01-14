using UnityEngine;
using System.Collections;

//Codigo de https://www.youtube.com/watch?v=aPMBoqcRSyY

public class randomStars : MonoBehaviour
{
    public GameObject stars;
    private Vector3 randomVector;

    [SerializeField] 
    public int range_bottom_y = 100;
    public int range_bottom_x = -200;
    public int range_top_x = 100;
    public int range_top_y = 200;

    public void Update(){
        randomVector = new Vector3(Random.Range(range_bottom_x,range_top_x),Random.Range(range_bottom_y,range_top_y), 35);
        Instantiate(stars, randomVector, transform.rotation);

    }


}
