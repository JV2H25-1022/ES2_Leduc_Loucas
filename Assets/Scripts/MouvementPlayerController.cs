using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouvementPlayerController : MonoBehaviour
{
    [SerializeField]
    private Vector3 deplacement;
    private SousMarinControl sousMarinControl;
    private Rigidbody rb_;

    public float vitesse = 5f; 
    public float sprintVitesse = 10f;
    public float walkVitesse = 5f; 

    private float currentVitesse; 
   

    private void Awake()
    {
        sousMarinControl = new SousMarinControl();

        sousMarinControl.Player.Mouvement.performed += LireDeplacement;
        sousMarinControl.Player.Mouvement.canceled += LireDeplacement;

        sousMarinControl.Player.Sprint.performed += OnSprint;
        sousMarinControl.Player.Sprint.canceled += OnSprint; 
    }

    private void OnEnable()
    {
        sousMarinControl.Player.Enable();
    }

    private void OnDisable()
    {
        sousMarinControl.Player.Disable();
    }

  
    private void OnSprint(InputAction.CallbackContext context)
    {
      
        bool isSprinting = context.ReadValue<float>() > 0.5f;

        if (isSprinting)
        {
          
            Debug.Log("Sprint activé");
            currentVitesse = Mathf.Lerp(currentVitesse, sprintVitesse, smoothTime);
        }
        else
        {
            
            Debug.Log("Sprint désactivé");
            currentVitesse = Mathf.Lerp(currentVitesse, walkVitesse, smoothTime);
        }
    }

    void Start()
    {
        rb_ = GetComponent<Rigidbody>();
        currentVitesse = walkVitesse; 
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

        // Calcul du mouvement avec la vitesse actuelle (qui peut changer en fonction du sprint)
        Vector3 mouvement = new Vector3(deplacement.x, deplacement.y, deplacement.z);
        Debug.Log("Movement input: " + mouvement);

        // Déplacement du sous-marin avec la vitesse actuelle
        rb_.MovePosition(rb_.position + mouvement * currentVitesse * Time.deltaTime);
    }
}
