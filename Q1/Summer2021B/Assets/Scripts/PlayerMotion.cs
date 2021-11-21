using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : MonoBehaviour
{
    private float speed,angularSpeed;
    private CharacterController controller;
    private float rotationAboutX=0, rotationAboutY=0;
    public GameObject PlayerCamera;
    // Start is called before the first frame update
    void Start()
    {
        speed = 2;
        angularSpeed = 20;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {//Time.deltaTime is time that has passed from frame to frame
        float dx, dy=-1,dz; // dy=-1 is a gravity

        // player rotation
        rotationAboutY += Input.GetAxis("Mouse X") * angularSpeed * Time.deltaTime;
        transform.localEulerAngles = new Vector3(0, rotationAboutY, 0);
        // camera rotation
        rotationAboutX -= Input.GetAxis("Mouse Y") * angularSpeed * Time.deltaTime;
        PlayerCamera.transform.localEulerAngles = new Vector3(rotationAboutX, 0, 0);
        // motion after rotation
        dz = Input.GetAxis("Vertical"); //can be one of: -1, 0 , 1
        dz *= speed * Time.deltaTime;
        dx = Input.GetAxis("Horizontal");
        dx *= speed * Time.deltaTime;
        // example of simple motion
        // forward/backward
        // transform.Translate(new Vector3(0, 0, dy * speed * Time.deltaTime));
        // left/right
        //transform.Translate(new Vector3(dx* speed * Time.deltaTime, 0, 0 ));

        // motion using CharacterController
        Vector3 motion = new Vector3(dx, dy, dz); // motion is defined in Local coordinates
        motion = transform.TransformDirection(motion);//Now motion is in Global coordinates
        controller.Move(motion);// must recieve Vector3 in Global coordinates
    }
}
