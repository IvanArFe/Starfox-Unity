using UnityEngine;

public class Kills : MonoBehaviour
{
    private int kills = 0;



    public void killed()
    {
        kills++;
    }

    public int getKills()
    {
        return kills;
    }
}
