import { RouterProvider, createBrowserRouter } from 'react-router-dom';
import SignUpPage from './pages/SignUpPage';
import SignInPage from './pages/SignInPage';
import HomePage from './pages/HomePage';
import './App.css';

const App = () => {
    const router = createBrowserRouter([
        {
            path: '/',
            element: <HomePage />,
        },
        {
            path: '/SignUp',
            element: <SignUpPage />,
        },
        {
            path: '/SignIn',
            element: <SignInPage />,
        },
    ]);

    return <RouterProvider router={router} />;
};

export default App;
