<script lang="ts">
	let { data } = $props();
	let { characters } = data;
	//let characterShare = configuration?.characterShare ?? 0;
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
	<!-- {#if characterShare > 0}
		<div class="text-sm font-light">
			Number of characters that can be shared are: {characterShare}
		</div>
	{/if} -->
</div>
