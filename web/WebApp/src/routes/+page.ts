import type { Character } from '../models/Character.js';
import type { PageLoad } from './$types.js';
import { apiUrl } from "../common/environment/urls"

export async function load({ fetch, params }) {

    const res = await fetch(`${apiUrl}/GetAllCharacters`);
	const item = await res.json();

    return {
        characters: item as Character[]
    }
}