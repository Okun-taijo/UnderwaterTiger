using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraVerticalMovement : MonoBehaviour
{
    [SerializeField] private float _swipeSpeed;
    [SerializeField] private float _minXRotation;
    [SerializeField] private float _maxXRotation;

    private Vector2 _touchStart;
    private float currentRotationX;

    void Start()
    {
        currentRotationX = transform.localEulerAngles.x;
    }

    void Update()
    {
        //вариант для теста на компе
        if (Input.GetMouseButtonDown(0))
        {
            _touchStart = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            float swipeDistanceY = Input.mousePosition.y - _touchStart.y;
            float rotationAngle = swipeDistanceY * _swipeSpeed * Time.deltaTime;
            float newRotationX = currentRotationX - rotationAngle;
            newRotationX = Mathf.Clamp(newRotationX, _minXRotation, _maxXRotation);
            transform.localEulerAngles = new Vector3(newRotationX, transform.localEulerAngles.y, transform.localEulerAngles.z);
            currentRotationX = newRotationX;
            _touchStart = Input.mousePosition;
        }
        

        //для телефона
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                _touchStart = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                float swipeDistanceY = touch.position.y - _touchStart.y;
                float rotationAngle = swipeDistanceY * _swipeSpeed * Time.deltaTime;
                float newRotationX = currentRotationX - rotationAngle;
                newRotationX = Mathf.Clamp(newRotationX, _minXRotation, _maxXRotation);
                transform.localEulerAngles = new Vector3(newRotationX, transform.localEulerAngles.y, transform.localEulerAngles.z);
                currentRotationX = newRotationX;
                _touchStart = touch.position;
            }
        }
    }
}

