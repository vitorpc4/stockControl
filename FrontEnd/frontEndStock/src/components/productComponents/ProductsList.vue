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
          label="Adicionar"
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
            {{ props.row.createDate }}
          </q-td>
          <q-td key="status" :props="props">
            {{ props.row.status }}
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
      <AddProduct />
    </q-dialog>
    <q-dialog v-model="openEditProduct">
      <EditProduct :id="id" />
    </q-dialog>
    <q-dialog v-model="openDeleteProduct">
      <DeleteProduct :id="id" />
    </q-dialog>
  </div>
</template>

<script>
import { computed, defineComponent, onMounted, ref } from 'vue';
import { useProductStore } from 'src/stores/ProductStore';
import AddProduct from './AddProduct.vue';
import EditProduct from './EditProduct.vue';
import DeleteProduct from './DeleteProduct.vue';
export default defineComponent({
  components: { AddProduct, EditProduct, DeleteProduct },
  setup() {
    const productStore = useProductStore();
    const openAddProduct = ref(false);
    const openEditProduct = ref(false);
    const openDeleteProduct = ref(false);
    const id = ref(0);
    const columns = [
      {
        name: 'id',
        required: true,
        label: 'id',
        align: 'left',
        field: (row) => row.id,
        format: (val) => `${val}`,
        sortable: true,
      },
      {
        name: 'name',
        align: 'center',
        label: 'Name',
        field: 'name',
        sortable: true,
      },
      {
        name: 'description',
        align: 'center',
        label: 'Description',
        field: 'description',
        sortable: true,
      },
      { name: 'type', align: 'center', label: 'Type', field: 'type' },
      {
        name: 'quantity',
        align: 'center',
        label: 'Quantity',
        field: 'quantity',
      },
      {
        name: 'unitValue',
        align: 'center',
        label: 'Unit Value',
        field: 'unitValue',
      },
      {
        name: 'createDate',
        label: 'Create Date',
        field: 'createDate',
        sortable: true,
        align: 'center',
        sort: (a, b) => parseInt(a, 10) - parseInt(b, 10),
      },
      {
        name: 'status',
        label: 'status',
        field: 'status',
        align: 'center',
        sortable: true,
        sort: (a, b) => parseInt(a, 10) - parseInt(b, 10),
      },
      {
        name: 'Action',
        label: 'Action',
        field: 'Action',
        align: 'center',
      },
    ];
    const rows = [];
    onMounted(() => {
      productStore.fetchProducts();
    });
    const allProduct = computed(() => productStore.getAllProducts);
    const adicionaItem = () => {
      openAddProduct.value = true;
    };
    const editar = (objectId) => {
      id.value = objectId;
      openEditProduct.value = true;
    };
    const remove = (objectId) => {
      id.value = objectId;
      openDeleteProduct.value = true;
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
    };
  },
});
</script>
