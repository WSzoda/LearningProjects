using System;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    private enum SwipeDirection {Up, Down, Left, Right}
    
    private Vector3 _swipeStartPosition;
    private Vector3 _swipeEndPosition;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            _swipeStartPosition = Input.GetTouch(0).position;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            _swipeEndPosition = Input.GetTouch(0).position;
            Vector3 swipeDelta = _swipeEndPosition - _swipeStartPosition;
            
            SwipeDirection swipeDirection = DetermineSwipeDirection(swipeDelta);
        }
    }

    private SwipeDirection DetermineSwipeDirection(Vector3 swipeDelta)
    {
        Vector3 normalizedDelta = swipeDelta.normalized;
        
        if (Math.Abs(normalizedDelta.x) > Math.Abs(normalizedDelta.y))
        {
            return swipeDelta.x > 0 ? SwipeDirection.Right : SwipeDirection.Left;
        }
        else
        {
            return swipeDelta.y > 0 ? SwipeDirection.Up : SwipeDirection.Down;
        }
    }
    
    
}
