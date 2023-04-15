using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarAprerance : MonoBehaviour
{
    public string playerName;
    public Color carColor;
    public Text nameText;
    public Renderer carRenderer;
    public int playerNumber;
    public Camera backCamera;

    int carRego;
    bool regoSet = false;
    public CheckPointController checkPoint;

    // Start is called before the first frame update
    void Start()
    {
        // if(playerNumber == 0)
        // {
        //     playerName = PlayerPrefs.GetString("PlayerName");
        //     carColor = ColorCar.IntToColor(PlayerPrefs.GetInt("Red"),

        //     PlayerPrefs.GetInt("Green"), PlayerPrefs.GetInt("Blue"));
        // }
        // else
        // {
        //     playerName = "Random " + playerNumber;
        //     carColor = new Color(Random.Range(0f,255f) / 255, Random.Range(0f, 255f) / 255,

        //     Random.Range(0f, 255f) / 255);
        // }
        
        // nameText.text = playerName;
        // carRenderer.material.color = carColor;
        // nameText.color = carColor;
    }

    void LateUpdate()
    {
        if (!regoSet)
        {
            carRego = Leaderboard.RegisterCar(playerName);
            regoSet = true;
            return;
        }

        Leaderboard.SetPosition(carRego, checkPoint.lap, checkPoint.checkPoint);
    }

    public void SetNameAndColor(string name, Color color)
    {
        playerName = name;
        nameText.text = name;
        carRenderer.material.color = color;
        nameText.color = color;
        Debug.Log(playerName);
        Debug.Log(nameText.text);

    }

    public void SetLocalPlayer()
    {
        FindObjectOfType<CamerController>().SetCameraProperties(this.gameObject);
        playerName = PlayerPrefs.GetString("PlayerName");
        Debug.Log("TEST!");
        Debug.Log(playerName);
        carColor = ColorCar.IntToColor(PlayerPrefs.GetInt("Red"), PlayerPrefs.GetInt("Green"), PlayerPrefs.GetInt("Blue"));
        nameText.text = playerName;
        carRenderer.material.color = carColor;
        nameText.color = carColor;
        RenderTexture rt = new RenderTexture(1024, 1024, 0);
        backCamera.targetTexture = rt;
        FindObjectOfType<RaceController>().SetMirror(backCamera);
    }
}
