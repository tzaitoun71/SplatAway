using UnityEngine;

public class GunCode : MonoBehaviour {

    public float damge = 10f;
    public float range = 100f;

    public ParticleSystem MuzzleFlash;
    
    public Camera fpsCam;           
	// Update is called once per frame
	void Update () {
		
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
            
        }
	}

    void Shoot ()
    {
        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            MuzzleFlash.Play();

            Debug.Log(hit.transform.name);
            dieobj target = hit.transform.GetComponent<dieobj>();
            if (target != null)
            {
                target.TakeDamage(damge);
            }
            else
            {
                MuzzleFlash.Stop();
            }
        }
    }
        
}
