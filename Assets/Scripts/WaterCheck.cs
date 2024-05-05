using UnityEngine;

public class WaterCheck : MonoBehaviour
{
    [SerializeField]
    private LayerMask waterLayerMask = 4;

    public bool isSwimming;

    private void OnTriggerStay2D(Collider2D collider)
    {
        isSwimming = collider != null && (((1 << collider.gameObject.layer) & waterLayerMask) != 0);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isSwimming = false;
    }
}
