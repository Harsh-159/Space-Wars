using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("Player Char")]
    [SerializeField] float xMov = 8f;
    [SerializeField] float yMov = 8f;
    private int shieldTime=2;

    [Header("Other prop")]
    [SerializeField] float bulletVelocity = 20f;
    [SerializeField] float offset = 0.5f;
    [SerializeField] GameObject laser=null;
    [SerializeField] float projectileFiringPeriod = 0.5f;
    [SerializeField] GameObject shield=null;
    Coroutine firingCorouting=null;
    public int ShieldCount = 3;
    public bool controlAllowed = true;
    LevelSetter currentLevel;
    private void Start()
    {
        currentLevel = FindObjectOfType<LevelSetter>();
    }

    // Update is called once per frame
    void Update()
    {
        float xPos = transform.position.x + xMov*Input.GetAxis("Horizontal")*Time.deltaTime*PlayerPrefs.GetFloat("difficulty");
        float yPos = transform.position.y + yMov * Input.GetAxis("Vertical")*Time.deltaTime * PlayerPrefs.GetFloat("difficulty");
        xPos = Mathf.Clamp(xPos,Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x+offset,Camera.main.ViewportToWorldPoint(new Vector3(1,0,0)).x-offset);
        yPos = Mathf.Clamp(yPos, Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y+offset, Camera.main.ViewportToWorldPoint(new Vector3(0, 0.3f, 0)).y);
        transform.position = new Vector2(xPos, yPos);
    
        if (Input.GetKeyDown(KeyCode.Space))
        {
            firingCorouting=StartCoroutine(FireContinuously());
        }
        if (Input.GetKeyUp(KeyCode.Space)||(!controlAllowed))
        {
            if (firingCorouting != null)
            {
                StopCoroutine(firingCorouting);
            }
            
        }
        if (Input.GetKeyDown(KeyCode.S) && ShieldCount>0)
        {
            ShieldCount--;
            currentLevel.ChangeShield();
            GameObject myShield = Instantiate(shield, gameObject.transform.position, Quaternion.identity) as GameObject;
            myShield.transform.parent = gameObject.transform;
            Destroy(myShield, shieldTime);
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject curBullet = Instantiate(laser, transform.position, Quaternion.identity) as GameObject;
            curBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletVelocity);
            yield return new WaitForSeconds(projectileFiringPeriod/PlayerPrefs.GetFloat("difficulty"));
        }
        
    }
}
