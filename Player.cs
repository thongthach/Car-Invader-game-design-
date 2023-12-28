using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;
//using UnityEngine.InputSystem;
//using System.Net.Sockets;
//using System.Text;
public class Player : MonoBehaviour
{
    [SerializeField] InputAction movement;

    [SerializeField] float speed = 1.0f;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 5f;
    [SerializeField] float positionPitch = -2.0f;
    [SerializeField] GameObject lasers;



    float horizontal_throw;
    float vertical_throw;
    float controlPitchFactor = -10f;
    float controlYawFactor = -50f;

   // public string esp32IpAddress = "192.168.1.100";
    //public int esp32Port = 12345;

    //private TcpClient client;
    //private NetworkStream stream;



    // Start is called before the first frame update
    private void OnEnable()
    {
        movement.Enable();
    }
    private void OnDisable()
    {
        movement.Disable();
    }

    void Start()
    {
        //client = new TcpClient(esp32IpAddress, esp32Port);
        //stream = client.GetStream();
    }
    void ProcessFiring()
    {


        if (Input.GetButton("Fire1"))
        {

            Debug.Log("Key is pressed");
            //SendCommand("1");
            ActiveLaser(true);



        }
        else
        {

            DisableLaser(false);
        }
       

    }
    void ActiveLaser(bool isActive)
    {



        lasers.SetActive(isActive);
        var emissionModule = lasers.GetComponent<ParticleSystem>().emission;
        emissionModule.enabled = isActive;
        if (isActive)
        {

            if (!emissionModule.enabled)
            {
                emissionModule.enabled = false;
            }
            else
            {
                emissionModule.enabled = true;
            }
        }

    }

    void DisableLaser(bool inActive)
    {


        lasers.SetActive(inActive);
        var emissionModule = lasers.GetComponent<ParticleSystem>().emission;
        emissionModule.enabled = inActive;




    }

    void ProcessRotation()
    {

        float pitch = transform.localPosition.x * positionPitch + vertical_throw * controlPitchFactor;
        float roll = transform.localRotation.z * positionPitch + horizontal_throw * controlYawFactor;
        float yawn = transform.localRotation.z;

        transform.localRotation = Quaternion.Euler(pitch, yawn, roll);




    }
    /*void SendCommand(string command)
    {
        byte[] data = Encoding.ASCII.GetBytes(command);
        stream.Write(data, 0, data.Length);
    }*/

    // Update is called once per frame
    void Update()
    {

        horizontal_throw = movement.ReadValue<Vector2>().x;
        vertical_throw = movement.ReadValue<Vector2>().y;
        float xOffset = horizontal_throw * Time.deltaTime * speed;
        float newxPos = transform.localPosition.x + xOffset;
        float clampedxPos = Mathf.Clamp(newxPos, -xRange, xRange); //range of the offset distance moving





        float yOffset = vertical_throw * Time.deltaTime * speed;
        float newyPos = transform.localPosition.y + yOffset;
        float clampedyPos = Mathf.Clamp(newyPos, -yRange, yRange);

        transform.localPosition = new Vector3(newxPos, newyPos, transform.localPosition.z);


        // OnEnable();


        //Debug.Log(horizontal_throw);
        //float vertical_throw = Input.GetAxis("Vertical");
        ProcessRotation();
        ProcessFiring();

    }
}
