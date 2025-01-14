using UnityEngine;

public class Kills : MonoBehaviour
{
    [SerializeField]
    public int kills = 0;

    public void initialize()
    {
        kills = 0;
    }

    public void killed()
    { 
        
        kills++;
    }

    public int getKills()
    {
        
        return kills;
    }

    public void setKills()
    {
        kills = -50;
    }
}
