import React from 'react';
import {createBrowserRouter, RouterProvider} from "react-router-dom";
import { Layout } from './components/layout';
import { AuthenticatedPage } from './pages/authenticated-only';
import { ChatPage } from './pages/chat';
import { HomePage } from './pages/home';
import { LoginPage } from './pages/login';
import { NotAuthenticatedPage } from './pages/not-authenticated-only';

export const App = () => {
  const router = createBrowserRouter([
    {
      path: "/",
      element: <Layout/>,
      children: [
        {
          path: "/auth",
          element: <NotAuthenticatedPage/>,
          children: [
            {
              path: "/auth/login",
              element: <LoginPage/>
            }
          ]
        },
        {
          path: "/",
          element: <AuthenticatedPage/>,
          children: [
            {
              path: "/chat",
              element: <ChatPage/>
            },
            {
              path: "/home",
              element: <HomePage/>
            }
          ]
        }
      ]
    }
  ]);

  return (
      <RouterProvider router={router}/>
  );
}