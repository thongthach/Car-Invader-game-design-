using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Laser : MonoBehaviour
{
    [SerializeField] InputAction movement ;
    [SerializeField] float forward_shoot ;
    [SerializeField] float shoot ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        forward_shoot = movement.ReadValue<Vector2>().y;
        shoot = transform.localPosition.y + forward_shoot ;
        transform.localPosition = new Vector3(transform.localPosition.x, shoot, transform.localPosition.z);

    }
}
