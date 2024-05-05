using UnityEngine;

public class LootDrop : MonoBehaviour
{
    public static void Drop(string LootToDrop, GameObject DropLocation)
    {
        ObjectPooler.Instance.SpawnFromPool(LootToDrop, new Vector2 (DropLocation.transform.position.x, DropLocation.transform.position.y + 1));
    }

    public static void Drop(string LootToDrop, GameObject DropLocation, int numberOfDrops)
    {
        for (int i = 0; i < numberOfDrops; i++)
        {
            float randomLocation = Random.value;
            ObjectPooler.Instance.SpawnFromPool(LootToDrop, new Vector2(DropLocation.transform.position.x + randomLocation, DropLocation.transform.position.y + 1 + randomLocation));
        }
    }
}
