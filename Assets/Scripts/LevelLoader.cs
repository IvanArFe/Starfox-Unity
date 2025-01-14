using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class LevelLoader : MonoBehaviour
{

    public Animator transition;
    public Kills kills;

    void Start() {
        kills.initialize();   
    }

    // Update is called once per frame
    void Update()
    {
        
        if (kills.getKills() == 10 || kills.getKills() == 20)
        {
            kills.killed();
            LoadNextLevel();
        } 
        else if (kills.getKills() < -15)
        {
            LoadEnd();
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadEnd()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(levelIndex);
    }
}