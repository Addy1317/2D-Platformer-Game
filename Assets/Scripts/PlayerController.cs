using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Outscal
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Player Animator")]
        [SerializeField] private Animator _animator;
        [SerializeField] private float _speed;

        [Header("Player Health")]
        [SerializeField] private int _playerHealth = 3;
        [SerializeField] private int _heartCount;
        [SerializeField] private bool _isDead;
        [SerializeField] private Transform _startPosition;

        [Header("Player Jump Force")]
        [SerializeField] private float _jumpForce;
        private bool _isGrounded = true;

        [Header("Physics Components")]
        private Rigidbody2D _rigidbody2D;
        private BoxCollider2D _boxcollider2D;
        private Camera _mainCamera;

        [Header("Death UI")]
        [SerializeField] private GameObject _deathUIPanel;
        [SerializeField] private Image [] hearts;

        [Header("Script Reference")]
        [SerializeField] private ScoreController _scoreController;
        [SerializeField] private GameOverController _gameOverController;

        private void Awake()
        {
            _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
            _boxcollider2D = gameObject.GetComponent<BoxCollider2D>();
            _mainCamera = gameObject.GetComponent<Camera>();
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

            MoveCharacter(horizontal, vertical);
            PlayerMovementAnimation(horizontal, vertical);
        }
        private void MoveCharacter(float horizontal, float vertical)
        {
            Vector3 position = transform.position;
            position.x += horizontal * _speed * Time.deltaTime;
            transform.position = position;

            // Move Character vertically
            if (vertical > 0 && _isGrounded)
            {
                _rigidbody2D.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Force);
            }
        }

        private void PlayerMovementAnimation(float horizontal, float vertical)
        {
            _animator.SetFloat("Speed", Mathf.Abs(horizontal));

            Vector3 scale = transform.localScale;
            if (horizontal < 0)
            {
                scale.x = -1f * Mathf.Abs(scale.x);
            }
            else if (horizontal > 0)
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
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                _animator.SetBool("Crouch", true);
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

        public void PickUpKey()
        {
            Debug.Log("Player picked the Key");
            _scoreController.IncrementScore(10);
        }

        public void KillPlayer()
        {
            _animator.SetBool("Dead", true);
            _gameOverController.PlayerDied();
            this.enabled = false;
          
        }

        /*
        public void DecreaseHealth()
        {
            _playerHealth--;
            HandleHealthUI();
            if (_playerHealth <= 0)
            {
                PlayDeathAnimation();
                PlayerDeath();
            }
            else
            {
                transform.position = _startPosition.position;
            }
        }
        ?
        public void PlayerDeath()
        {
            _isDead = true;
            _mainCamera.transform.parent = null;
            _deathUIPanel.gameObject.SetActive(true);
            _rigidbody2D.constraints = RigidbodyConstraints2D.FreezePosition;
            ReloadLevel();
        }

        public void PlayDeathAnimation()
        {
           _animator.SetTrigger("Die");
        }

        private void ReloadLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void HandleHealthUI()
        {
            for (int i = 0; i < hearts.Length; i++)
            {
                //i < _playerHealth ? hearts[i].color = Color.red : hearts[i].color = Color.black;

                if( i <_playerHealth)
                {
                    hearts[i].color = Color.red;
                }

                else
                {
                    hearts[i].color = Color.black;
                }
            }
        }
        */
    }
}



