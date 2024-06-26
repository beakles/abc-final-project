﻿using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] 
    private LayerMask groundLayerMask = 8;

    public bool isGrounded;

    private void OnTriggerStay2D(Collider2D collider)
    {
        isGrounded = collider != null && (((1 << collider.gameObject.layer) & groundLayerMask) != 0);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }
}
