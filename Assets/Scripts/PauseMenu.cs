using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseUI;

    public bool paused = false;
	
    void Start()
    {
        pauseUI.SetActive(false);
    }

    void Update()
    {
        if(Input.GetButtonDown("Pause"))
        {
            paused = !paused;
        }

        if(paused)
        {
            pauseUI.SetActive(true);
            Time.timeScale = 0;
        }

        if(!paused)
        {
            pauseUI.SetActive(false);
            Time.timeScale = 1;
        }
    }
	
    public void Resume()
    {
        paused = false;
    }

    public void Restart()
    {
        //Application.LoadLevel(Application.loadedLevel);
        SceneManager.LoadScene(Application.loadedLevel);
    }

    public void MainMenu()
    {
        //Application.LoadLevel(0);
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
