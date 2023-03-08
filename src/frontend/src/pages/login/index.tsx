import React, {useEffect, useState} from "react";
import {AuthClient} from "../../generated/auth.client";
import {GrpcWebFetchTransport} from "@protobuf-ts/grpcweb-transport";
import {Navigate} from "react-router-dom";

export const LoginPage = () => {

    const [client, setClient] = useState<AuthClient>();
    const [userName, setUserName] = useState('');
    const [isAuthenticated, setAuthenticated] = useState(false);

    const login = async () => {
      const response = await client!.login({userName: userName});
      let accessToken = response.response.accessToken;
      localStorage.setItem("access_token", accessToken);
      setAuthenticated(true);
    }

    const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        await login();
    };

    useEffect(() => {
        let transport = new GrpcWebFetchTransport({
            baseUrl: "http://localhost:5232"
        });

        const cl = new AuthClient(transport);
        setClient(cl);
    }, []);

    if (isAuthenticated) {
        return (
            <Navigate to={"/chat"}/>
        )
    }

    return (
        <div>
            <form onSubmit={handleSubmit}>
                <div>
                    <label htmlFor={"username"}>
                        Username:
                    </label>
                    <input
                        type="text"
                        id="username"
                        value={userName}
                        onChange={(e) => setUserName(e.target.value)}
                    />
                </div>

                <button type="submit">Log in</button>
            </form>
        </div>
    )
}