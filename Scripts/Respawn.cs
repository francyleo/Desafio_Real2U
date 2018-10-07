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
	private Transform resp;//Variavel para indicar a posição em que vai aparecer o personagem
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
	//armazena o valor do numero usado para calcular o valor da distância.
	private float aces;
	//####### Variaveis #######//

	void Start ()
	{
		aces = 130f;
	}

	//Função para instanciar clone do personagem na tela(Prefab)
	public void create()
	{
		//pegar posicionamento digitado
		resp.position = new Vector3(float.Parse(posX.text)*aces,float.Parse(posY.text)*aces,float.Parse(posZ.text)*aces);
		//verificar se o personagem ja esta na tela
		if(!isCreate)
		{
			clone = Instantiate(personagem,resp.position,Quaternion.identity);
			//designa a rotação do personagem
			clone.transform.Rotate (float.Parse(rotX.text)*aces,float.Parse(rotY.text)*aces,float.Parse(rotZ.text)*aces,Space.Self);
			isCreate = true;//para não criar mais de 1
		}else {
			/**
				caso o personagem ja temha sido criado,deleta-o e cria um personagem
				novo de acordo com as coordenadas atualizadas.	
			 */
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