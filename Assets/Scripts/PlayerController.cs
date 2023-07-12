using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outscal
{
    public class PlayerController : MonoBehaviour
    { 
        [Header("Animator Attributes")]
        [SerializeField] private Animator _animator;
        [SerializeField] private float _speed;

        [Header("Physics Component")]
        [SerializeField] private float _jumpForce;
        private bool _isGrounded = true;
        private Rigidbody2D _rigidbody2D;
        private BoxCollider2D _boxcollider2D;

        private void Awake()
        {
            _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
            _boxcollider2D = gameObject.GetComponent<BoxCollider2D>();
        }

        private void Update()
        {
            PlayerMovement();
            PlayerCrouch();      
        }

        private void PlayerMovement()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Jump");

            MoveCharacter(horizontal , vertical);
            PlayerMovementAnimation(horizontal , vertical);
        }

        private void MoveCharacter(float horizontal, float vertical)
        {
            Vector3 position = transform.position;
            position.x += horizontal * _speed * Time.deltaTime;
            transform.position = position;

           // Move Character vertically
            if(vertical > 0 && _isGrounded)
            {
                _rigidbody2D.AddForce(new Vector2(0f, _jumpForce),ForceMode2D.Force);
            }
        }

        private void PlayerMovementAnimation(float horizontal, float vertical)
        {
            _animator.SetFloat("Speed", Mathf.Abs(horizontal));

            Vector3 scale = transform.localScale;
            if (horizontal < 0)
            {
                scale.x = -1f * Mathf.Abs( scale.x);
            }
            else if(horizontal > 0)
            {
                scale.x = Mathf.Abs(scale.x);
            }

            transform.localScale = scale;

            if (vertical > 0 && _isGrounded)
            {
                _animator.SetBool("Jump", true);
                Debug.Log(_animator + "Jump");
            }
            else
            {
                _animator.SetBool("Jump", false);
            }
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

        private void OnCollisionStay2D(Collision2D other)
        {
            if (other.transform.tag == "Platform")
            {
                _isGrounded = true;
                Debug.Log(_isGrounded + "TRUE");
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.transform.tag == "Platform")
            {
                _isGrounded = false;
                Debug.Log(_isGrounded + "FALSE");
            }
        }
    }
}