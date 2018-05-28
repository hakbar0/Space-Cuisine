using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    //todo fix lighting bug

    [SerializeField] float rcsThrust = 100f; //Allows change in editor but not in other scripts
    [SerializeField] float mainThrust = 10f;

    Rigidbody rigidBody;
    AudioSource audioSource;

    enum State { Alive, Dieing, Transcending };
    State state = State.Alive;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(state == State.Alive)
        {
            Thrust();
            Rotate();
        }
    }

    private void Thrust()
    {
        float thrustThisFrame = mainThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up * thrustThisFrame); // can rotate when thrusting. Use relative so acts on direction.
            if (!audioSource.isPlaying) audioSource.Play();
        }

        else audioSource.Stop();
    }

    private void Rotate()
    {
        rigidBody.freezeRotation = true; //take manual control of physics rotation.

        float rotationThisFrame = rcsThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.A)) transform.Rotate(Vector3.forward * rotationThisFrame); // z axis rotate

        else if (Input.GetKey(KeyCode.D)) transform.Rotate(-Vector3.forward * rotationThisFrame);

        rigidBody.freezeRotation = false; //resume physics control of physics rotation.
    }

    void OnCollisionEnter(Collision collision)
    {
        if (state != State.Alive) return;

        switch (collision.gameObject.tag)
        {
            case "Friendly":
  
                break;

            case "Finish":
                state = State.Transcending;
                Invoke("LoadNextScene", 1f);
                break;

            default:
                state = State.Dieing;
                Invoke("LoadFirstScene", 1f);
                break;
        }
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(1);
    }

    private void LoadFirstScene()
    {
        SceneManager.LoadScene(0);
    }
}


