using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float minDistanceToGlow;

    //private Material keyMaterial;
    //private Color keyEmissiveColor;
    //private GameObject player;

    //private void Start()
    //{
    //    keyMaterial = gameObject.GetComponent<Renderer>().material;
    //    keyEmissiveColor = gameObject.GetComponent<Renderer>().material.GetColor("_EmissionColor");
    //    player = GameObject.FindGameObjectWithTag("Player");
    //    //Debug.Log("Emissive" + transform.name + "Colour: " + keyMaterial.GetColor("_EmissionColor"));
    //    Debug.Log("Intensity "+transform.name+": "+ keyEmissiveColor.a);
    //}
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, rotationSpeed, 0));
        //if (Vector3.Distance(transform.position, player.transform.position) >= minDistanceToGlow)
        //{
        //    return;
        //}
        //else
        //{
        //    Debug.Log("Distance converted to alpha: "+ (minDistanceToGlow - Vector3.Distance(transform.position, player.transform.position)) / minDistanceToGlow);
        //    keyEmissiveColor.a =  (minDistanceToGlow - Vector3.Distance(transform.position, player.transform.position))/minDistanceToGlow;
        //    keyMaterial.SetColor("_EmissionColor", keyEmissiveColor);
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}
