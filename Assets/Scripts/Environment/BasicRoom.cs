using System;
using UnityEngine;

enum RoomShape
{
    Basic,
    Starter,
    Wackadoodle
}

public class BasicRoom : MonoBehaviour
{
    // TODO do we want a list of walls?

    public Wall walls;
    private const RoomShape RoomShape = global::RoomShape.Basic;

    private void Start()
    {
        switch (RoomShape)
        {
            case RoomShape.Basic:
                //TODO make this the 4 walls
                // top
                var go = Instantiate(walls, transform.position + new Vector3(0,4.67f,0), Quaternion.identity, transform);
                var door = Instantiate(walls.door, transform.position + new Vector3(0,4.67f,0), Quaternion.identity, go.transform);
                door.transform.localScale = new Vector3(0.05f,1,1);
                // bottom
                go = Instantiate(walls, transform.position + new Vector3(0,-4.67f,0), Quaternion.identity, transform);
                door = Instantiate(walls.door, transform.position + new Vector3(0,-4.67f,0), Quaternion.identity, go.transform);
                door.transform.localScale = new Vector3(0.05f,1,1);
                // left
                go = Instantiate(walls, transform.position + new Vector3(8.55f,0,0), Quaternion.AngleAxis(90f, Vector3.forward), transform);
                door = Instantiate(walls.door, transform.position + new Vector3(8.55f,0,0), Quaternion.AngleAxis(90f, Vector3.forward), go.transform);
                go.transform.localScale = new Vector3(10,1,1);
                door.transform.localScale = new Vector3(0.1f,1,1);
                // right
                go = Instantiate(walls, transform.position + new Vector3(-8.55f,0,0), Quaternion.AngleAxis(90f, Vector3.forward), transform);
                door = Instantiate(walls.door, transform.position + new Vector3(-8.55f,0,0), Quaternion.AngleAxis(90f, Vector3.forward), go.transform);
                go.transform.localScale = new Vector3(10,1,1);
                door.transform.localScale = new Vector3(0.1f,1,1);
                break;
            case RoomShape.Starter:
            case RoomShape.Wackadoodle:
                break;
            default:
                print("Room shape is not done " + RoomShape);
                break;
        }
    }
}
