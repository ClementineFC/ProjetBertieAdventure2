using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControleur : MonoBehaviour
{
    public GameObject target;
    public float vitesseRotateCamera;
    public float amplitude;
    public float mouseY;
    public float positionY;
    // Start is called before the first frame update
    void Start()
    {
        positionY = 0.0f;
        vitesseRotateCamera = 5.0f;
        amplitude = 3.0f;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mouseY = Input.GetAxis("Mouse Y");
        positionY = transform.position.y - mouseY * Time.deltaTime * vitesseRotateCamera;
        if (positionY > target.transform.position.y + amplitude)
        {
            positionY = target.transform.position.y + amplitude;
        }
        if (positionY < target.transform.position.y - amplitude)
        {
            positionY = target.transform.position.y - amplitude;
        }
        transform.position = new Vector3(transform.position.x, positionY, transform.position.z);
        transform.LookAt(target.transform.position);

    }
}

