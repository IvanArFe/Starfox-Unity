using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class LevelLoader : MonoBehaviour
{
    
    public Animator transition;

    // Update is called once per frame
    void Update()
    {
        if (false)
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
