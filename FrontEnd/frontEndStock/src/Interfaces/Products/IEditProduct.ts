export default interface IEditProduct {
  id: number;
  name: string;
  description: string;
  type: string;
  quantity: number;
  unitValue: number;
  status: boolean;
  createDate: Date;
}
