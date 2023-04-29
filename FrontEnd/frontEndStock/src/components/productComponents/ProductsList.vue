<template>
  <div class="q-pa-md">
    <q-table
      flat
      bordered
      title="Products"
      :rows="rows.concat(...allProduct)"
      :columns="columns"
      row-key="id"
    >
      <template v-slot:top-right>
        <q-btn
          color="primary"
          icon-right="add"
          label="Add"
          no-caps
          @click="adicionaItem"
        />
      </template>
      <template v-slot:body="props">
        <q-tr :props="props">
          <q-td key="id" :props="props">
            {{ props.row.id }}
          </q-td>
          <q-td key="name" :props="props">
            {{ props.row.name }}
          </q-td>
          <q-td key="description" :props="props">
            {{ props.row.description }}
          </q-td>
          <q-td key="type" :props="props">
            {{ props.row.type }}
          </q-td>
          <q-td key="quantity" :props="props">
            {{ props.row.quantity }}
          </q-td>
          <q-td key="unitValue" :props="props">
            {{ props.row.unitValue }}
          </q-td>
          <q-td key="createDate" :props="props">
            {{ formatCreateDate(props.row.createDate) }}
          </q-td>
          <q-td key="status" :props="props">
            <q-icon size="sm" color="green" v-if="props.row.status" name="done">
            </q-icon>
            <q-icon size="sm" color="red" v-if="!props.row.status" name="close">
            </q-icon>
          </q-td>
          <q-td key="Action" :props="props">
            <div class="q-pa-sm q-gutter-sm">
              <q-btn
                @click="editar(props.row.id)"
                size="sm"
                round
                color="primary"
                icon="edit"
              />
              <q-btn
                size="sm"
                @click="remove(props.row.id)"
                round
                color="red"
                icon="delete"
              />
            </div>
          </q-td>
        </q-tr>
      </template>
    </q-table>
    <q-dialog v-model="openAddProduct">
      <AddProduct @close="openAddProduct = false" />
    </q-dialog>
    <q-dialog v-model="openEditProduct">
      <EditProduct @close="openEditProduct = false" :id="id" />
    </q-dialog>
    <q-dialog v-model="openDeleteProduct">
      <DeleteProduct @close="openDeleteProduct = false" :id="id" />
    </q-dialog>
  </div>
</template>

<script lang="ts">
import { computed, defineComponent, onMounted, ref } from 'vue';
import { useProductStore } from 'src/stores/ProductStore';
import AddProduct from './AddProduct.vue';
import EditProduct from './EditProduct.vue';
import DeleteProduct from './DeleteProduct.vue';
import { formatDate } from 'src/Utils/Utils';
export default defineComponent({
  components: { AddProduct, EditProduct, DeleteProduct },
  setup() {
    const productStore = useProductStore();
    const openAddProduct = ref(false);
    const openEditProduct = ref(false);
    const openDeleteProduct = ref(false);

    const id = ref(0);
    // eslint-disable-next-line @typescript-eslint/no-explicit-any
    const columns: any = [
      {
        name: 'id',
        label: 'id',
        align: 'center',
        field: 'id',
        sortable: true,
      },
      {
        name: 'name',
        label: 'Name',
        align: 'center',
        field: 'name',
        sortable: true,
      },
      {
        name: 'description',
        label: 'Description',
        align: 'center',
        field: 'description',
        sortable: true,
      },
      {
        name: 'type',
        label: 'Type',
        align: 'center',
        field: 'type',
        sortable: true,
      },
      {
        name: 'quantity',
        label: 'Quantity',
        align: 'center',
        field: 'quantity',
        sortable: true,
      },
      {
        name: 'unitValue',
        label: 'Unit Value',
        align: 'center',
        field: 'unitValue',
        sortable: true,
      },
      {
        name: 'createDate',
        label: 'Create Date',
        align: 'center',
        field: 'createDate',
        sortable: true,
      },
      {
        name: 'status',
        label: 'status',
        align: 'center',
        field: 'status',
        sortable: true,
      },
      {
        name: 'Action',
        label: 'Action',
        align: 'center',
        field: 'Action',
        sortable: false,
      },
    ];

    // eslint-disable-next-line @typescript-eslint/no-explicit-any
    const rows: any = [];

    onMounted(() => {
      productStore.fetchProducts();
    });
    const allProduct = computed(() => productStore.getAllProducts);
    const adicionaItem = () => {
      openAddProduct.value = true;
    };
    const editar = (objectId: number) => {
      id.value = objectId;
      openEditProduct.value = true;
    };
    const remove = (objectId: number) => {
      id.value = objectId;
      openDeleteProduct.value = true;
    };
    const formatCreateDate = (createDate: Date) => {
      const date = new Date(createDate);
      return formatDate(date);
    };

    return {
      columns,
      rows,
      openAddProduct,
      openEditProduct,
      openDeleteProduct,
      allProduct,
      id,
      adicionaItem,
      editar,
      remove,
      formatCreateDate,
    };
  },
});
</script>
