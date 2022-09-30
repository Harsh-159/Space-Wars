using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelSetter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthMeasure=null;
    [SerializeField] TextMeshProUGUI shieldCount = null;
    private GameObject player;
    // Start is called before the first frame update
    void Awake()
    {
        PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex);
        Debug.Log(PlayerPrefs.GetString("Locker"));
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Health>().ResetSetter();
        healthMeasure.text = (player.GetComponent<Health>().getHealth() / 10).ToString();
        shieldCount.text = (player.GetComponent<PlayerControl>().ShieldCount.ToString());
    }
    public void ChangeHealth()
    {
        healthMeasure.text = (player.GetComponent<Health>().getHealth() / 10).ToString();
    }
    public void ChangeShield()
    {
        shieldCount.text = (player.GetComponent<PlayerControl>().ShieldCount.ToString());
    }

}
