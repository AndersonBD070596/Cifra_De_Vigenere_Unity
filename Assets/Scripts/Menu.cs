using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Menu : MonoBehaviour
{
    [Header("Encrypt")]
    [SerializeField] private TMP_InputField encrypt_input = null;
    [SerializeField] private TMP_InputField key_encrypt_input = null;
    [SerializeField] private GameObject button_encrypt = null;
    [Header("Descrypt")]
    [SerializeField] private TMP_InputField descrypt_input = null;
    [SerializeField] private TMP_InputField key_descrypt_input = null;
    [SerializeField] private GameObject button_descrypt = null;
    void Update()
    {
        Active_Button_Encrypt();
        Active_Button_Descrypt();
    }
    private void Active_Button_Encrypt()
    {
        if (encrypt_input.text.Length > 0&& key_encrypt_input.text.Length > 0)
        {
            button_encrypt.SetActive(true);
        }
        else
        {
            button_encrypt.SetActive(false);
        }
    }
    private void Active_Button_Descrypt()
    {
        if (descrypt_input.text.Length > 0 && key_descrypt_input.text.Length > 0)
        {
            button_descrypt.SetActive(true);
        }
        else
        {
            button_descrypt.SetActive(false);
        }
    }
    public void Button_Exit()
    {
        Application.Quit();
    }
}