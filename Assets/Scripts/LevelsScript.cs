using UnityEngine;


public class LevelsScript : MonoBehaviour {

    public GameObject Panel;

    public void lvl1()
    {
        Application.LoadLevel(3);
    }

    public void lvl2()
    {
        Application.LoadLevel(4);
    }

    public void lvl3()
    {
        Application.LoadLevel(5);
    }

    public void lvl4()
    {
        Application.LoadLevel(6);
    }

    public void lvl5()
    {
        Application.LoadLevel(7);
    }

    public void Tutorial()
    {
        Application.LoadLevel(2);
    }

    public void MainMenu()
    {
        Application.LoadLevel(0);
    }

}
