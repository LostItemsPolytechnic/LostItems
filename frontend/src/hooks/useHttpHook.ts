import { useState } from 'react';
import { ApiRes } from '../services/api';
export type stateType = 'loading' | 'error' | 'success' | 'waiting';

const useHttpHook = () => {
    const [state, setState] = useState<stateType>('waiting');
    const [errorMsg, setErrorMsg] = useState('');

    const makeRequest = async <T>(callMethod: () => Promise<ApiRes<T>>): Promise<T> => {
        try {
            setState('loading');

            const res = await callMethod();

            if (!res.success) {
                setState('error');
                throw res.data;
            }

            setState('success');
            return res.data;
        } catch (e: any) {
            setState('error');
            setErrorMsg(e);
            throw e;
        }
    };

    const resetError = () => {
        setState('waiting');
    };

    return { makeRequest, resetError, state, setState, errorMsg };
};

export default useHttpHook;
