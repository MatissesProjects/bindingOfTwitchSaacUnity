using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Wall : MonoBehaviour
{
    public GameObject door;

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("hit the wall " + other.gameObject.name);
    }
}
