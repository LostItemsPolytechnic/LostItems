import { Route, Routes } from 'react-router-dom';
import './assets/scss/app.scss';
import Auth from './pages/Auth';
import ItemPage from './pages/Item';
import Main from './pages/Main';
import { useEffect, useState } from 'react';
import useHttpHook from './hooks/useHttpHook';
import { meAuth } from './services/client/auth';
import Header from './components/Header';

function App() {
    const [isAuth, setIsAuth] = useState(true);

    const { makeRequest } = useHttpHook();

    useEffect(() => {
        makeRequest(() => meAuth()).catch(() => setIsAuth(false));
    }, []);

    const onLogIn = () => {
        setIsAuth(true);
    };

    const onLogOut = () => {
        setIsAuth(false);
    };

    return (
        <Routes>
            {!isAuth ? (
                <Route path="*" element={<Auth onLogIn={onLogIn} />} />
            ) : (
                <>
                    <Route
                        path="/"
                        element={
                            <>
                                <Header onLogOut={onLogOut} /> <Main />
                            </>
                        }
                    />
                    <Route path="/item/:id" element={<ItemPage />} />
                </>
            )}
        </Routes>
    );
}

export default App;
