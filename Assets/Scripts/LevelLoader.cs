using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class LevelLoader : MonoBehaviour
{
    
    public Animator transition;
    public Kills kills;

    // Update is called once per frame
    void Update()
    {
        
        if (kills.getKills() == 20 || kills.getKills() == 50)
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        
        yield return new WaitForSeconds(1f);
        
        SceneManager.LoadScene(levelIndex);
    }
}
