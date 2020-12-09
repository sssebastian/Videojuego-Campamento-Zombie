using UnityEngine;
using System.Collections;

namespace CompleteProject
{
    public class MovimientoEnemigo : MonoBehaviour
    {
        Transform jugador;               // Reference to the player's position.
        SaludJugador saludJugador;      // Reference to the player's health.
        SaludEnemigo saludEnemigo;        // Reference to this enemy's health.
        UnityEngine.AI.NavMeshAgent nav;               // Reference to the nav mesh agent.


        void Awake ()
        {
            // Set up the references.
            jugador = GameObject.FindGameObjectWithTag ("Player").transform;
			saludJugador = jugador.GetComponent <SaludJugador> ();
			saludEnemigo = GetComponent <SaludEnemigo> ();
            nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
        }


        void Update ()
        {
            // If the enemy and the player have health left...
			if(saludEnemigo.saludActual> 0 && saludJugador.saludActual > 0)
            {
                // ... set the destination of the nav mesh agent to the player.
				nav.SetDestination (jugador.position);
            }
            // Otherwise...
            else
            {
                // ... disable the nav mesh agent.
                nav.enabled = false;
            }
        }
    }
}