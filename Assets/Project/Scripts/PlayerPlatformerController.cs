﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.LastShupToTauCeti
{
    public class PlayerPlatformerController : PhysicsObject
    {

        public float maxSpeed = 7;
        public float jumpTakeOffSpeed = 7;

        [SerializeField]
        private SpriteRenderer spriteRenderer;
        [SerializeField]
        private Animator animator;

        protected override void ComputeVelocity()
        {
            Vector2 move = Vector2.zero;

            move.x = Input.GetAxis("Horizontal");

            if (Input.GetButtonDown("Jump") && grounded)
            {
                velocity.y = jumpTakeOffSpeed;
            }
            else if (Input.GetButtonUp("Jump"))
            {
                if (velocity.y > 0)
                {
                    velocity.y = velocity.y * 0.5f;
                }
            }

            bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));
            if (flipSprite)
            {
                spriteRenderer.flipX = !spriteRenderer.flipX;
            }

            //animator.SetBool("grounded", grounded);
            animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

            targetVelocity = move * maxSpeed;
        }
    }
}

