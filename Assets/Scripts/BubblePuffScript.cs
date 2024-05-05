using UnityEngine;

public class BubblePuffScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameMultiplier.gameMultiplier += 0.5f;
            GameMultiplier.one_timbre += 0.05f;

            if (GameMultiplier.one_timbre > 0.9f) {
                GameMultiplier.one_timbre = 0.9f;
            }

            gameObject.SetActive(false);

            //************* Send the message to the client...
            OSCHandler.Instance.SendMessageToClient ("pd", "/unity/one_timbre", GameMultiplier.one_timbre);
            //*************
        }
    }
}
