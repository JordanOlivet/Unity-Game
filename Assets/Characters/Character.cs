using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    #region Private fields

    Vector2 movementInput;
    Rigidbody2D rb;

    private List<RaycastHit2D> collisions;

    #endregion

    #region Public Fields

    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;

    #endregion

    #region Character Statistics

    public float BaseDamage = 1;
    public float BaseMaxHealth = 10;
    public float BaseRegenRate = 0.1f;
    public float BaseMoveSpeed = 1;
    public float BaseArmor = 0;
    public float BaseRange = 1;
    public float BaseProjectileSpeed = 1;
    public float BaseDuration = 1;
    public float BaseProjectileAmount = 1;
    public float BaseCooldown = 1;
    public float BaseChance = 0;
    public float BaseXpGain = 1;
    public float BaseCurrencyGain = 1;
    public float BaseCorruption = 0;
    public float BaseMagnetSize = 1;
    public float BaseRevive = 0;
    public float BaseReroll = 0;
    public float BaseBanish = 0;
    public float BaseSkip = 0;


    #endregion

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
            int collisionCount = rb.Cast(movementInput, movementFilter, collisions, BaseMoveSpeed * Time.fixedDeltaTime + collisionOffset);

            if (collisionCount == 0)
            {
                rb.MovePosition(rb.position + BaseMoveSpeed * Time.fixedDeltaTime * movementInput);
            }
        }
    }

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }
}
