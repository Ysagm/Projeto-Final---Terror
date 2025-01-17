using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    //[SerializeField] private string nameOfLevel;
    [SerializeField] private GameObject Menu;
    [SerializeField] private GameObject Intro;
    [SerializeField] private GameObject Blackout;
    [SerializeField] private GameObject Options;
    [SerializeField] private GameObject Extra;
    [SerializeField] private GameObject Credits;
    [SerializeField] private GameObject Epilogue;
    [SerializeField] private GameObject EpilogueBlackout;
    [SerializeField] private GameObject IntroVoice;
    [SerializeField] private GameObject BGMusic;
    


    //Cena Blackout: aguardar por 3.5 segundos e ir direto para o Jogo
     public string SceneToLoad = "Jogo";
     public bool cenaBlackout = false;
     public bool cenaEpilogue = false;
     public float DelayTime = 3.5f;


     public void Play() 
     {
        if (cenaBlackout == true)     
        {
         StartCoroutine("Wait");
         Destroy(IntroVoice);
         Destroy (BGMusic);
         Debug.Log("Entrou Play");
        }       
     }

     
     private IEnumerator Wait()
     {
         yield return new WaitForSeconds(DelayTime);
 
            SceneManager.LoadScene(SceneToLoad, LoadSceneMode.Single);
     }   
     
     private IEnumerator WaitEpilogue()
     {
         yield return new WaitForSeconds(DelayTime);
 
         OpenEpilogue();   
     }        
    
    
    public void OpenIntro(){
        Menu.SetActive(false);
        Intro.SetActive(true);
        Debug.Log("Abriu intro");
        }        
    
    public void CloseIntro(){
        Intro.SetActive(false);
        Menu.SetActive(true);
        Destroy(IntroVoice);
    }
    public void OpenBlackout(){
        Destroy (BGMusic);
        Menu.SetActive(false);
        Blackout.SetActive(true);
        cenaBlackout = true;
        Debug.Log("Abriu Blackout");
        Play();
    }
    public void OpenOptions(){
        Menu.SetActive(false);
        Options.SetActive(true);
        Debug.Log("Abriu opção");
    }
    public void CloseOptions(){
        Options.SetActive(false);
        Menu.SetActive(true);
    }
    public void OpenExtra(){
        Menu.SetActive(false);
        Extra.SetActive(true);
        Debug.Log("Abriu extra");
    }
    public void CloseExtra(){
        Extra.SetActive(false);
        Menu.SetActive(true);
    }

    public void OpenCredits(){
        Menu.SetActive(false);
        Credits.SetActive(true);
        Debug.Log("Abriu credits");
    }
    public void CloseCredits(){
        Credits.SetActive(false);
        Menu.SetActive(true);
    }
    public void OpenEpilogue(){
        Destroy (BGMusic);
        Blackout.SetActive(false);
        Epilogue.SetActive(true);
        cenaEpilogue = true;
        SceneToLoad = "Menu";
        Debug.Log("Abriu Epilogue");
        Play();
    }  

    public void OpenEpilogueBlackout(){
        Destroy (BGMusic);
        Epilogue.SetActive(false);
        EpilogueBlackout.SetActive(true);
        Debug.Log("Abriu EpilogueBlackout");
       
    }

    public void OpenMenu(){
        SceneManager.LoadScene(SceneToLoad, LoadSceneMode.Single);
        Destroy (BGMusic);
        EpilogueBlackout.SetActive(false);
        Menu.SetActive(true);
        Debug.Log("Abriu menu");
        }     
    
}


/*
public class videoscript : MonoBehaviour
{
 
     VideoPlayer video;
 
    void Start()
    {
        video = GetComponent<VideoPlayer>();
        video.Play();
        StartCoroutine("WaitForMovieEnd");
    }
 
 
    public IEnumerator WaitForMovieEnd()
    {
        while (video.isPlaying)
        {
            yield return new WaitForEndOfFrame();
         
        }
        OnMovieEnded();
    }
 
     void OnMovieEnded()
    {
        SceneManager.LoadScene(0);
    }
}
*/

