using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeCharacterRotation : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    private Vector2 _touchStart, _touchEnd;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                _touchStart = touch.position;
            }

            if (touch.phase == TouchPhase.Moved)
            {
                _touchEnd = touch.position;

                float swipeDistanceX = _touchEnd.x - _touchStart.x;

                transform.Rotate(Vector3.up, -swipeDistanceX * _rotationSpeed * Time.deltaTime);

                _touchStart = _touchEnd;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            _touchStart = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            _touchEnd = Input.mousePosition;

            float swipeDistanceX = _touchEnd.x - _touchStart.x;

            transform.Rotate(Vector3.up, -swipeDistanceX * _rotationSpeed * Time.deltaTime);

            _touchStart = _touchEnd;
        }

    }
}
