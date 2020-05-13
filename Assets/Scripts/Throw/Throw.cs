using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Vector2 startPosition, endPosition, direction;
    float touchTimeStart, touchTimeEnd, timeInterval;
    private float throwForce = 5f;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.touchCount > 0) {
            if (Input.GetTouch(0).phase == TouchPhase.Began) {
                touchTimeStart = Time.time;
                startPosition = Input.GetTouch(0).position;
            }

            if (Input.GetTouch(0).phase == TouchPhase.Ended) {
                touchTimeEnd = Time.time;
                endPosition = Input.GetTouch(0).position;

                timeInterval = touchTimeEnd - touchTimeStart;
                direction = startPosition - endPosition;
                rb2d.AddForce(-direction/timeInterval * throwForce);
            }
        }
    }
}
