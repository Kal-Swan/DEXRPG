import * as v from '$env/dynamic/public';

export const apiUrl = v.env.PUBLIC_API_URL !== undefined ? v.env.PUBLIC_API_URL : 'http://localhost:5105';