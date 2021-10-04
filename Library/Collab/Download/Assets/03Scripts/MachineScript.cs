using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineScript : MonoBehaviour
{
    public GameObject MachineCanvas;
    private GameObject target;
    public GameObject sound;

    private void Awake()
    {
        MachineCanvas.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector3.forward, Mathf.Infinity);
            for (int i = 0; i < 1 && MachineCanvas.activeSelf != true; i++)
            {
                if (hit.collider == null)
                    continue;
                if (hit.transform == null)
                    continue;
                if (hit.transform.tag.Equals("Machine"))
                {
                    Debug.Log(hit.collider.name);
                    target = hit.transform.gameObject;
                    Instantiate(sound);
                    MachineCanvas.SetActive(true);
                }
            }

        }
    }

    public void DisableMachineUI()
    {
        MachineCanvas.SetActive(false);
    }
}
