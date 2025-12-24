import './header.scss';

const Header: React.FC<{ onLogOut: () => void }> = ({ onLogOut }) => {
    return (
        <header className="header">
            <div className="container">
                <a href="#" className="header__logo">
                    Campus Lost & Found
                </a>
                <div className="header__right_wrapper">
                    {/* <button className="header__btn">Profile</button> */}
                    <button className="header__btn" onClick={onLogOut}>
                        Logout
                    </button>
                </div>
            </div>
        </header>
    );
};

export default Header;
