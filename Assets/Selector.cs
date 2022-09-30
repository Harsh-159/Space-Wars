using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Selector : MonoBehaviour
{
    [SerializeField] bool locked = true;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = gameObject.GetComponent<Button>(); //Grabs the button component
        btn.onClick.AddListener(TaskOnClick); //Adds a listner on the button
    }

    // Update is called once per frame
    void TaskOnClick()
    {
        int curlen = gameObject.name.Length;
        string number = gameObject.name.Substring(8, curlen - 9);
        int intnumber = Int16.Parse(number);
        if (PlayerPrefs.GetString("Locker").Contains(number))
        {
            locked = false;
        }
        
        if (locked == false)
        {
            
            SceneManager.LoadScene(intnumber + 3);
        }
        
    }
}
