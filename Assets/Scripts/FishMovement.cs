using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _changeRotationInterval;
    [SerializeField] private float _maxRotationAngle;
    private float _timer;
    private Rigidbody _rigidBody;
    void Awake()
    {
        _timer = _changeRotationInterval;
        _rigidBody= GetComponent<Rigidbody>();
        if (_rigidBody == null)
        {
            _rigidBody = gameObject.AddComponent<Rigidbody>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * _moveSpeed);
        _timer -= Time.deltaTime;
        if (_timer < 0)
        {
            float randomAngle = Random.Range(-_maxRotationAngle, _maxRotationAngle);
            transform.Rotate(Vector3.up, randomAngle);
            _timer = _changeRotationInterval;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Vector3 newDirection = Vector3.Reflect(_rigidBody.velocity.normalized, collision.contacts[0].normal);
            _rigidBody.velocity = newDirection * _moveSpeed;
        }
    }
    public void SetSpeed(float speed)
    {
        _moveSpeed = speed;
    }
}
