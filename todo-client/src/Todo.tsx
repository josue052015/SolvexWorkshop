import { HubConnection, HubConnectionBuilder } from "@microsoft/signalr";
import React, { useEffect, useRef, useState } from "react";
import { Button, Input, notification } from "antd";

export const Todo = () => {
    const [connection, setConnection] = useState<null | HubConnection>(null);
    const [inputText, setInputText] = useState("");
  /*   const [ todoList, setTodoList ] = useState([]);
    let latestTodo = useRef(null); */
    const [ todoList, setTodoList ] = useState(String);


    useEffect(() => {
        const connect = new HubConnectionBuilder()
            .withUrl("https://localhost:44311/hubs/todos")
            .withAutomaticReconnect()
            .build();

        setConnection(connect);
    }, []);

    useEffect(() => {
        if (connection) {
            connection
                .start()
                .then(() => {
                    connection.on("ReceiveTodo", (todo) => {
                        notification.open({
                            message: "New Notification",
                            description: todo,
                        });
      
                    });
                })
                .catch((error) => console.log(error));
        }
    }, [connection]);

    const SendTodo = async () => {
        if (connection) await connection.send("SendTodo", inputText);
       
     // todos = inputText;
   setTodoList(inputText);
        setInputText("");
    };
    

    return (
        <>
       <h1>{todoList}</h1>
            <Input
                value={inputText}
                onChange={(input) => {
                    setInputText(input.target.value);
                }}
            />
            <Button onClick={SendTodo} type="primary">
                Send
            </Button>

            <ul>
               
            </ul>

        </>
    );
};

export interface todoProps{
    todos: string
}