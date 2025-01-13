import type { Character } from '../models/Character.js';
import type { PageLoad } from './$types.js';
import { apiUrl } from "../common/environment/urls"

export async function load({ fetch, params }) {
    try {
        console.log('test api url');
        console.log(apiUrl);
        const res = await fetch(`${apiUrl}/GetAllCharacters`);
        console.log(res);
        const item = await res.json();
    
        return {
            characters: item as Character[]
        }

    } catch (error) {
        console.error(error);
        return {
            characters: []
        }
    }
}