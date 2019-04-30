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


}
