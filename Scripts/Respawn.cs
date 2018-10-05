using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Respawn : MonoBehaviour
{
	//####### Variaveis #######//
	[SerializeField]
	private GameObject personagem;//Variavel para armazerar o Prefab do Personagem
	[SerializeField]
	private Transform respawn;//Variavel para indicar a posição em que vai aparecer o personagem
	private bool isCreate;//variavel de controle de quantidade de personagem
	//Variaveis criada para o clone instaciado do personagem
	private GameObject clone;
	//Variaveis criada para os Labels do Posição
	[SerializeField]
	private InputField posX;
	[SerializeField]
	private InputField posY;
	[SerializeField]
	private InputField posZ;
	//Variaveis criada para os Labels do rotação
	[SerializeField]
	private InputField rotX;
	[SerializeField]
	private InputField rotY;
	[SerializeField]
	private InputField rotZ;
	//####### Variaveis #######//

	//Função para instanciar clone do personagem na tela(Prefab)
	public void create()
	{
		//pegar posicionamento e rotacionamento digitado
		respawn.position = new Vector3(float.Parse(posX.text),float.Parse(posY.text),float.Parse(posZ.text));
		//verificar se o personagem ja esta na tela
		if(!isCreate)
		{
			clone = Instantiate(personagem,respawn.position,Quaternion.identity);
			clone.transform.Rotate (float.Parse(rotX.text),float.Parse(rotY.text),float.Parse(rotZ.text),Space.Self);
			isCreate = true;//para não criar mais de 1
		}else {
			delete();
			create();
		}
	}
	//Função para apagar o clone do personagem(Prefab)
	public void delete()
	{
		//Verificar se esta na tela
		if(isCreate)
		{
			Destroy (clone);
			isCreate = false;
		}
	}
}
