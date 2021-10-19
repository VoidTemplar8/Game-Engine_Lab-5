using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceCapsuleCommand : IActivity
{
    Vector3 position;
    Color color;
    Transform cube;

    public PlaceCapsuleCommand(Vector3 position, Color color, Transform cube)
    {
        this.position = position;
        this.color = color;
        this.cube = cube;
    }

    public void Execute()
    {
        CubePlacer.PlaceCube(position, color, cube);
    }
}
