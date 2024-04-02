using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIPoints : MonoBehaviour
{
    int displayedPoints = 0;
    public TextMeshProUGUI pointsLabel;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnPointsUpdated.AddListener(UpdatePoints);
    }

    // Update is called once per frame
    void UpdatePoints()
    {
        StartCoroutine(UpdatePointsCoroutine());
    }

    IEnumerator UpdatePointsCoroutine()
    {
        while (displayedPoints < GameManager.Instance.Points)
        {
            displayedPoints++;
            pointsLabel.text=displayedPoints.ToString();
            yield return new WaitForSeconds(0.1f);
        }
        yield return null;
    }
}
