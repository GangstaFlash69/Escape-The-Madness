using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kube : MonoBehaviour, IInteractable
{
    Material mat;
 
    private void Start() {
        mat = GetComponent<MeshRenderer>().material;
    }
 
    public string GetDescription() {
        return "Press E to start the magic...";
    }
 
    public void Interact() {
        mat.color = new Color(Random.value, Random.value, Random.value);
    }
}
