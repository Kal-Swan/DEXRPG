<script lang="ts">
	import type { Character } from '../../../models/Character';
	import type { PageData } from './$types';
	export let data: PageData;
	let character = data.character as Character;
</script>

<h1>{character.name}</h1>
