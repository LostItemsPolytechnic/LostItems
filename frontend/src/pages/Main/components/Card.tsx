import { Link } from 'react-router-dom';
import itemStatus from '../../../utils/enums/itemStatus';
import React from 'react';

interface CardProps {
    imgUrl: string;
    name: string;
    descr: string;
    id: string;
    status: itemStatus;
}

const Card: React.FC<CardProps> = ({ imgUrl, name, descr, id, status }) => {
    console.log(status, 'status Card');

    return (
        <div className="card d-flex">
            <img src={imgUrl} alt="" className="card__img" />
            <div className="card__right">
                <h3 className="card__right-title">{name}</h3>
                <p className="card__right-descr">{descr}</p>
                <div className="card__right-wrapper">
                    <div
                        className={`card__right-info ${
                            status === itemStatus.Found ? 'card__right-info--found' : 'card__right-info--returned'
                        }`}>
                        {status === itemStatus.Found ? 'Found' : 'Returned'}
                    </div>
                    <Link to={'/item/' + id}>
                        <button className="button-blue card__right-btn">View Details</button>
                    </Link>
                </div>
            </div>
        </div>
    );
};

export default Card;
