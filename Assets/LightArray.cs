using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityStandardAssets.Utility.TimedObjectActivator;

public class LightArray : MonoBehaviour {
    public List<GameObject> lights;
    public int lightPos;
    public int trail;
    private bool stop = false;
    public AudioSource winSound;
    private string WIN_LIGHT = "winLight";
    
    // Use this for initialization
    void Start() 
    {
        lights = new List<GameObject>();
    }

    // Update is called once per frame
    void FixedUpdate() 
    {
        if (Input.GetKeyDown(KeyCode.Space)) { stop = true; } 
        if (Input.GetKeyDown(KeyCode.DownArrow)) { stop = false; }

        if (lights.Count < 1)
        {
            // Do logic in case somebody sets the light count to less than 1?
        }
      
        //Invoke("lightClear", .0001f);
        if (stop == false) 
        {
            for (int i = 0; i < lights.Count; i++)
            {
                lights[i].SetActive(true);
                lights[i - trail].SetActive(false);
            }
        }

        if ((lights[0].tag == WIN_LIGHT) && (stop))
        {
            stop = false;
            trail = 30;

            winSound.Play();
            Debug.Log("WINNER");
        }
    }

    // void lightClear()
    // {
    //     if (stop == false)
    //     {
    //         for (int i = 0; i < 100; i++)
    //         {
    //             lightsOff.Add(lightsOn[i]);
    //             lightsOn.Remove(lightsOn[i]);
    //         }

    //         lightsOn.Clear();           
    //     }
    // }
}

