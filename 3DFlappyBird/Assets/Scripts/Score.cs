using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    void Update() => GetComponent<TMP_Text>().SetText(movement.score.ToString());
}
