using UnityEngine;
using TMPro;

public class PointsDisplay : MonoBehaviour
{
    public PointsManager PointsManager;
    public TMP_Text pointsText; // Use TMP_Text instead of Text

    private void Update()
    {
        if (PointsManager == null)
        {
            Debug.LogError("PointsManager is not assigned!");
            return;
        }

        float currentPoints = PointsManager.GetCurrentPoints();
        float pointsPerSecond = PointsManager.GetCurrentPointsPerSecond();
        pointsText.text = "Points " + currentPoints.ToString("F2") + "x" + pointsPerSecond.ToString("F2");
    }
}