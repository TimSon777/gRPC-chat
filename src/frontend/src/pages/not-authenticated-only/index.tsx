import {Navigate, Outlet} from "react-router-dom";
import { isAuthenticated } from "../../services/accounting";

export const NotAuthenticatedPage = () => {
    if (!isAuthenticated()){
        return (
            <Outlet/>
        )
    }

    return (
        <Navigate to={"/home"}/>
    )
}