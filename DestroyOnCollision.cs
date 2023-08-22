﻿using UnityEngine;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TheLibraryElectric
{
#if UNITY_EDITOR
    [AddComponentMenu("The Library Electric/Destroy On Collision")]
#endif
    public class DestroyOnCollision : MonoBehaviour
    {
#if UNITY_EDITOR
[Header("Destroy Sound Audio Src")]
[SerializeField]
#endif
        public AudioSource audioSource;
        private Transform rigManager;
        private void Start()
        {
            rigManager = GameObject.Find("[RigManager (Blank)]")?.transform;
        }
        private void OnCollisionEnter(Collision collision)
        {
            // Check if the colliding GameObject is not a child of the excluded object
            if (!collision.transform.IsChildOf(rigManager) && collision.gameObject.layer != 13)
            {
                audioSource.Play();
                // Destroy the colliding GameObject
                Destroy(collision.gameObject);
            }
        }
#if !UNITY_EDITOR
        public DestroyOnCollision(IntPtr ptr) : base(ptr) { }
#endif
    }
}