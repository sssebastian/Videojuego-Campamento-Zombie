using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace CompleteProject
{
	public class SaludJugador : MonoBehaviour
    {
        public int saludInicio = 100;                            // The amount of health the player starts the game with.
        public int saludActual;                                   // The current health the player has.
        public Slider barraSalud;                                 // Reference to the UI's health bar.
        public Image imagenDano;                                   // Reference to an image to flash on the screen on being hurt.
        public AudioClip clipMuerte;                                 // The audio clip to play when the player dies.
        public float velocidadFlash = 5f;                               // The speed the damageImage will fade at.
        public Color colorFlash = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.


        Animator anim;                                              // Reference to the Animator component.
        AudioSource playerAudio;                                    // Reference to the AudioSource component.
        MovimientoJugador playerMovement;                              // Reference to the player's movement.
        DisparoJugador playerShooting;                              // Reference to the PlayerShooting script.
        bool isDead;                                                // Whether the player is dead.
        bool damaged;                                               // True when the player gets damaged.


        void Awake ()
        {
            // Setting up the references.
            anim = GetComponent <Animator> ();
            playerAudio = GetComponent <AudioSource> ();
            playerMovement = GetComponent <MovimientoJugador> ();
            playerShooting = GetComponentInChildren <DisparoJugador> ();

            // Set the initial health of the player.
            saludActual = saludInicio;
        }


        void Update ()
        {
            // If the player has just been damaged...
            if(damaged)
            {
                // ... set the colour of the damageImage to the flash colour.
                imagenDano.color = colorFlash;
            }
            // Otherwise...
            else
            {
                // ... transition the colour back to clear.
                imagenDano.color = Color.Lerp (imagenDano.color, Color.clear, velocidadFlash * Time.deltaTime);
            }

            // Reset the damaged flag.
            damaged = false;
        }


        public void TakeDamage (int amount)
        {
            // Set the damaged flag so the screen will flash.
            damaged = true;

            // Reduce the current health by the damage amount.
            saludActual -= amount;

            // Set the health bar's value to the current health.
            barraSalud.value = saludActual;

            // Play the hurt sound effect.
            playerAudio.Play ();

            // If the player has lost all it's health and the death flag hasn't been set yet...
            if(saludActual <= 0 && !isDead)
            {
                // ... it should die.
                Death ();
            }
        }


        void Death ()
        {
            // Set the death flag so this function won't be called again.
            isDead = true;

            // Turn off any remaining shooting effects.
            playerShooting.DisableEffects ();

            // Tell the animator that the player is dead.
            anim.SetTrigger ("Die");

            // Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).
            playerAudio.clip = clipMuerte;
            playerAudio.Play ();

            // Turn off the movement and shooting scripts.
            playerMovement.enabled = false;
            playerShooting.enabled = false;
        }


        public void RestartLevel ()
        {
            // Reload the level that is currently loaded.
            Application.LoadLevel (Application.loadedLevel);
        }
    }
}