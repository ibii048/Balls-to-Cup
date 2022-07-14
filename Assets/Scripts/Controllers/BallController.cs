using System;
using Managers;
using UnityEngine;

namespace Controllers
{
    public class BallController : MonoBehaviour
    {
        [SerializeField] private float _mass;
        [SerializeField] private float _gravityScale;
        [SerializeField] private float _friction;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private PhysicsMaterial2D _physicsMaterial;
        
        private bool _isCollided = false;
        private void OnEnable()
        {
            _isCollided = false;
        }

        private void Start()
        {
            _rigidbody.mass = _mass;
            _rigidbody.gravityScale = _gravityScale;
            _physicsMaterial.friction = _friction;
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if(_isCollided) return;
            
            switch (collider.tag)
            {
                case Const.Tags.FINAL_POINT_TAG:
                    EventManager.RaiseBallInCupEvent();
                    _isCollided = true;
                    break;
                
                case Const.Tags.DEAD_POINT_TAG:
                    EventManager.RaiseBallMissedEvent();
                    _isCollided = true;
                    break;
                
                default:
                    break;
            }
        }
    }
}
