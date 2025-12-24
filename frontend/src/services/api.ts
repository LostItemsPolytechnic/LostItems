const API_BASE = 'http://localhost:5113/api';

export type ApiRes<T> =
    | {
          success: true;
          data: T;
      }
    | {
          success: false;
          data: string;
      };

export async function apiRequest<T>(endpoint: string, options: RequestInit = {}): Promise<ApiRes<T>> {
    const response = await fetch(`${API_BASE}${endpoint}`, {
        credentials: 'include',
        headers: {
            'Content-Type': 'application/json',
            ...(options.headers || {}),
        },
        ...options,
    });

    const raw = await response.text();

    if (!response.ok) {
        let msg = raw;

        try {
            const parsed = JSON.parse(raw);
            msg = parsed.message || parsed.error || raw;
        } catch {}

        return { success: false, data: msg };
    }

    if (!raw) {
        return { success: true, data: null as T };
    }

    let parsed: T;

    try {
        parsed = JSON.parse(raw) as T;
    } catch {
        parsed = raw as unknown as T;
    }

    return { success: true, data: parsed };
}
