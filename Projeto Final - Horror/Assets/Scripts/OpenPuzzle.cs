using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

using Photon.Pun;
using Photon.Realtime;

public class OpenPuzzle : MonoBehaviour
{
    public bool GameIsPause = false;
    public GameObject puzzle, papelPuzzle1, papelPuzzle2;
    PhotonView photonView;

    private Coroutine openCoroutine;

    public bool chatActive;

    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && chatActive == false)
        {
            if (GameIsPause)
            {
                Close();
            }
            else
            {
                openCoroutine = StartCoroutine(Open());
            }
        }
        

    }

    IEnumerator Open()
    {
        //Quando subir
        GameIsPause = true;

        if (PhotonNetwork.IsMasterClient)
        {
            //papelPuzzle1.transform.localEulerAngles = Vector3.right * 45;
             papelPuzzle1.GetComponent<Animator>().Play("LiftBook");
        }
        else
        {
            //papelPuzzle2.transform.localEulerAngles = Vector3.left * 45;
            papelPuzzle2.GetComponent<Animator>().Play("LiftBook");
        }
            
        
        ///Debug.Log("Papel sobe");

        yield return new WaitForSeconds(0.4f);
        puzzle.SetActive(true);

    }

    public void Close()
    {
        //Debug.LogError("FDP");
        if(openCoroutine != null)
            StopCoroutine(openCoroutine);
        GameIsPause = false;
        puzzle.SetActive(false);

        if (PhotonNetwork.IsMasterClient)
        {
            //papelPuzzle1.transform.localEulerAngles = Vector3.zero;
            papelPuzzle1.GetComponent<Animator>().Play("DefaultPosition");
        }
        else
        {
            //papelPuzzle2.transform.localEulerAngles = Vector3.zero;
            papelPuzzle2.GetComponent<Animator>().Play("DefaultPosition");
        }
    }

    public void ChatIsActive(BaseEventData eventdata)
    {
        chatActive = true;
    }

    public void ChatIsNotActive(BaseEventData eventdata)
    {
        chatActive = false;
    }

}
