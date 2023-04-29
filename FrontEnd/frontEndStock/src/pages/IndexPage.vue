<template>
  <q-layout
    view="hHh Lpr lff"
    container
    style="height: 100vh"
    class="shadow-2"
    :class="$q.dark.isActive ? 'bg-grey-9' : 'bg-grey-3'"
  >
    <products-list></products-list>
  </q-layout>
</template>

<script lang="ts">
import ProductsList from 'components/productComponents/ProductsList.vue';
import { defineComponent } from 'vue';

export default defineComponent({
  name: 'IndexPage',
  components: { ProductsList },
});
</script>
