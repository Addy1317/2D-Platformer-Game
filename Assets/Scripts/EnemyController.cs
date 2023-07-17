using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outscal
{
    public class EnemyController : MonoBehaviour
    {
      
        [Header("Patrolling Speed")]
        [SerializeField] private float _patrollingSpeed;

        [Header("Patrolling Direction")]
        [SerializeField] private int _movingRight = 1;
        [SerializeField] private GameObject _groundDetector;
        [SerializeField] private float _rayDistance;

        [Header("Animator Component")]
        [SerializeField] private Animator _enemyAnimator;

        private void Update()
        {
            
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<PlayerController>() != null)
            {
                collision.transform.GetComponent<PlayerController>().DecreaseHealth();
               // PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
               // playerController.KillPlayer();
            }
        }

        private void PatrolEnemy()
        {
            _enemyAnimator.SetBool("isPatrol", true);
            transform.Translate(_movingRight * Vector2.right * _patrollingSpeed * Time.deltaTime);

            RaycastHit2D hit = Physics2D.Raycast(_groundDetector.transform.position, Vector2.down, _rayDistance);

            if (!hit)
            {
                transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
                _movingRight = _movingRight * -1;
            }
        }
        
    }
}