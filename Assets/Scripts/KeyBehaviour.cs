using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float minDistanceToGlow;

    private Light[] lights;
    private Transform player;

    private void Start()
    {
        lights = GetComponentsInChildren<Light>();
        foreach (var light in lights)
        {
            light.intensity = 0;
        }
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player == null)
        {
            Debug.Log("No player found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));

        if (Vector3.Distance(transform.position, player.position) >= minDistanceToGlow && lights[0].intensity != 0)
        {
            foreach (var light in lights)
            {
                light.intensity = 0;
            }
        }
        else if(Vector3.Distance(transform.position, player.position) < minDistanceToGlow)
        {
            float intensity = (minDistanceToGlow - Vector3.Distance(transform.position, player.transform.position)) / (minDistanceToGlow * 10);
            //Debug.Log("Key Intensity: " + intensity);
            foreach (var light in lights)
            {
                light.intensity = intensity;
                //light.intensity = lightIntensity;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}
