using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float sensivityVertical = 5.0f;
    public float sensivityHorizontal = 5.0f;

    public float minimumVertical = -45.0f;
    public float maximumVertical = 45.0f;

    private float rotationX = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //rotationX -= Input.GetAxis("Mouse Y") * sensivityVertical;
        //rotationX = Mathf.Clamp(rotationX, minimumVertical, maximumVertical);
        

        // uses left and right arrows
        float deltaY = Input.GetAxis("Horizontal") * sensivityHorizontal;

        float deltaZ = -Input.GetAxis("Mouse X") * sensivityHorizontal;
        //float rotationY = transform.localEulerAngles.y + deltaY;
        //transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
        
    }
}
