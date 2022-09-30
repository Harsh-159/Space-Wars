using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageDealer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int damage=10;
    private float deathTime = 1f;
    //private float delay = 2f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        collision.gameObject.GetComponent<Health>().doDamage(damage);
        if (collision.gameObject.GetComponent<Health>().getHealth() <= 0)
        {
            if (collision.gameObject.tag == "Player")
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().revertHealth();
                SceneManager.LoadScene("Lose");

            }
            else if(collision.gameObject.tag=="Enemy")
            {
                ParticleSystem myParticle = Instantiate(collision.gameObject.GetComponent<EnemyMove>().deathEffect);
                myParticle.transform.position = collision.gameObject.transform.position;
                Destroy(collision.gameObject);
                Destroy(myParticle, deathTime);
            }
            //Destroy(collision.gameObject);
        }
    }
}
