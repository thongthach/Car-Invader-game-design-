using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    [SerializeField] GameObject score;
   // [SerializeField] Transform parent;
    [SerializeField] int ScorePerHit = 10;
    [SerializeField] int hitpoint = 1;
    Scoreboard scoreboard;
    /* [SerializeField] private float timer = 5;
     [SerializeField] float enemySpeed = 10.0f;
     private float bulletTime;
     public GameObject enemyBullet;
     // Start is called before the first frame update
    
    // [SerializeField] GameObject death;
    void ShootAtPlayer()
     {
         bulletTime -= Time.deltaTime;
         if (bulletTime > 0) return;
         bulletTime = timer;
         GameObject bulletObject = Instantiate(enemyBullet, transform.position, Quaternion.identity) as GameObject; 
         Rigidbody bulletrig = bulletObject.GetComponent<Rigidbody>();
         bulletrig.AddForce(bulletrig.transform.forward * enemySpeed);
         Destroy(bulletObject);

     }
    */

    void Start()
    {
        scoreboard = FindAnyObjectByType<Scoreboard>();     
    }
    void OnParticleCollision(GameObject other)
    {

        ProcessHit();
        if (hitpoint < 1)
        {
            HitPoint();
        }

      //  Instantiate(explosion,transform.position, Quaternion.identity);
        //Destroy(gameObject);
       
        
      
    }
    void HitPoint()
    {
        Instantiate( explosion, transform.position, Quaternion.identity);
       // hit.transform.parent = parent;

        Destroy(gameObject);

    }
     void ProcessHit()
    {
        hitpoint--;
        scoreboard.Score(ScorePerHit);
    }

    



}
