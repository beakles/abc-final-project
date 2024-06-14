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

                OSCHandler.Instance.SendMessageToClient ("pd", "/unity/note_d", 1);
                OSCHandler.Instance.SendMessageToClient ("pd", "/unity/note_e", 1);
                OSCHandler.Instance.SendMessageToClient ("pd", "/unity/note_f", 1);
            }

            gameObject.SetActive(false);

            if (GameMultiplier.gameTempo <= 120) {
                OSCHandler.Instance.SendMessageToClient ("pd", "/unity/drum_heavy", 1);
            } 
            
            if (GameMultiplier.gameTempo <= 110) {
                OSCHandler.Instance.SendMessageToClient ("pd", "/unity/note_c", 1);
                OSCHandler.Instance.SendMessageToClient ("pd", "/unity/note_g", 1);
                OSCHandler.Instance.SendMessageToClient ("pd", "/unity/note_a", 1);
            }

            //************* Send the message to the client...
            OSCHandler.Instance.SendMessageToClient ("pd", "/unity/one_timbre", GameMultiplier.oneTimbre);
            //*************

            //************* Send the message to the client...
            OSCHandler.Instance.SendMessageToClient ("pd", "/unity/tempo", GameMultiplier.gameTempo);
            //*************

            //************* Send the message to the client...
            OSCHandler.Instance.SendMessageToClient ("pd", "/unity/puff", 1);
            //*************
        }
    }
}
