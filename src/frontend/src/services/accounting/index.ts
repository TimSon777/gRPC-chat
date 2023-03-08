import { useNavigate } from "react-router-dom";

export const isAuthenticated = () => {
    return getToken() !== null;
}

export const useLogout = () => {
    localStorage.removeItem("access_token");
    const navigator = useNavigate();
    navigator("/login");
}

export const getToken = () => {
    return localStorage.getItem("access_token");
}

export const setToken = (token: string) => {
  localStorage.setItem("access_token", token);
}