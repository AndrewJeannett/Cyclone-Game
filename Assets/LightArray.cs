using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityStandardAssets.Utility.TimedObjectActivator;

public class LightArray : MonoBehaviour {
    public List<GameObject> lights;
    public int trail;
    private bool stop;
    public AudioSource winSound;
    private string WIN_LIGHT = "winLight";
    private int lightIndex;
    
    // Use this for initialization
    void Start() {
        foreach (GameObject light in lights) 
        {
            light.SetActive(false);
        }
        stop = false;
        lightIndex = 0;
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (Input.GetKeyDown(KeyCode.Space)) { stop = true; } 
        if (Input.GetKeyDown(KeyCode.DownArrow)) { stop = false; }

        if (lightIndex >= lights.Count) {
            lightIndex = 0;
        }
        
        if (stop == false) {
            StartCoroutine("LightTrail");
        } else {
            /* if player hits 'Stop', we want to deactivate 
            the trailing lights to avoid false wins */
            foreach (GameObject light in lights) {
                if (!(light.Equals(lights[lightIndex]))) {
                    light.SetActive(false);
                }
            }
        }

        if ((lights[0].tag == WIN_LIGHT) && (stop))
        {
            stop = false;
            winSound.Play();
            Debug.Log("WINNER");
        }
    }

    IEnumerator LightTrail() {
        lights[lightIndex].SetActive(true);
        lightIndex++;
        if (lightIndex > trail)
        {
            lights[lightIndex - trail].SetActive(false);
        }
        yield return new WaitForSeconds(0.1f);
    }

}

