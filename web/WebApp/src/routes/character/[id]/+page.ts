import type { Character } from '../../../models/Character.js';
export async function load({ fetch, params }) {

    const res = await fetch(`http://localhost:5105/${params.id}`);
    const item = await res.json();

    return {
        character: item as Character
    }
}