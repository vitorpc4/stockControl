<template>
  <div class="col" style="max-width: 50em; height: 34em">
    <q-card>
      <div>
        <q-card-section>
          <div class="text-h6">Alert</div>
        </q-card-section>

        <q-card-section class="q-pt-none">
          <q-input v-model="name" label="Name" />
          <q-input v-model="description" label="Description" />
          <q-input v-model="type" label="Type" />
          <q-input v-model="quantity" label="Quantity" />
          <q-input v-model="unitvalue" label="Unit value" />
          <q-toggle v-model="status" label="Ativo" />
        </q-card-section>

        <q-card-actions align="right">
          <q-btn
            flat
            @click="save"
            label="Salvar"
            color="green"
            v-close-popup
          />
          <q-btn flat label="Cancelar" color="red" v-close-popup />
        </q-card-actions>
      </div>
    </q-card>
  </div>
</template>

<script lang="ts">
import { defineComponent, ref } from 'vue';
import { useProductStore } from 'src/stores/ProductStore';
import IAddProduct from 'src/Interfaces/Products/IAddProduct';
export default defineComponent({
  setup() {
    const productStore = useProductStore();
    const name = ref('');
    const description = ref('');
    const type = ref('');
    const quantity = ref(0);
    const unitvalue = ref(0);
    const status = ref(true);

    let product: IAddProduct = {
      name: '',
      description: '',
      type: '',
      quantity: 0,
      unitValue: 0,
      status: false,
    };

    const save = () => {
      product.name = name.value;
      product.description = description.value;
      product.type = type.value;
      product.quantity = quantity.value;
      product.unitValue = unitvalue.value;
      product.status = status.value;
      productStore.addProduct(product);
    };

    return {
      name,
      description,
      type,
      quantity,
      unitvalue,
      status,
      save,
    };
  },
});
</script>
