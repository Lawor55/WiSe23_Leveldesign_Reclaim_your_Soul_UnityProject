using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float minDistanceToGlow;

    private new Light light;
    private float lightIntensity;
    private Transform player;

    private void Start()
    {
        light = GetComponent<Light>();
        lightIntensity = light.intensity;
        light.intensity = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player = null)
        {
            Debug.Log("No player found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));

        if (Vector3.Distance(transform.position, player.transform.position) >= minDistanceToGlow)
        {
            light.intensity = 0;
        }
        else
        {
            light.intensity = lightIntensity;
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
