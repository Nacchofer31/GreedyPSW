using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character_mov : MonoBehaviour {

    GameOver GameOverScene;
    //Initial variables
    private Vector2 direction = Vector2.zero;
    private Vector2 InitialPosition;
    private float currentHealth;
    

    int life;

    [Header("Physics")]
    Rigidbody2D rb;
    Animator animations;

    public float RunSpeed = 0.5f;
    public Map map;

    public GameObject Lifes;
    public GameObject Foods;
    public Interactable focus;
    public HealthBar healthBar;
    public AudioSource walkingSoundEffect;
    public AudioClip eatingSound;

    [Header("Powers")]
    public Powers powers;

    public void damagedByTrap()
    {
        currentHealth = healthBar.getSize();
        healthBar.setSize(currentHealth + 0.3333f);
        Hurt();
        Invoke("StopDying", 1f);
    }

    void Start()
    {
        walkingSoundEffect.pitch = 1.5f;
        animations = gameObject.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        InitialPosition = rb.position;
        life = 3;
        healthBar.setSize(0f);
        powers = new Powers();
    }

    void Update()
    {
        Tecla();

        Orientation();

        Move();

        FocusOut();
    }

    void Tecla()
    {
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction = Vector2.up;
            
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            direction = Vector2.down;
            
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = Vector2.right;
            
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        { 
            direction = Vector2.left;
            
        }

        else if (Input.GetKey(KeyCode.Space))
        {
            if (focus != null && focus.CompareTag("Food"))
            {
                FruitSpawner fruit = focus.GetComponent<FruitSpawner>();
                OnMusicPlaying(eatingSound);
                CaloriesScript.caloriesValue += fruit.calories;

                if (CaloriesScript.caloriesValue >= 100) { healthBar.setSize(healthBar.getSize() - 0.1f); CaloriesScript.caloriesValue = 0; }

                focus.Interact();
                RemoveFocus();
            }

        }

        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(!powers.invencibility)
            {
                powers.StartInvulnerable();
                Debug.Log("Invecibility ON");
            }
            else
            {
                powers.StopInvulnerable();
                Debug.Log("Invecibility OFF");
            }
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (!powers.superSpeed)
            {
                RunSpeed += powers.StartSuperSpeed();
                Debug.Log("SuperSpeed ON");
            }
            else
            {
                RunSpeed += powers.StopSuperSpeed();
                Debug.Log("SuperSpeed OFF");
            }
        }

        else
        {
            direction = Vector2.zero;
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if(!map.IsPaused && direction != Vector2.zero)
        {
            transform.localPosition += (Vector3)(direction * RunSpeed) * Time.deltaTime;
            direction = Vector2.zero;
            if(!powers.superSpeed)
            {
                walkingSoundEffect.pitch = 1.5f;
                animations.SetBool("IsMoving", true);
            }
            else
            {
                walkingSoundEffect.pitch = 2.5f;
                animations.SetBool("IsRunning", true);
            }
            GetComponent<AudioSource>().UnPause();
            
        }

        else
        {
            if(!powers.superSpeed)
            {
                animations.SetBool("IsMoving", false);
            }
            else
            {
                animations.SetBool("IsRunning", false);
            }
            GetComponent<AudioSource>().Pause();

        }
        
    }

    void Orientation()
    {
        if (!map.IsPaused)
        {

            if (direction == Vector2.right)
            {
                transform.localScale = new Vector3(0.23215f, 0.23215f, 1);
            }

            else if (direction == Vector2.left)

            {
                transform.localScale = new Vector3(-0.23215f, 0.23215f, 1);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if(!powers.invencibility)
            {
                powers.StartInvulnerable();
                Die();
                healthBar.setSize(0f);
            }

            else
            {
                enemy_ia Enemy = (enemy_ia) other.gameObject.GetComponent<enemy_ia>();
                KillEnemy(Enemy);
            }
                
        }

       /**if (other.gameObject.CompareTag("ExplodingTrap")) {
           if (!powers.invencibility)
            {
                Hurt();
                currentHealth = healthBar.getSize();
                if (currentHealth == 1f) {
                    Lifes.transform.Find("Life_" + (4 - life).ToString()).gameObject.SetActive(false);
                    life--;
                }
                healthBar.setSize(currentHealth + 0.3333f);
                Move();
                
            }

        }**/

        if (other.gameObject.CompareTag("Food"))
        {
            Interactable newFocus = other.GetComponent<Fruit>();
            SetFocus(newFocus);
        }
    }
    void Hurt()
    {
        animations.SetBool("IsHurting", true);
    }
    void Die()
    {
        Hurt();
        Respawn();
        powers.StopInvulnerable();
    }

    void KillEnemy(enemy_ia other)
    {
        other.Restart();
    }

    void Respawn()
    {
        if(life > 1)
        {
            Lifes.transform.Find("Life_" + (4-life).ToString()).gameObject.SetActive(false);
            life--;
            
            rb.transform.position = InitialPosition;
            Invoke("StopDying", 1f);
        }
        else
        {
            Debug.Log("You Died");
            CaloriesScript.caloriesValue = 0;
            PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("GameOver");
        }
        
    }

    void StopDying()
    {
        animations.SetBool("IsHurting", false);
    }

    void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if(focus != null)
            {
                focus.onDefocused();
            }
            focus = newFocus;
        }
        newFocus.onFocused(transform);
        

    }

    void RemoveFocus()
    {
        if (focus != null)
        {
            focus.onDefocused();
        }

        focus = null;
    }

    void FocusOut()
    {
        if(focus != null)
        {
            float distance = Vector3.Distance(rb.transform.position, focus.transform.position);
            if (distance - 1f > focus.radius)
            {
                RemoveFocus();
            }
        }
    }
    private void OnMusicPlaying(AudioClip clip) {
        SoundManager.instance.PlaySingle(clip);
    }

}
