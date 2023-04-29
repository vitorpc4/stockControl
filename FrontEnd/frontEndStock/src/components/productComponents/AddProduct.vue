<template>
  <div class="col" style="max-width: 50em; height: 40em">
    <q-form @submit="save">
      <q-card>
        <div>
          <q-card-section>
            <div class="text-h6">Adicionar</div>
          </q-card-section>
          <q-card-section class="q-pt-none">
            <q-input
              :rules="nameRules"
              v-model="name"
              lazy-rules
              label="Name"
            />
            <q-input
              :rules="descriptionRules"
              v-model="description"
              label="Description"
            />
            <q-input :rules="typeRules" v-model="type" label="Type" />
            <q-input
              type="number"
              :rules="quantityRules"
              v-model="quantity"
              label="Quantity"
            />
            <q-input
              :rules="unitvalueRules"
              v-model="unitvalue"
              mask="#.##"
              fill-mask="0"
              reverse-fill-mask
              label="Unit value"
            />
            <q-toggle v-model="status" label="Ativo" />
          </q-card-section>
          <q-card-actions align="right">
            <q-btn flat type="submit" label="Salvar" color="green" />
            <q-btn flat label="Cancelar" color="red" v-close-popup />
          </q-card-actions>
        </div>
      </q-card>
    </q-form>
  </div>
</template>

<script lang="ts">
import { defineComponent, ref } from 'vue';
import { useProductStore } from 'src/stores/ProductStore';
import IAddProduct from 'src/Interfaces/Products/IAddProduct';
import { useQuasar } from 'quasar';

export default defineComponent({
  setup(props, { emit }) {
    const $q = useQuasar();
    const productStore = useProductStore();
    const name = ref('');
    const description = ref('');
    const type = ref('');
    const quantity = ref(0);
    const unitvalue = ref(0);
    const status = ref(true);
    const closeModal = ref(0);
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
      productStore
        .addProduct(product)
        .then(() => {
          emit('close');
          $q.notify({
            color: 'green',
            textColor: 'white',
            icon: 'cloud_done',
            message: 'Product saved',
          });
        })
        .catch(() => {
          $q.notify({
            color: 'red',
            textColor: 'white',
            icon: 'error',
            message: 'Failed to save',
          });
        });
    };

    const nameRules = [
      (val: string) =>
        (val && val.length >= 3) ||
        'The name field must have at least 3 characters',
    ];
    const descriptionRules = [
      (val: string) =>
        (val && val.length >= 3) ||
        'The description field must have at least 3 characters',
    ];
    const typeRules = [
      (val: string) => (val && val.length > 0) || 'Enter a valid type',
    ];
    const quantityRules = [
      (val: number) => (val && val > 0) || 'Enter a valid quantity',
    ];
    const unitvalueRules = [
      (val: number) => (val && val > 0) || 'Enter a valid value',
    ];

    const moneyFormatForDirective = {
      decimal: '.',
      thousands: ',',
      prefix: '$ ',
      precision: 2,
      masked: true /* doesn't work with directive */,
    };

    return {
      name,
      description,
      type,
      quantity,
      unitvalue,
      status,
      nameRules,
      descriptionRules,
      typeRules,
      quantityRules,
      unitvalueRules,
      closeModal,
      moneyFormatForDirective,
      save,
    };
  },
});
</script>
