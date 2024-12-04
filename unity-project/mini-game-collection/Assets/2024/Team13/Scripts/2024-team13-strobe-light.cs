using UnityEngine;
namespace MiniGameCollection.Games2024.Team13
{
    public class StrobeLight : MonoBehaviour
    {
        public Light lightSource; // Reference to the Directional Light
        public float strobeInterval = 0.1f; // Interval in seconds for the strobe effect
        public float maxIntensity = 2f; // Max intensity for the strobe
        public float minIntensity = 0f; // Min intensity for the strobe
        private float nextStrobeTime;
        void Start()
        {
            if (lightSource == null)
            {
                Debug.LogError("No light source assigned!"); // Checks if light source is assigned
                return;
            }
            nextStrobeTime = Time.time + strobeInterval;
        }
        void Update()
        {
            if (Time.time >= nextStrobeTime)
            {
                lightSource.intensity = lightSource.intensity == maxIntensity ? minIntensity : maxIntensity;
                nextStrobeTime = Time.time + strobeInterval;
            }
        }
    }
}