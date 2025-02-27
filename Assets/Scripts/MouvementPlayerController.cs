using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouvementPlayerController : MonoBehaviour
{
    [SerializeField]
    private Vector3 deplacement;
    [SerializeField]
    //private Vector3 deplacementVertical;
    private SousMarinControl sousMarinControl;
    private Rigidbody rb_;

    public float vitesse = 5f; // Vitesse de déplacement
     public float sprintVitesse = 10f;

     public float walkVitesse = 5f;

     public bool isSprintOn = false;

    private void Awake()
    {
        sousMarinControl = new SousMarinControl();

        sousMarinControl.Player.Mouvement.performed += LireDeplacement;
        sousMarinControl.Player.Mouvement.canceled += LireDeplacement;

       sousMarinControl.Player.Sprint.performed += ActiverSprint;
       sousMarinControl.Player.Sprint.canceled += DesactiverSprint;
    }

    private void OnEnable()
    {
        sousMarinControl.Player.Enable();
    }

    private void OnDisable()
    {
        sousMarinControl.Player.Disable();
    }

private void ActiverSprint(InputAction.CallbackContext context)
{
    // Dès que l'utilisateur appuie sur Shift, on active le sprint
    vitesse = sprintVitesse;
    
}

private void DesactiverSprint(InputAction.CallbackContext context)
{
    // Dès que l'utilisateur relâche Shift, on rétablit la vitesse normale
    vitesse = walkVitesse;
 
}


    void Start()
    {
        rb_ = GetComponent<Rigidbody>();
    }

    private void LireDeplacement(InputAction.CallbackContext context)
    {
        deplacement = context.ReadValue<Vector3>();
    }

    void Update()
    {
        if (rb_ == null)
        {
            Debug.LogError("Rigidbody component is missing");
            return;
        }

        if (sousMarinControl == null)
        {
            Debug.LogError("SousMarinControl class is missing");
            return;
        }

        Vector3 mouvement = new Vector3(deplacement.x, deplacement.y, deplacement.z);
        Debug.Log("Movement input: " + mouvement);
        rb_.MovePosition(rb_.position + mouvement * vitesse * Time.deltaTime);
    }
}