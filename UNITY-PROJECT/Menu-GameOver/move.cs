using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class move : MonoBehaviour {
	public GameObject target;
	public GameObject player;
	public GameObject player_2;
	private Mob_Ressources TargetScript;
	private Player_Ressources playerscript;
	private bool Move; 
	private bool Dead;

	private Animation animation;
	public float look_sens = 7f;
	public float y_rotation;
	public float jumpSpeed = 8f;
	public float gravity = 20f;
	private Vector3 moveDirection = Vector3.zero;
	public Camera maincamera;
	public Camera secondcamera;
	public Slider slider;
	public float val = 0;

	// Use this for initialization
	void Start ()
	{
		Dead = false;
		Move = true;
		player = GameObject.FindGameObjectWithTag("CraftSystem");
		player_2 = GameObject.FindGameObjectWithTag("Player");
		playerscript = player.GetComponent<Player_Ressources> ();
		Screen.lockCursor = true;
		animation = GetComponent<Animation> ();
		maincamera = Camera.main;
		secondcamera = (Camera)GameObject.Find ("first_view").GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if ((Move == true) && (Dead == false)) {
			Ray ray = maincamera.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 1 << LayerMask.NameToLayer ("EnnemyHitBox"))) {
				Debug.DrawRay (ray.origin, ray.direction * 1, Color.red);
				if ((hit.collider.GetComponent<Collider> ().tag == "EnnemyHitBox") && (hit.distance < 2f && hit.distance > 1f)) {
					print ("a portee");
					target = hit.collider.transform.parent.gameObject;
					TargetScript = target.GetComponent<Mob_Ressources> ();
				} else {
					target = null;
					TargetScript = null; 
				}
			}
			if (slider != null && slider.value > 0)
				slider.value = val--;
			y_rotation -= Input.GetAxis ("Mouse X") * look_sens;
			transform.rotation = Quaternion.Euler (0f, -y_rotation, 0f);
			CharacterController controller = GetComponent<CharacterController> ();
			if (controller.isGrounded) {
				if (Input.GetKeyDown (KeyCode.Space)) {
					GetComponent<Animation> ().CrossFade ("Jump1"); 
					transform.Translate (0f, 1f * Time.deltaTime * 3f, 0f);
				}
			}
			if (Input.GetKeyDown (KeyCode.C)) {
				ChangeView ();
			}
			moveDirection.y -= gravity * Time.deltaTime;
			controller.Move (moveDirection * Time.deltaTime);
			Move_player ();
		}
		else if ((Move == false) && (Dead == true)){
			GetComponent<Animation> ().CrossFade ("Dead");
			Dead = false;
			Destroy (player_2, 6);
//			ChangeSceneTimer += Time.deltaTime;
//			if (ChangeSceneTimer >= ChangeSceneDelay)
			StartCoroutine("Wait");
		}
	}
	IEnumerator Wait(){
		yield return new WaitForSeconds(5);
		SceneManager.LoadScene ("GameOver");
	}

	void ChangeView()
	{
		if (maincamera.enabled == true) {
			maincamera.enabled = false;
			secondcamera.enabled = true;
			
		} else {
			maincamera.enabled = true;
			secondcamera.enabled = false;
		}
	}

	void Move_player()
	{
		if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.LeftShift)) {
			GetComponent<Animation> ().CrossFade ("Run"); 
			transform.Translate (0f, 0f, 1f * Time.deltaTime * 4);
		} else if (Input.GetKey (KeyCode.W) && !Input.GetKey (KeyCode.LeftShift)) {
			GetComponent<Animation> ().CrossFade ("Walk_carry"); 
			transform.Translate (0f, 0f, 1f * Time.deltaTime * 1.5f);
		} else if (Input.GetKey (KeyCode.A)) {
			GetComponent<Animation> ().CrossFade ("Strafe_run_left"); 
			transform.Translate (1f * Time.deltaTime * -4, 0f, 0f);
		} else if (Input.GetKey (KeyCode.S)) {
			GetComponent<Animation> ().CrossFade ("Walk_backward"); 
			transform.Translate (0f, 0f, 1f * Time.deltaTime * -1.5f);
		} else if (Input.GetKey (KeyCode.D)) {
			GetComponent<Animation> ().CrossFade ("Strafe_run_right"); 
			transform.Translate (1f * Time.deltaTime * 4, 0f, 0f);
		} else if (playerscript.getPlayerHealth () == 0) {
			Move = false;
			Dead = true;
		} else if (Input.anyKey == false) {
			GetComponent<Animation> ().CrossFade ("Idle_carry2"); 
		}
		if (Input.GetKey (KeyCode.E)) {
			GetComponent<Animation> ().CrossFade ("Strike1");
			InfligerDegatsTarget (100f);
		} else if (Input.GetMouseButtonDown (1)) {
			GetComponent<Animation> ().CrossFade ("Strike8");
			InfligerDegatsTarget (100f);
		}
	}

	private void InfligerDegatsTarget(float value)
	{
		if (target != null) {
			TargetScript.receiveDommage (value);
		}
	}
}