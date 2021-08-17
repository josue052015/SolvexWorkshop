import { HubConnection, HubConnectionBuilder } from "@microsoft/signalr";
import { Empty } from "antd";
import React, { useEffect, useRef, useState } from "react";

export default function ListTodo() {

    const [hubConnection, setHubConnetion] = useState<HubConnection>();
    const [text, setText] = useState<string>("");
    const [todoList, setTodoList] = useState<Array<string>>([]);

    useEffect(() => {
        createHubConnection()
    }, [])

    const createHubConnection = async () => {
        const hubConnection = new HubConnectionBuilder().withUrl("https://localhost:44311/hubs/todos").build()
        try {
            await hubConnection.start()
        }
        catch (x) {
            console.log("error", x);
        }
        setHubConnetion(hubConnection);
    }
   
    useEffect(() => {
        if (hubConnection) {
            hubConnection.on("ReceiveTodo", (todo) => {
                setTodoList((prevState => {
                    return prevState.concat(todo);
                }))
            })
        }
    }, [hubConnection])

    const sendTodo = async () => {
        if (text != "") {
            if (hubConnection) {
                setText("")
                await hubConnection.invoke("SendTodo", text)
            }
        }
        else {
            alert("No puede dejar el espacio en blanco")
        }
    }

    return (
        <>
            <div className="wrapper">
                <header>Todo list</header>
                <div className="inputField">
                    <input value={text} placeholder="Ingrese su tarea" onChange={(e: any) => {
                        setText(e.target.value)
                    }} />
                    <button onClick={sendTodo}><i className="fas fa-plus"></i></button>
                </div>
                <div>
                    <ul className="todoList">
                        {todoList.map((item: string, index: number) => {
                            return (
                                <li key={index}>{item}</li>
                            )
                        })}
                    </ul>
                </div>
            </div>
        </>
    );
}
