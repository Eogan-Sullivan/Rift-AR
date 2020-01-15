using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ARManager : MonoBehaviour {
	
	// List of all connectes webcams
	WebCamDevice[] webcamDevices;
	WebCamTexture webcamLeft;
	WebCamTexture webcamRight;

	// The static webcam parameters for 2 identical webcams
	public static int webcamPixelHeight = 720;
	public static int webcamPixelWidtht = 1280;

	// The static FOV of the webcams
	public static int webcamFovHorizontal = 0;
	public static int webcamFovVertical = 0;

	// Reference to the HUD
	public Camera oneCamera;

	void Start () {
		
		// Test if ARManager is attached to the OculusRift GameObject
		if (this.name.Equals("OculusRift"))
			Debug.Log ("Correct GameObject");		
		setupWebcams ();
	}	
	// Update is called once per frame
	void Update () {

		// Buttons 
		// increase height of OculusRift
		if (Input.GetKeyDown (KeyCode.KeypadPlus)) {
			Vector3 position = this.transform.position;
			position.y += 0.1f;
			this.transform.position = position;
		}
		// decrease height of OculusRift
		if (Input.GetKeyDown (KeyCode.KeypadMinus)) {
			Vector3 position = this.transform.position;
			position.y -= 0.1f;
			this.transform.position = position;
		}		
		// recenter
		if (Input.GetKeyDown (KeyCode.Space)) {
			OVRManager.display.RecenterPose();
		}
	}
	void setupWebcams() {
		
		// Get connected webcams
		webcamDevices = WebCamTexture.devices;
		foreach (WebCamDevice device in webcamDevices)
			Debug.Log ("Webcam " + " = " + device.name);

		// Setup the BackgroundVideo
		webcamLeft = new WebCamTexture (webcamDevices [0].name);
		webcamLeft.requestedHeight = webcamPixelHeight;
		webcamLeft.requestedWidth = webcamPixelWidtht;
		webcamRight = new WebCamTexture (webcamDevices [2].name);
		webcamRight.requestedHeight = webcamPixelHeight;
		webcamRight.requestedWidth = webcamPixelWidtht;

		GameObject.Find("QuadRightEye").GetComponent<Renderer>().material.mainTexture = webcamRight;
		GameObject.Find("QuadLeftEye").GetComponent<Renderer>().material.mainTexture = webcamLeft;
		webcamRight.Play();
		webcamLeft.Play();
	}
	
	void switchWebcams() {		
		webcamLeft.Stop();
		webcamRight.Stop();		
		WebCamTexture tmpWebcam = webcamLeft;
		webcamLeft = webcamRight;
		webcamRight = tmpWebcam;	
		GameObject.Find("QuadRightEye").GetComponent<Renderer>().material.mainTexture = webcamRight;
		GameObject.Find("QuadLeftEye").GetComponent<Renderer>().material.mainTexture = webcamLeft;
		webcamLeft.Play();
		webcamRight.Play();
	}
}
