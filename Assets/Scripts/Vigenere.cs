using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Vigenere : MonoBehaviour
{
	[Header("Encrypt")]
	[SerializeField] private TMP_InputField encrypt_input = null;
	[SerializeField] private TMP_InputField key_encrypt_input = null;
	[SerializeField] private TMP_Text encrypt_result = null;
	[SerializeField] private TMP_Text key_encrypt_result = null;
	[Header("Descrypt")]
	[SerializeField] private TMP_InputField descrypt_input = null;
	[SerializeField] private TMP_InputField key_descrypt_input = null;
	[SerializeField] private TMP_Text descrypt_result = null;
	[SerializeField] private TMP_Text key_descrypt_result = null;
	//void Start()
	//   {

	//   }
	//   void Update()
	//   {

	//   }
	private bool Check_Key_And_Text(string text, string key)
	{
		for (int i = 0; i <= key.Length; i++)
		{
			if (i >= key.Length)
			{
				return false;
			}
			if (key[i] >= 'A' && key[i] <= 'Z')
			{
				break;
			}
		}
		for (int i = 0; i <= text.Length; i++)
		{
			if (i >= text.Length)
			{
				return false;
			}
			if (text[i] >= 'A' && text[i] <= 'Z')
			{
				break;
			}
		}
		return true;
	}
	private int Key_Position(int key_pos, string key)
	{
		do
		{
			key_pos++;
			if (key_pos >= key.Length - 1)
			{
				key_pos = 0;
			}
		} while (key[key_pos] < 'A' && key[key_pos] > 'Z');
		return key_pos;
	}
	public void Start_Encrypt()
	{
		string text = encrypt_input.text.ToUpper();
		string key = key_encrypt_input.text.ToUpper();
		if (!Check_Key_And_Text(text, key))
		{
			key_encrypt_result.text = encrypt_result.text = "Chave ou texto invalidos";
		}
		key_encrypt_result.text = key;
		string encrypted_text = "";
		encrypt_result.text = Recursion_Encrypt(text, key, 0, encrypted_text, 0);
	}
	public void Start_Descript()
	{
		string text = descrypt_input.text.ToUpper();
		string key = key_descrypt_input.text.ToUpper();
		if (!Check_Key_And_Text(text, key))
		{
			key_descrypt_result.text = descrypt_result.text = "Chave ou texto invalidos";
		}
		key_descrypt_result.text = key;
		string descrypted_text = "";
		descrypt_result.text = Recursion_Descript(text, key, 0, descrypted_text, 0);
	}
	private string Recursion_Encrypt(string text, string key, int key_pos, string encrypted_text, int position)
	{
		if (position < text.Length)
		{
			char letra;
			if (text[position] >= 'A' && text[position] <= 'Z')
			{
				letra = (char)((text[position] + key[key_pos]) % 26);
				encrypted_text += (char)(letra + 'A');
				key_pos = Key_Position(key_pos, key);
			}
			else
			{
				encrypted_text += (text[position]);
			}
			position++;
			return Recursion_Encrypt(text, key, key_pos, encrypted_text, position);
		}
		return encrypted_text;
	}
	private string Recursion_Descript(string text, string key, int key_pos, string encrypted_text, int position)
	{
		if (position < text.Length)
		{
			char letra;
			if (text[position] >= 'A' && text[position] <= 'Z')
			{
				letra = (char)((text[position] - key[key_pos] + 26) % 26);
				encrypted_text += (char)(letra + 'A');
				key_pos = Key_Position(key_pos, key);
			}
			else
			{
				encrypted_text += (text[position]);
			}
			position++;
			return Recursion_Descript(text, key, key_pos, encrypted_text, position);
		}
		return encrypted_text;
	}
}