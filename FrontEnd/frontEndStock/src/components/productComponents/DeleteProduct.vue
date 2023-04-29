<template>
  <div class="col" style="max-width: 50em">
    <q-card style="width: 700px; max-width: 80vw">
      <q-card-section>
        <div class="text-h6">Deletar</div>
      </q-card-section>

      <q-card-section class="q-pt-none">
        Are you sure you want to delete the product?
      </q-card-section>

      <q-card-actions align="right" class="bg-white text-teal">
        <q-btn @click="remove" flat color="red" label="OK" v-close-popup />
        <q-btn flat label="Cancel" v-close-popup />
      </q-card-actions>
    </q-card>
  </div>
</template>
<script>
import { defineComponent } from 'vue';
import { useProductStore } from 'src/stores/ProductStore';
export default defineComponent({
  props: {
    id: {
      type: Number,
      required: true,
    },
  },
  setup(props) {
    const productStore = useProductStore();
    const remove = () => {
      productStore.deleteProduct(props.id);
    };

    return {
      remove,
    };
  },
});
</script>
