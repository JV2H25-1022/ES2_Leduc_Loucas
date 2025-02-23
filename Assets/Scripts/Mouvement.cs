using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Vitesse de déplacement du personnage
    public float moveSpeed = 5f;

    // Référence au Rigidbody pour appliquer la physique
    private Rigidbody rb;

    // Direction du déplacement
    private Vector3 moveDirection;

    void Start()
    {
        // Récupère la référence au Rigidbody attaché au personnage
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Récupère les entrées de l'utilisateur pour le déplacement
        float horizontal = Input.GetAxis("Horizontal"); // A, D ou flèches gauche/droite
        
        float vertical = Input.GetAxis("Vertical"); // W, S ou flèches haut/bas



        // Calcul de la direction de mouvement
        moveDirection = new Vector3(horizontal, 0f, vertical).normalized;
    }

    void FixedUpdate()
    {
        // Déplace le personnage en fonction de la direction et de la vitesse
        rb.MovePosition(transform.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }
}
