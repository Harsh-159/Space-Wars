using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] int health=40;
    LevelSetter currentlevel;
    private void Start()
    {
        if (gameObject.tag == "Player")
        {
            currentlevel = FindObjectOfType<LevelSetter>();
        }
    }
    public int getHealth()
    {
        return health;
    }
    public void doDamage(int damage)
    {
        health -= damage;
        if (gameObject.tag == "Player")
        {
            currentlevel.ChangeHealth();
        }
        else if ((gameObject.tag=="Enemy")&&(SceneManager.GetActiveScene().name=="Endless Mode"))
        {
            FindObjectOfType<KillCounter>().chageCount();
        }
    }
    public void revertHealth()
    {
        health = 40;
    }
    public void ResetSetter()
    {
        currentlevel = FindObjectOfType<LevelSetter>();
    }
}
