using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchFlicker : MonoBehaviour
{
    [Header("Flicker Timings")]
    [SerializeField] private float defaultTimeTillFlicker;
    [SerializeField] private float offsetTimeTillFlicker;
    [SerializeField] private float defaultFlickerDuration;
    [SerializeField] private float offsetFlickerDuration;

    [Header("Flicker Intensity")]
    [SerializeField] private float minFlickeringIntensity;
    [SerializeField] private float flickeringIntensityOffset;

    private Light playerLight;
    //private bool initiateFlicker = true;
    private float noFlicker;
    private float flickerTimer;
    private float defaultIntensity;

    // Start is called before the first frame update
    void Start()
    {
        playerLight = GetComponent<Light>();
        defaultIntensity = playerLight.intensity;
        noFlicker = defaultTimeTillFlicker;
        flickerTimer = defaultFlickerDuration;
    }

    // Update is called once per frame
    void Update()
    {
        if (noFlicker > 0)
        {
            noFlicker -= Time.deltaTime;
            if (playerLight.intensity != defaultIntensity)
            {
                playerLight.intensity = defaultIntensity;
            }
            if (flickerTimer < 0)
            {
                flickerTimer = Random.Range(defaultFlickerDuration, offsetFlickerDuration);
            }
        }
        else
        {
            flickerTimer -= Time.deltaTime;
            if (flickerTimer < 0)
            {
                noFlicker = Random.Range(defaultTimeTillFlicker, defaultTimeTillFlicker + offsetTimeTillFlicker);
            }
            Flicker();
        }
        //if (initiateFlicker)
        //{
        //    initiateFlicker = false;
        //    StartCoroutine(StartFlicker());
        //    Debug.Log("Initiate Flicker");
        //}
    }

    //    private IEnumerator StartFlicker()
    //    {
    //        Flicker();
    //        yield return new WaitForSeconds(Random.Range(defaultTimeTillFlicker, defaultTimeTillFlicker + offsetTimeTillFlicker));
    //    }

    public void Flicker()
    {
        //Debug.Log("Flicker");

        //for (flickerTimer = Random.Range(defaultFlickerDuration, offsetFlickerDuration); flickerTimer > 0; flickerTimer -= Time.deltaTime)
        //{
        //    Debug.Log("Flickering for " + flickerTimer + " Seconds");
        //    float randomIntensity = Random.Range(minFlickeringIntensity, minFlickeringIntensity + flickeringIntensityOffset);
        //    playerLight.intensity = randomIntensity;
        //}
        //initiateFlicker = true;
        //playerLight.intensity = defaultIntensity;

        float randomIntensity = Random.Range(minFlickeringIntensity, minFlickeringIntensity + flickeringIntensityOffset);
        playerLight.intensity = randomIntensity;
    }
}
