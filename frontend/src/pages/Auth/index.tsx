import { useState } from 'react';

import './auth.scss';
import { Button, Form, Spinner } from 'react-bootstrap';
import { logIn, signUp } from '../../services/client/auth';
import useHttpHook from '../../hooks/useHttpHook';

type authType = 'login' | 'signup';

interface AuthProps {
    onLogIn: () => void;
}

const Auth: React.FC<AuthProps> = ({ onLogIn }) => {
    const [authMethod, setAuthMethod] = useState<authType>('login');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    const { makeRequest, state, errorMsg } = useHttpHook();

    const onSubmit = async () => {
        if (!email.trim() || !password.trim()) return;

        makeRequest<void>(() => (authMethod === 'login' ? logIn(email, password) : signUp(email, password))).then(
            () => {
                onLogIn();
            }
        );
    };

    return (
        <main className="auth">
            <div className="auth-modal">
                <h2 className="auth-modal__title">{authMethod === 'login' ? 'Login' : 'Signup'}</h2>
                <h3 className="auth-modal__title-under">Lost & found portal for students</h3>

                <div className="auth-modal__wrapper-btn">
                    <button
                        onClick={() => setAuthMethod('login')}
                        className={`auth-modal__btn ${authMethod === 'login' ? 'auth-modal__btn--active' : ''}`}>
                        Login
                    </button>

                    <button
                        onClick={() => setAuthMethod('signup')}
                        className={`auth-modal__btn ${authMethod === 'signup' ? 'auth-modal__btn--active' : ''}`}>
                        Signup
                    </button>
                </div>

                {state === 'loading' ? (
                    <Spinner animation="border" />
                ) : (
                    <form
                        className="auth-modal__form"
                        onSubmit={(e) => {
                            e.preventDefault();
                            onSubmit();
                        }}>
                        <Form.Group className="mb-3 auth-modal__group">
                            <Form.Label className="auth-modal__label">Email</Form.Label>
                            <Form.Control
                                value={email}
                                onChange={(e) => setEmail(e.target.value)}
                                type="email"
                                className="auth-modal__input"
                                placeholder="you@campus.edu"
                            />
                        </Form.Group>

                        <Form.Group className="mb-3 auth-modal__group">
                            <Form.Label className="auth-modal__label">Password</Form.Label>
                            <Form.Control
                                value={password}
                                onChange={(e) => setPassword(e.target.value)}
                                type="password"
                                className="auth-modal__input"
                                placeholder="password"
                            />
                        </Form.Group>
                        {state === 'error' && <p className="text-danger">{errorMsg}</p>}
                        <Button type="submit" className="auth-modal__submit">
                            Continue
                        </Button>
                    </form>
                )}
            </div>
        </main>
    );
};

export default Auth;
