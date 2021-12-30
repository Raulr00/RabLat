
    private void Start()
    {
        //Time.timeScale = 0;

        if (!GameManager.mostrarMenu)
        {
            //Hacer el countDown
            Debug.Log("no Mostrat menu");
            canvasMenu.SetActive(false);
            empezarPartida();
        }
        else
        {
            Debug.Log(" Mostrat menu");
        }

    }

    public void Jugar()
    {
        //SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
        //Time.timeScale = 1;
        empezarPartida();

    }

    public menu getempezar()
    {

        return empezarPartida;
    }


    public void Salir()
    {
        Application.Quit();
    }
}