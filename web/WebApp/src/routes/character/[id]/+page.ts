import type { Character } from '../../../models/Character.js';
import { apiUrl } from '../../../common/environment/urls';
export async function load({ fetch, params }) {

    const res = await fetch(`${apiUrl}/${params.id}`);
    const item = await res.json();

    return {
        character: item as Character
    }
}