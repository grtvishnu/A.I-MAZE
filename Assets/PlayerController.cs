using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    public Animator anim;
    float motionSmoothTime = .1f;

    private void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>() 
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                //Move our agent
                agent.SetDestination(hit.point);

            }

        }
        float speed = agent.velocity.magnitude / agent.speed;
        anim.SetFloat("Speed", speed, motionSmoothTime, Time.deltaTime);
    }
}
