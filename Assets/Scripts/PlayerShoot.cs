using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    ObjectPooler objectPooler;

    public static int maxOrbs = 2;
    public static int activeOrbs = 0;

    bool isFiring = false;

    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isFiring = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isFiring = false;
        }
    }

    private void FixedUpdate()
    {
        if (isFiring && activeOrbs < maxOrbs)
        {
            SpawnOrb();
            //************* Send the message to the client...
            OSCHandler.Instance.SendMessageToClient ("pd", "/unity/fire", 1);
            //*************
        }
    }

    void SpawnOrb()
    {
        objectPooler.SpawnFromPool("Orb", transform.position);
        activeOrbs++;
        isFiring = false;
    }
}
