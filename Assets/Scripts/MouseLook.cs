using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //Variablen für Maus Input aus Unity
    private float mouseX;
    private float mouseY;

    //Setting für Mausempfindlichkeit
    [SerializeField]
    private float sensitivity = 100f;

    //Object für Player Object und Kamera
    [SerializeField]
    private Transform player;
    private float camTilt = 0f;

    //Gecalled wenn das Object fertig geladen hat
    private void Start()
    {
        //lockt den cursor in der mitte des bildschirmes der anwendung und versteckt ihn
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //holt sich den Maus Input aus Unity, multipliziert es mit der eingestellten empfindlichkeit und deltaTime damit es unabhängig von der Framerate ist
        mouseX = Input.GetAxis("Mouse X") * sensitivity;
        mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        //begrenzt camTilt auf einen 180° bereich damit man maximal gerade nach oben und unten schauen kann
        camTilt -= mouseY;
        camTilt = Mathf.Clamp(camTilt, -90f, 90f);

        //wendet die X Rotation auf die Z achse des Spielers an um das gesammte Model zu drehen und die Y Rotation auf die Kamera
        transform.localRotation = Quaternion.Euler(camTilt, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
    }
}
