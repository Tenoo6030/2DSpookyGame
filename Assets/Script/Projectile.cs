﻿using UnityEngine;

public class Projectile : MonoBehaviour
{
   [SerializeField] private float speed;
    private float direction;
    private bool hit;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime*direction;
        transform.Translate(movementSpeed, 0, 0);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        boxCollider.enabled = false;
        gameObject.SetActive(false);
    }
   public void SetDirection(float _direction)
    {
        direction = _direction;
        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction) 
        {
           localScaleX = -localScaleX;
        }
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }
}
