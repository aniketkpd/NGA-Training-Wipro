export interface Event {
  name: string;
  date: string;
  price: number;
  category: 'Conference' | 'Workshop' | 'Concert';
}
