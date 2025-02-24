using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class MouvementPlayerController : MonoBehaviour
{
    [SerializeField]
    private Vector3 deplacement;
    [SerializeField]
    private Vector3 deplacementVertical;
    private SousMarinControl sousMarinControl;
    private Rigidbody rb_;
    private void Awake()
    {
     sousMarinControl = new SousMarinControl();

     sousMarinControl.Player.Mouvement.performed += LireDeplacement;
    sousMarinControl.Player.Mouvement.canceled += LireDeplacement;

    }






    private void LireDeplacement(InputAction.CallbackContext context)
    {
        deplacement = context.ReadValue<Vector3>();
    }
    private void OnEnable()
    {
        sousMarinControl.Player.Enable();
    }

    private void OnDisable()
    {
        sousMarinControl.Player.Disable();
    }

 void Start()
 {

 }
  void Update()
 {
rb_.Translate(deplacement, x.Local);
 }
}
