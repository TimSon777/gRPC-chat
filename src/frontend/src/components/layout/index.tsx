import {Outlet, useNavigate} from "react-router-dom";
import {isAuthenticated } from "../../services/accounting";
import React, {useState} from "react";

export const Layout = () => {

    const navigate = useNavigate();
    const [authenticated, setAuthenticated] = useState(isAuthenticated());

    const logout = () => {
      localStorage.removeItem("access_token");
      setAuthenticated(false);
      navigate('/auth/login');
    }

    return (
        <>
            <section>
                {isAuthenticated() && <button onClick={logout}>
                    Logout
                </button>}
            </section>
            <Outlet/>
        </>
    );
}