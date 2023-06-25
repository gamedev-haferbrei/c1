using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    [SerializeField] InputAction movementControls;
    [SerializeField] InputAction basicShootControls;
    [SerializeField] AudioManager audioManager;
    // For the special attack controls look at Special Attack UI in the hierarchy

    [SerializeField] WaveManager waveManager;

    [SerializeField] GameObject laserPrefab;
    [SerializeField] GameObject homingRocketPrefab;
    [SerializeField] GameObject specialLaser;
    [SerializeField] GameObject clonePrefab;
    [SerializeField] GameObject clonePrefabD;

    Vector2 moveDirection;
    Rigidbody2D rb;
    Transform tr;

    float timer = 0;

    private void OnEnable()
    {
        movementControls.Enable();
        basicShootControls.Enable();

        basicShootControls.performed += ctx => ShootLaser();
    }

    private void OnDisable()
    {
        movementControls.Disable();
        basicShootControls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = movementControls.ReadValue<Vector2>();
        if (basicShootControls.IsInProgress() && timer >= 0.5f)
        { 
            ShootLaser();
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDirection * moveSpeed;
    }

    public void ShootLaser()
    {
        Instantiate(laserPrefab, transform.position, Quaternion.Euler(0f, 0f, -90f));
        audioManager.LaserAudio();
    }

    public void ShootTripleLaser()
    {
        Instantiate(laserPrefab, transform.position + new Vector3(-0.3f, -0.3f), Quaternion.Euler(0f, 0f, -90f));
        Instantiate(laserPrefab, transform.position, Quaternion.Euler(0f, 0f, -90f));
        Instantiate(laserPrefab, transform.position + new Vector3(-0.3f, 0.3f), Quaternion.Euler(0f, 0f, -90f));
        audioManager.LaserAudio();
    }

    public void ShootHomingRocket()
    {
        Instantiate(homingRocketPrefab, transform.position, Quaternion.identity);
    }

    // This just kills the player in all cases, but maybe the player could have HP as well? Might get too complicated
    public void Damage(int damage)
    {
        GameObject particleManager = GameObject.FindWithTag("ParticleManager");
        ParticleSystem particleSystem = particleManager.GetComponent<ParticleSystem>();
        particleSystem.Play();
        audioManager.PlayerAudio();
        waveManager.GameOver();
    }

    public void SpecialAttack2 ()
    {
        //Instantiate(specialLaser, transform.position, Quaternion.identity);
        StartCoroutine(SpecialAttack2Doer());
    }

    public void BunshinNoJutsu()
    {
        StartCoroutine(SpawnClones());         
    }

    IEnumerator SpecialAttack2Doer()
    {
        //https://stackoverflow.com/questions/30056471/how-to-make-the-script-wait-sleep-in-a-simple-way-in-unity
        //Print the time of when the function is first called.
        Instantiate(specialLaser, transform.position, Quaternion.identity);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);

        //After we have waited 5 seconds print the time again.
        Instantiate(specialLaser, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1);
        Instantiate(specialLaser, transform.position, Quaternion.identity);
    }

    IEnumerator SpawnClones()
    {
        int i = 0;
        while (i < 3) 
        { 
            Instantiate(clonePrefab, transform.position, Quaternion.Euler(0f, 0f, -90f));
            Instantiate(clonePrefabD, transform.position, Quaternion.Euler(0f, 0f, -90f));
            i++;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
