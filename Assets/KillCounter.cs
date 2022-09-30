using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI kills=null;
    private int killsnum = 0;
    private void Awake()
    {
        try
        {
            PlayerPrefs.GetInt("HighScore");
        }
        catch
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }
    }
    private void Start()
    {
        kills.text = killsnum.ToString() + "/" + PlayerPrefs.GetInt("HighScore").ToString();
    }
    public void chageCount()
    {
        killsnum += 1;
        if (killsnum > PlayerPrefs.GetInt("HighScore")){
            PlayerPrefs.SetInt("HighScore", killsnum);
        }
        kills.text = killsnum.ToString() + "/" + PlayerPrefs.GetInt("HighScore").ToString();
    }
}
