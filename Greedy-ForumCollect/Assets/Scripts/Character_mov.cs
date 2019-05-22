using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Character_mov : MonoBehaviour {

    GameOver GameOverScene;
    //Initial variables
    private Vector2 direction = Vector2.zero;
    private Vector2 InitialPosition;
    private float currentHealth;
    private bool SuperSpeedOn = false;
    private bool Invencibility = false;
    private bool PowerUpUsed = false;
    private bool damaged = false;


    int life;

    [Header("Physics")]
    Rigidbody2D rb;
    Animator animations;

    private readonly float PrevRunSpeed = 0.7f;
    public float RunSpeed;
    public Map map;

    public GameObject Lifes;
    public GameObject Foods;
    public Interactable focus;
    public HealthBar healthBar;
    public FruitsText fruitText;
    public Item FoodFocus;

    [Header("Character Sounds")]
    public AudioClip explosionSound;
    public AudioSource walkingSoundEffect;
    public AudioClip eatingSound;
    public AudioClip hurtSound;

    [Header("Powers")]
    public Powers powers;

    public void damagedByTrap()
    {
        currentHealth = healthBar.getSize();
        
        //Hurt(0.333f);
        Invoke("StopDying", 1.5f);
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
        currentHealth = 0f;
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
            if (FoodFocus != null && FoodFocus.CompareTag("Food"))
            {
                FruitSpawner fruit = FoodFocus.GetComponent<FruitSpawner>();
                OnMusicPlaying(eatingSound);
                fruitText.fruitConsumed();
                CaloriesScript.caloriesValue += fruit.calories;
                map.addLevelScore((float)fruit.calories);

                if (CaloriesScript.caloriesValue >= 100) { healthBar.setSize(healthBar.getSize() - 0.1f); CaloriesScript.caloriesValue = 0; }

                FoodFocus.Interact();
                RemoveFocus();
            }
            /*if(focus != null && focus.CompareTag("Power-Up"))
            {
                PowerUpUsed = true;
                if(focus.name == "Boots")
                {
                    Powers power = focus.GetComponent<Powers>();
                    power.Activate();
                    SuperSpeedOn = true;
                    map.BootsUI.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);

                    focus.gameObject.SetActive(false);
                    focus.Interact();
                    RemoveFocus();
                    Invoke("SPOff", 5f);
                }

                else if(focus.name == "Shield")
                {
                    Powers power = focus.GetComponent<Powers>();
                    power.Activate();
                    powers.invencibility = true;
                    map.ShieldUI.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);

                    focus.gameObject.SetActive(false);
                    focus.Interact();
                    RemoveFocus();
                }
                
            }*/

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
            if (!SuperSpeedOn)
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
            Debug.Log(newFocus.name);
            //SetFocus(newFocus);
            focus = newFocus;
            if (newFocus.name == "Boots")
            {
                Powers power = newFocus.GetComponent<Powers>();
                power.Activate();
                SuperSpeedOn = true;
                map.BootsUI.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);

                newFocus.gameObject.SetActive(false);
                newFocus.Interact();
                RemoveFocus();
                Invoke("SPOff", 5f);
            }

            else if (newFocus.name == "Shield")
            {
                Powers power = newFocus.GetComponent<Powers>();
                power.Activate();
                powers.invencibility = true;
                map.ShieldUI.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);

                newFocus.gameObject.SetActive(false);
                newFocus.Interact();

            }
        }
    }

    public void Hurt(float damage)
    {
        currentHealth += damage;
        healthBar.setSize(currentHealth);
        OnMusicPlaying(hurtSound);
        animations.SetBool("IsHurting", true);
        Debug.Log(currentHealth.ToString());
        if (currentHealth >= 1)
        {
            Respawn();
        }
        else
        {            
            Invoke("StopDying", 1f);
        }
        

    }
    void Die()
    {
        Hurt(0f);
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
            currentHealth = 0f;
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

    public void LifeUp()
    {
        if(life < 3)
        {
            currentHealth = 0f;
            healthBar.setSize(currentHealth);
            Lifes.transform.Find("Life_" + (4 - life + 1).ToString()).gameObject.SetActive(true);
            life++;
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
            float distance = Vector3.Distance(transform.position, focus.transform.position);
            if (distance - 1f > focus.radius)
            {
                RemoveFocus();
            }
        }
        if(FoodFocus != null)
        {
            float distance = Vector3.Distance(transform.position, FoodFocus.transform.position);
            Debug.Log(distance.ToString());
            if (distance -5f > FoodFocus.radius * 2)
            {
                FoodFocus.onDefocused();
                FoodFocus = null;
            }
        }
    }
    private void OnMusicPlaying(AudioClip clip) {
        SoundManager.instance.PlaySingle(clip);
    }

    void SPOff()
    {
        RunSpeed = PrevRunSpeed;
        SuperSpeedOn = false;
        animations.SetBool("IsRunning", false);
        map.BootsUI.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
    }

    public bool getPowerUpUsed()
    {
        return PowerUpUsed;
    }

    public bool getDamaged()
    {
        return damaged;
    }
}
