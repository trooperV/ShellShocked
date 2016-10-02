using UnityEngine;

public class MainMenu : MonoBehaviour {

    public GameObject Panel;

    public void Play()
    {
        Application.LoadLevel(3);
    }

    public void Tutorial()
    {
        Application.LoadLevel(2);
    }

    public void Levels()
    {
        Application.LoadLevel(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
