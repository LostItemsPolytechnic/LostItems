import React from 'react';
import useHttpHook from '../../../hooks/useHttpHook';
import { markReturnedItem } from '../../../services/client/item';

const ReturnBtn: React.FC<{ id?: string; isReturned: boolean; onReturn: () => void }> = ({
    id,
    isReturned,
    onReturn,
}) => {
    const { state, setState, errorMsg, makeRequest } = useHttpHook();

    const onMarkReturned = () => {
        makeRequest(() => markReturnedItem(id!)).then(() => {
            onReturn();
            setState('success');
        });
    };

    console.log(isReturned, "isReturned ReturnBtn");

    return (
        <>
            <button
                onClick={onMarkReturned}
                className="item__btn button-blue"
                disabled={isReturned || !id || state === 'loading'}>
                Mark as Returned
            </button>
            {state === 'error' && <p className="text-danger">{errorMsg}</p>}
        </>
    );
};

export default React.memo(ReturnBtn);
