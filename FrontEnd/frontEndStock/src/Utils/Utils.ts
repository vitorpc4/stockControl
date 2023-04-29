import moment from 'moment';
export function formatDate(date: Date) {
  moment.locale('pt');
  return moment(date).format('YYYY-MM-DD HH:MM:SS');
}
