using UnityEngine;

public class Kills : MonoBehaviour
{
    private int kills = 0;



    public void killed()
    { 
        Debug.Log("number of kills");
        Debug.Log(kills);
        kills++;
    }

    public int getKills()
    {
        Debug.Log("get kills");
        Debug.Log(kills);
        return kills;
    }
}
