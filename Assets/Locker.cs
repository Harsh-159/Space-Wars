using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetString("Locker") == "")
        {
            PlayerPrefs.SetString("Locker", "0");
        }
    }
}
