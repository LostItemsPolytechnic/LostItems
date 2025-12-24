import { useEffect, useState } from 'react';
import './item.scss';
import { Link, useParams } from 'react-router-dom';
import { getItemById, ItemType } from '../../services/client/item';
import useHttpHook from '../../hooks/useHttpHook';
import { Spinner } from 'react-bootstrap';
import itemStatus from '../../utils/enums/itemStatus';
import ReturnBtn from './Components/ReturnBtn';

const ItemPage = () => {
    const { id } = useParams<{ id: string }>();
    const { makeRequest, state, setState, errorMsg } = useHttpHook();

    const [item, setItem] = useState<ItemType | null>(null);

    useEffect(() => {
        if (item?.id === id || id === undefined) return;

        makeRequest<ItemType>(() => getItemById(id)).then((res) => {
            if (res === undefined || !res) return;

            setItem(res);
            setState('success');
        });
    }, [id]);

    console.log(
        item,
        'item',
        item?.status,
        'isReturned Item',
        itemStatus.Returned === itemStatus.Returned,
        'isReturned Item  === itemStatus.return'
    );

    return (
        <main className="item">
            <div className="item__body">
                <Link className="item__close" to={'/'}>
                    ← Back
                </Link>
                <hr />
                {state === 'loading' || state === 'waiting' ? (
                    <Spinner animation="border" />
                ) : item !== undefined ? (
                    <>
                        <img src="https://i.postimg.cc/Rh2cgC9W/Item.png" alt="name" className="item__img" />
                        <h3 className="item__name">Black Leather Wallet</h3>
                        <div className="item__status">
                            <h5 className="item__status-descr">Status:</h5>
                            <h4 className="item__status-info">
                                {item?.status === itemStatus.Found ? 'Found' : 'Returned'}
                            </h4>
                        </div>
                        <ReturnBtn
                            id={id}
                            isReturned={item?.status === itemStatus.Returned}
                            onReturn={() => setItem((prev) => (prev ? { ...prev, status: itemStatus.Returned } : prev))}
                        />
                        <div className="item__descr">
                            <h3 className="item__descr-title">Description:</h3>
                            <div className="item__descr-field">{item?.description}</div>
                        </div>
                    </>
                ) : (
                    <p className="text-danger">{errorMsg || "Item wasn't found"}</p>
                )}
            </div>
        </main>
    );
};

export default ItemPage;
