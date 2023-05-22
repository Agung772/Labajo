using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandController : MonoBehaviour
{
    public GameObject commandInput;

    private void Update()
    {
        SpawnCommand();
    }


    int commandCount;
    void SpawnCommand()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            commandCount++;
            if (commandCount == 5)
            {
                commandInput.SetActive(true);
                commandInput.GetComponent<InputField>().Select();
            }
        }
    }

    //Command
    public void Command(string command)
    {
        //Command tanpa angka
        string tempCommand = "";
        for (int i = 0; i < command.Length; i++)
        {
            if (Char.IsLetter(command[i]))
                tempCommand += command[i];
        }

        //---------------------------------------------------------------------------------
        //Set perintah / command

        //Set jam
        if (tempCommand == "jam")
        {
            string jamString = "";
            int jamInt = 0;

            //Mencari angka
            for (int i = 0; i < command.Length; i++)
            {
                if (Char.IsDigit(command[i]))
                    jamString += command[i];
            }

            //Convert string ke int
            int.TryParse(jamString, out jamInt);

            //Set jamnnyaaa
            WaktuController.instance.SetJam(jamInt);
        }

        //Set speed
        else if (tempCommand == "speed")
        {
            string commandString = "";
            int commandInt = 0;

            //Mencari angka
            for (int i = 0; i < command.Length; i++)
            {
                if (Char.IsDigit(command[i]))
                    commandString += command[i];
            }

            //Convert string ke int
            int.TryParse(commandString, out commandInt);

            //Set perintahnnya
            PlayerController.instance.speedPlayer = commandInt;
        }

        //Speed normal
        else if (tempCommand == "speednormal")
        {
            //Set perintahnnya
            PlayerController.instance.speedPlayer = PlayerController.instance.speedNormal;
        }
        else
        {
            print("Perintah tidak ada!");
        }


        commandInput.SetActive(false);
        commandInput.GetComponent<InputField>().text = null;
        commandCount = 0;

    }
}
