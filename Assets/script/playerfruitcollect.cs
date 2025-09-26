 using TMPro;
 using UnityEngine;

public class playerfruitcollect : MonoBehaviour
{
    public int fruitCollected = 0;

    public TextMeshProUGUI fruitText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Fruit")) return;
        fruitCollected++;
        fruitText.text = fruitCollected.ToString();

        Destroy(other.gameObject);
    }
}
