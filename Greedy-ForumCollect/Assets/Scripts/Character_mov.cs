using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Character_mov : MonoBehaviour {

    [Header("Interactions")]
    public Map map;

    [Header("UI")]
    public GameObject Lifes;
    public GameObject Foods;
    public Interactable focus;
    public HealthBar healthBar;
    public FruitsText fruitText;
    public CaloriesScript caloriesScript;
    public Item FoodFocus, PowerUp;

    [Header("Character Sounds")]
    public AudioClip explosionSound;
    public AudioSource walkingSoundEffect;
    public AudioClip eatingSound;
    public AudioClip hurtSound;

    [Header("Powers")]
    private Powers powers;

    [Header("Initial Variables")]
    public float RunSpeed = 0.7f;
    private int numLifes = 3;
    public readonly float PrevRunSpeed = 0.7f;
    private float currentHealth;

    [Header("Movement")]
    private Vector2 direction = Vector2.zero;
    private Vector2 InitialPosition;

    [Header("Physics")]
    Rigidbody2D rb;
    public Animator animations;

    [Header("Scenes")]
    private GameOver GameOverScene;

    [Header("State")]
    private State currentState;
    public bool SuperSpeedOn = false;
    private bool PowerUpUsed = false;
    private bool damaged = false;

    public bool GetPowerUpUsed()
    {
        return PowerUpUsed;
    }

    public bool GetDamaged()
    {
        return damaged;
    }

    public void LifeUp()
    {
        if (numLifes < 3)
        {
            RestartHealth();
            Lifes.transform.Find("Life_" + (numLifes + 1).ToString()).gameObject.SetActive(true);
            numLifes++;
        }
    }

    public int getLifes()
    {
        return numLifes;
    }

    public float getCurrentHealth()
    {
        return currentHealth;
    }

    public void Hurt(float damage)
    {
        currentHealth += damage;
        if (healthBar != null)
        {
            healthBar.setSize(currentHealth);
            OnMusicPlaying(hurtSound);
            animations.SetBool("IsHurting", true);
            if (currentHealth >= 1)
            {
                Respawn();
            }
            else
            {
                Invoke("StopDying", 1f);
            }
        }
    }

    public void IncrementRunSpeed(float increment)
    {
        RunSpeed += increment;
    }

    public void Start()
    {       
        walkingSoundEffect.pitch = 1.5f;
        animations = gameObject.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        InitialPosition = rb.position;
        RestartHealth();
        powers = new Powers();
        setState(new NormalState(this));
    }

    public void setState(State state)
    {
        if(currentState!= null) { currentState.OnStateEnter(); }

        currentState = state;

        if (currentState != null) { currentState.OnStateExit(); }
    }

    public void Tecla()
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
                map.OnFruitConsumed();
                map.OnCaloriesAdded(fruit.calories);
                map.AddLevelScore((float)fruit.calories);

                int actualCalories = caloriesScript.GetCalories();
                if (actualCalories >= 100)
                {
                    healthBar.setSize(healthBar.getSize() - 0.1f);
                    caloriesScript.SetCalories(0);
                }

                focus.Interact();
                RemoveFocus();
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

    public void Move()
    {
        if(!map.IsPaused && direction != Vector2.zero)
        {
            transform.localPosition += (Vector3)(direction * RunSpeed) * Time.deltaTime;
            direction = Vector2.zero;
            if(!SuperSpeedOn)
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
            if(!SuperSpeedOn)
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

    public void Orientation()
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

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if(!powers.invencibility)
            {
                powers.StartInvulnerable();
                Die();
                RestartHealth();
            }

            else
            {
                enemy_ia Enemy = (enemy_ia) other.gameObject.GetComponent<enemy_ia>();
                KillEnemy(Enemy);
                powers.invencibility = false;
                map.ShieldUI.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
            }               
        }

       if (other.gameObject.CompareTag("ExplodingTrap")) {
            damaged = true;
            if (!powers.invencibility)
            {
                OnMusicPlaying(explosionSound);               
            }
        }

        if (other.gameObject.CompareTag("Food"))
        {
            Interactable newFocus = other.GetComponent<Item>();
            SetFocus(newFocus);
            focus = newFocus;
        }

        if(other.gameObject.CompareTag("Fire"))
        {
            map.FireUI.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        }

        if (other.gameObject.CompareTag("Power-Up"))
        {
            Item newFocus = other.GetComponent<Item>();
            PowerUp = other.GetComponent<Item>();
            focus = newFocus;

            if (newFocus.name == "Heart")
            {
                Powers power = newFocus.GetComponent<Powers>();
                if (numLifes < 3)
                {
                    numLifes++;
                    Lifes.transform.Find("Life_" + (4 - numLifes).ToString()).gameObject.SetActive(true);
                    newFocus.gameObject.SetActive(false);
                    newFocus.Interact();
                    RemoveFocus();
                }               
            }
        }
    }

    public void KillEnemy(enemy_ia other)
    {
        other.Restart();
    }

   public void Update()
    {
        Tecla();

        Orientation();

        Move();

        FocusOut();

        currentState.CheckPower();
    }

    void Die()
    {
        Hurt(0f);
        Respawn();
        powers.StopInvulnerable();
    }

    void Respawn()
    {
        if(numLifes > 1)
        {
            RestartHealth();
            Lifes.transform.Find("Life_" + (4-numLifes).ToString()).gameObject.SetActive(false);
            numLifes--;
            
            rb.transform.position = InitialPosition;
            Invoke("StopDying", 1f);
        }

        else
        {
            caloriesScript.SetCalories(0);
            PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("GameOver");
        }       
    }

    void RestartHealth()
    {
        currentHealth = 0f;
        healthBar.setSize(0f);
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

    public void RemoveFocus()
    {
        if (focus != null)
        {
            focus.onDefocused();
        }

        focus = null;
    }

    public void FocusOut()
    {
        if(focus != null)
        {
            float distance = Vector3.Distance(transform.position, focus.transform.position);

            if (distance - 1f > focus.radius)
            {
                RemoveFocus();
            }
        }

        if(FoodFocus != null)
        {
            float distance = Vector3.Distance(transform.position, FoodFocus.transform.position);
            if (distance -5f > FoodFocus.radius * 2)
            {
                FoodFocus.onDefocused();
                FoodFocus = null;
            }
        }
    }

    void OnMusicPlaying(AudioClip clip)
    {
        SoundManager.instance.PlaySingle(clip);
    }

    void SPOff()
    {
        RunSpeed = PrevRunSpeed;
        SuperSpeedOn = false;
        animations.SetBool("IsRunning", false);
        map.BootsUI.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
        setState(new NormalState(this));

    }

    void InvulOff()
    {
        map.ShieldUI.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
        powers.invencibility = false;
        setState(new NormalState(this));

    }

    public void SetAnimations()
    {
        animations.SetBool("IsRunning", true);
    }

    public void InvulOn()
    {
        powers.StartInvulnerable();
    }
}
