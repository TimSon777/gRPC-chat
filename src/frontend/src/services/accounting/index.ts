import { useNavigate } from "react-router-dom";

export const isAuthenticated = () => {
    return getToken() !== null;
}

export const useLogout = () => {
    localStorage.removeItem("access_token");
    const navigator = useNavigate();
    navigator("/login");
}

export const useLogin = (token : string) => {
    localStorage.setItem("access_token", token);
    const navigator = useNavigate();
    navigator("/chat");
}

export const getToken = () => {
    return localStorage.getItem("access_token");
}