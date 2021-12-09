<template>
    <div class="search-holder">
        <div class="search-holder-banner">
            <div class="header-container">
                <h1 class="search-header">
                    Grocery Stores Nearby
                </h1>
                <div class="search-bar">
                    <div class="form-holder">
                        <div class="search">
                            <input
                            v-model="searchText"
                           class="form-control"
                            type="text"
                            />
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
export default {

}
</script>

<style>

</style>