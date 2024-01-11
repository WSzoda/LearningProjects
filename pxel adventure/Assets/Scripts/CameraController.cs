using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{

    public Transform player;
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y,-10);
    }
}
