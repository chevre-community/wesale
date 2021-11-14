export default function seperateWithSpace(value) {
  return String(value).replace(/\B(?=(\d{3})+(?!\d))/g, " ");
}
