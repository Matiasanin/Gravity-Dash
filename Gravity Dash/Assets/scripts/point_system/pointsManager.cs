using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    private float basePoints = 100.0f; // Initial points value
    private float currentPoints;
    private float pointsPerSecond;
    private float timeSinceLastIncrease = 0.0f;
    private float timeSinceStart = 0.0f;

    private void Start()
    {
        currentPoints = basePoints;
    }

    private void Update()
    {
        timeSinceLastIncrease += Time.deltaTime;
        timeSinceStart += Time.deltaTime;

        // Calculate the points increase per second based on time
         pointsPerSecond = CalculatePointsPerSecond();

        // Add points based on time passed and points per second
        currentPoints += pointsPerSecond * Time.deltaTime;

        // Check if 0.5 minutes have passed
        if (timeSinceLastIncrease >= 30.0f)
        {
            currentPoints *= 1.25f; // Multiply by 25%
            timeSinceLastIncrease = 0.0f; // Reset the timer
         //   Debug.Log("Multiply x 25% : " + pointsPerSecond);
        }

        // Check if 5 minutes have passed
        if (timeSinceLastIncrease >= 300.0f)
        {
            currentPoints *= 1.5f; // Multiply by 50%
            timeSinceLastIncrease = 0.0f; // Reset the timer
        //    Debug.Log("Multiply x 10 : " + pointsPerSecond);
        }

       // Debug.Log(pointsPerSecond);
    }

    private float CalculatePointsPerSecond()
    {
        // Points increase per second based on timeSinceStart, this always gives false
        float basePointsPerSecond = 2.5f + (timeSinceStart <= 0.0f ? 2f : Mathf.Min((timeSinceStart - 60.0f) / 60.0f, 3.0f));
        
        // Points increase per second Magic on 3minutes
        if (timeSinceStart > 15.0f)
        {
            // Random points increase between 1x and 5x per second after 3 minutes
            float randomMultiplier = Random.Range(1.0f, 3.0f);
            // basePointsPerSecond *= randomMultiplier;
             basePointsPerSecond *= 5;
         //   Debug.Log("Random Magic x : " + randomMultiplier);
         //   Debug.Log(basePointsPerSecond);
        }
        if (timeSinceStart > 25.0f)
        {
            // Random points increase between 1x and 5x per second after 3 minutes
            float randomMultiplier = Random.Range(1.0f, 3.0f);
            // basePointsPerSecond *= randomMultiplier;
            basePointsPerSecond *= 10;
         //   Debug.Log("Random Magic x : " + randomMultiplier);
          //  Debug.Log(basePointsPerSecond);
        }

        return basePointsPerSecond;
    }

    public float GetCurrentPoints()
    {
        return currentPoints;
    }
    public float GetCurrentPointsPerSecond()
    {
        return pointsPerSecond;
    }
}





