import itemStatus from '../../utils/enums/itemStatus';
import { apiRequest } from '../api';

export type ItemType = {
    id: string;
    description: string;
    name: string;
    status: itemStatus;
};

export type FilterItems = {
    input?: string;
    fromTime?: Date;
    toTime?: Date;
    status?: itemStatus;
};

export const getItems = async () => {
    const res = await apiRequest<ItemType[]>('/items');

    return res;
};

export const addItem = async (name: string, description: string, file: File) => {
    const data = { name, description };
    const res = apiRequest('/items', { method: 'POST', body: JSON.stringify(data) });

    return res;
};

export const getItemById = async (id: string) => {
    const res = await apiRequest<ItemType>('/items/' + id);

    return res;
};

export const markReturnedItem = async (id: string) => {
    const res = await apiRequest<void>('/items/return/' + id, { method: 'PUT' });

    return res;
};

export const getFilterItems = async (filter: FilterItems) => {
    const params = new URLSearchParams();

    if (filter.input) params.append('input', filter.input);
    if (filter.fromTime) params.append('fromTime', filter.fromTime.toISOString());
    if (filter.toTime) params.append('toTime', filter.toTime.toISOString());
    if (filter.status !== undefined) params.append('status', filter.status.toString());

    const query = params.toString();
    const url = query ? `/items/filter?${query}` : '/items/filter';

    return await apiRequest<ItemType[]>(url);
};
