import type { Actions } from "@sveltejs/kit";

export const actions: Actions = {
    create: async ({ request }) => { 
        console.log('test create');
        const data = await request.formData();
        const name = data.get('name');
        console.log(name);

        const response = await fetch('http://localhost:5105/createCharacter', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ name }),
        });

        if (response.status !== 201) {
            return { status: response.status };
        }

        return { status: 200 };
    },
    deleteAll: async () => {
        console.log('test deleteAll');
        const response = await fetch('http://localhost:5105/deleteAllCharacters', {
            method: 'DELETE',
        });

        if (response.status !== 200) {
            return { status: response.status };
        }

        return { status: 200 };
    }
}