using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePoint : MonoBehaviour
{
    public Text pointsText;
    // Start is called before the first frame update
   public void SetUp(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() ;

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
