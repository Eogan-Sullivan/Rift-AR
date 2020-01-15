using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FitToScreen : MonoBehaviour {
    private float margin = 0f;
    public float scaleFactor = 1f;
    // Use this for initialization
    void Start () {
   
    Camera cam = this.transform.parent.GetComponent<Camera>();

        float height = (cam.orthographicSize * 2f);
        float width = (height * Screen.width / Screen.height);
        float fix = 0;

        if (width > height) fix = width + margin;
        if (width < height) fix = height + margin;
        this.transform.localScale = new Vector3((fix / scaleFactor) * 4 / 3, fix / scaleFactor, 0.1f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
