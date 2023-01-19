using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSkeletonController : MonoBehaviour
{
    public float moveSpeed = 1;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;

    Vector2 movementInput;
    Rigidbody2D rb;

    private List<RaycastHit2D> collisions;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collisions = new List<RaycastHit2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (movementInput != Vector2.zero)
        {
            int collisionCount = rb.Cast(movementInput, movementFilter, collisions, moveSpeed * Time.fixedDeltaTime + collisionOffset);

            if (collisionCount == 0)
            {
                rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * movementInput);
            }
        }
    }

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }
}
