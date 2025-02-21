using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Sousmarin : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void OnMouvement(InputValue directionBase)
    {
        Vector3 directionInput = directionBase.Get<Vector3>();

        _animator.SetFloat("Deplacement", directionInput.magnitude);

    }
}









   