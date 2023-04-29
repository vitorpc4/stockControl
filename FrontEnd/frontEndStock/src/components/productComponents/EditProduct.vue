<template>
  <div class="col" style="max-width: 50em; height: 45em">
    <q-form @submit="save">
      <q-card>
        <div>
          <q-card-section>
            <div class="text-h6">Edit</div>
          </q-card-section>
          <q-card-section class="q-pt-none">
            <q-input :rules="nameRules" v-model="name" label="Name" />
            <q-input
              :rules="descriptionRules"
              v-model="description"
              label="Description"
            />
            <q-input :rules="typeRules" v-model="type" label="Type" />
            <q-input
              :rules="quantityRules"
              v-model="quantity"
              type="number"
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
            <q-input v-model="viewCrateDate" label="Create Date" readonly />
            <q-toggle v-model="status" label="Ativo" />
          </q-card-section>
          <q-card-actions align="right">
            <q-btn flat type="submit" label="Salvar" color="green" />
            <q-btn flat label="Cancel" color="red" v-close-popup />
          </q-card-actions>
        </div>
      </q-card>
    </q-form>
  </div>
</template>

<script lang="ts">
import { defineComponent, ref, onMounted } from 'vue';
import { useProductStore } from 'src/stores/ProductStore';
import IEditProduct from 'src/Interfaces/Products/IEditProduct';
import { useQuasar } from 'quasar';
import { formatDate } from 'src/Utils/Utils';
export default defineComponent({
  props: {
    id: {
      type: Number,
      required: true,
    },
  },
  setup(props, { emit }) {
    const productStore = useProductStore();
    const name = ref('');
    const description = ref('');
    const type = ref('');
    const quantity = ref(0);
    const unitvalue = ref(0);
    const status = ref(true);
    const createDate = ref(new Date());
    const viewCrateDate = ref('');
    const $q = useQuasar();

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

    onMounted(() => {
      const productView = productStore.getAllProducts.find(
        (x) => x.id == props.id
      );
      name.value = productView?.name || '';
      description.value = productView?.description || '';
      type.value = productView?.type || '';
      quantity.value = productView?.quantity || 0;
      unitvalue.value = productView?.unitValue || 0;
      status.value = productView?.status || false;
      createDate.value = productView?.createDate || new Date();
      viewCrateDate.value = formatDate(createDate.value);
    });

    let product: IEditProduct = {
      id: 0,
      name: '',
      description: '',
      type: '',
      quantity: 0,
      unitValue: 0,
      status: false,
      createDate: new Date(),
    };

    const save = () => {
      product.id = props.id || 0;
      product.name = name.value;
      product.description = description.value;
      product.type = type.value;
      product.quantity = quantity.value;
      product.unitValue = unitvalue.value;
      product.status = status.value;
      product.createDate = createDate.value;
      productStore
        .editProduct(product)
        .then(() => {
          emit('close');
          $q.notify({
            color: 'green',
            textColor: 'white',
            icon: 'cloud_done',
            message: 'Edited Product',
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

    return {
      name,
      description,
      type,
      quantity,
      unitvalue,
      status,
      createDate,
      nameRules,
      descriptionRules,
      typeRules,
      quantityRules,
      unitvalueRules,
      viewCrateDate,
      save,
    };
  },
});
</script>
