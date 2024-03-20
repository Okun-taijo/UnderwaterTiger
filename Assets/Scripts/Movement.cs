using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3.0f;
    [SerializeField] private Animator _animator;
    private Dictionary<string, bool> movementDirections = new Dictionary<string, bool>
    {
        { "Forward", false },
        { "Backward", false },
        { "Left", false },
        { "Right", false }
    };
    void Update()
    {
        foreach (var direction in movementDirections)
        {
            if (direction.Value)
            {
                Move(direction.Key);
            }
        }
    }
    public void OnPointerDownMove(string direction)
    {
        movementDirections[direction] = true;
        _animator.SetTrigger("Walk");
    }
    public void OnPointerUpMove(string direction)
    {
        movementDirections[direction] = false;
        _animator.SetTrigger("Idle");
    }
    private void Move(string direction)
    {
        Vector3 movement = Vector3.zero;
        switch (direction)
        {
            case "Forward":
                movement += transform.forward;
                break;
            case "Backward":
                movement -= transform.forward;
                break;
            case "Left":
                movement -= transform.right;
                break;
            case "Right":
                movement += transform.right;
                break;
        }
        
        transform.localPosition += movement.normalized * moveSpeed * Time.deltaTime;
    }
}

