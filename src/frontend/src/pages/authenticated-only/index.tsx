import {Navigate, Outlet } from "react-router-dom"
import { isAuthenticated } from "../../services/accounting"

export const AuthenticatedPage = () => {
    if (isAuthenticated()){
        return (
            <Outlet/>
        )
    }
    
    return (
        <Navigate to={"/auth/login"}/>
    )
}