using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MiniGameCollection.Games2024.Team13
{
    public class LazerControl : MonoBehaviour
    {
        public GameObject lazer;
        public GameObject player2;
        public Vector3 resetPosition;
        private int currentStep = 0;
        private int[] correctSequence = { 0, 1, 2 };
        private void Start()
        {
            lazer.SetActive(true);
        }
        public void TileSteppedOn(int tileIndex)
        {
            if (tileIndex == correctSequence[currentStep])
            {
                currentStep++;
                if (currentStep >= correctSequence.Length)
                {
                    DeactivateLaser();
                }
            }
            else
            {
                currentStep = 0;
            }
        }
        private void DeactivateLaser()
        {
            lazer.SetActive(false);
            currentStep = 0;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == player2 && lazer.activeSelf)
            {
                ResetPlayer();
            }
        }
        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Lazer"))
            {
                ResetPlayer();
            }
        }
        private void ResetPlayer()
        {
            player2.transform.position = resetPosition;
            Rigidbody rb = player2.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }
}