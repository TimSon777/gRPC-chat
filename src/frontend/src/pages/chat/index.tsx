import { GrpcWebFetchTransport } from "@protobuf-ts/grpcweb-transport";
import {useState, useEffect, useRef} from "react";
import { ReceiveMessageResponse } from "../../generated/chat";
import { ChatClient } from "../../generated/chat.client";
import { Empty } from "../../generated/google/protobuf/empty";
import {getToken} from "../../services/accounting";

export const ChatPage = () => {
    const [client, setClient] = useState<ChatClient>();
    const [messages, setMessages] = useState<ReceiveMessageResponse[]>([]);
    const inputMessage = useRef<HTMLInputElement>(null);
    
    const meta = {
        Authorization: `Bearer ${getToken()}`
    }

    const connect = async () => {
        const response = await client!.connect(Empty, {meta: meta});
    }

    const receiveMessages = async () => {
        const stream = client!.receiveMessages({}, { meta: meta });

        for await (let message of stream.responses) {
            setMessages(m => [...m, message])
        }
    }

    const onSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        const request = {
            text: inputMessage.current?.value || "empty"
        }

        await client!.sendMessage(request, {meta: meta})

        if (inputMessage.current) {
            inputMessage.current.value = "";
        }
    };

    useEffect(() => {
        let transport = new GrpcWebFetchTransport({
            baseUrl: "http://localhost:5232"
        });

        const cl = new ChatClient(transport);
        setClient(cl);
    }, []);
    

    useEffect(() => {
        if (client){
            connect().then(_ => receiveMessages());
        }

    }, [client])
    
    return (
        <>
            <section>
                {messages.map(m => <div>
                    {m.from} {m.text}
                </div>)}
            </section>
            <section>
                <form onSubmit={onSubmit}>
                    <input placeholder={"Message"} ref={inputMessage}/>
                    <button>Send</button>
                </form>
            </section>
        </>
    )
}