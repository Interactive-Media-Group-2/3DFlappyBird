using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    void Update() => GetComponent<TMP_Text>().SetText("High Score: " + movement.highscore.ToString());
}
