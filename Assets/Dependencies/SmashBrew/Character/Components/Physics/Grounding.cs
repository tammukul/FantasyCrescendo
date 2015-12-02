﻿using UnityEngine;
using System;
using System.Collections.Generic;

namespace Hourai.SmashBrew {

    [RequiredCharacterComponent]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(CapsuleCollider), typeof(Animator))]
    public class Grounding : MonoBehaviour {
        
        private CapsuleCollider _movementCollider;
        private Animator _animator;

        private HashSet<Collider> ground;

        public event Action OnGrounded;

        public bool IsGrounded {
            get { return _animator.GetBool(CharacterAnimVars.Grounded); }
            private set {
                if (IsGrounded == value)
                    return;
                _animator.SetBool(CharacterAnimVars.Grounded, value);
                if (OnGrounded != null)
                    OnGrounded();
            }
        }

        void Awake() {
            ground = new HashSet<Collider>();
            _movementCollider = GetComponent<CapsuleCollider>();
            _animator = GetComponent<Animator>();
        }

        void OnCollisionEnter(Collision col) {
            ContactPoint[] points = col.contacts;
            if (points.Length <= 0)
                return;

            float r2 = _movementCollider.radius * _movementCollider.radius;
            Vector3 bottom = transform.TransformPoint(_movementCollider.center - Vector3.up * _movementCollider.height / 2);
            for (var i = 0; i < points.Length; i++)
                if ((points[i].point - bottom).sqrMagnitude < r2)
                    ground.Add(points[i].otherCollider);
            IsGrounded = ground.Count > 0;
        }

        protected virtual void OnCollisionExit(Collision col) {
            if (ground.Remove(col.collider))
                IsGrounded = ground.Count > 0;
        }
    }

}
