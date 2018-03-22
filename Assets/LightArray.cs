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
    public GameObject winLight;
    public float speed;
    
    // Use this for initialization
    void Start() {
        InvokeRepeating("LightTrail",speed,speed);
        
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
             
           // StartCoroutine(LightTrail());
        } else {
            /* if player hits 'Stop', we want to deactivate 
            the trailing lights to avoid false wins */
            foreach (GameObject light in lights) {
               if (!(light.Equals(lights[lightIndex]))) {
                    light.SetActive(false);
                }
                if ((light.Equals(lights[lightIndex]))) {
                    light.SetActive(true);
                }
            }
        }
 Debug.Log(lightIndex);
 //if ((lights[0].tag == WIN_LIGHT) && (stop))
        if ((lightIndex==46) && (stop))
        {
            lights.Remove(winLight);
            winLight.SetActive(true);
            stop = false;
            winSound.Play();
            Debug.Log("WINNER");
            trail=50;
           
        }
    }

    void LightTrail() {
       
     if (stop==false){
        lights[lightIndex].SetActive(true);
        lightIndex++;
       
        if (lightIndex > trail)
        {
            lights[lightIndex - trail].SetActive(false);
        }
       
     }
    } 

}

