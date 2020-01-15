using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject cube,dimples,sphere,monitor;

    Vector3 cubepos, spherepos, dimplespos,monitorpos;
    // Use this for initialization
    void Start()
    {
        cubepos = new Vector3(-3.5f, 0.5000001f, -5.71f);
        spherepos = new Vector3(-2.480268f, 0.5f, -8.749043f);
        dimplespos = new Vector3(-1.92f, 1.473062e-16f, -6.63408f);
        monitorpos = new Vector3(4.770238f, 0.27f, -9.052811f);    
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void spawnCube()
    {
        if (GameObject.FindGameObjectWithTag("Cube") == false)
        {
            Instantiate(cube, cubepos, cube.transform.rotation);
        }
    }
    public void spawnSphere()
    {
        if (GameObject.FindGameObjectWithTag("Sphere") == false)
        {

            Instantiate(sphere, spherepos, sphere.transform.rotation);
        }
    }
    public void spawnMonitor()
    {
        if (GameObject.FindGameObjectWithTag("Monitor") == false)
        {

            Instantiate(monitor, monitorpos, monitor.transform.rotation);
        }
    }
    public void spawnDimples()
    {
        if (GameObject.FindGameObjectWithTag("Dimples") == false)
        {

            Instantiate(dimples, dimplespos, dimples.transform.rotation);
        }
    }
    public void removeCube()
    {
        if (GameObject.FindGameObjectWithTag("Cube"))
        {
            Destroy(GameObject.FindGameObjectWithTag("Cube"));
        }
    }
    public void removeSphere()
    {
        if (GameObject.FindGameObjectWithTag("Sphere"))
        {
            Destroy(GameObject.FindGameObjectWithTag("Sphere"));
        }
    }
    public void removeDimples()
    {
        if (GameObject.FindGameObjectWithTag("Dimples"))
        {
            Destroy(GameObject.FindGameObjectWithTag("Dimples"));
        }
    }
    public void removeMonitor()
    {
        if (GameObject.FindGameObjectWithTag("Monitor"))
        {
            Destroy(GameObject.FindGameObjectWithTag("Monitor"));
        }
    }


}


