<template>
  <div class="col" style="max-width: 50em">
    <q-card style="width: 700px; max-width: 80vw">
      <q-card-section>
        <div class="text-h6">Delete</div>
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
import { defineComponent, onMounted } from 'vue';
import { useProductStore } from 'src/stores/ProductStore';
import { useQuasar } from 'quasar';
export default defineComponent({
  props: {
    id: {
      type: Number,
      required: true,
    },
  },
  setup(props, { emit }) {
    const $q = useQuasar();
    const productStore = useProductStore();
    const enterclick = () => {
      console.log('foi clicado');
    };
    onMounted(() => {
      window.addEventListener('keyup', function (event) {
        if (event.key == 'Enter') {
          remove();
        }
      });
    });
    const remove = () => {
      productStore
        .deleteProduct(props.id)
        .then(() => {
          emit('close');
          $q.notify({
            color: 'orange',
            textColor: 'white',
            icon: 'delete_forever',
            message: 'Product deleted',
          });
        })
        .catch(() => {
          $q.notify({
            color: 'red',
            textColor: 'white',
            icon: 'error',
            message: 'Product deleted',
          });
        });
    };

    return {
      remove,
      enterclick,
    };
  },
});
</script>
