import { useState } from 'react';

import './auth.scss';
import { Button, Form } from 'react-bootstrap';

type authType = 'login' | 'signup';

const Auth = () => {
    const [authMethod, setAuthMethod] = useState<authType>('login');

    return (
        <main className="auth">
            <div className="modal">
                <h2 className="modal__title">{authMethod === 'login' ? 'Login' : 'Signup'}</h2>
                <h3 className="modal__title_under">Lost & found portal for students</h3>
                <div className="modal__wrapper-btn">
                    <button
                        onClick={() => setAuthMethod('login')}
                        className={`modal__btn ${authMethod === 'login' ? 'modal__btn-active' : ''}`}>
                        Login
                    </button>
                    <button
                        onClick={() => setAuthMethod('signup')}
                        className={`modal__btn ${authMethod === 'signup' ? 'modal__btn-active' : ''}`}>
                        Signup
                    </button>
                </div>
                <form className="modal_form" onSubmit={(e) => e.preventDefault()}>
                    <Form.Group className="mb-3 modal__group">
                        <Form.Label className="modal__label" htmlFor="email">
                            Email
                        </Form.Label>
                        <Form.Control id="email" type="email" className="modal__input" />
                    </Form.Group>

                    <Form.Group className="mb-3 modal__group">
                        <Form.Label className="modal__label" htmlFor="password">
                            Password
                        </Form.Label>
                        <Form.Control id="password" type="password" className="modal__input" />
                    </Form.Group>

                    <Button type="submit" className="modal__submit">
                        Continue
                    </Button>
                </form>
            </div>
        </main>
    );
};

export default Auth;
