using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PegScript : MonoBehaviour
{
    int timesHit = 0;
    public bool pegSnapped;
    public bool taskLogUpdated;

    public GameObject pegSocket1;
    public GameObject pegSocket2;
    public GameObject pegSocket3;
    public GameObject pegSocket4;

    bool tentObjectFound;
    public GameObject tentObject1;
    public GameObject tentObject2;
    public GameObject tentObject3;
    private TentScript tentScript1;
    private TentScript tentScript2;
    private TentScript tentScript3;

    public TaskLog taskLog;

    private void Awake()
    {
        tentObject1 = GameObject.Find("Pitched Tent Group 1");
        tentObject2 = GameObject.Find("Pitched Tent Group 2");
        tentObject3 = GameObject.Find("Pitched Tent Group 3");
    }

    private void Start()
    {
        tentScript1 = tentObject1.GetComponent<TentScript>();
        tentScript2 = tentObject2.GetComponent<TentScript>();
        tentScript3 = tentObject3.GetComponent<TentScript>();
    }

    private void Update()
    {
        if (!taskLogUpdated && timesHit == 3)
        {
            if (this.gameObject.name == "Peg 1")
            {
                taskLog.FirstPegHammered();
            }
            else if (this.gameObject.name == "Peg 2")
            {
                taskLog.SecondPegHammered();
            }
            else if (this.gameObject.name == "Peg 3")
            {
                taskLog.ThirdPegHammered();
            }
            else if (this.gameObject.name == "Peg 4")
            {
                taskLog.FourthPegHammered();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Mallet")
        {
            Debug.Log("Hit");
            if (timesHit < 3 && pegSnapped)
            {
                this.gameObject.transform.position += new Vector3(0, -0.03f, 0);
                timesHit++;

                
            }
        }
    }

    public void SetPegSnapped()
    {
        pegSnapped = true;
        if (this.gameObject.name == "Peg 1")
        {
            StartCoroutine("DestroySocket1");
        }

        if (this.gameObject.name == "Peg 2")
        {
            StartCoroutine("DestroySocket2");
        }

        if (this.gameObject.name == "Peg 3")
        {
            StartCoroutine("DestroySocket3");
        }

        if (this.gameObject.name == "Peg 4")
        {
            StartCoroutine("DestroySocket4");
        }
    }

    IEnumerator DestroySocket1()
    {
        XRGrabInteractable interactableComponent = this.gameObject.GetComponent<XRGrabInteractable>();
        Rigidbody rigidBodyComponent = this.gameObject.GetComponent<Rigidbody>();
        yield return new WaitForSeconds(1f);
        Destroy(interactableComponent);
        rigidBodyComponent.isKinematic = true;
        rigidBodyComponent.useGravity = false;
        Destroy(pegSocket1);
    }

    IEnumerator DestroySocket2()
    {
        XRGrabInteractable interactableComponent = this.gameObject.GetComponent<XRGrabInteractable>();
        Rigidbody rigidBodyComponent = this.gameObject.GetComponent<Rigidbody>();
        yield return new WaitForSeconds(1f);
        Destroy(interactableComponent);
        rigidBodyComponent.isKinematic = true;
        rigidBodyComponent.useGravity = false;
        Destroy(pegSocket2);
    }

    IEnumerator DestroySocket3()
    {
        XRGrabInteractable interactableComponent = this.gameObject.GetComponent<XRGrabInteractable>();
        Rigidbody rigidBodyComponent = this.gameObject.GetComponent<Rigidbody>();
        yield return new WaitForSeconds(1f);
        Destroy(interactableComponent);
        rigidBodyComponent.isKinematic = true;
        rigidBodyComponent.useGravity = false;
        Destroy(pegSocket3);
    }
    IEnumerator DestroySocket4()
    {
        XRGrabInteractable interactableComponent = this.gameObject.GetComponent<XRGrabInteractable>();
        Rigidbody rigidBodyComponent = this.gameObject.GetComponent<Rigidbody>();
        yield return new WaitForSeconds(1f);
        Destroy(interactableComponent);
        rigidBodyComponent.isKinematic = true;
        rigidBodyComponent.useGravity = false;
        Destroy(pegSocket4);
    }
}
