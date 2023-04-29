import { defineStore } from 'pinia';
import IAddProduct from 'src/Interfaces/Products/IAddProduct';
import IEditProduct from 'src/Interfaces/Products/IEditProduct';
import IReadProduct from 'src/Interfaces/Products/IReadProduct';
import { api } from 'src/boot/axios';

export type StateProduct = {
  readProduct: IReadProduct[];
  addProduct: IAddProduct[];
  editProduct: IEditProduct[];
};

export const useProductStore = defineStore('Product', {
  state: () =>
    ({
      readProduct: [],
      addProduct: [],
      editProduct: [],
    } as StateProduct),
  getters: {
    getAllProducts(state) {
      return state.readProduct;
    },
  },
  actions: {
    async fetchProducts() {
      try {
        const url = 'product';
        const data = await api.get(url);
        this.readProduct = data.data;
      } catch (error) {
        this.readProduct = [];
      }
    },
    async addProduct(product: IAddProduct) {
      const url = 'product';
      const data = await api.post(url, product);
      this.readProduct.push(data.data);
    },
    async editProduct(product: IEditProduct) {
      const url = 'product';
      const data = await api.put(url, product);
      const findObject = this.readProduct.findIndex((x) => x.id == product.id);
      this.readProduct[findObject] = data.data;
    },
    async deleteProduct(id: number) {
      const url = `product/${id}`;
      await api.delete(url);
      const findObject = this.readProduct.findIndex((x) => x.id == id);
      this.readProduct.splice(findObject, 1);
    },
  },
});
