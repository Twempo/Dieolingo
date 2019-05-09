using UnityEngine;

public class Interactable : MonoBehaviour
{
    private float radius = 3f;
    public Item itemData;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public bool isItem()
    {
        if (itemData != null)
            return true;
        return false;
    }
    public bool isDoor()
    {
        return false;
    }
}
