using UnityEngine;

namespace CompleteProject
{
    public class ManejadorGameOver : MonoBehaviour
    {
		public SaludJugador saludJugador;       // Reference to the player's health.


        Animator anim;                          // Reference to the animator component.


        void Awake ()
        {
            // Set up the reference.
            anim = GetComponent <Animator> ();
        }


        void Update ()
        {
            // If the player has run out of health...
			if(saludJugador.saludActual <= 0)
            {
                // ... tell the animator the game is over.
                anim.SetTrigger ("GameOver");
            }
        }
    }
}