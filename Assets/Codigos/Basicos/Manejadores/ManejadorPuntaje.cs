using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace CompleteProject
{
    public class ManejadorPuntaje : MonoBehaviour
    {
        public static int puntaje;        // The player's score.


        Text text;                      // Reference to the Text component.


        void Awake ()
        {
            // Set up the reference.
            text = GetComponent <Text> ();

            // Reset the score.
			puntaje = 0;
        }


        void Update ()
        {
            // Set the displayed text to be the word "Score" followed by the score value.
			text.text = "Puntaje: " + puntaje;
        }
    }
}