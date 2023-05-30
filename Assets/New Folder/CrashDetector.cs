using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    CircleCollider2D head;
    [SerializeField] float reset = 1.5f; 
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    bool hasCrashed = true; 

    void Start(){
        head = GetComponent<CircleCollider2D>();

    }
    private void OnCollisionEnter2D(Collision2D other) {            
        if(other.gameObject.tag == "Ground"&& head.IsTouching(other.collider)){
            crashEffect.Play();
            if(hasCrashed){
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            hasCrashed = false;
            }
            GetComponent<PlayerController>().DisableControl();
            Invoke("ReloadScene", reset);                  
        }
    }

    void ReloadScene(){
            SceneManager.LoadScene(0);
    }
    }
