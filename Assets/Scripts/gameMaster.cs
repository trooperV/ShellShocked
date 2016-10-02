using UnityEngine;
using UnityEngine.UI;

public class gameMaster : MonoBehaviour {

    public int points;

    public Text pointsText;
    public Text inputText;

    void Start()
    {
        if(PlayerPrefs.HasKey("Points"))
        {
            if(Application.loadedLevel == 3 || Application.loadedLevel == 2)
            {
                PlayerPrefs.DeleteKey("Points");
                points = 0;
            }else
            {
                points = PlayerPrefs.GetInt("Points");
            }
        }
    }

    void Update()
    {
        pointsText.text = ("Points:" + points);
    }
}
