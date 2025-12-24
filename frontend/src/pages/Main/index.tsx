import { Spinner } from 'react-bootstrap';
import useHttpHook from '../../hooks/useHttpHook';
import { FilterItems, getFilterItems, getItems, ItemType } from '../../services/client/item';
import itemStatus from '../../utils/enums/itemStatus';
import Card from './components/Card';
import MainModal from './components/MainModal';
import './scss/main.scss';
import { useEffect, useMemo, useState } from 'react';
import React from 'react';

const Main = () => {
    const [startFrom, setStartFrom] = useState<Date | undefined>();
    const [endDate, setEndDate] = useState<Date | undefined>();
    const [search, setSearch] = useState('');
    const [cardData, setCardData] = useState<ItemType[]>([]);
    const [filter, setFiter] = useState<FilterItems>({});

    const [showModal, setShowModal] = useState<boolean>(false);

    const { state, setState, makeRequest, errorMsg } = useHttpHook();

    useEffect(() => {
        makeRequest<ItemType[]>(() => getFilterItems(filter)).then((res) => {
            setCardData([...res]);
            setState('success');
        });
    }, [filter]);

    const content = useMemo(() => {
        switch (state) {
            case 'loading':
            case 'waiting':
                return <Spinner animation="border" />;
            case 'error':
                return <p className="text-danger">{errorMsg}</p>;
            case 'success':
                return <View data={cardData} />;
        }
    }, [state, cardData, errorMsg]);

    return (
        <main className="main">
            <hr />

            <div className="filter">
                <input
                    type="text"
                    className="filter__search"
                    value={search}
                    onChange={(e) => setSearch(e.target.value)}
                    onBlur={() => {
                        if (filter.input === search) return;

                        setFiter((prev) => ({ ...prev, input: search }));
                    }}
                    placeholder="Search items…"
                />
                <div className="filter__wrapper d-flex justify-content-center">
                    <div className="filter__group">
                        <label htmlFor="fromDate" className="filter__label">
                            From date:
                        </label>
                        <input
                            id="fromDate"
                            type="date"
                            value={startFrom ? startFrom.toISOString().split('T')[0] : ''}
                            onChange={(e) => setStartFrom(new Date(e.target.value))}
                            onBlur={() => {
                                if (filter.fromTime === startFrom) return;

                                setFiter((prev) => ({ ...prev, fromTime: startFrom }));
                            }}
                            className="border rounded-lg p-2 text-base filter__date"
                        />
                    </div>
                    <div className="filter__group">
                        <label htmlFor="endDate" className="filter__label">
                            End date:
                        </label>
                        <input
                            id="endDate"
                            type="date"
                            value={endDate ? endDate.toISOString().split('T')[0] : ''}
                            onChange={(e) => setEndDate(new Date(e.target.value))}
                            onBlur={() => {
                                if (filter.toTime === endDate) return;

                                setFiter((prev) => ({ ...prev, toTime: endDate }));
                            }}
                            className="border rounded-lg p-2 text-base filter__date"
                        />
                    </div>
                </div>
            </div>
            <hr />

            {content}

            <button onClick={() => setShowModal(true)} className="button-blue main__btn-add">
                +
            </button>
            <MainModal needToShow={showModal} setShow={setShowModal} />
        </main>
    );
};

const View: React.FC<{ data: ItemType[] }> = ({ data }) => {
    console.log(data, 'data View (main)');

    return (
        <div className="card_list">
            {data.map((item) => (
                <Card
                    key={item.id}
                    imgUrl="...."
                    name={item.name}
                    descr={item.description}
                    id={item.id}
                    status={item.status}
                />
            ))}
        </div>
    );
};

export default Main;
