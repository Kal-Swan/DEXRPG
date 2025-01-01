<script lang="ts">
	import type { Character } from '../models/Character';
	import type { PageData } from './$types';
	import { apiUrl } from '../common/environment/urls';
	export let data: PageData;
	let characters = data.characters as Character[];
	console.log(apiUrl);

	if (characters?.length > 0) console.log(characters[0].name);
</script>

<div class="flex flex-col items-center">
	<h1>Characters</h1>
	<form class="mb-5 flex flex-col" method="POST" action="?/create">
		<input
			class="ring-1 ring-teal-50 focus:ring-2 focus:ring-teal-100"
			type="text"
			placeholder="Name"
			name="name"
		/>
		<button
			class="border-b-2 border-b-teal-500 hover:border-b-teal-100 focus:border-b-teal-200"
			type="submit">Create</button
		>
	</form>

	{#if characters?.length === 0}
		<p>No characters found</p>
	{:else}
		<form class="mb-5" method="POST" action="?/deleteAll">
			<button
				class="border-b-2 border-b-teal-500 hover:border-b-teal-100 focus:border-b-teal-200"
				type="submit">Delete all characters</button
			>
		</form>
		<ul style="margin-bottom: 10px;">
			{#each characters as character}
				<li>
					<a href="/character/{character.id}">{character.name}</a>
				</li>
			{/each}
		</ul>
	{/if}
</div>
