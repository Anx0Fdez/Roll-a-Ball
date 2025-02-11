using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    // Referencia al transform del jugador.
    public Transform player;

    // Referencia al componente NavMeshAgent para la búsqueda de caminos.
    private NavMeshAgent navMeshAgent;

    // Start es llamado antes de la primera actualización del frame.
    void Start()
    {
        // Obtiene y almacena el componente NavMeshAgent adjunto a este objeto.
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update es llamado una vez por cada frame.
    void Update()
    {
        // Si hay una referencia al jugador...
        if (player != null)
        {
            // Establece el destino del enemigo a la posición actual del jugador.
            navMeshAgent.SetDestination(player.position);
        }
    }
}