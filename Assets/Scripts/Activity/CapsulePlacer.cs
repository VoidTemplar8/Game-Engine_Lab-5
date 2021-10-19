using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsulePlacer : MonoBehaviour
{
    static List<Transform> cubes;

    public static void PlaceCube(Vector3 position, Color color, Transform cube)
    {
        Transform newCube = Instantiate(cube, position, Quaternion.identity);
        newCube.GetComponentInChildren<MeshRenderer>().material.color = color;
        if (cubes == null)
        {
            cubes = new List<Transform>();
        }
        cubes.Add(newCube);
    }
}
