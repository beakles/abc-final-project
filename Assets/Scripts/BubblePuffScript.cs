using UnityEngine;

public class BubblePuffScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameMultiplier.gameMultiplier += 0.5f;
            GameMultiplier.oneTimbre += 0.05f;

            GameMultiplier.gameTempo -= 3;

            if (GameMultiplier.oneTimbre > 0.9f) {
                GameMultiplier.oneTimbre = 0.9f;
            }

            if (GameMultiplier.gameTempo < 100) {
                GameMultiplier.gameTempo = 100;
            }

            gameObject.SetActive(false);

            //************* Send the message to the client...
            OSCHandler.Instance.SendMessageToClient ("pd", "/unity/one_timbre", GameMultiplier.oneTimbre);
            //*************

            //************* Send the message to the client...
            OSCHandler.Instance.SendMessageToClient ("pd", "/unity/tempo", GameMultiplier.gameTempo);
            //*************
        }
    }
}
