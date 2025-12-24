import { apiRequest } from '../api';

export const logIn = async (email: string, password: string) => {
    var res = await apiRequest<void>('/auth/login', { method: 'POST', body: JSON.stringify({ email, password }) });

    if (!res.success && res.data === 'Unauthorized') res.data = 'Invalid creditionals';

    return res;
};

export const signUp = async (email: string, password: string) => {
    var res = await apiRequest<void>('/auth/register', { method: 'POST', body: JSON.stringify({ email, password }) });

    return res;
};

export const meAuth = async () => {
    var res = await apiRequest<void>('/auth/me');

    return res;
};
