using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public AudioSource source;
	public AudioClip DeathSound;
	public int Scene;
	public float speed;
	public float WalkSpeed;
	public float RunSpeed;
	public float rotationSpeed;
    public Transform carmeraTransform;
	public float Jumpheight;
	private float originalStepOffset;
	private Vector3 moveDirection;
	private Vector3 velocity;
    
	private CharacterController characterController;
	private Animator anim;
	public float health;
   

	
	private void Start()
	{
		characterController = GetComponent<CharacterController>();
		anim = GetComponentInChildren<Animator>();
		originalStepOffset = characterController.stepOffset;
	}

	private void Update()
	{
		Move();
	}
	private void Move()
	{
		if(characterController.isGrounded && velocity.y <0)
		{
			velocity.y = -2f;
		}
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		moveDirection = new Vector3(moveHorizontal, 0.0f, moveVertical);
        moveDirection = Quaternion.AngleAxis(carmeraTransform.rotation.eulerAngles.y,Vector3.up)*moveDirection;
			
		if(moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection,Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation,toRotation,rotationSpeed*Time.deltaTime);
        }

		if(characterController.isGrounded)
		{
			anim.SetBool("isGrounded", true);
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
			if(moveDirection !=Vector3.zero &&  !Input.GetKey(KeyCode.LeftShift))
			{
				Walk();
			}
			else if(moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
			{
				Run();
			}
			else if(moveDirection == Vector3.zero)
			{
				Idle();
			}
			
			if(Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded == true)
			{	
				velocity.y = Mathf.Sqrt(Jumpheight * -2  *Physics.gravity.y);
				anim.SetBool("isGrounded", false);
				anim.SetBool("isJumping", true);
			}
			moveDirection *=  speed;
		}
		else
		{
			if (velocity.y < 10)
            {
                anim.SetBool("isFalling", true);
				anim.SetBool("isJumping", false);
				anim.SetBool("isGrounded", false);
            }
		}
		characterController.Move(moveDirection*speed*Time.deltaTime);

		velocity.y += Physics.gravity.y*Time.deltaTime;

		characterController.Move(velocity *Time.deltaTime);
	}

	private void  Walk()
	{
		speed = WalkSpeed;
		anim.SetFloat("Movement",0.5f,0.1f,Time.deltaTime);  
	}

	private void Idle()
	{
		anim.SetFloat("Movement",0,0.1f,Time.deltaTime);
	}

	private void Run()
	{
		speed = RunSpeed;
		anim.SetFloat("Movement",1,0.1f,Time.deltaTime);
	}

	private void Jump()
	{
		anim.SetBool("isJumping", true);
		velocity.y = Mathf.Sqrt(Jumpheight * -2  *Physics.gravity.y);
	}

	public void Addhealth(float amounce)
    {
		health += amounce;
    }
    public void DiscreasedHealth(float amounce)
    {
        health -= amounce;
        if(health <= 0 )
        {
           	anim.SetBool("isDead",true);	
			StartCoroutine(PlayDeadSound());		
			StartCoroutine(WaitForSceneLoad());
        }
    }
	
	private IEnumerator PlayDeadSound() 
	{
		yield return new WaitForSeconds(1);
		source.clip = DeathSound;
        source.Play();
 	}

	private IEnumerator WaitForSceneLoad() 
	{
		yield return new WaitForSeconds(3);
		SceneManager.LoadScene(Scene); 
 	}

}