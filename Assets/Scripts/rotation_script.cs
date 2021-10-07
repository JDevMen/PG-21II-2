using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation_script : MonoBehaviour
{
    public float degreesRotation = 30f;
    public float rotationSpeed = 5f;

    private float degreesRotated = 0f;
    private int rotationDirection = 1;
    private float rotation = 0f;

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Keypad4)){
        //    gameObject.transform.Rotate(Vector3.back*10);
        //}
        //else if (Input.GetKeyDown(KeyCode.Keypad6))
        //{
        //    gameObject.transform.Rotate(Vector3.forward * 10);
        //}

        if(rotationDirection ==1)
        {
            if (degreesRotated >= degreesRotation)
            {
                rotationDirection *= -1;
            }
            rotation = rotationSpeed * Time.deltaTime * rotationDirection;
            gameObject.transform.Rotate(Vector3.forward * rotation);
            degreesRotated += rotation;
        }
        else
        {
            if(degreesRotated <= -degreesRotation)
            {
                rotationDirection *= -1;
            }
            rotation = rotationSpeed * Time.deltaTime * rotationDirection;
            gameObject.transform.Rotate(Vector3.forward * rotation);
            degreesRotated += rotation;
   

        }


    }
}
