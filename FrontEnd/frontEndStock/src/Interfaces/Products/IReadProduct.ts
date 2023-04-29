export default interface IReadProduct {
  id: number;
  name: string;
  description: string;
  type: string;
  quantity: number;
  unitValue: number;
  createDate: Date;
  updateDate: Date;
  status: boolean;
}
