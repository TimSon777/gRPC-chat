import { Outlet } from "react-router-dom";
import { useLogout, isAuthenticated } from "../../services/accounting";

export const Layout = () => {
    return (
        <>
            <section>
                {isAuthenticated() && <button onClick={useLogout}>
                    Logout
                </button>}
            </section>
            <Outlet/>
        </>
    );
}