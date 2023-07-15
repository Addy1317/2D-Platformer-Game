using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outscal
{
    public class EnemyController : MonoBehaviour
    {
        [Header("Transform Reference")]
        [SerializeField] private GameObject _pointA;
        [SerializeField] private GameObject _pointB;
        private Transform _currentPoint;

        [Header("Patrolling Speed")]
        [SerializeField] private float _patrollingSpeed;

        [Header("Physics Component")]
        private Rigidbody2D _rigidbody2D;

        [Header("Animator Component")]
        [SerializeField] private Animator _animator;

        private void Start()
        {
            _animator = gameObject.GetComponent<Animator>();
            _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
           
            _currentPoint = _pointB.transform;
            _animator.SetBool("isPatrolling", true);
        }

        private void Update()
        {
            EnemyPattrolling();
          
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<PlayerController>() != null)
            {
                Debug.Log("Key Interacted");
                PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
                playerController.KillPlayer();
            }
        }

        private void EnemyPattrolling()
        {
            Vector2 point = _currentPoint.position - transform.position;

            if (_currentPoint == _pointB.transform)
            {
                _rigidbody2D.velocity = new Vector2(_patrollingSpeed, 0);
            }
            else
            {
                _rigidbody2D.velocity = new Vector2(-_patrollingSpeed, 0);
            }

            if( Vector2.Distance(transform.position , _currentPoint.position) < 0.5f && _currentPoint == _pointB.transform)
            {
                _currentPoint = _pointA.transform;
            }

            if (Vector2.Distance(transform.position, _currentPoint.position) < 0.5f && _currentPoint == _pointA.transform)
            {
                _currentPoint = _pointB.transform;
            }
        }
    }
}