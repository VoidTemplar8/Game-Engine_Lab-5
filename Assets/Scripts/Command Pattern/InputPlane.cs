using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlane : MonoBehaviour
{
    Camera maincam;
    RaycastHit hitInfo;
    public Transform cubePrefab;
    public Transform capsulePrefab;
    public bool shapeSwitch = false;

    // Start is called before the first frame update
    void Awake()
    {
        maincam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (shapeSwitch == false)
            {
                 Ray ray = maincam.ScreenPointToRay(Input.mousePosition);
                 if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
                 {
                    Color c = new Color(Random.Range(0.5f, 1f), Random.Range(0.5f, 1f), Random.Range(0.5f, 1f));
                    //CubePlacer.PlaceCube(hitInfo.point, c, cubePrefab);

                       ICommand command = new PlaceCubeCommand(hitInfo.point, c, cubePrefab);
                    CommandInvoker.AddCommand(command);
                 }
            }
            if (shapeSwitch == true)
            {
                Ray ray = maincam.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
                {
                    Color c = new Color(Random.Range(0.5f, 1f), Random.Range(0.5f, 1f), Random.Range(0.5f, 1f));
                    //CubePlacer.PlaceCube(hitInfo.point, c, capsulePrefab);

                    IActivity command2 = new PlaceCapsuleCommand(hitInfo.point, c, capsulePrefab);
                    CommandInvoker.AddCommand2(command2);
                }
            }
        }

    }
    public void TogglePrefab()
    {
        if (shapeSwitch == true)
        {
            shapeSwitch = false;
            return;
        }

        if (shapeSwitch == false)
        {
            shapeSwitch = true;
            return;
        }
    }
}
