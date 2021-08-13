import { HubConnection, HubConnectionBuilder } from "@microsoft/signalr";
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
    //TODO: ojo aqui
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
        if (hubConnection) {
            setText("")
            await hubConnection.invoke("SendTodo", text)
        }
    }

    return (
        <>
            <div className = "wrapper">
                <input value={text} onChange={(e: any) => {
                    setText(e.target.value)
                }} />
                <button onClick={sendTodo}>holaaaa</button>
                <div>
                    <h2>Todos</h2>
                    <ul>
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
