using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct PlayerSfx
{
    public AudioClip[] fire;
    public AudioClip[] reload;
}

public class FireCtrl : MonoBehaviour
{
    public enum WeaponType
    {
        RIFLE = 0,
        SHOTGUN
    }
   
    public WeaponType currWeapon=WeaponType.RIFLE;
    public GameObject bullet;
    private ParticleSystem muzzleFlash;
    private AudioSource _audio;
    public Transform firePos;
    public ParticleSystem cartridge;
    public PlayerSfx playerSfx;

    private Shake shake;

    public Image magazineImg;
    public Text magazineText;
    public int maxBullet = 10;
    public int remainingBullet = 10;
    public float reloadTime = 2.0f;
    private bool isReloading=false;

    // Start is called before the first frame update
    void Start()
    {
        muzzleFlash = firePos.GetComponentInChildren<ParticleSystem>();
        _audio = GetComponent<AudioSource>();
        shake = GameObject.Find("CameraRig").GetComponent<Shake>();

       
    }

    // Update is called once per frame
    void Update()
    {
        if(!isReloading&&Input.GetMouseButtonDown(0))
        {
            --remainingBullet;
            Fire();
            if(remainingBullet==0)
            {
                StartCoroutine(Reloading());
            }
        }
    }
    void Fire()
    {
        StartCoroutine(shake.ShakeCamera());
        Instantiate(bullet, firePos.position, firePos.rotation);
        cartridge.Play();
        //FireSfx();
        AudioSource audio = GameObject.Find("BulletExplosionFire").GetComponent<AudioSource>();
       audio.Play();
        magazineImg.fillAmount = (float)remainingBullet / (float)maxBullet;
        UpdateBulletText();

    }

    IEnumerator Reloading()
    {
        isReloading = true;
        AudioSource audio = GameObject.Find("HPCharacter").GetComponent<AudioSource>();
        audio.Play();
        yield return new WaitForSeconds(1.0f);
        isReloading = false;
        magazineImg.fillAmount = 1.0f;
        remainingBullet = maxBullet;
        UpdateBulletText();
    }

    void UpdateBulletText()
    {
        magazineText.text = string.Format("<color=#ff0000>{0}</color>/{1}", remainingBullet, maxBullet);
    }

   /* void FireSfx()
    {
        var _sfx = playerSfx.fire[(int)currWeapon];
        _audio.PlayOneShot(_sfx, 1.0f);
    }*/
}
