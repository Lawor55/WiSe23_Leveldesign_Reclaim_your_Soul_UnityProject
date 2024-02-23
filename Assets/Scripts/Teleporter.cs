using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform teleportGoal;
    [SerializeField] private bool flipViewDirection;
    //[SerializeField] private bool ignoreModX;
    //[SerializeField] private bool ignoreModZ;

    private GameObject player;
    private CharacterController characterController;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        characterController = player.GetComponent<CharacterController>();
        //Debug.Log("Teleporter.cs\nName: " + transform.name + "\nPosition: " + transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Teleport(teleportGoal, transform);
        }
    }

    public void Teleport(Transform teleportGoal, Transform originPosition)
    {
        //preperation of positional modifier
        //Vector3 goalPosition = teleportGoal.position;
        Vector3 goalPosition;
        Vector3 relativePlayerPosition = player.transform.position - originPosition.position;
        if (flipViewDirection)
        {
            goalPosition = teleportGoal.position - relativePlayerPosition;
            goalPosition.y = teleportGoal.position.y + relativePlayerPosition.y;
        }
        else
        {
            goalPosition = teleportGoal.position + relativePlayerPosition;
        }

        //if (ignoreModX)
        //{
        //    goalPosition.x = player.transform.position.x;
        //}
        //if (ignoreModZ)
        //{

        //    goalPosition.z = player.transform.position.z;
        //}

        //preperation of rotation modifier
        Quaternion relativePlayerRotation = Quaternion.Euler(player.transform.rotation.eulerAngles - transform.rotation.eulerAngles);
        //Quaternion goalRotation = player.transform.rotation;
        Quaternion goalRotation = Quaternion.Euler(teleportGoal.rotation.eulerAngles + relativePlayerRotation.eulerAngles);
        if (flipViewDirection)
        {
            goalRotation.eulerAngles = new Vector3(goalRotation.eulerAngles.x, goalRotation.eulerAngles.y + 180, goalRotation.eulerAngles.z);
        }

        //teleportation gets applied
        characterController.enabled = false;
        player.transform.SetPositionAndRotation(goalPosition, goalRotation);
        characterController.enabled = true;
        Debug.Log("Teleport\n" + "Relative Player Position: " + relativePlayerPosition + "\n" + "Relative Player Rotation: " + relativePlayerRotation);
    }
}
