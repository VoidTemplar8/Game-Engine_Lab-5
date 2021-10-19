using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker : MonoBehaviour
{
    static Queue<ICommand> commandBuffer;

    static List<ICommand> commandHistory;
    static int counter;

    static Queue<IActivity> commandBuffer2;

    static List<IActivity> commandHistory2;

    private void Awake() 
    {
        commandBuffer = new Queue<ICommand>();
        commandHistory = new List<ICommand>();
    }

    public static void AddCommand(ICommand command)
    {
        while(commandHistory.Count > counter)
        {
            commandHistory.RemoveAt(counter);
        }
        
        commandBuffer.Enqueue(command);
    }

    public static void AddCommand2(IActivity command2)
    {
        while (commandHistory2.Count > counter)
        {
            commandHistory2.RemoveAt(counter);
        }

        commandBuffer2.Enqueue(command2);
    }

    // Update is called once per frame
    void Update()
    {
        if (commandBuffer.Count > 0)
        {
            ICommand c = commandBuffer.Dequeue();
            c.Execute();
            
            //commandBuffer.Dequeue().Execute();

            commandHistory.Add(c);
            counter++;
            Debug.Log("Command history length: " + commandHistory.Count);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (counter > 0)
                {
                    counter--;
                    commandHistory[counter].Undo();
                }
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                if (counter < commandHistory.Count)
                {
                    commandHistory[counter].Execute();
                    counter++;
                }
            }
        }

        if (commandBuffer2.Count > 0)
        {
            IActivity d = commandBuffer2.Dequeue();
            d.Execute();

            //commandBuffer2.Dequeue().Execute();

            commandHistory2.Add(d);
            counter++;
            Debug.Log("Command history length: " + commandHistory2.Count);
        }
        else
        {
             if (Input.GetKeyDown(KeyCode.R))
            {           
                if (counter < commandHistory2.Count)
                {
                    commandHistory2[counter].Execute();
                    counter++;
                }
            }
        }
    }
}
