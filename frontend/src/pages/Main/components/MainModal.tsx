import { useState } from 'react';
import { Button, Form, Modal, Spinner } from 'react-bootstrap';
import useHttpHook from '../../../hooks/useHttpHook';
import { addItem } from '../../../services/client/item';

interface ModalProps {
    needToShow: boolean;
    setShow: (state: boolean) => void;
}

const MainModal: React.FC<ModalProps> = ({ needToShow, setShow }) => {
    const [itemName, setItemName] = useState('');
    const [description, setDescription] = useState('');
    const [image, setImage] = useState<File | null>(null);

    const { state, errorMsg, setState, makeRequest } = useHttpHook();

    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();

        if (!itemName.trim() || !description.trim() || image === null) return;

        makeRequest(() => addItem(itemName, description, image))
            .then(() => setState('success'))
            .then(() => setShow(false));
    };

    return (
        <Modal className="main-modal" show={needToShow} onHide={() => setShow(false)} centered>
            <Modal.Header closeButton>
                <Modal.Title className="main-modal__title">Add Found Item</Modal.Title>
            </Modal.Header>

            <Modal.Body>
                {state === 'waiting' || state === 'error' ? (
                    <form className="main-modal__form" onSubmit={handleSubmit}>
                        <Form.Group className="mb-3 modal__group">
                            <Form.Label className="main-modal__label" htmlFor="itemName">
                                Item name
                            </Form.Label>
                            <Form.Control
                                id="itemName"
                                type="text"
                                className="main-modal__input"
                                value={itemName}
                                onChange={(e) => setItemName(e.target.value)}
                            />
                        </Form.Group>

                        <Form.Group className="mb-3 modal__group">
                            <Form.Label className="main-modal__label" htmlFor="description">
                                Description
                            </Form.Label>
                            <Form.Control
                                id="description"
                                type="text"
                                className="main-modal__input main-modal__input-descr"
                                value={description}
                                onChange={(e) => setDescription(e.target.value)}
                            />
                        </Form.Group>

                        <Form.Group className="mb-3 main-modal__group">
                            <Form.Label className="main-modal__label" htmlFor="imageUpload">
                                Image upload
                            </Form.Label>
                            <Form.Control
                                id="imageUpload"
                                type="file"
                                className="main-modal__input"
                                accept="image/*"
                                onChange={(e) => {
                                    const input = e.target as HTMLInputElement;
                                    const file = input.files?.[0] ?? null;
                                    setImage(file);
                                }}
                            />
                        </Form.Group>
                        {state === 'error' && <p className="text-danger">{errorMsg}</p>}
                        <Button type="submit" className="main-modal__btn main-modal__btn-submit">
                            Publish
                        </Button>

                        <Button
                            type="button"
                            className="main-modal__btn main-modal__btn-cancel"
                            onClick={() => setShow(false)}>
                            Cancel
                        </Button>
                    </form>
                ) : (
                    <Spinner animation="border" />
                )}
            </Modal.Body>
        </Modal>
    );
};

export default MainModal;
