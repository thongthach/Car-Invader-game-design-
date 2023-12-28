using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetection : MonoBehaviour
{
    [SerializeField]   float loadDelay = 2.0f;
    [SerializeField] ParticleSystem explosion;

    // Start is called before the first frame update

    //  void OnCollisionEnter(Collision other)
    //{
    //     Debug.Log(this.name + "bumped into" + other.gameObject.name);   
    //}


    void OnTriggerEnter(Collider other)
    {

        StartCrash();
        Explosion();


    }
    
     void OnParticleCollision(GameObject other)
    {
        GetComponent<BoxCollider>().enabled = false;
        StartCrash();
        Explosion();
        Destroy(gameObject);
        Debug.Log("hit");
       
    }

    void Explosion()
    {
        explosion.Play();


    }
    void StartCrash()
    {
        GetComponent<BoxCollider>().enabled = false;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Player>().enabled = false;
        
        Invoke("ReloadLevel", loadDelay);
        



    }
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);


    }
    // Update is called once per frame
   
}
