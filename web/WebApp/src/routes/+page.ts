import type { Character } from '../models/Character.js';
import type { PageLoad } from './$types.js';

export async function load({ fetch, params }) {

    const res = await fetch('http://localhost:5105/GetAllCharacters');
	const item = await res.json();

    return {
        characters: item as Character[]
    }
}