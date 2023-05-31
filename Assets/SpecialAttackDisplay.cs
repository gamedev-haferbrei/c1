using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SpecialAttackDisplay : MonoBehaviour
{
    [SerializeField] Image fill;
    [SerializeField] InputAction attackControls;
    [SerializeField] float cooldownLength = 1f;
    [SerializeField] UnityEvent attackAction;

    float cooldownTimer = 0f;

    private void OnEnable()
    {
        attackControls.Enable();
        attackControls.performed += DoAttack;
    }

    private void OnDisable()
    {
        attackControls.Disable();
    }

    void DoAttack(InputAction.CallbackContext ctx)
    {
        if (cooldownTimer > 0f) return;
        cooldownTimer = 1f;
        attackAction.Invoke();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer = Mathf.Max(0f, cooldownTimer - Time.deltaTime);
        fill.fillAmount = cooldownTimer / cooldownLength;
    }
}
