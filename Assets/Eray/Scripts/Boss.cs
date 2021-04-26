using System;
using Cagri.Scripts;
using UnityEngine;

namespace Eray.Scripts
{
    public class Boss : MonoBehaviour, IEnemy
    {
        [SerializeField] private Animator anim;
        private GameObject _player;

        private bool _isAttacking;
        private bool _isScreaming;
        private bool _playerInRange;
        private bool _canMove;
        private bool _canRotate;

        private BossState _state;
        private readonly BossState _attackState = new AttackState();
        private readonly BossState _moveState = new MoveState();
        private readonly BossState _screamState = new ScreamState();
        private readonly BossState _idleState = new IdleState();


        private void Awake()
        {
            
        }


        private void Attack()
        {
            if (_playerInRange && !_isScreaming)
                _isAttacking = true;
            if (_isAttacking)
            {
                _isAttacking = false;
                _state = _attackState;
                _canMove = false;
                _canRotate = false;
            }
        }

        private void Update()
        {
            
        }

        private void RotateToPlayer()
        {
            if (_canRotate && !_isAttacking)
            {
                
            }
        }

        private void MoveToPlayer()
        {
            if (_canMove && !_playerInRange)
            {
                
            }
        }

        private void Scream()
        {
            _isScreaming = true;
            _canMove = false;
            _canRotate = false;
        }

        private void BossLogic()
        {
            _state.PlayAnimation(anim);
        }

        //using in animation event
        public void EndOfAttack()
        {
            
        }

        public void OnPlayerHit()
        {
            throw new NotImplementedException();
        }

        public void OnActive()
        {
            throw new NotImplementedException();
        }

        public void OnDeActive()
        {
            throw new NotImplementedException();
        }
    }
}