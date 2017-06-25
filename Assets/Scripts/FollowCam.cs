using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {
    static public FollowCam S; //singleton
    public float easing = .05f;
    public bool _____________________;
    public Vector2 minXY;

    //fields set dynamically 
    public GameObject poi;
    public float camZ;

    void Awake()
    {
        S = this;
        camZ = this.transform.position.z;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 destination;
        if (poi == null)
        {
            destination = Vector3.zero;
        } else
        {
            destination = poi.transform.position;
            if (poi.tag == "Projectile")
            {
                if (poi.GetComponent<Rigidbody>().IsSleeping() )
                {
                    poi = null;
                    return;
                }
            }
        }
        // if there's only one line following an if, it doesnt need braces
       
        // Get the position of the poi

	}

    void Update()
    {
        if (poi == null) return; // return if there is no poi

        Vector3 destination = poi.transform.position;
        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);
        destination = Vector3.Lerp(transform.position, destination, easing);
        //Retain a destination.z of camZ
        destination.z = camZ;
        //Set the camera to the destination
        transform.position = destination;
        this.GetComponent<Camera>().orthographicSize = destination.y + 10;
    }
}
