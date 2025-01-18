import type { Character } from '../models/Character.js';
import type { PageLoad } from './$types.js';
import { apiUrl } from "../common/environment/urls"

export async function load({ fetch, params }) {
    try {
        console.log('test api url');
        console.log(apiUrl);
        const configurationResponse = await fetch(`${apiUrl}/configuration`);
        const configuration = await configurationResponse.json() as AppConfiguration;
        const res = await fetch(`${apiUrl}/GetAllCharacters`);
        console.log(res);
        const item = await res.json();
        console.log('item');
        console.log(item);
    
        return {
            characters: item as Character[],
            configuration
        }

    } catch (error) {
        console.error(error);
        return {
            characters: [] as Character[]
        }
    }
}