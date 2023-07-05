using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outscal
{
    public class PlayerController : MonoBehaviour
    { 
        [Header("Animator Attribtes")]
        [SerializeField] private Animator _animator;

        private void Update()
        {
            PlayerRun();
            PlayerCrouch();
            PlayerJump();
        }

        private void PlayerRun()
        {
            float speed = Input.GetAxis("Horizontal");
            _animator.SetFloat("Speed", Mathf.Abs(speed));

            Vector3 scale = transform.localScale;
            if (speed < 0)
            {
                scale.x = -1f * Mathf.Abs( scale.x);
            }
            else if(speed > 0)
            {
                scale.x = Mathf.Abs(scale.x);
            }

            transform.localScale = scale;
        }

        private void PlayerCrouch()
        {
            if(Input.GetKeyDown(KeyCode.LeftControl))
            {
                _animator.SetBool("Crouch",true);
                Debug.Log(_animator + "Crouch");   
            }
            else
            {
                _animator.SetBool("Crouch", false);
            }
        }

        private void PlayerJump()
        {
            float VerticalInput = Input.GetAxis("Vertical");

            if(VerticalInput > 0)
            {
                _animator.SetBool("Jump", true);
                Debug.Log(_animator + "Jump");
            }
            else 
            {
                _animator.SetBool("Jump", false);
            }
        }
    }
}