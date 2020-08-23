﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Работа с интерфейсами
using UnityEngine.SceneManagement; //Работа со сценами
using UnityEngine.Audio; //Работа с аудио


public class GameMenu : MonoBehaviour
{
	public bool isOpened = false; //Открыто ли меню
	public float volume = 0; //Громкость
	public int quality = 0; //Качество
	public bool isFullscreen = false; //Полноэкранный режим
	public AudioMixer audioMixer; //Регулятор громкости
	public Dropdown resolutionDropdown; //Список с разрешениями для игры
	private Resolution[] resolutions; //Список доступных разрешений
	private int currResolutionIndex = 0; //Текущее разрешение
	public GameObject Menu;
 				
    // Start is called before the first frame update
    void Start()
    {
    	 //Menu = GameObject.FindGameObjectWithTag("Menu");

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape)) 
		{
			ShowHideMenu();
		}
    }

    public void ShowHideMenu()
		{
			isOpened = !isOpened;
			//GetComponent<Menu>().enabled = isOpened; //Включение или отключение Canvas. Ещё тут можно использовать метод SetActive()
		}
	public void ChangeVolume(float val) //Изменение звука
	{
		volume = val;
	}

	public void ChangeResolution(int index) //Изменение разрешения
	{
		currResolutionIndex = index;
	}

	public void ChangeFullscreenMode(bool val) //Включение или отключение полноэкранного режима
	{
		isFullscreen = val;
	}

	public void ChangeQuality(int index) //Изменение качества
	{
		quality = index;
	}	

	public void GoToMain()
	{
		SceneManager.LoadScene("Menu"); //Переход на сцену с названием Menu
	}
}
