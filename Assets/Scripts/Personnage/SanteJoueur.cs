using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SanteJoueur : MonoBehaviour
{
    [Header("Gestion de la santé")]
    public float niveauOxygene = 100;
    public float niveauOxygeneMax = 100;
    public float perteOxygene = 0.1f;

    [Header("Sons")]
    [SerializeField] AudioClip sonMort;
    [SerializeField] AudioClip sonOxygene;
    [SerializeField] AudioClip sonBlesse;

    [Header("Composants")]
    ControlesJoueur controles;
    Animator animator;
    AudioSource audiosource;


    void Start()
    {
        controles = GetComponent<ControlesJoueur>();
        animator = GetComponent<Animator>();
        audiosource = GetComponent<AudioSource>();
    }

    void Update()
    {
        niveauOxygene -= perteOxygene * Time.deltaTime;
    }
    public void RecevoirDegats(int degats)
    {
        niveauOxygene -= degats;
        // if niv oxy < 0 {=niv oxy = 0 }
        Mathf.Clamp(niveauOxygene, 0, niveauOxygeneMax);

        if (niveauOxygene <= 0)
        {
            // Handle player death logic here
        }
    }

    public void Soigner(int soins)
    {
        niveauOxygene += soins;
        Mathf.Clamp(niveauOxygene, 0, niveauOxygeneMax);



    }

     public IEnumerator Mourir()
     {
        controles.etatPerso = EtatPerso.MORT;
        animator.SetTrigger("Mort");
        audiosource.PlayOneShot(sonMort);
        yield return new WaitForSeconds(3);
        controles.RedemarrerPartie();

    }
}
    




