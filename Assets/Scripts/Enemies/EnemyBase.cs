using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animaiton;

namespace Enemy
{
    public class EnemyBase : MonoBehaviour, IDamageable 
    {
        public Collider collider;
        public FlashColor flashColor;
        public float startLife = 10f;
        public ParticleSystem particleSystem;


        private float _currentLife;
        [SerializeField] private AnimationBase _animationBase;

        [Header("Animation Start")]
        public float startAnimationDuration = .2f;
        public Ease startAnimationEase = Ease.OutBack;
        public bool startWithBornAnimation = true;

        private Player _player;

        private void Awake()
        {
            Init();
        }


        protected virtual void ResetLife()
        {
            _currentLife = startLife;
        }

        protected virtual void Init()
        {
            ResetLife();
            BornAnimation();
        }

        protected virtual void Kill()
        {
            
            OnKill();
        }

        protected virtual void OnKill()
        {
            if (collider != null) collider.enabled = false;
            Destroy(gameObject, 3f);
            PlayAnimationByTrigger(AnimationType.DEATH);
        }

        public void OnDamage(float f)
        {
            if (flashColor != null) flashColor.Flash();
            if (particleSystem != null) particleSystem.Emit(15);

            transform.position -= transform.forward;

            _currentLife -= f;

            if( _currentLife <= 0 )
            {
                Kill();
            }
        }

        #region ANIMATION
        private void BornAnimation()
        {
            transform.DOScale(0, startAnimationDuration).SetEase(startAnimationEase).From();
        }

        public void PlayAnimationByTrigger(AnimationType animationType)
        {
            _animationBase.PlayAnimationByTrigger(animationType);
        }
        #endregion


        //debug
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.T))
            {
                OnDamage(5f);
            }

        }

        public void Damage(float damage)
        {
            OnDamage(damage);
        }

        public void Damage(float damage, Vector3 dir)
        {
            OnDamage(damage);
            transform.DOMove(transform.position - dir, .1f);
        }

        private void OnCollisionEnter(Collision collision)
        {
            Player p = collision.transform.GetComponent<Player>();

            if (p != null)
            {
                p.Damage(1);
            }
        }
    }
}