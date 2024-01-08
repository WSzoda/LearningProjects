using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public void MoveCharacter(SwipeDirection direction)
    {
        switch (direction)
        {
            case SwipeDirection.Up:
                transform.Translate(new Vector3(0, 0, 1.5f));
                break;
            case SwipeDirection.Right:
                transform.Translate(new Vector3(1.5f, 0, 0));
                break;
            case SwipeDirection.Down:
                transform.Translate(new Vector3(0, 0, -1.5f));
                break;
            case SwipeDirection.Left:
                transform.Translate(new Vector3(-1.5f, 0, 0));
                break;
        }
    }
}
